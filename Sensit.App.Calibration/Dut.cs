using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Sensit.TestSDK.Dut;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	public class TestResults
	{
		public TimeSpan? ElapsedTime { get; set; }
		public double? Setpoint { get; set; }
		public double? Reference { get; set; }
		public double? SensorValue { get; set; }
	}

	/// <summary>
	/// Manage devices under test.
	/// </summary>
	/// <remarks>
	/// Similarly to the Equipment class, we have the ability to create any type
	/// of DUT, and then we pass the selected type to the user for each needed
	/// interface.
	/// </remarks>
	public class Dut
	{
		// settings for the DUT
		private ModelSetting _settings;

		// used when the user selects "Simulator" option for DUTs.
		private Simulator _simulator;

		// analog sensor device
		private AnalogSensor _analogSensor;

		#region Delegates

		// Set DUT status.
		public Action<uint, DutStatus> SetStatus;

		// Set DUT serial number.
		public Action<uint, string> SetSerialNumber;

		#endregion

		#region Properties

		/// <summary>
		/// Data collected during a test.
		/// </summary>
		public List<TestResults> Results { get; set; } = new List<TestResults>();

		/// <summary>
		/// Type of device under test.
		/// </summary>
		public IDeviceUnderTest Device { get; private set; }

		#endregion

		#region Constructor

		public Dut(ModelSetting settings)
		{
			_settings = settings;

			// Create DUT object.
			// Only the one chosen by the user will end up being used.
			switch (settings.Label)
			{
				case "Simulator":
					_simulator = new Simulator();
					Device = _simulator;
					break;
				default:
					_analogSensor = new AnalogSensor();
					Device = _analogSensor;
					break;
			}
		}

		#endregion

		public void Open()
		{
			if (Device.Selected == true)
			{
				// Set status to "Found".
				Device.Status = DutStatus.Found;

				// Update GUI.
				SetStatus(Device.Index, Device.Status);
			}
		}

		public void Close()
		{
			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail))
			{
				// Set status to Pass.
				Device.Status = DutStatus.Pass;

				// Update GUI.
				SetStatus(Device.Index, Device.Status);

				// Save test results to csv file.
				string filename = "DUT" + Device.Index + "Results.csv";
				string fullPath = Path.Combine(Properties.Settings.Default.LogDirectory, filename);
				using (var writer = new StreamWriter(fullPath, true))
				using (var csv = new CsvWriter(writer))
				{
					csv.WriteRecords(Results);
				}
			}
		}

		public void ComputeCoefficients()
		{
			// Only process found or failed DUTs.
			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail))
			Device.ComputeCoefficients();
		}
	}
}
