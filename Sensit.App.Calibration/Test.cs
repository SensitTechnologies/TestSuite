using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using CsvHelper;
using Sensit.TestSDK.Dut;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;

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

		public class TestResults
		{
			public double Setpoint { get; set; }
			public double Reference { get; set; }
			public double SensorValue { get; set; }
			//public double Error { get; set; }
		}

		private BackgroundWorker _testThread;   // task that will handle test operations
		private Equipment _equipment;			// test equipment object
		private List<IDeviceUnderTest> _duts;	// devices under test
		private List<TestResults> dutData;
		private int _numDuts;					// number of devices under test displayed on the form

		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		#endregion

		#region Properties

		/// <summary>
		/// Settings for selected model.
		/// </summary>
		public ModelSetting ModelSettings { get; set; }

		/// <summary>
		/// Settings for selected range.
		/// </summary>
		public RangeSetting RangeSettings { get; set; }

		/// <summary>
		/// Settings for selected test.
		/// </summary>
		public TestSetting TestSettings { get; set; }

		/// <summary>
		/// Number of devices under test
		/// </summary>
		public int NumDuts
		{
			get => _numDuts;
			set
			{
				// If the test is running, throw an error.
				if (_testThread.IsBusy)
				{
					throw new Exception("Cannot change number of DUTs when test is running.");
				}

				_numDuts = value;
			}
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Test()
		{
			// Set up the background worker.
			_testThread = new BackgroundWorker
			{
				WorkerReportsProgress = true,
				WorkerSupportsCancellation = true
			};
			_testThread.DoWork += TestThread;
			_testThread.ProgressChanged += ProgressChanged;
			_testThread.RunWorkerCompleted += RunWorkerCompleted;
		}

		#region Thread Management

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

		#region DUT Management

		/// <summary>
		/// Create DUT objects and initialize them with settings chosen by the user.
		/// </summary>
		private void DutOpen()
		{
			// Create a list of DUTs.
			// TODO:  (Medium priority) Choose type of DUT based on settings.
			_duts = new List<IDeviceUnderTest>(NumDuts);

			// Keep track of how many DUTs are selected.
			int numSelected = 0;

			// Create each DUT object.
			for (int i = 0; i < NumDuts; i++)
			{
				_duts.Add(new AnalogSensor
				{
					Index = i,
					// Model = "",
					// Version = "",
					Selected = true,	// Replace this with user setting from FormCalibration.
					Status = DutStatus.Init,
					SerialNumber = string.Empty,
					Message = string.Empty,
				});
				numSelected++;
			}

			// TODO:  (Low priority) Open DUT ports (if applicable); throw exception is no DUT ports could be opened.

			// Turn all DUTs on.
			foreach (IDeviceUnderTest dut in _duts)
			{
				if (dut.Status == DutStatus.Found)
				{
					_equipment.DutInterface?.PowerOn(dut.Index);
				}
			}

			// Verify communication with each DUT.
			foreach (IDeviceUnderTest dut in _duts)
			{
				if (dut.Status == DutStatus.Found)
				{
					// TODO:  (Low priority) Talk to each DUT to verify communication.

					dut.Status = DutStatus.Found;
				}
			}
		}

		private void DutClose()
		{
			// Turn off DUTs that have been found.
			foreach (IDeviceUnderTest dut in _duts)
			{
				if ((dut.Status != DutStatus.PortError) &&
					(dut.Status != DutStatus.NotFound))
				{
					_equipment.DutInterface?.PowerOff(dut.Index);
				}
			}

			foreach (IDeviceUnderTest dut in _duts)
			{
				if ((dut.Status == DutStatus.Found) ||
					(dut.Status == DutStatus.Fail) ||
					(dut.Status == DutStatus.NotFound))
				{
					// TODO:  (Low priority) Close DUT ports (if applicable).
				}
			}
		}

		#endregion

		private void PopupAlarm(string errorMessage)
		{
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
		}

		private void DutCycle(TestVariable variable, double setpoint)
		{
			// Get reading from each DUT.
			foreach (IDeviceUnderTest dut in _duts)
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }

				// TODO:  foreach (IReferenceDevice ref in _testSettings.References)
				// Get reference reading.
				_equipment.GasReference.Read();

				// Calculate error.
				double error = _equipment.GasReference.AnalyteConcentration - setpoint;

				// Check tolerance.
				if (Math.Abs(error) > variable.ErrorTolerance)
				{
					// TODO:  Log an error, "Reference out of tolerance during DutCycle."
					// Mark DUT as failed too.
				}

				// TODO:  Update GUI with reference info.
				double dutValue = _equipment.DutInterface.ReadAnalog(dut.Index);

				// Save the result.
				dutData.Add(new TestResults
				{
					Setpoint = setpoint,
					Reference = _equipment.GasReference.AnalyteConcentration,
					SensorValue = dutValue
				});
			}
		}

		private void SetpointCycle(TestVariable variable, double setpoint)
		{
			// Set setpoint.
			_equipment.GasController.AnalyteConcentrationSetpoint = setpoint;

			// TODO:  (Low priority) Update GUI with setpoint.

			// Get start time.
			Stopwatch stopwatch = Stopwatch.StartNew();

			double previous = setpoint;
			TimeSpan timeoutValue = TimeSpan.Zero;

			// Take readings until they are within tolerance for the required settling time.
			while (stopwatch.Elapsed < variable.StabilityTime)
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }

				// Process timeouts.
				if (stopwatch.Elapsed > variable.Timeout)
				{
					// Prompt user; cancel test if requested.
					PopupAlarm("Not able to reach stability.");

					// Reset the timer.
					stopwatch.Restart();
				}

				// Get reference reading.
				_equipment.GasReference.Read();
				double reading = _equipment.GasReference.AnalyteConcentration;

				// Calculate error.
				double error = reading - setpoint;

				// Calculate rate of change.
				double rate = (reading - previous)
					/ (variable.Interval.TotalSeconds / 1000);
				previous = reading;

				// If tolerance has been exceeded, reset the stability time.
				if (Math.Abs(error) > variable.ErrorTolerance)
				{
					stopwatch.Restart();
				}

				// TODO:  (Low priority) Update GUI.

				// Wait to get desired reading frequency.
				Thread.Sleep(variable.Interval);
			}
		}

		private void GasTest(TestComponent testComponent)
		{
			// Set active control mode.
			_equipment.GasController.SetControlMode(ControlMode.Control);

			// Collect data.
			foreach (double sp in testComponent.Setpoints)
			{
				// Abort if requested.
				if (_testThread.CancellationPending) { break; }

				// Achieve the setpoint.
				SetpointCycle(testComponent.IndependentVariable, sp);

				// Read data from each DUT.
				// TODO:  (Low priority) Do not process setpoints outside range of the DUT.
				// TODO:  (Low priority) Only process found or failed DUTs?
				for (int i = 0; i < testComponent.NumberOfSamples; i++)
				{
					// Take samples via DUT interface.
					_equipment.DutInterface.Read();

					DutCycle(testComponent.IndependentVariable, sp);
				}
			}

			// Set controller to passive mode.
			_equipment.GasController.SetControlMode(ControlMode.Ambient);
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
			Stopwatch stopwatch = Stopwatch.StartNew();
			dutData = new List<TestResults>();

			try
			{
				// Anything within this do-while structure can be cancelled.
				do
				{
					// Create an object to represent test equipment, and
					// update equipment settings.
					_testThread.ReportProgress(2, "Reading equipment settings...");
					_equipment = new Equipment();
					if (_testThread.CancellationPending) { break; }

					// Configure test equipment.
					_testThread.ReportProgress(3, "Configuring test equipment...");
					_equipment.Open();
					if (_testThread.CancellationPending) { break; }

					// Initialize DUTs.
					_testThread.ReportProgress(4, "Initializing DUTs...");
					DutOpen();
					if (_testThread.CancellationPending) { break; }

					// Perform test actions.
					foreach (TestComponent c in TestSettings.Components)
					{
						GasTest(c);
					}

					// Close DUTs.
					_testThread.ReportProgress(5, "Closing DUTs...");
					DutClose();

					// TODO:  Identify passing DUTs.
					_testThread.ReportProgress(95, "Identifying passed DUTS...");
				} while (false);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().ToString());
			}

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			// Calculate end time.
			stopwatch.Stop();
			TimeSpan elapsedtime = stopwatch.Elapsed;

			// Close test equipment.
			try
			{
				_testThread.ReportProgress(99, "Closing test equipment...");
				_equipment.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().ToString());
			}

			// Save test results to csv file.
			using (var writer = new StreamWriter("results.csv"))
			using (var csv = new CsvWriter(writer))
			{
				csv.WriteRecords(dutData);
			}

			// Update the GUI.
			_testThread.ReportProgress(100, "Done.");

			// If the operation was cancelled by the user, set the cancel property.
			if (_testThread.CancellationPending) { e.Cancel = true; }
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
	}
}
