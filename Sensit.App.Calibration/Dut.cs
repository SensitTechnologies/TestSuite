using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Sensit.TestSDK.Devices;
using System.ComponentModel;
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

	public enum DutStatus
	{
		[Description("")]
		Init,
		Testing,
		[Description("Not Found")]
		NotFound,
		[Description("Port Error")]
		PortError,
		Fail,
		Done
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
		#region Fields

		// settings for the DUT
		private readonly ModelSetting _settings;

		// generic manual device, used whenever the user selects "Manual" option for DUTs.
		private Manual _manual;

		// Sensit G3 device
		private SensitG3 _sensitG3;

		#endregion

		#region Delegates

		// Set DUT status.
		public Action<uint, DutStatus> SetStatus;

		// Set DUT serial number.
		public Action<uint, string> SetSerialNumber;

		#endregion

		#region Properties
		/// <summary>
		/// Datalogger (for analog sensor DUTs)
		/// </summary>
		public IDutInterfaceDevice DutInterface { get; set; }

		/// <summary>
		/// Data collected during a test.
		/// </summary>
		public List<TestResults> Results { get; set; } = new List<TestResults>();

		/// <summary>
		/// DUT's fixture position or channel
		/// </summary>
		public uint Index { get; set; }

		/// <summary>
		/// true if under test; false if idle
		/// </summary>
		public bool Selected { get; set; }

		/// <summary>
		/// DUT status (pass, fail, etc.)
		/// </summary>
		public DutStatus Status { get; set; }

		/// <summary>
		/// DUT's unique identification number
		/// </summary>
		public string SerialNumber { get; set; }

		/// <summary>
		/// A message to be added to the log
		/// </summary>
		public string Message { get; set; }

		#endregion

		#region Constructor

		public Dut(ModelSetting settings)
		{
			_settings = settings;

			// Create DUT object.
			// Only the one chosen by the user will end up being used.
			switch (settings.Label)
			{
				// Analog sensors use the DUT Interface device from the
				// Equipment class, so we need do nothing here.
				case "Analog Sensor":
					break;

				// Create a Sensit G3 console device.
				case "Sensit G3":
					_sensitG3 = new SensitG3();
					break;

				// "Manual" DUTs require an object that will prompt the user.
				// If the DUT type is not recognized, assume it's this type.
				case "Manual":
				default:
					_manual = new Manual();
					break;
			}
		}

		#endregion

		public void Open()
		{
			// If the DUT has been enabled by the user...
			if (Selected)
			{
				// If the DUT is an analog sensor (a.k.a. uses a datalogger)...
				if ((_settings.Label == "Analog Sensor") && (DutInterface != null))
				{
					// Configure DUT Interface device.
					DutInterface.Channels[(int)Index - 1] = Selected;
				}
				// If the DUT is a G3...
				else if (_sensitG3 != null)
				{
					// Connect to it.
					_sensitG3.Open("COM11");
				}

				// Set status to "Testing".
				Status = DutStatus.Testing;

				// Update GUI.
				SetStatus(Index, Status);
			}
		}

		public void Close()
		{
			if ((Status == DutStatus.Testing) ||
				(Status == DutStatus.Fail))
			{
				// Set status to "Done."
				Status = DutStatus.Done;

				// Update GUI.
				SetStatus(Index, Status);

				// Save test results to csv file.
				string filename = SerialNumber + ".csv";
				string fullPath = Path.Combine(Properties.Settings.Default.LogDirectory, filename);
				using (var writer = new StreamWriter(fullPath, true))
				using (var csv = new CsvWriter(writer))
				{
					csv.WriteRecords(Results);
				}
			}
		}

		public void Read(TimeSpan elapsedTime, double setpoint, double reference)
		{
			// Only process found or failed DUTs.
			if ((Status == DutStatus.Testing) ||
				(Status == DutStatus.Fail))
			{
				double reading = 0.0;

				// If the DUT is an analog sensor (a.k.a. uses a datalogger)...
				if ((_settings.Label == "Analog Sensor") && (DutInterface != null))
				{
					reading = DutInterface.Readings[Index];
				}
				// If the DUT is a G3...
				else if (_sensitG3 != null)
				{
					_sensitG3.Read();

					reading = _sensitG3.Readings[VariableType.GasConcentration];
				}
				// If the DUT is a "manual" device...
				else if (_manual != null)
				{
					_manual.Read();

					reading = _manual.Readings[VariableType.GasConcentration];
				}

				// Save the result.
				Results.Add(new TestResults
				{
					ElapsedTime = elapsedTime,
					Setpoint = setpoint,
					Reference = reference,
					SensorValue = reading
				});
			}
		}
	}
}
