using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
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
		private List<AnalogSensor> _duts;       // devices under test

		private ModelSetting _modelSettings;    // settings for selected model
		private RangeSetting _rangeSettings;    // settings for selected range
		private TestSetting _testSettings;		// settings for selected test

		#region Delegates

		// Report test progress.
		public Action<int, string> Update;

		// Report test results.
		public Action Finished;

		// Update the GUI's list of available ranges (when the selected model changes).
		public Action<List<string>> SetRanges;

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

				// Remember the new setting.
				Properties.Settings.Default.Model = value;

				// Re-populate the ranges available in the GUI.
				SetRanges(Ranges);
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

				// Find each test.
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

			// Fetch product settings (so we can get available models, ranges, tests).
			_settings = Settings.Load<ProductSettings>(Properties.Settings.Default.ProductSettingsFile);
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
		private void DutInitialize()
		{
			// Create a list of DUTs.
			// TODO:  Choose type of DUT based on settings.
			_duts = new List<AnalogSensor>(NumDuts);

			// Keep track of how many DUTs are selected.
			int numSelected = 0;

			// Create each DUT object.
			for (int i = 0; i < NumDuts; i++)
			{
				_duts.Add(new AnalogSensor
				{
					Index = i,
					// TODO:  Get these settings from GUI.
					// Model = "",
					// Version = "",
					Selected = true,
					Status = DutStatus.Init,
					SerialNumber = string.Empty,
					Message = string.Empty,
				});
				numSelected++;
			}

			// Throw exception if no DUTs are selected.
			if (numSelected == 0)
			{
				throw new Exception("You must select at least one DUT.");
			}

			// TODO:  Open DUT ports (if applicable).
			// TODO:  Throw exception is no DUT ports could be opened.
		}

		private void DutOpen()
		{
			foreach (IDeviceUnderTest dut in _duts)
			{
				if (dut.Status == DutStatus.Init)
				{
					// TODO:  Open ports if necessary.

					dut.Status = DutStatus.Found;
				}
			}
		}

		private void DutClose()
		{
			foreach (IDeviceUnderTest dut in _duts)
			{
				if ((dut.Status == DutStatus.Found) ||
					(dut.Status == DutStatus.Fail) ||
					(dut.Status == DutStatus.NotFound))
				{
					// TODO:  Close DUT ports (if applicable).
				}
			}
		}

		private void DutPowerOn()
		{
			// Turn all DUTs on.
			foreach (IDeviceUnderTest dut in _duts)
			{
				if (dut.Status == DutStatus.Found)
				{
					_equipment.DutInterface?.PowerOn(dut.Index);
				}
			}
		}

		private void DutFind()
		{
			// Communicate with each DUT.
			foreach (IDeviceUnderTest dut in _duts)
			{
				if (dut.Status == DutStatus.Found)
				{
					// TODO:  Talk to each DUT to verify communication.

					dut.Status = DutStatus.Found;
				}
			}
		}

		private void DutPowerOff()
		{
			foreach (IDeviceUnderTest dut in _duts)
			{
				// Turn off DUTs that have been found.
				if ((dut.Status != DutStatus.PortError) &&
					(dut.Status != DutStatus.NotFound))
				{
					_equipment.DutInterface?.PowerOff(dut.Index);
				}
			}
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

		private void ReadTestSettings()
		{
			// Read the settings file.
			_settings = Settings.Load<ProductSettings>(Properties.Settings.Default.ProductSettingsFile);

			// Find the selected model settings.
			_modelSettings = _settings.ModelSettings.Find(i => i.Label == SelectedModel);
			if (_modelSettings == null)
			{
				throw new Exception("Model settings not found. Please contact Engineering.");
			}

			// Find the selected range settings.
			_rangeSettings = _modelSettings.RangeSettings.Find(i => i.Label == SelectedRange);
			if (_rangeSettings == null)
			{
				throw new Exception("Range settings not found. Please contact Engineering.");
			}

			// Find the selected test settings.
			_testSettings = _settings.TestSettings.Find(i => i.Label == SelectedTest);
			if (_testSettings == null)
			{
				throw new Exception("Test settings not found. Please contact Engineering.");
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
			// Do not access the form's BackgroundWorker reference directly.
			// Instead, use the reference provided by the sender parameter.
			BackgroundWorker bw = sender as BackgroundWorker;

			// Get start time.
			var stopwatch = Stopwatch.StartNew();

			try
			{
				// Anything within this do-while structure can be cancelled.
				do
				{
					// Read test settings (specific to Model, Range, Test).
					_testThread.ReportProgress(1, "Reading DUT and test settings...");
					ReadTestSettings();
					if (bw.CancellationPending) { break; }

					// Create an object to represent test equipment, and
					// update equipment settings.
					_testThread.ReportProgress(2, "Reading equipment settings...");
					_equipment = new Equipment();
					if (bw.CancellationPending) { break; }

					// Configure test equipment.
					_testThread.ReportProgress(3, "Configuring test equipment...");
					_equipment.Open();
					if (bw.CancellationPending) { break; }

					// Initialize DUTs.
					_testThread.ReportProgress(4, "Initializing DUTs...");
					DutInitialize();
					if (bw.CancellationPending) { break; }

					// TODO:  Configure DUTs (i.e. if there were some default settings or programmable range).

					// Perform test actions.
					foreach (TestCommand cmd in _testSettings.Commands)
					{
						switch (cmd)
						{
							case TestCommand.ColdCal:
								break;
							case TestCommand.HotCal:
								break;
							case TestCommand.NoTempCal:
								break;
							case TestCommand.RoomCal:
								break;
							case TestCommand.SetRange:
								break;
							case TestCommand.SetTemp:
								break;
							case TestCommand.Span:
								break;
							case TestCommand.Verify:
								Verify();
								break;
							case TestCommand.Zero:
								break;
							case TestCommand.Default:
								break;
							default:
								throw new Exception("Unrecognized test command: " + cmd.ToString());
						}
					}

					// Close DUTs.
					_testThread.ReportProgress(5, "Closing DUTs...");
					DutClose();

					// Identify passing DUTs.
					_testThread.ReportProgress(95, "Identifying passed DUTS...");
					Thread.Sleep(250); // One second.
				} while (false);

				// Everything between here and the end of the test should be fast
				// and highly reliable since it cannot be cancelled.

				// Calculate end time.
				stopwatch.Stop();
				TimeSpan elapsedtime = stopwatch.Elapsed;

				// TODO:  Add (continuous) logger support (to CSV for now).
				// Should likely be a logger class in the SDK.

				// Close test equipment.
				_testThread.ReportProgress(95, "Closing test equipment...");
				_equipment.Close();
				Thread.Sleep(100); // One second.
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, ex.GetType().ToString());
			}

			// Done!
			_testThread.ReportProgress(100, "Done.");

			// If the operation was cancelled by the user, set the cancel property.
			if (bw.CancellationPending) { e.Cancel = true; }
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

		/// <summary>
		/// Save user settings (for next time the application runs).
		/// </summary>
		public void SaveSettings()
		{
			// TODO:  Bug:  Settings don't seem to be saved.
			Properties.Settings.Default.Save();
		}
	}
}
