﻿using System;
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
			TurnOff,	// Remove power from DUT.
			TurnOn,		// Apply power to DUT.			  
			Default,    // Set factory default settings.
			Range,      // Set range settings.
			Zero,       // Perform zero-calibration.
			Span,       // Perform span-calibration.
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
		private int _samplesTotal;				// helps calculate percent complete
		private int _samplesComplete = 0;		// helps calculate percent complete

		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		#endregion

		#region Properties

		public TimeSpan? ElapsedTime => _stopwatch?.Elapsed;

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
		public List<TestVariable> Variables;

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

		// TODO:  Use timer instead of Thread.Sleep.
		private void SetpointCycle(TestVariable variable, double setpoint)
		{
			// Set setpoint.
			_testThread.ReportProgress(PercentProgress, "Setting setpoint...");
			// TODO:  Figure out how to set analyte bottle concentration.
			//_equipment.GasMixController.AnalyteBottleConcentration = 25;
			_equipment.Controllers[variable.VariableType].SetControlMode(ControlMode.Control);
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
				double reading = _equipment.References[variable.VariableType].Read(variable.VariableType);

				// Calculate error.
				error = reading - setpoint;

				// Calculate rate of change.
				double rate = (reading - previous); // / (variable.Interval.TotalSeconds / 1000);
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
				Thread.Sleep(1000);
			} while ((stopwatch.Elapsed <= variable.StabilityTime) ||
					(Math.Abs(error) > variable.ErrorTolerance));
		}

		private void ComponentCycle(TestComponent testComponent)
		{
			// Achieve setpoint(s).
			foreach (TestVariable v in testComponent.Variables)
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }
			
				// Set active control mode.
				_equipment.Controllers[v.VariableType].SetControlMode(ControlMode.Control);

				// Collect data.
				foreach (double sp in v.Setpoints)
				{
					// Abort if requested.
					if (_testThread.CancellationPending) { break; }

					// Achieve the setpoint.
					SetpointCycle(v, sp);

					// Read data from each DUT.
					for (int i = 0; i < testComponent.Samples; i++)
					{
						// Abort if requested.
						if (_testThread.CancellationPending) { break; }

						// Update GUI.
						_testThread.ReportProgress(PercentProgress, "Taking sample " + i.ToString() + " of " + testComponent.Samples + ".");

						// Take samples via DUT interface.
						_equipment.DutInterface.Read();

						_samplesComplete++;

						// Get reading from each DUT.
						foreach (Dut dut in _duts)
						{
							// Abort if requested.
							if (_testThread.CancellationPending) { break; }

							// Read and process DUT data.
							dut.Read(sp, v.ErrorTolerance);
						}

						// Wait to get desired reading frequency.
						Thread.Sleep(testComponent.Interval);
					}
				}
			}

			// Set controller(s) to passive mode.
			foreach (TestVariable v in testComponent.Variables)
			{
				_equipment.Controllers[v.VariableType].SetControlMode(ControlMode.Ambient);
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
