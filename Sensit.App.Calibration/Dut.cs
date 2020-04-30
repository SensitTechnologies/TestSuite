using System;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using Sensit.TestSDK.Devices;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;
using System.Threading;

namespace Sensit.App.Calibration
{
	public class TestResults
	{
		public TimeSpan? ElapsedTime { get; set; }
		public double? Setpoint { get; set; }
		public double? Reference { get; set; }
		public double? SensorValue { get; set; }
		public string SensorMessage { get; set; } = string.Empty;
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

		// CSV writer
		StreamWriter writer;
		CsvWriter csv;

		// generic manual device, used whenever the user selects "Manual" option for DUTs.
		private Manual _manual;

		// Sensit G3 device
		private SensitG3 _sensitG3;

		// generic serial device (send a message, get a response)
		private GenericSerialDevice _genericSerialDevice;

		#endregion

		#region Delegates

		// Set DUT status.
		public Action<uint, DutStatus> SetStatus { get; set; }

		// Set DUT serial number.
		public Action<uint, string> SetSerialNumber { get; set; }

		#endregion

		#region Properties

		/// <summary>
		/// Datalogger (for analog sensor DUTs)
		/// </summary>
		public IDatalogger DutInterface { get; set; }

		/// <summary>
		/// Data collected during a test.
		/// </summary>
		/// <remarks>
		/// This is a public property so it can be data bound to the GUI to show to the user.
		/// </remarks>
		public List<TestResults> Results { get; } = new List<TestResults>();

		/// <summary>
		/// DUT's fixture position or channel
		/// </summary>
		public uint Index { get; set; }

		/// <summary>
		/// true if under test; false if idle
		/// </summary>
		public bool Selected { get; set; }

		/// <summary>
		/// DUT status (pass, fail, etc.) to be added to the log
		/// </summary>
		public DutStatus Status { get; set; }

		/// <summary>
		/// DUT's unique identification number
		/// </summary>
		public string SerialNumber { get; set; }

		/// <summary>
		/// A message from the calibration program to be added to the log
		/// </summary>
		public string StatusMessage { get; set; }

		/// <summary>
		/// Type of DUT
		/// </summary>
		public string Type => _settings.Label;

		/// <summary>
		/// Serial port used for communication (e.g. "COM3")
		/// </summary>
		public string CommPort { get; set; }

		/// <summary>
		/// Prompt sent to the DUT to read from it.
		/// </summary>
		public string CommPrompt { get; set; }

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="settings">applicable settings</param>
		public Dut(ModelSetting settings)
		{
			_settings = settings;

			// Create DUT object.
			// Only the one chosen by the user will end up being used.
			switch (settings?.Label)
			{
				// Analog sensors use the DUT Interface device from the
				// Equipment class, so we need do nothing here.
				case "Datalogger":
					break;

				// Create a Sensit G3 console device.
				case "Sensit G3":
					_sensitG3 = new SensitG3();
					break;

				// Create a new generic serial device.
				case "Serial Device":
					_genericSerialDevice = new GenericSerialDevice();
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
				// If the DUT uses a datalogger...
				if ((_settings?.Label == "Datalogger") && (DutInterface != null))
				{
					// Configure DUT Interface device.
					DutInterface.Channels[(int)Index - 1] = Selected;
				}

				// Connect to serial ports.
				// TODO:  Make baud rate some sort of option.
				_sensitG3?.Open(CommPort);

				if (_genericSerialDevice != null)
				{
					_genericSerialDevice.WriteSerialProperties();
					_genericSerialDevice.Open(CommPort, 9600);
					_genericSerialDevice.Command = CommPrompt;
				}

				// Set status to "Testing".
				Status = DutStatus.Testing;

				// Update GUI.
				SetStatus(Index, Status);

				// Initialize CSV file writer.
				string filename = SerialNumber + ".csv";
				string fullPath = Path.Combine(Properties.Settings.Default.LogDirectory, filename);
				writer = new StreamWriter(fullPath, true);
				csv = new CsvWriter(writer);
			}
		}

