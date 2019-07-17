using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace Sensit.App.WebSensors
{
	public class Test
	{
		#region Enumerations

		/// <summary>
		/// Non-measurement related commands that can be executed during a test.
		/// </summary>
		/// <remarks>
		/// These actions can activate a relay, send info to the DUTs, etc.
		/// </remarks>
		public enum Command
		{
			TurnDutsOff,	// Remove power from DUT.
			TurnDutsOn,		// Apply power to DUT.			  
			Default,		// Set factory default settings.
			Range,			// Set range settings.
			Zero,			// Perform zero-calibration.
			Span,			// Perform span-calibration.
		}

		/// <summary>
		/// Types of tolerances for DUT ranges
		/// </summary>
		public enum ToleranceType
		{
			Absolute,			// Quantity of range.
			PercentFullScale,   // Percent of positive range.
			PercentReading      // Percent of reading.
		}

		#endregion

		#region Fields

		private BackgroundWorker _testThread;   // task that will handle test operations
		private readonly List<Sensor> _sensors; // sensors
		private Stopwatch _elapsedTimeStopwatch;// keeper of test's elapsed time

		#endregion

		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		#endregion

		#region Properties



		#endregion

		#region Thread Management

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="equipment">equipment used by the test</param>
		/// <param name="duts">devices being tested</param>
		public Test(List<Sensor> sensors)
		{
			// Save the reference to the sensors objects.
			_sensors = sensors;

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
			// Update GUI.
			// TODO:  What should percent progress be?
			_testThread.ReportProgress(0, "Taking sample.");

			// Record the data applicable to each DUT.
			foreach (Sensor sensor in _sensors)
			{
				// Only process sensors that are online.
				if (sensor.Status == SensorStatus.Online)
				{
					// Save the result.
					sensor.Data.Add(new SensorData
					{
						ElapsedTime = _elapsedTimeStopwatch.Elapsed,
					});
				}

				if (_testThread.CancellationPending) { break; }
			}

			// TODO: Wait to get desired reading frequency.
			Thread.Sleep(1000);
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
					// Connect to sensors.
					_testThread.ReportProgress(0, "Connecting to sensors...");
					if (_testThread.CancellationPending) { break; }

					// Initialize DUT interface device.
					_testThread.ReportProgress(0, "Configuring DUT Interface Device...");
					// TODO:  This is ugly.  Make it go away.
					List<bool> selections = new List<bool>();
					foreach (Sensor sensor in _sensors)
					{
						if (_testThread.CancellationPending) { break; }

						if (sensor.Status == SensorStatus.Online)
							selections.Add(true);
						else
							selections.Add(false);

						sensor.Open();
					}

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
				// Close sensors; save log files.
				foreach (Sensor sensor in _sensors)
				{
					sensor.Close();
				}

				// Close test equipment.
				_testThread.ReportProgress(99, "Closing sensors...");
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
