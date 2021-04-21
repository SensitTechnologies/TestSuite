using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using CsvHelper;	// TODO:  replace with Sensit.TestSDK.Files
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

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
	public class Dut : IDisposable
	{
		#region Fields

		// settings for the DUT
		private readonly ModelSetting _settings;

		// CSV writer
		StreamWriter _writer;
		CsvWriter _csv;

		// generic manual device, used whenever the user selects "Manual" option for DUTs.
		private Manual _manual;

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

		/// <summary>
		/// Baud rate for serial port (e.g. 9600)
		/// </summary>
		public int CommBaudRate { get; set; } = 9600;

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
				// Connect to serial ports.
				if (_genericSerialDevice != null)
				{
					_genericSerialDevice.Open(CommPort, CommBaudRate);
					_genericSerialDevice.Command = CommPrompt;
				}

				// Set status to "Testing".
				Status = DutStatus.Testing;

				// Update GUI.
				SetStatus(Index, Status);

				// Initialize CSV file writer.
				string filename = SerialNumber + ".csv";
				string fullPath = Path.Combine(Properties.Settings.Default.LogDirectory, filename);
				_writer = new StreamWriter(fullPath, true);
				_csv = new CsvWriter(_writer, CultureInfo.CurrentCulture);
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
			}

			if (Selected)
			{
				// Close serial ports.
				_genericSerialDevice?.Close();
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

				// If the DUT is a generic serial device...
				if (_genericSerialDevice != null)
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
				_csv?.WriteRecords(new List<TestResults> { testResult });

				// Save the result.
				Results.Add(testResult);
			}
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </remarks>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose managed resources.
				_csv?.Dispose();
				_genericSerialDevice?.Dispose();
				_writer?.Dispose();
			}
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1001
		/// </remarks>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
