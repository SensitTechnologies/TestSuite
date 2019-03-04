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
		//public double? Error { get; set; }
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
		private ModelSetting _settings;
		private Equipment _equipment;

		// used when the user selects "Simulator" option for DUTs.
		private Simulator _simulator;

		// analog sensor device
		private AnalogSensor _analogSensor;

		#region Delegates

		// Set DUT status.
		public Action<int, DutStatus> SetStatus;

		// Set DUT serial number.
		public Action<int, string> SetSerialNumber;

		// Get test's elapsed time.
		public Func<TimeSpan?> GetElapsedTime;

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

		public Dut(ModelSetting settings, Equipment equipment)
		{
			_settings = settings;
			_equipment = equipment;

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

		public void Open()
		{
			if (Device.Selected == true)
			{
				_equipment?.DutInterface?.PowerOn(Device.Index);

				// TODO:  (Low priority) Open DUT ports (if applicable); throw exception is no DUT ports could be opened.
				// TODO:  (Low priority) Talk to each DUT to verify communication.
				// If communication succeeds, set status to "Found".
				Device.Status = DutStatus.Found;

				// Update GUI.
				SetStatus(Device.Index, Device.Status);
			}
		}

		public void Close()
		{
			// Turn off DUTs that have been found, passed, failed.
			if ((Device.Status != DutStatus.PortError) &&
				(Device.Status != DutStatus.NotFound))
			{
				_equipment?.DutInterface?.PowerOff(Device.Index);
			}

			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail) ||
				(Device.Status == DutStatus.NotFound))
			{
				// TODO:  (Low priority) Close DUT ports (if applicable).
			}

			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail))
			{
				// TODO:  Identify passing DUTs.
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

		public void Read(double setpoint, double errorTolerance)
		{
			// Only process found or failed DUTs.
			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail))
			{
				// Get reference reading.
				double gasMix = _equipment.References[VariableType.GasConcentration].Read(VariableType.GasConcentration);

				// Calculate error.
				double error = gasMix - setpoint;

				// Check tolerance.
				if (Math.Abs(error) > errorTolerance)
				{
					// TODO:  Log an error, "Reference out of tolerance during DUT Read."

					// Mark DUT as failed.
					Device.Status = DutStatus.Fail;

					// Update GUI.
					SetStatus(Device.Index, Device.Status);
				}

				// Read value from DUT.
				double? dutValue = _equipment?.DutInterface?.ReadAnalog(Device.Index);

				// Save the result.
				Results.Add(new TestResults
				{
					ElapsedTime = GetElapsedTime(),
					Setpoint = setpoint,
					Reference = gasMix,
					SensorValue = dutValue
				});
			}
		}

		public void ComputeCoefficients()
		{
			// Only process found or failed DUTs.
			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail))
			Device.ComputeCoefficients();
		}

		#endregion
	}
}
