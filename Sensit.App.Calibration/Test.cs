using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	public class Test
	{
		public enum Command
		{
			TurnDutsOff,	// Remove power from DUT.
			TurnDutsOn,		// Apply power to DUT.			  
			Default,		// Set factory default settings.
			Range,			// Set range settings.
			Zero,			// Perform zero-calibration.
			Span,			// Perform span-calibration.
		}

		public enum ToleranceType
		{
			Absolute,			// Quantity of range.
			PercentFullScale,   // Percent of positive range.
			PercentReading      // Percent of reading.
		}

		private BackgroundWorker _testThread;   // task that will handle test operations
		private TestSetting _settings;			// settings for test
		private Equipment _equipment;			// test equipment object
		private readonly List<Dut> _duts;       // devices under test
		private Stopwatch _elapsedTimeStopwatch;// keeper of test's elapsed time
		private int _samplesTotal;				// helps calculate percent complete
		private int _samplesComplete = 0;		// helps calculate percent complete

		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		#endregion

		#region Properties

		// TODO:  Perhaps replace this single property with properties for SamplesComplete and SamplesTotal?
		public int PercentProgress
		{
			get
			{
				int percent = (int)(_samplesComplete / (double)_samplesTotal * 100.0);

				// Check for overflow or underflow.
				if ((percent < 0) || (percent > 100))
				{
					throw new TestException("Percent progress is out of range; please contact Engineering."
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
		/// This will be accessed by the FormCalibration to display the variables values.
		/// </remarks>
		public List<TestControlledVariable> Variables;

		#endregion

		#region Thread Management

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="equipment">equipment used by the test</param>
		/// <param name="duts">devices being tested</param>
		public Test(TestSetting settings, Equipment equipment, List<Dut> duts)
		{
			// Save the reference to the equipment and DUTs objects.
			_settings = settings;
			_equipment = equipment;
			_duts = duts;

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
			foreach (TestComponent c in settings.Components)
			{
				_samplesTotal += c.Samples;
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
			Update(e.ProgressPercentage, e.UserState as string);
		}

		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// If the test was cancelled, update the GUI's status accordingly.
			if (e.Cancelled)
			{
				Update(0, "Test cancelled.");
			}

			// Run actions required when test is completed (i.e. update GUI).
			Finished?.Invoke();
		}

		#endregion

		/// <summary>
		/// If we can't reach a setpoint, stop the equipment and prompt the user.
		/// </summary>
		/// <param name="errorMessage">message to display to the user</param>
		private void PopupAlarm(string errorMessage)
		{
			// Stop the equipment to reduce change of damage.
			// TODO:  Ensure measure/vent mode is supported for all devices.
			// Measure mode should save active setpoints but not use them.  Vent mode might discard setpoints?
			// TODO:  Equipment should have a property for control devices and reference devices.
			// Those properties could be Dictionaries with the key being the variable type.
			// Then we can initialize them in Equipment.cs, iterate through them here, and set parameters when needed.
			foreach (KeyValuePair<VariableType, IControlDevice> c in _equipment.Controllers)
			{
				c.Value.SetControlMode(ControlMode.Measure);
			}

			// Alert the user.
			DialogResult result = MessageBox.Show(errorMessage
				+ Environment.NewLine + "Abort the test?", "Test Error", MessageBoxButtons.YesNo);

			// If requested, cancel the test.
			if (result == DialogResult.Yes)
			{
				// TODO:  Log the abort action.

				// Abort the test.
				_testThread.CancelAsync();
			}
			// If we're continuing to test, attempt to control variables again.
			else
			{
				foreach (KeyValuePair<VariableType, IControlDevice> c in _equipment.Controllers)
				{
					c.Value.SetControlMode(ControlMode.Control);
				}
			}
		}

		private void ProcessCommand(Command? command)
		{
			switch (command)
			{
				case Command.TurnDutsOff:
				case Command.TurnDutsOn:
				case Command.Default:
				case Command.Range:
				case Command.Span:
				case Command.Zero:
				default:
					break;
			}
		}

		private async void ProcessSetpoint(TestControlledVariable variable, double setpoint, TimeSpan interval)
		{
			// Update GUI.
			_testThread.ReportProgress(PercentProgress, "Setting setpoint...");

			// Set setpoint.
			_equipment.Controllers[variable.VariableType].WriteSetpoint(variable.VariableType, setpoint);

			// Get start time.
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch timeoutWatch = Stopwatch.StartNew();

			double previous = setpoint;
			TimeSpan timeoutValue = TimeSpan.Zero;

			// Take readings until they are within tolerance for the required settling time.
			double error;
			do
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }

				// Process timeouts.
				if (timeoutWatch.Elapsed > variable.Timeout)
				{
					// Prompt user; cancel test if requested.
					PopupAlarm("Not able to reach stability.");

					// Reset the timeout stopwatch.
					timeoutWatch.Restart();
				}

				// Get reference reading.
				_equipment.References[variable.VariableType].Update();
				double reading = _equipment.References[variable.VariableType].Read(variable.VariableType);

				// Calculate error.
				error = reading - setpoint;

				// Calculate rate of change.
				double rate = (reading - previous) / (interval.TotalSeconds / 1000);
				previous = reading;

				// If tolerance has been exceeded, reset the stability time.
				if (Math.Abs(error) > variable.ErrorTolerance)
				{
					stopwatch.Restart();
				}

				// Update GUI.
				_testThread.ReportProgress(PercentProgress, "Setpoint time to go:  "
					+ (variable.StabilityTime - stopwatch.Elapsed).ToString(@"hh\:mm\:ss"));

				// Wait to get desired reading frequency.
				await Task.Delay(interval);
			} while ((stopwatch.Elapsed <= variable.StabilityTime) ||
					(Math.Abs(error) > variable.ErrorTolerance));
		}

		private void ProcessSamples(double setpoint)
		{
			// Create an object to hold reference device readings.
			Dictionary<VariableType, double> referenceReadings = new Dictionary<VariableType, double>();

			// Fetch reference data and add it to the dictionary.
			foreach (VariableType reference in _settings?.References ?? Enumerable.Empty<VariableType>())
			{
				double value = _equipment.References[reference].Read(reference);

				referenceReadings.Add(reference, value);
			}

			// Fetch readings from the DUTs.
			List<double> dutValue = _equipment.DutInterface.Read();

			// Record the data applicable to each DUT.
			foreach (Dut dut in _duts)
			{
				// Only process found or failed DUTs.
				if ((dut.Device.Status == DutStatus.Found) ||
					(dut.Device.Status == DutStatus.Fail))
				{
					// Save the result.
					dut.Results.Add(new TestResults
					{
						ElapsedTime = _elapsedTimeStopwatch.Elapsed,
						Setpoint = setpoint,
						Reference = referenceReadings[VariableType.GasConcentration],
						SensorValue = dutValue[(int)(dut.Device.Index - 1)]
					});
				}

				if (_testThread.CancellationPending) { break; }
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
		private async void ProcessTest()
		{
			// For each component...
			foreach (TestComponent c in _settings?.Components ?? Enumerable.Empty<TestComponent>())
			{
				// For each DUT command...
				foreach (Command command in c?.Commands ?? Enumerable.Empty<Command>())
				{
					// Perform DUT command.
					ProcessCommand(command);

					if (_testThread.CancellationPending) { break; }
				}

				// For each controlled variable...
				foreach (TestControlledVariable v in c?.ControlledVariables ?? Enumerable.Empty<TestControlledVariable>())
				{
					// Set active control mode.
					_equipment.Controllers[v.VariableType].SetControlMode(ControlMode.Control);

					// For each setpoint...
					foreach (double sp in v?.Setpoints ?? Enumerable.Empty<double>())
					{
						// Set the setpoint.
						ProcessSetpoint(v, sp, c.Interval);

						// For each sample.
						for (int i = 0; i < c.Samples; i++)
						{
							// TODO:  Check stability of all controlled variables.

							// Take sample data.
							_testThread.ReportProgress(PercentProgress, "Taking sample " + i.ToString() + " of " + c.Samples + ".");
							ProcessSamples(sp);

							// Wait to get desired reading frequency.
							await Task.Delay(c.Interval);

							_samplesComplete++;

							if (_testThread.CancellationPending) { break; }
						}

						if (_testThread.CancellationPending) { break; }
					}

					if (_testThread.CancellationPending) { break; }
				}

				if (_testThread.CancellationPending) { break; }
			}
		}

		/// <summary>
		/// This runs during a test.
		/// </summary>
		/// <remarks>
		/// This method handles all the testing of the DUTs.  Every time the
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
					_equipment.Open();
					if (_testThread.CancellationPending) { break; }

					// Initialize DUTs.
					List<bool> selections = new List<bool>();
					foreach (Dut dut in _duts)
					{
						if (_testThread.CancellationPending) { break; }

						// TODO:  This is ugly.  Make it go away.
						if (dut.Device.Selected)
							selections.Add(true);
						else
							selections.Add(false);
					}

					// Configure DUT interface device.
					// TODO:  This should happen before DUTs are opened, or within dut.Open().
					_testThread.ReportProgress(0, "Configuring DUT Interface Device...");
					_equipment.DutInterface.Configure(3, selections);

					// Perform test actions.
					ProcessTest();
				} while (false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().ToString());
			}

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			// Calculate end time.
			_elapsedTimeStopwatch.Stop();
			TimeSpan elapsedtime = _elapsedTimeStopwatch.Elapsed;

			try
			{
				// Close test equipment.
				_testThread.ReportProgress(99, "Closing test equipment...");
				_equipment.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().ToString());
			}

			// Update the GUI.
			_testThread.ReportProgress(100, "Done.");
			MessageBox.Show("Test complete.", "Notice");

			// If the operation was cancelled by the user, set the cancel property.
			if (_testThread.CancellationPending) { e.Cancel = true; }
		}
	}
}