		public void Close()
		{
			if ((Status == DutStatus.Testing) ||
				(Status == DutStatus.Fail))
			{
				// Turn DUT off.  Should I keep this here?
				TurnOff();

				// Set status to "Done."
				Status = DutStatus.Done;

				// Update GUI.
				SetStatus(Index, Status);
			}

			if (Selected)
			{
				// Close serial ports.
				_sensitG3?.Close();
				_genericSerialDevice?.Close();
			}
		}

		public void Dispose()
		{
			// Dispose of the CSV writer if it is not null.
			csv?.Dispose();
			writer?.Dispose();

			// Free the references.
			csv = null;
			writer = null;
		}

		public void TurnOff()
		{
			// If the DUT is a G3...
			if (_sensitG3 != null)
			{
				// Turn it off.
				_sensitG3.TurnOff();

				// Format data from device.
				var testResult = new TestResults
				{
					ElapsedTime = new TimeSpan(),
					Setpoint = 0.0,
					Reference = 0.0,
					SensorValue = _sensitG3.Readings[VariableType.GasConcentration],
					SensorMessage = _sensitG3.Message,
				};

				// Save test results to csv file.
				csv?.WriteRecords(new List<TestResults> { testResult });

				// Save the result.
				Results.Add(testResult);

				// Wait 15 seconds to ensure it has time to purge gas.
				Thread.Sleep(new TimeSpan(0, 0, 15));
			}
		}

		public void Zero()
		{
			// If the DUT is a G3...
			if (_sensitG3 != null)
			{
				// Perform auto-zero.
				_sensitG3.Zero();

				// Format data from device.
				var testResult = new TestResults
				{
					ElapsedTime = new TimeSpan(),
					Setpoint = 0.0,
					Reference = 0.0,
					SensorValue = _sensitG3.Readings[VariableType.GasConcentration],
					SensorMessage = _sensitG3.Message,
				};

				// Save test results to csv file.
				csv?.WriteRecords(new List<TestResults> { testResult });

				// Save the result.
				Results.Add(testResult);
			}
		}

		public void Span()
		{
			// If the DUT is a G3...
			if (_sensitG3 != null)
			{
				// Perform span calibration.
				_sensitG3.Span();

				// Format data from device.
				var testResult = new TestResults
				{
					ElapsedTime = new TimeSpan(),
					Setpoint = 0.0,
					Reference = 0.0,
					SensorValue = _sensitG3.Readings[VariableType.GasConcentration],
					SensorMessage = _sensitG3.Message,
				};

				// Save test results to csv file.
				csv?.WriteRecords(new List<TestResults> { testResult });

				// Save the result.
				Results.Add(testResult);
			}
		}

		public void Read(TimeSpan elapsedTime, double setpoint, double reference)
		{
			// Only process found or failed DUTs.
			if ((Status == DutStatus.Testing) ||
				(Status == DutStatus.Fail))
			{
				double reading = 0.0;
				string message = string.Empty;

				// If the DUT uses a datalogger...
				if ((_settings?.Label == "Datalogger") && (DutInterface != null))
				{
					reading = DutInterface.Readings[Index];
				}
				// If the DUT is a G3...
				else if (_sensitG3 != null)
				{
					_sensitG3.Read();

					reading = _sensitG3.Readings[VariableType.GasConcentration];
					message = _sensitG3.Message;
				}
				// If the DUT is a generic serial device...
				else if (_genericSerialDevice != null)
				{
					_genericSerialDevice.Read();

					message = _genericSerialDevice.Message;
				}
				// If the DUT is a "manual" device...
				else if (_manual != null)
				{
					_manual.Read();

					reading = _manual.Readings[VariableType.GasConcentration];
				}

				// Format data from device.
				var testResult = new TestResults
				{
					ElapsedTime = elapsedTime,
					Setpoint = setpoint,
					Reference = reference,
					SensorValue = reading,
					SensorMessage = message,
				};

				// Save test results to csv file.
				csv?.WriteRecords(new List<TestResults> { testResult });

				// Save the result.
				Results.Add(testResult);
			}
		}
	}
}
