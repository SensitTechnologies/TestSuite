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
	/// The serial interface here is just a debug console that is not present
	/// in production firmware.
	/// </remarks>
	public class SensitG3 : SerialDevice, IGasConcentrationReference, IMessageReference
	{
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

		private void WriteToG3(string message)
		{
			try
			{
				// Send command to turn the instrument off.
				SerialPort.WriteLine(message);
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

		public void TurnOff()
		{
			// Send command to turn the instrument off.
			WriteToG3("666");

			// Read from the serial port.
			Thread.Sleep(200);
			string message = string.Empty;
			while (SerialPort.BytesToRead != 0)
			{
				message += SerialPort.ReadExisting();
			}

			// Flush the port.
			SerialPort.DiscardInBuffer();

			// Save the whole string as a message to be logged.
			// Replace any newlines or tabs with spaces to avoid weird log files.
			Message = Regex.Replace(message, @"\t|\n|\r", " ");
		}

		public void Zero()
		{
			// Send command to perform auto-zero.
			WriteToG3("5zz");

			// Read from the serial port.
			Thread.Sleep(200);
			string message = string.Empty;
			while (SerialPort.BytesToRead != 0)
			{
				message += SerialPort.ReadExisting();
			}

			// Flush the port.
			SerialPort.DiscardInBuffer();

			// Save the whole string as a message to be logged.
			// Replace any newlines or tabs with spaces to avoid weird log files.
			Message = Regex.Replace(message, @"\t|\n|\r", " ");
		}

		public void Span()
		{
			try
			{
				// Send command to perform calibration.
				WriteToG3("520");

				// Read from the serial port.
				Thread.Sleep(200);
				string message = string.Empty;
				while (SerialPort.BytesToRead != 0)
				{
					message += SerialPort.ReadExisting();
				}

				// Wait 45 seconds.
				Thread.Sleep(45000);

				// Read from the serial port.
				while (SerialPort.BytesToRead != 0)
				{
					message += SerialPort.ReadExisting();
				}

				// Flush the port.
				SerialPort.DiscardInBuffer();

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
				switch (GasSelection)
				{
					case Gas.Methane:
						// Read from the appropriate sensor.
						SerialPort.WriteLine("5dd");
						break;
					case Gas.Oxygen:
						// Read from the appropriate sensor.
						SerialPort.WriteLine("1dd");
						break;
					case Gas.CarbonMonoxide:
						// Read from the appropriate sensor.
						SerialPort.WriteLine("2dd");
						break;
					case Gas.HydrogenSulfide:
						// Read from the appropriate sensor.
						SerialPort.WriteLine("3dd");
						break;
					case Gas.HydrogenCyanide:
						// Read from the appropriate sensor.
						SerialPort.WriteLine("4dd");
						break;
					default:
						throw new DeviceSettingNotSupportedException("Gas selection " + GasSelection.ToString() + " is not supported.");
				}

				// Read from the serial port.
				Thread.Sleep(200);
				string message = string.Empty;
				while (SerialPort.BytesToRead != 0)
				{
					message += SerialPort.ReadExisting();
				}

				// Flush the port.
				SerialPort.DiscardInBuffer();

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

		#region Serial Device Methods

		public new int BaudRate
		{
			set
			{
				if ((value != 115200))
				{
					throw new DeviceSettingNotSupportedException("The G3 only supports 115200 baud.");
				}

				SerialPort.BaudRate = value;
			}
		}

		public new int DataBits
		{
			set
			{
				if (value != 8)
				{
					throw new DeviceSettingNotSupportedException("The G3 only supports 8 data bits.");
				}

				SerialPort.DataBits = value;
			}
		}

		public new Parity Parity
		{
			set
			{
				if (value != Parity.None)
				{
					throw new DeviceSettingNotSupportedException("The G3 does not support parity.");
				}

				SerialPort.Parity = value;
			}
		}

		public new StopBits StopBits
		{
			set
			{
				if (value != StopBits.One)
				{
					throw new DeviceSettingNotSupportedException("The G3 only supports one stop bit.");
				}

				SerialPort.StopBits = value;
			}
		}

		public override void WriteSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
		{
			// This device only supports its default settings,
			// so there is nothing to do here except update the properties.
			DataBits = dataBits;
			Parity = parity;
			StopBits = stopBits;
		}

		/// <summary>
		/// Open the serial port with the correct settings.
		/// </summary>
		/// <param name="portName">com port name (i.e. "COM3")</param>
		/// <param name="baudRate">baud rate (only 115200 is supported)</param>
		public override void Open(string portName, int baudRate = 115200)
		{
			try
			{
				// Set serial port settings.
				SerialPort.PortName = portName;
				SerialPort.BaudRate = baudRate;
				SerialPort.DataBits = 8;
				SerialPort.Parity = Parity.None;
				SerialPort.StopBits = StopBits.One;
				SerialPort.Handshake = Handshake.None;
				SerialPort.ReadTimeout = 500;
				SerialPort.WriteTimeout = 500;

				// Messages are terminated with a line feed and carriage return.
				SerialPort.NewLine = "\n\r";

				// Open the serial port.
				SerialPort.Open();
			}
			catch (SystemException ex)
			{
				throw new DevicePortException("Could not open G3's serial port."
					+ Environment.NewLine + ex.Message);
			}
		}

		#endregion
	}
}
