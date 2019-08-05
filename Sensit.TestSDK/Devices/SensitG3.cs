using System;
using System.Collections.Generic;
using System.IO.Ports;
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
	public class SensitG3 : SerialDevice, IGasConcentrationReference
	{
		#region Reference Device Methods

		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; } = UnitOfMeasure.Concentration.PartsPerMillion;

		public Gas GasSelection { get; set; } = Gas.Methane;

		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double>
		{
			{ VariableType.GasConcentration, 0.0 }
		};

		public void Read()
		{
			try
			{
				switch (GasSelection)
				{
					case Gas.Methane:
						// Read from the appropriate sensor.
						_serialPort.Write("1dd");
						break;
					case Gas.Oxygen:
						// Read from the appropriate sensor.
						_serialPort.Write("2dd");
						break;
					case Gas.CarbonMonoxide:
						// Read from the appropriate sensor.
						_serialPort.Write("3dd");
						break;
					case Gas.HydrogenSulfide:
						// Read from the appropriate sensor.
						_serialPort.Write("4dd");
						break;
					case Gas.HydrogenCyanide:
						// Read from the appropriate sensor.
						_serialPort.Write("5dd");
						break;
					default:
						throw new DeviceSettingNotSupportedException("Gas selection " + GasSelection.ToString() + " is not supported.");
				}

				// Read from the serial port.
				Thread.Sleep(200);
				string message = string.Empty;
				while (_serialPort.BytesToRead != 0)
				{
					message += _serialPort.ReadExisting();
				}

				// Flush the port.
				_serialPort.DiscardInBuffer();

				// Parse the string.
				string[] words = message.Split(' ');

				// Parse the reading.
				Readings[VariableType.GasConcentration] = Convert.ToDouble(words[4]);
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

				_serialPort.BaudRate = value;
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

				_serialPort.DataBits = value;
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

				_serialPort.Parity = value;
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

				_serialPort.StopBits = value;
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
				_serialPort.PortName = portName;
				_serialPort.BaudRate = baudRate;
				_serialPort.DataBits = 8;
				_serialPort.Parity = Parity.None;
				_serialPort.StopBits = StopBits.One;
				_serialPort.Handshake = Handshake.None;
				_serialPort.ReadTimeout = 500;
				_serialPort.WriteTimeout = 500;

				// Messages are terminated with a line feed and carriage return.
				_serialPort.NewLine = "\n\r";

				// Open the serial port.
				_serialPort.Open();
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
