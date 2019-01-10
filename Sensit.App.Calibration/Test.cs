using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace Sensit.App.Calibration
{
	public class Test
	{
		public Action<int, string> Update;	// action to run as test progresses
		public Action Finished;				// action to run after test finishes

		// task that will handle test operations
		private BackgroundWorker testThread = new BackgroundWorker();

		// number of devices under test
		private int _numDuts;
		private string _model;
		private string _range;
		private string _test;

		/// <summary>
		/// Constructor
		/// </summary>
		public Test()
		{
			// Set up the background worker.
			testThread.WorkerReportsProgress = true;
			testThread.WorkerSupportsCancellation = true;
			testThread.DoWork += TestThread;
			testThread.ProgressChanged += ProgressChanged;
			testThread.RunWorkerCompleted += RunWorkerCompleted;
		}

		#region Private Methods

		private void ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			// Run action required as test progresses (i.e. update GUI).
			Update(e.ProgressPercentage, e.UserState as String);
		}

		private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			// If the test was cancelled, update the GUI's status accordingly.
			if (e.Cancelled)
			{
				Update(0, "Test cancelled.");
			}

			// Run actions required when test is completed (i.e. update GUI).
			Finished();
		}
		
		private void InitializeDuts()
		{
			
		}
		
		private void ProcessCommand()
		{
			
		}
		
		private void RecordLog()
		{
			// TODO:  Do this continuously rather than just at the end of a test.
			// Should likely be a logger class in the SDK.
		}

		#region DUT Helper Methods
		
		private void ScanAllDuts(Action action)
		{
			
		}
		
		private void ScanSelectedDuts(Action action)
		{
			
		}
		
		private void ScanOpenedDuts(Action action)
		{
			
		}
		
		private void ScanFoundOrFailDuts(Action action)
		{
			
		}
		
		#endregion
		
		#region Test Actions
		
		private void SetMassFlow()
		{
			
		}
		
		private void SetpointCycle()
		{
			
		}
		
		private void DutCycle()
		{
			
		}
		
		private void CheckTolerance()
		{
			
		}
		
		private void ComputeError()
		{
			
		}
		
		private void Verify()
		{
			
		}
				
		#endregion

		/// <summary>
		/// This runs during a test.
		/// </summary>
		/// <remarks>
		/// This page helped guide implementation of how to cancel the task.
		/// https://docs.microsoft.com/en-us/dotnet/framework/winforms/controls/how-to-run-an-operation-in-the-background
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TestThread(object sender, DoWorkEventArgs e)
		{
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = sender as BackgroundWorker;

			// Get start time.
			var stopwatch = Stopwatch.StartNew();

			// Anything within this do-while structure can be cancelled.
			do
			{
				// Read system settings.
				testThread.ReportProgress(5, "Reading test settings...");
				Thread.Sleep(1000); // One second.
				if (bw.CancellationPending) { break; }

				// Read DUT settings (specific to Model, Range, Test).
				testThread.ReportProgress(10, "Reading DUT settings...");
				Thread.Sleep(1000); // One second.
				if (bw.CancellationPending) { break; }

				// Initialize GUI.

				// Configure test equipment.
				testThread.ReportProgress(15, "Configuring test equipment...");
				Thread.Sleep(1000); // One second.
				if (bw.CancellationPending) { break; }

				// Open selected DUTs.
				testThread.ReportProgress(20, "Opening DUT communication...");
				Thread.Sleep(1000); // One second.
				if (bw.CancellationPending) { break; }

				// Apply power to opened DUTs.
				testThread.ReportProgress(25, "Applying power to DUTs...");
				Thread.Sleep(1000); // One second.
				if (bw.CancellationPending) { break; }

				// Wait for DUTs to power up.
				testThread.ReportProgress(30, "Power-up delay...");
				Thread.Sleep(2500);
				if (bw.CancellationPending) { break; }

				// Configure DUTs.

				// Perform test actions.

				// Close DUTs.

				// Identify passing DUTs.
				testThread.ReportProgress(80, "Identifying passed DUTS...");
				Thread.Sleep(250); // One second.
			} while (false);

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			// Calculate end time.
			testThread.ReportProgress(85, "Calculating elapsed time....");
			stopwatch.Stop();
			Thread.Sleep(100); // One second.

			// Record log.
			testThread.ReportProgress(90, "Recording log...");
			TimeSpan elapsedtime = stopwatch.Elapsed;
			Thread.Sleep(100); // One second.

			// Close support devices.
			testThread.ReportProgress(95, "Closing test equipment...");
			Thread.Sleep(100); // One second.

			// Done!
			testThread.ReportProgress(100, "Done.");

			// If the operation was cancelled by the user, set the cancel property.
			if (bw.CancellationPending) { e.Cancel = true; }
		}

		#endregion

		/// <summary>
		/// Start a new test.
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
		/// Stop the test.
		/// </summary>
		public void Stop()
		{
			// Cancel the test operation.
			testThread.CancelAsync();
		}

		/// <summary>
		/// Return whether a test is running.
		/// </summary>
		/// <returns>true if test is running; false otherwise</returns>
		public bool IsBusy()
		{
			return testThread.IsBusy;
		}

		/// <summary>
		/// Set the number of DUTs handled in the test.
		/// </summary>
		/// <param name="duts"></param>
		public void SetNumDuts(int duts)
		{
			// If the test is running, throw an error.
			if (testThread.IsBusy)
			{
				throw new Exception("Cannot change number of DUTs when test is running.");
			}

			_numDuts = duts;
		}

		/// <summary>
		/// Set the DUT type.
		/// </summary>
		/// <param name="model"></param>
		public void SetModel(string model)
		{
			// If the test is running, throw an error.
			if (testThread.IsBusy)
			{
				throw new Exception("Cannot change model when test is running.");
			}

			_model = model;

			// TODO:  Re-populate the available ranges.

			// TODO:  Re-populate the available tests.
		}

		/// <summary>
		/// Set the DUT range.
		/// </summary>
		/// <param name="range"></param>
		public void SetRange(string range)
		{
			// If the test is running, throw an error.
			if (testThread.IsBusy)
			{
				throw new Exception("Cannot change range when test is running.");
			}

			_range = range;

			// TODO:  Re-populate the available tests.
		}

		/// <summary>
		/// Select what test to perform.
		/// </summary>
		/// <param name="test"></param>
		public void SetTest(string test)
		{
			// If the test is running, throw an error.
			if (testThread.IsBusy)
			{
				throw new Exception("Cannot change test type when test is running.");
			}

			_test = test;
		}
	}
}
