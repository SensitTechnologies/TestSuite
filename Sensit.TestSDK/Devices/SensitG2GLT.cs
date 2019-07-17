using System;
using System.Collections.Generic;
using System.IO.Ports;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	public class SensitG2GLT : IGasConcentrationReference
	{
		// Sensit G2-GLT uses two serial ports.  Devices for each port.
		public SensitG2GLTPort ReadPort = new SensitG2GLTPort();
		public SensitG2GLTPort WritePort = new SensitG2GLTPort();

		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; } = UnitOfMeasure.Concentration.PartsPerMillion;

		public Gas GasSelection { get; set; }

		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double>
		{
			{ VariableType.GasConcentration, 0.0 }
		};

		public void Read()
		{
			switch (GasSelection)
			{
				case Gas.Methane:
					// Read from the appropriate sensor.
					WritePort.Write("message");

					break;
				default:
					throw new DeviceSettingNotSupportedException("Gas selection " + GasSelection.ToString() + " is not supported.");
			}

			// Read from the serial port.
			string message = ReadPort.ReadBlocking();
			
			// TODO:  Parse the reading.

		}
	}

	public class SensitG2GLTPort : SerialDevice
	{
		public new int BaudRate
		{
			set
			{
				if ((value != 115200) && (value != 230400))
				{
					throw new DeviceSettingNotSupportedException("The G2-GLT only supports 115200 and 230400 baud.");
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
					throw new DeviceSettingNotSupportedException("The G2-GLT only supports 8 data bits.");
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
					throw new DeviceSettingNotSupportedException("The G2-GLT does not support parity.");
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
					throw new DeviceSettingNotSupportedException("The G2-GLT only supports one stop bit.");
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
		/// <param name="portName">serial port name (i.e. "COM3")</param>
		/// <param name="baudRate">baud rate (115200 and 230400 are supported)</param>
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

				// Messages are terminated with a line feed.

				// Open the serial port.
				_serialPort.Open();
			}
			catch (SystemException ex)
			{
				throw new DevicePortException("Could not open G2-GLT serial port."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void Write(string message)
		{
			_serialPort.Write(message);
		}

		public string ReadBlocking()
		{
			string message = string.Empty;

			try
			{
				// Read from the serial port.
				while (_serialPort.BytesToRead != 0)
				{
					message += _serialPort.ReadExisting();
				}

				// Flush the port.
				_serialPort.DiscardInBuffer();
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from G2-GLT."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from G2-GLT."
					+ Environment.NewLine + ex.Message);
			}

			return message;
		}
	}
}
