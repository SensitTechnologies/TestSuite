using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	public class Test
	{
		public enum DutCommand
		{
			Default,    // Set factory default settings.
			Range,      // Set range settings.
			Zero,       // Perform zero-calibration.
			Span,       // Perform span-calibration.
		}

		public enum VariableType
		{
			GasConcentration,
			MassFlow,
			VolumeFlow,
			Velocity,
			Pressure,
			Temperature
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
		private Stopwatch _stopwatch;           // keeper of test's elapsed time
		private int _stepsTotal;				// helps calculate percent complete
		private int _stepsComplete = 0;			// helps calculate percent complete

		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		#endregion

		#region Properties

		public TimeSpan? ElapsedTime => _stopwatch?.Elapsed;

		public int PercentProgress
		{
			get
			{
				int percent = (int)(_stepsComplete / (double)_stepsTotal * 100.0);

				// Check for overflow or underflow.
				if ((percent < 0) || (percent > 100))
				{
					throw new TestException("Percent progress is out of range; please contact Engineering."
						+ Environment.NewLine + "Steps Complete:  " + _stepsComplete.ToString()
						+ Environment.NewLine + "Steps Total:  " + _stepsTotal.ToString());
				}

				return percent;
			}
		}

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
			_stepsTotal = 0;
			foreach (TestComponent c in settings.Components)
			{
				int samples = c.Setpoints.Count * c.NumberOfSamples;
				_stepsTotal += samples;
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
			// Remember what the equipment setpoint was.
			double flowSetpoint = _equipment.GasMixController.MassFlowSetpoint;
			double mixSetpoint = _equipment.GasMixController.GasMixSetpoint;

			// Stop the equipment to prevent damage to it.
			_equipment.GasMixController.MassFlowSetpoint = 0.0;
			_equipment.GasMixController.GasMixSetpoint = 0.0;
			_equipment.GasMixController.WriteGasMixSetpoint();

			// Alert the user.
			DialogResult result = MessageBox.Show(errorMessage
				+ Environment.NewLine + "Abort the test?"
				, "Test Error", MessageBoxButtons.YesNo);

			// If requested, cancel the test.
			if (result == DialogResult.Yes)
			{
				// TODO:  Log the abort action.

				// Abort the test.
				_testThread.CancelAsync();
			}
			// If we're continuing to test, reset the equipment setpoint.
			else
			{
				_equipment.GasMixController.MassFlowSetpoint = flowSetpoint;
				_equipment.GasMixController.GasMixSetpoint = mixSetpoint;
				_equipment.GasMixController.WriteGasMixSetpoint();
			}
		}

		private void SetpointCycle(TestVariable variable, double setpoint)
		{
			// Set setpoint.
			_testThread.ReportProgress(PercentProgress, "Setting setpoint...");
			_equipment.GasMixController.AnalyteBottleConcentration = 25;
			_equipment.GasMixController.MassFlowSetpoint = 300;
			_equipment.GasMixController.GasMixSetpoint = setpoint;
			_equipment.GasMixController.WriteGasMixSetpoint();

			// Get start time.
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch timeoutWatch = Stopwatch.StartNew();

			double mixPrevious = setpoint;
			double flowPrevious;
			TimeSpan timeoutValue = TimeSpan.Zero;

			// Take readings until they are within tolerance for the required settling time.
			double massFlowError;
			double mixError;
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
				_equipment.GasReference.Read();
				double mixReading = _equipment.GasReference.GasMix;
				double flowReading = _equipment.GasReference.MassFlow;

				// Calculate error.
				mixError = mixReading - setpoint;
				massFlowError = flowReading - 300;

				// Calculate rate of change.
				double mixRate = (mixReading - mixPrevious)
					/ (variable.Interval.TotalSeconds / 1000);
				double florRate = (flowReading - mixReading)
					/ (variable.Interval.TotalSeconds / 1000);
				mixPrevious = mixReading;
				flowPrevious = flowReading;

				// If tolerance has been exceeded, reset the stability time.
				if ((Math.Abs(mixError) > variable.ErrorTolerance) ||
					(Math.Abs(massFlowError) > variable.ErrorTolerance))
				{
					stopwatch.Restart();
				}

				// Update GUI.
				_testThread.ReportProgress(PercentProgress, "Setpoint time to go:  "
					+ (variable.StabilityTime - stopwatch.Elapsed).ToString(@"hh\:mm\:ss"));

				// Wait to get desired reading frequency.
				Thread.Sleep(variable.Interval);
			} while ((stopwatch.Elapsed <= variable.StabilityTime) ||
					(Math.Abs(mixError) > variable.ErrorTolerance) ||
					(Math.Abs(massFlowError) > variable.ErrorTolerance));
		}

		private void ComponentCycle(TestComponent testComponent)
		{
			// Set active control mode.
			_equipment.GasMixController.SetControlMode(ControlMode.Control);

			// Collect data.
			foreach (double sp in testComponent.Setpoints)
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }

				// Achieve the setpoint.
				SetpointCycle(testComponent.IndependentVariable, sp);

				// Read data from each DUT.
				for (int i = 0; i < testComponent.NumberOfSamples; i++)
				{
					// Abort if requested.
					if (_testThread.CancellationPending) { break; }

					// Update GUI.
					_testThread.ReportProgress(PercentProgress, "Taking sample " + i.ToString() + " of " + testComponent.NumberOfSamples + ".");

					// Take samples via DUT interface.
					_equipment.DutInterface.Read();

					_stepsComplete++;

					// Get reading from each DUT.
					foreach (Dut dut in _duts)
					{
						// Abort if requested.
						if (_testThread.CancellationPending) { break; }

						// Read and process DUT data.
						dut.Read(sp, testComponent.IndependentVariable.ErrorTolerance);
					}

					// Wait to get desired reading frequency.
					Thread.Sleep(testComponent.SampleInterval);
				}
			}

			// Set controller to passive mode.
			_equipment.GasMixController.SetControlMode(ControlMode.Ambient);
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
			_stopwatch = Stopwatch.StartNew();

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

						_testThread.ReportProgress(0, "Initializing DUT #" + dut.Device.Index + "...");
						dut.Open();

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
					foreach (TestComponent c in _settings.Components)
					{
						// Abort if requested.
						if (_testThread.CancellationPending) { break; }

						ComponentCycle(c);
					}
				} while (false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().ToString());
			}

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			// Calculate end time.
			_stopwatch.Stop();
			TimeSpan elapsedtime = _stopwatch.Elapsed;

			try
			{
				// Close DUTs.
				_testThread.ReportProgress(99, "Closing DUTs...");
				foreach (Dut dut in _duts)
				{
					dut.Close();
				}

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
