using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Automate
{
	/// <summary>
	/// Set of values needed to control a device's variable.
	/// </summary>
	public class TestVariable
	{
		public decimal Actual { get; set; }

		public decimal Setpoint { get; set; }

		public decimal Tolerance { get; set; }
		
		public TimeSpan Interval { get; set; }
		
		public TimeSpan Timeout { get; set; }
		
		public TimeSpan DwellTime { get; set; }
	}

	public class Test : IDisposable
	{
		#region Fields

		// task that will handle test operations
		private readonly BackgroundWorker _testThread;

		// test events
		private readonly List<EventSetting> _events;

		// test equipment
		private readonly Equipment _equipment;

		// keeper of test results
		private readonly Log _log;

		// whether test is paused
		private bool _pause = false;

		// helps calculate percent complete
		private readonly uint _samplesTotal;

		// helps calculate percent complete
		private uint _samplesComplete = 0;

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
				int percent = 0;

				// Prevent exception if all events have 0 duration.
				if (_samplesTotal != 0)
				{
					percent = (int)(_samplesComplete / (double)_samplesTotal * 100.0);
				}

				// Check for overflow or underflow.
				if ((percent < 0) || (percent > 100))
				{
					throw new TestException("Percent progress is out of range."
						+ Environment.NewLine + "Steps Complete:  " + _samplesComplete.ToString(CultureInfo.CurrentCulture)
						+ Environment.NewLine + "Steps Total:  " + _samplesTotal.ToString(CultureInfo.CurrentCulture));
				}

				return percent;
			}
		}

		/// <summary>
		/// Number of events that have been completed.
		/// </summary>
		public uint EventsComplete { get; private set; } = 0;

		/// <summary>
		/// Controlled/independent variables for the current test component.
		/// </summary>
		/// <remarks>
		/// This will be accessed by the FormCalibration to display the variables values and setpoints.
		/// </remarks>
		public Dictionary<(string name, VariableType variable), TestVariable> Variables { get; private set; } =
			new Dictionary<(string, VariableType), TestVariable>();

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
		public Test(List<EventSetting> events, Equipment equipment, string filename)
		{
			// Save object references.
			_events = events;
			_equipment = equipment;

			// Create a log.
			_log = new Log(filename);

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
			foreach (EventSetting e in _events)
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
			_equipment.SetControlMode(ControlMode.Passive);

			// Alert the user (asking if they wish to retry or not).
			DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo);

			// If we're continuing to test, attempt to control variables again.
			if (result == DialogResult.Yes)
			{
				_equipment.SetControlMode(ControlMode.Active);
			}
			// If requested, cancel the test.
			else
			{
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
			// Fetch readings from references.
			_equipment.Read();

			foreach (KeyValuePair<(string name, VariableType variable), TestVariable> v in Variables)
			{
				// If applicable device supports reading the value, monitor it.
				if (_equipment.Devices[v.Key.name].Readings.ContainsKey(v.Key.variable))
				{
					// Get the reading from the device.
					decimal reading = _equipment.Devices[v.Key.name].Readings[v.Key.variable];

					// Update global variable.
					v.Value.Actual = Convert.ToDecimal(reading);

					// If the variable is not near the setpoint...
					if (Math.Abs(v.Value.Setpoint - v.Value.Actual) > v.Value.Tolerance)
					{
						// Attempt to achieve the setpoint again.
						ProcessSetpoint(v.Key.Item1, v.Key.Item2);
					}
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

		private void ProcessSetpoint(string deviceName, VariableType variable)
		{
			// Update GUI.
			_testThread.ReportProgress(PercentProgress, "Setting setpoint...");

			// Find the values applicable to the selected device/variable.
			TestVariable values = Variables[(deviceName, variable)];

			_equipment.Devices[deviceName].Write(variable, values.Setpoint);

			// If applicable device supports reading the value, monitor it.
			if (_equipment.Devices[deviceName].Readings.ContainsKey(variable))
			{
				// Get start time.
				Stopwatch stopwatch = Stopwatch.StartNew();
				Stopwatch timeoutWatch = Stopwatch.StartNew();

				// Take readings until they are within tolerance for the required settling time.
				decimal error;
				do
				{
					// Abort if requested.
					if (_testThread.CancellationPending) { break; }

					// Process timeouts.
					if (timeoutWatch.Elapsed > values.Timeout)
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
					decimal reading = _equipment.Devices[deviceName].Readings[variable];

					// Update global variable.
					Variables[(deviceName, variable)].Actual = Convert.ToDecimal(reading);

					// Calculate error.
					error = reading - values.Setpoint;

					// If tolerance has been exceeded, reset the stability time.
					if (Math.Abs(error) > values.Tolerance)
					{
						_testThread.ReportProgress(PercentProgress, "Waiting for stability...");
						stopwatch.Restart();
					}
					else if (values.DwellTime > new TimeSpan(0, 0, 0))
					{
						// Update GUI (include dwell time if applicable).
						_testThread.ReportProgress(PercentProgress, "Dwell time left:  " +
							(values.DwellTime - stopwatch.Elapsed).ToString(@"hh\:mm\:ss", CultureInfo.CurrentCulture));

						// Reset the timeout stopwatch.
						timeoutWatch.Restart();
					}

					// Wait to get desired reading frequency.
					Thread.Sleep(values.Interval);
				} while ((stopwatch.Elapsed <= values.DwellTime) ||
						(Math.Abs(error) > values.Tolerance));
			}
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
		private void ProcessEvents()
		{
			// For each event...
			foreach (EventSetting e in _events)
			{
				TestVariable testVariable = new TestVariable
				{
					Setpoint = e.Value,
					Tolerance = e.ErrorTolerance,
					Interval = e.Interval,
					Timeout = e.Timeout,
					DwellTime = e.DwellTime
				};

				// If the variable is new, create it.  If it already exists, update it.
				if (Variables.ContainsKey((e.DeviceName, e.Variable)) == false)
				{
					Variables.Add((e.DeviceName, e.Variable), testVariable);
				}
				else
				{
					Variables[(e.DeviceName, e.Variable)] = testVariable;
				}

				// Set the setpoint.
				ProcessSetpoint(e.DeviceName, e.Variable);

				// For each sample...
				for (int i = 1; i <= e.Duration; i++)
				{
					// Update GUI.
					_testThread.ReportProgress(PercentProgress, "Taking sample " + i.ToString(CultureInfo.CurrentCulture) + " of " + e.Duration + ".");

					// Check stability of all controlled variables.
					StabilityCheck();

					// Pause the test if necessary.
					if (_pause == true)
					{
						ProcessPause();
					}

					// Record sample data.
					_log.Write(_equipment.Devices);

					// Wait to get desired reading frequency.
					Thread.Sleep(e.Interval);

					// Update the number of completed samples.
					_samplesComplete++;

					if (_testThread.CancellationPending) { break; }
				}

				// Update the number of completed events.
				EventsComplete++;

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
			try
			{
				// Anything within this do-while structure can be cancelled.
				do
				{
					// Initialize test equipment.
					_testThread.ReportProgress(0, "Configuring test equipment...");
					_equipment.Open();
					_log.WriteHeader(_equipment.Devices);

					// Repeat test if requested.
					do
					{
						// Initialize global variables and properties.
						_samplesComplete = 0;
						EventsComplete = 0;

						// Set active control mode.
						_equipment.SetControlMode(ControlMode.Active);

						// Perform test actions.
						ProcessEvents();
					} while (Repeat && (_testThread.CancellationPending == false));
				} while (false);
			}
			catch (Exception ex)
			{
				PopupAbort(ex.Message, ex.GetType().ToString());
			}

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			try
			{
				// Stop all controllers.
				_equipment.SetControlMode(ControlMode.Passive);

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
				_testThread?.Dispose();
				_log?.Dispose();
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
