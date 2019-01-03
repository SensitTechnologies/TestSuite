using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

namespace Sensit.App.Calibration
{
	public class Test
	{
		public Action<int, string> UpdateStatus;		// method to update test status

		// task that will handle test operations
		private BackgroundWorker testThread = new BackgroundWorker();

		public Test()
		{
			// Set up the background worker.
			testThread.WorkerReportsProgress = true;
			testThread.WorkerSupportsCancellation = true;
			testThread.DoWork += TestThread;
			testThread.ProgressChanged += ProgressChanged;
			testThread.RunWorkerCompleted += RunWorkerCompleted;
		}

		public bool IsRunning()
		{
			return testThread.IsBusy;
		}

		/// <summary>
		/// Start a new thread to do tests.
		/// </summary>
		public void Start()
		{
			// Run "TestProcess" asynchronously (using a background worker).
			if (testThread.IsBusy == false)
			{
				// Start the asynchronous operation.
				testThread.RunWorkerAsync();
			}
		}

		/// <summary>
		/// Stop the test thread.
		/// </summary>
		public void Stop()
		{
			// Stop the "TestProcess" thread.
			// Cancel the asynchronous operation.
			testThread.CancelAsync();
		}

		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Update the GUI.
			UpdateStatus(e.ProgressPercentage, e.UserState as String);
		}

		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{

		}

		public void TestThread(object sender, DoWorkEventArgs e)
		{
			// Initialize abort flag.
			testThread.ReportProgress(0, "Initializing...");

			// Get start time.


			// Read settings.
			testThread.ReportProgress(5, "Reading test settings...");

			// Read DUT settings (specific to Model, Range, Test).
			testThread.ReportProgress(10, "Reading DUT settings...");

			// Initialize GUI.

			// Configure support devices.
			testThread.ReportProgress(15, "Configuring test equipment...");

			// Open selected DUTs.
			testThread.ReportProgress(20, "Opening DUT communication...");

			// Apply power to opened DUTs.
			testThread.ReportProgress(25, "Applying power to DUTs...");

			// Wait for DUTs to power up.
			testThread.ReportProgress(30, "Power-up delay...");
			Thread.Sleep(2500);

			// Configure DUTs.

			// Perform test actions.

			// Close DUTs.

			// Identify passing DUTs.
			testThread.ReportProgress(80, "Identifying passed DUTS...");

			// Calculate end time.
			testThread.ReportProgress(85, "Calculating elapsed time....");

			// Record log.
			testThread.ReportProgress(90, "Recording log...");

			// Close support devices.
			testThread.ReportProgress(95, "Closing test equipment...");
		}
	}
}
