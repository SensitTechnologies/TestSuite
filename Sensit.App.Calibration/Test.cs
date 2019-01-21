using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Sensit.TestSDK.Dut;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;

namespace Sensit.App.Calibration
{
	public class Test
	{
		private BackgroundWorker _testThread;   // task that will handle test operations
		private ProductSettings _settings;      // product settings for model, range, test
		private Equipment _equipment;			// test equipment object
		private List<IDeviceUnderTest> _duts;	// devices under test


		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		// Update the GUI's list of available ranges (when the selected model changes).
		public Action<List<string>> SetRanges;

		// Fetch test equipment readings.
		public Func<Dictionary<Reference, double>> SystemRead;

		#endregion

		#region Properties

		/// <summary>
		/// Number of devices under test
		/// </summary>
		public int NumDuts
		{
			get => Properties.Settings.Default.NumDuts;
			set
			{
				// If the test is running, throw an error.
				if (_testThread.IsBusy)
				{
					throw new Exception("Cannot change number of DUTs when test is running.");
				}

				Properties.Settings.Default.NumDuts = value;
			}
		}

		/// <summary>
		/// Type of device under test
		/// </summary>
		public string SelectedModel
		{
			get => Properties.Settings.Default.Model;
			set
			{
				// If the test is running, throw an error.
				if (_testThread.IsBusy)
				{
					throw new Exception("Cannot change model when test is running.");
				}

				// Re-populate the ranges available in the GUI.
				SetRanges(Ranges);

				Properties.Settings.Default.Model = value;
			}
		}

		/// <summary>
		/// Range of devices under test
		/// </summary>
		public string SelectedRange
		{
			get => Properties.Settings.Default.Range;
			set
			{
				// If the test is running, throw an error.
				if (_testThread.IsBusy)
				{
					throw new Exception("Cannot change range when test is running.");
				}

				Properties.Settings.Default.Range = value;
			}
		}

		/// <summary>
		/// What test to perform.
		/// </summary>
		public string SelectedTest
		{
			get => Properties.Settings.Default.Test;
			set
			{
				// If the test is running, throw an error.
				if (_testThread.IsBusy)
				{
					throw new Exception("Cannot change test type when test is running.");
				}

				Properties.Settings.Default.Test = value;
			}
		}

		/// <summary>
		/// Available models to select from
		/// </summary>
		public List<string> Models
		{
			get
			{
				// Create a new list.
				List<string> models = new List<string>();

				// Add each model in the settings (if any models exist).
				foreach (ModelSetting model in _settings.ModelSettings ?? new List<ModelSetting>())
				{
					models.Add(model.Label);
				}

				return models;
			}
		}

		/// <summary>
		/// Available ranges to select from
		/// </summary>
		public List<string> Ranges
		{
			get
			{
				// Find the selected model settings object.
				ModelSetting m = _settings.ModelSettings.Find(x => x.Label == SelectedModel);

				// Create a new list.
				List<string> ranges = new List<string>();

				// Find each range associated with the model (if any ranges exist).
				foreach (RangeSetting r in m?.RangeSettings ?? new List<RangeSetting>())
				{
					ranges.Add(r.Label);
				}

				return ranges;
			}
		}

		/// <summary>
		/// Available tests to select from
		/// </summary>
		public List<string> Tests
		{
			get
			{
				// Create a new list.
				List<string> tests = new List<string>();

				if (_settings.TestSettings != null)
				{
					foreach (TestSetting t in _settings.TestSettings ?? new List<TestSetting>())
					{
						tests.Add(t.Label);
					}
				}

				return tests;
			}
		}

		#endregion

		/// <summary>
		/// Constructor
		/// </summary>
		public Test()
		{
			// Set up the background worker.
			_testThread = new BackgroundWorker();
			_testThread.WorkerReportsProgress = true;
			_testThread.WorkerSupportsCancellation = true;
			_testThread.DoWork += TestThread;
			_testThread.ProgressChanged += ProgressChanged;
			_testThread.RunWorkerCompleted += RunWorkerCompleted;

			// Set up list of DUTs.
			_duts = new List<IDeviceUnderTest>();

			// Fetch product settings.
			_settings = Settings.Load<ProductSettings>(Properties.Settings.Default.ProductSettingsFile);

			// TODO:  Populate the GUI's options for model, range, test.
		}

		#region Private Methods

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
		
		private void InitializeDuts()
		{
			for (int i = 0; i < NumDuts; i++)
			{
				_duts.Add(new AnalogSensor(_equipment.DutInterface) as IDeviceUnderTest);
			}
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

		private void PowerOn()
		{
			foreach (IDeviceUnderTest s in _duts)
			{
				if (s.Selected)
				{
					s.PowerOn();
				}
			}
		}

		private void PowerOff()
		{
			foreach (AnalogSensor s in _duts)
			{
				// Turn off DUTs that have been found.
				if ((s.Status != DutStatus.PortError) &&
					(s.Status != DutStatus.NotFound))
				{
					s.PowerOff();
				}
			}
		}
		
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
				// Create an object to represent test equipment, and
				// update equipment settings.
				_testThread.ReportProgress(1, "Reading equipment settings...");
				_equipment = new Equipment();
				if (bw.CancellationPending) { break; }

				// Read DUT settings (specific to Model, Range, Test).
				_testThread.ReportProgress(2, "Reading DUT settings...");
				_settings = Settings.Load<ProductSettings>(Properties.Settings.Default.ProductSettingsFile);
				if (bw.CancellationPending) { break; }

				// Configure test equipment.
				_testThread.ReportProgress(15, "Configuring test equipment...");
				_equipment.Open();
				if (bw.CancellationPending) { break; }

				// Apply power to opened DUTs.
				_testThread.ReportProgress(25, "Applying power to DUTs...");
				PowerOn();
				if (bw.CancellationPending) { break; }

				// Configure DUTs.

				// Perform test actions.

				// Close DUTs.

				// Identify passing DUTs.
				_testThread.ReportProgress(95, "Identifying passed DUTS...");
				Thread.Sleep(250); // One second.
			} while (false);

			// Everything between here and the end of the test should be fast
			// and highly reliable since it cannot be cancelled.

			// Calculate end time.
			stopwatch.Stop();
			TimeSpan elapsedtime = stopwatch.Elapsed;

			// Record log.
			_testThread.ReportProgress(95, "Recording log...");
			Thread.Sleep(100); // One second.

			// Close test equipment.
			_testThread.ReportProgress(95, "Closing test equipment...");
			_equipment.Close();
			Thread.Sleep(100); // One second.

			// Done!
			_testThread.ReportProgress(100, "Done.");

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

		/// <summary>
		/// Save user settings (for next time the application runs).
		/// </summary>
		public void SaveSettings()
		{
			Properties.Settings.Default.Save();
		}
	}
}
