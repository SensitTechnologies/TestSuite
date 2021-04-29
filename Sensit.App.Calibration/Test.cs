using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	public class Test : IDisposable
	{
		#region Enumerations

		/// <summary>
		/// Non-measurement related commands that can be executed during a test.
		/// </summary>
		/// <remarks>
		/// These actions can activate a relay, etc.
		/// </remarks>
		public enum Command
		{
			TurnOff,	// Remove power from test equipment.
			TurnOn,		// Apply power to test equipment.
			Default,	// Set factory default settings.
			Range,		// Set range settings.
			Zero,		// Perform zero-calibration.
			Span,		// Perform span-calibration.
		}

		#endregion

		#region Fields

		private BackgroundWorker _testThread;	// task that will handle test operations
		private TestSetting _settings;			// settings for test
		private Equipment _equipment;			// test equipment object
		private Log _log;						// keeper of test results
		private Stopwatch _elapsedTimeStopwatch;// keeper of test's elapsed time
		private bool _pause = false;			// whether test is paused
		private uint _samplesTotal;				// helps calculate percent complete
		private uint _samplesComplete = 0;       // helps calculate percent complete

		#endregion

		#region Delegates

		// Report test progress.
		public Action<int, string> UpdateProgress { get; set; }

		// Report test results.
		public Action Finished { get; set; }

		#endregion

		#region Properties

		/// <summary>
		/// Progress of the test, in percent.
		/// </summary>
		public int PercentProgress
		{
			get
			{
				int percent = (int)(_samplesComplete / (double)_samplesTotal * 100.0);

				// Check for overflow or underflow.
				if ((percent < 0) || (percent > 100))
				{
					throw new TestException("Percent progress is out of range."
						+ Environment.NewLine + "Steps Complete:  " + _samplesComplete.ToString()
						+ Environment.NewLine + "Steps Total:  " + _samplesTotal.ToString());
				}

				return percent;
			}
		}

		/// <summary>
		/// Controlled/independent variables for the current test component.
		/// </summary>
		/// <remarks>
		/// This will be accessed by the FormCalibration to display the variables values and setpoints.
		/// </remarks>
		public Dictionary<VariableType, (decimal Value, decimal Setpoint)> Variables { get; private set; } = new Dictionary<VariableType, (decimal Value, decimal Setpoint)>();

		/// <summary>
		/// True if test should repeat until manually stopped.
		/// </summary>
		public bool Repeat { get; set; }

		#endregion

		#region Thread Management

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="equipment">equipment used by the test</param>
		public Test(TestSetting settings, string filename)
		{
			// Save the reference to the equipment and log file manager objects.
			_settings = settings;
			_equipment = new Equipment();
			_log = new Log(filename, _equipment);

			// Set up the background worker.
			_testThread = new BackgroundWorker
			{
				WorkerReportsProgress = true,
				WorkerSupportsCancellation = true
			};
			_testThread.DoWork += TestThread;
			_testThread.ProgressChanged += ProgressChanged;
			_testThread.RunWorkerCompleted += RunWorkerCompleted;

			// Calculate how many samples we'll take in the selected test.
			// This allows us to calculate the test's percent progress.
			_samplesTotal = 0;
			foreach (EventSetting e in _settings.Events)
			{
				_samplesTotal += e.Duration;
			}
		}

		/// <summary>
		/// Start a new test.
		/// </summary>
		public void Start()
		{
			// Run "TestProcess" asynchronously (using a background worker).
			if (_testThread.IsBusy == false)
			{
				// Start the asynchronous operation.
				_testThread.RunWorkerAsync();
			}
		}

		/// <summary>
		/// Stop the test.
		/// </summary>
		public void Stop()
		{
			// Cancel the test operation.
			_testThread.CancelAsync();
		}

		/// <summary>
		/// Pause the test.
		/// </summary>
		public void Pause()
		{
			// Set a global flag which will cause the test to pause at a convenient spot.
			_pause = true;
		}

		/// <summary>
		/// Return whether a test is running.
		/// </summary>
		/// <returns>true if test is running; false otherwise</returns>
		public bool IsBusy()
		{
			return _testThread.IsBusy;
		}

		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Run action required as test progresses (i.e. update GUI).
			UpdateProgress(e.ProgressPercentage, e.UserState as string);
		}

		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// If the test was cancelled, update the GUI's status accordingly.
			if (e.Cancelled)
			{
				UpdateProgress(0, "Test cancelled.");
			}

			// Run actions required when test is completed (i.e. update GUI).
			Finished?.Invoke();
		}

		#endregion

		/// <summary>
		/// If we can't reach a setpoint, stop the equipment and prompt the user.
		/// </summary>
		/// <remarks>
		/// Measure/vent mode must be supported for all devices.
		/// Measure mode should save active setpoints but not use them.
		/// Equipment has properties for control devices and reference devices.
		/// Those properties are Dictionaries with the key being the variable type.
		/// Then we can initialize them in Equipment.cs, iterate through them here, and set parameters when needed.
		/// </remarks>
		/// <param name="message">message to display to the user</param>
		/// <param name="caption">caption for the message</param>
		private void PopupRetryAbort(string message, string caption)
		{
			// Stop the equipment to reduce change of damage.
			foreach (IDevice device in _equipment.Devices.Values)
			{
				device.SetControlMode(ControlMode.Passive);
			}

			// Pause the elapsed time timer.
			_elapsedTimeStopwatch.Stop();

			// Alert the user (asking if they wish to retry or not).
			DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

			// Resume timing elapsed time.
			_elapsedTimeStopwatch.Start();

			// If we're continuing to test, attempt to control variables again.
			if (result == DialogResult.Yes)
			{
				foreach (IDevice device in _equipment.Devices.Values)
				{
					// Resume control mode.
					device.SetControlMode(ControlMode.Active);
				}
			}
			// If requested, cancel the test.
			else
			{
				// Abort the test.
				_testThread.CancelAsync();
			}
		}

		/// <summary>
		/// If some uncorrectable error occurs, stop the device and alert the user.
		/// </summary>
		/// <remarks>
		/// Because this is called when an uncorrectable error occurs, we can't allow
		/// this method to be interrupted by exceptions.  So we log them, but allow the
		/// method to continue.
		/// </remarks>
		/// <param name="errorMessage">message to display to the user</param>
		/// <param name="caption">caption for the message</param>
		private void PopupAbort(string errorMessage, string caption)
		{
			// Stop the equipment to reduce change of damage.
			foreach (IDevice device in _equipment.Devices.Values)
			{
				try
				{
					device.SetControlMode(ControlMode.Passive);
				}
				catch (DeviceException ex)
				{
					// If a device doesn't respond, log an error.
					_log.WriteMessage(ex.GetType().ToString() + ": " + ex.Message);
				}
			}

			// Alert the user.
			MessageBox.Show(errorMessage, caption);
		}

		/// <summary>
		/// Check whether all controlled variables are within stability tolerances.
		/// </summary>
		private void StabilityCheck()
		{
			// For each device...
			foreach (IDevice device in _equipment.Devices.Values)
			{
				foreach (KeyValuePair<VariableType, double> variable in device.Readings)
				{
					// Read the setpoint and reading.
					device.Read();
					double setpoint = device.Setpoints[variable.Key];
					double reading = device.Readings[variable.Key];

					// Update the GUI.
					Variables[variable.Key] = (Convert.ToDecimal(reading), Convert.ToDecimal(setpoint));

					// TODO:  Check for variables out of stability.
					//if (Math.Abs(setpoint - reading) > v.ErrorTolerance)
					//{
					//	// Attempt to achieve the setpoint again.
					//	ProcessSetpoint(v, setpoint, v.Interval);
					//}
				}
			}
		}

		/// <summary>
		/// Check if the test should be paused.
		/// </summary>
		/// <remarks>
		/// This should be called at convenient intervals within the test thread
		/// where the test can be paused.
		/// </remarks>
		private void ProcessPause()
	{
			// All we need to do is call the error method with a message for the user.
			PopupRetryAbort("The test is paused.  Continue?", "Notice");

			// Reset the flag once the user resumes the test.
			_pause = false;
		}

		private static void ProcessCommand(Command? command)
		{
			// Perform a command.
			switch (command)
			{
				case Command.TurnOff:
					break;
				case Command.TurnOn:
					break;
				case Command.Default:
					break;
				case Command.Range:
					break;
				case Command.Span:
					break;
				case Command.Zero:
					break;
				default:
					break;
			}
		}

		private void ProcessSetpoint(string deviceName, VariableType variable, double setpoint, TimeSpan interval, TimeSpan timeout, double tolerance, TimeSpan dwellTime)
		{
			// Update GUI.
			_testThread.ReportProgress(PercentProgress, "Setting setpoint...");

			// Set setpoint.
			_equipment.Devices[deviceName].Setpoints[variable] = setpoint;
			_equipment.Devices[deviceName].Write();

			// Get start time.
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch timeoutWatch = Stopwatch.StartNew();

			// Take readings until they are within tolerance for the required settling time.
			double error;
			do
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }

				// Process timeouts.
				if (timeoutWatch.Elapsed > timeout)
				{
					// Prompt user; cancel test if requested.
					PopupRetryAbort("Not able to reach stability." + Environment.NewLine + "Retry ?", "Stability Error");

					// Reset the timeout stopwatch.
					timeoutWatch.Restart();
				}

				// Process pause requests.
				if (_pause == true)
				{
					// Stop the clocks.
					stopwatch.Stop();
					timeoutWatch.Stop();

					// Pause the test.
					ProcessPause();

					// Restart the clocks.
					stopwatch.Start();
					timeoutWatch.Start();
				}

				// Get reference reading.
				_equipment.Devices[deviceName].Read();
				double reading = _equipment.Devices[deviceName].Readings[variable];

				// Calculate error.
				error = reading - setpoint;

				// Update the GUI.
				Variables[variable] = (Convert.ToDecimal(reading), Convert.ToDecimal(setpoint));
				string message = string.Empty;

				// If tolerance has been exceeded, reset the stability time.
				if (Math.Abs(error) > tolerance)
				{
					message = "Waiting for stability...";
					stopwatch.Restart();
				}
				else if (dwellTime > new TimeSpan(0, 0, 0))
				{
					// Update GUI (include dwell time if applicable).
					message = "Dwell time left:  " + (dwellTime - stopwatch.Elapsed).ToString(@"hh\:mm\:ss");

					// Reset the timeout stopwatch.
					timeoutWatch.Restart();
				}
				_testThread.ReportProgress(PercentProgress, message);

				// Wait to get desired reading frequency.
				Thread.Sleep(interval);
			} while ((stopwatch.Elapsed <= dwellTime) ||
					(Math.Abs(error) > tolerance));
		}

		private void ProcessSamples()
		{
			// Record test data.
			_log.Write(_elapsedTimeStopwatch.Elapsed);
		}

		/// <summary>
		/// Perform all requested test actions in order.
		/// </summary>
		/// <remarks>
		/// This method is basically a bunch of nested foreach loops corresponding to the test settings object.
		/// Note that for cancelling a test to work correctly, each foreach loop must contain this line, or
		/// else it will hang in that loop when a test is aborted:
		/// <code>
		/// if (_testThread.CancellationPending) { break; }
		/// </code>
		/// </remarks>
		private void ProcessTest()
		{
			// For each event...
			foreach (EventSetting e in _settings.Events)
			{
				// Set active control mode.
				_equipment.Devices[e.DeviceName].SetControlMode(ControlMode.Active);

				// Set the setpoint.
				ProcessSetpoint(e.DeviceName, e.Variable, e.Value, e.Interval, e.Timeout, e.ErrorTolerance, e.DwellTime);

				// For each sample...
				for (int i = 1; i <= e.Duration; i++)
				{
					// Update GUI.
					_testThread.ReportProgress(PercentProgress, "Taking sample " + i.ToString() + " of " + e.Duration + ".");

					// Fetch readings from references.
					_equipment.Read();

					// Check stability of all controlled variables.
					StabilityCheck();

					// Pause the test if necessary.
					if (_pause == true)
					{
						ProcessPause();
					}

					// Record sample data.
					ProcessSamples();

					// Wait to get desired reading frequency.
					Thread.Sleep(e.Interval);

					_samplesComplete++;

					if (_testThread.CancellationPending) { break; }
				}

				if (_testThread.CancellationPending) { break; }
			}
		}

		/// <summary>
		/// This runs during a test.
		/// </summary>
		/// <remarks>
		/// This method handles all the testing.  Every time the
		/// user presses "Start" this is what runs.  If you're trying to figure
		/// out what this application does, this is a good place to start.
		/// 
		/// This page helped guide implementation of how to cancel the task:
		/// https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-run-an-operation-in-the-background
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TestThread(object sender, DoWorkEventArgs e)
		{
			// Get start time.
			_elapsedTimeStopwatch = Stopwatch.StartNew();

			try
			{
				// Anything within this do-while structure can be cancelled.
				do
				{
					// Initialize test equipment.
					_testThread.ReportProgress(0, "Configuring test equipment...");
					_log.Open();
					_equipment.Open();

					// Repeat test if requested.
					do
					{
						// Initialize number of samples taken.
						_samplesComplete = 0;

						// Perform test actions.
						ProcessTest();
					} while (Repeat && (_testThread.CancellationPending == false));
				} while (false);
			}
			catch (Exception ex)
			{
				PopupAbort(ex.Message, ex.GetType().ToString());
			}

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			// Calculate end time.
			_elapsedTimeStopwatch.Stop();
			TimeSpan elapsedtime = _elapsedTimeStopwatch.Elapsed;

			try
			{
				// Stop all controllers.
				foreach (IDevice device in _equipment.Devices.Values)
				{
					device.SetControlMode(ControlMode.Passive);
				}

				// Close test equipment.
				_testThread.ReportProgress(99, "Closing test equipment...");
				_equipment.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
			finally
			{
				// Dispose of any used log resources.
				_log.Dispose();
			}

			// Update the GUI.
			_testThread.ReportProgress(100, "Done.");
			MessageBox.Show("Test complete.", "Notice");

			// If the operation was cancelled by the user, set the cancel property.
			if (_testThread.CancellationPending) { e.Cancel = true; }
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </remarks>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose managed resources.
				_equipment?.Dispose();
				_testThread?.Dispose();
			}
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1001
		/// </remarks>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
