using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Interface with the Sensit G3 prototypes for reading gas concentration.
	/// </summary>
	/// <remarks>
	/// The serial interface here is a debug console not present in production firmware.
	/// </remarks>
	public class SensitG3 : SerialDevice, IGasMixReference, IMessageReference
	{
		public override List<int> SupportedBaudRates { get; } = new List<int> { 115200 };

		#region Message Device Methods

		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; } = UnitOfMeasure.Concentration.PartsPerMillion;

		public Gas GasSelection { get; set; } = Gas.Methane;

		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double>
		{
			{ VariableType.GasConcentration, 0.0 }
		};

		/// <summary>
		/// Contains the entire (unparsed) response from the G3, which can be logged to a file if desired.
		/// </summary>
		public string Message { get; private set; }

		private string WriteToG3(string message)
		{
			try
			{
				// Send command to instrument.
				Port.WriteLine(message);
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from G3."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from G3."
					+ Environment.NewLine + ex.Message);
			}
			catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
			{
				throw new DeviceCommunicationException("Invalid response from G3."
					+ Environment.NewLine + ex.Message);
			}

			// Read from the serial port.
			Thread.Sleep(200);
			string response = string.Empty;
			while (Port.BytesToRead != 0)
			{
				response += Port.ReadExisting();
			}

			return response;
		}

		public void TurnOff()
		{
			// Send command to turn the instrument off.
			string message = WriteToG3("666");

			// Flush the port.
			Port.DiscardInBuffer();

			// Save the whole string as a message to be logged.
			// Replace any newlines or tabs with spaces to avoid weird log files.
			Message = Regex.Replace(message, @"\t|\n|\r", " ");
		}

		public void Zero()
		{
			// Send command to perform auto-zero.
			string message = WriteToG3("5zz");

			// Flush the port.
			Port.DiscardInBuffer();

			// Save the whole string as a message to be logged.
			// Replace any newlines or tabs with spaces to avoid weird log files.
			Message = Regex.Replace(message, @"\t|\n|\r", " ");
		}

		public void Span()
		{
			try
			{
				// Send command to perform calibration.
				string message = WriteToG3("520");

				// Wait 45 seconds.
				Thread.Sleep(45000);

				// Read from the serial port.
				while (Port.BytesToRead != 0)
				{
					message += Port.ReadExisting();
				}

				// Flush the port.
				Port.DiscardInBuffer();

				// Save the whole string as a message to be logged.
				// Replace any newlines or tabs with spaces to avoid weird log files.
				Message = Regex.Replace(message, @"\t|\n|\r", " ");
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from G3."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from G3."
					+ Environment.NewLine + ex.Message);
			}
			catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
			{
				throw new DeviceCommunicationException("Invalid response from G3."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void Read()
		{
			try
			{
				string message;

				switch (GasSelection)
				{
					case Gas.Methane:
						// Read from the appropriate sensor.
						message = WriteToG3("5dd");
						break;
					case Gas.Oxygen:
						// Read from the appropriate sensor.
						message = WriteToG3("1dd");
						break;
					case Gas.CarbonMonoxide:
						// Read from the appropriate sensor.
						message = WriteToG3("2dd");
						break;
					case Gas.HydrogenSulfide:
						// Read from the appropriate sensor.
						message = WriteToG3("3dd");
						break;
					case Gas.HydrogenCyanide:
						// Read from the appropriate sensor.
						message = WriteToG3("4dd");
						break;
					default:
						throw new DeviceSettingNotSupportedException("Gas selection " + GasSelection.ToString() + " is not supported.");
				}

				// Flush the port.
				Port.DiscardInBuffer();

				// Read TC sensor too.
				message += WriteToG3("TCd");

				// Flush the port.
				Port.DiscardInBuffer();

				// Save the whole string as a message to be logged.
				// Replace any newlines or tabs with spaces to avoid weird log files.
				Message = Regex.Replace(message, @"\t|\n|\r", " ");
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from G3."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from G3."
					+ Environment.NewLine + ex.Message);
			}
			catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
			{
				throw new DeviceCommunicationException("Invalid response from G3."
					+ Environment.NewLine + ex.Message);
			}
		}

		#endregion

		/// <summary>
		/// Open the serial port with the correct settings.
		/// </summary>
		public override void Open()
		{
			try
			{
				// Set serial port settings.
				Port.BaudRate = 115200;
				Port.DataBits = 8;
				Port.Parity = Parity.None;
				Port.StopBits = StopBits.One;
				Port.Handshake = Handshake.None;
				Port.ReadTimeout = 500;
				Port.WriteTimeout = 500;

				// Messages are terminated with a line feed and carriage return.
				Port.NewLine = "\n\r";

				// Open the serial port.
				Port.Open();
			}
			catch (SystemException ex)
			{
				throw new DevicePortException("Could not open G3's serial port."
					+ Environment.NewLine + ex.Message);
			}
		}
	}
}
