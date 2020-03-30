using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text.RegularExpressions;
using System.Threading;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Interface with any generic device which can be read from using a serial port.
	/// </summary>
	/// <remarks>
	/// Since we don't know what kind of device this is, we don't know what kind
	/// of data it will send.  So this class is a generic reference device, and
	/// will have a generic variable type which will be accessible as a string.
	/// </remarks>
	public class GenericSerialDevice : SerialDevice, IMessageReference
	{
		public string Command { get; set; } = string.Empty;

		#region Message Device Methods

		// Unused.
		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double> { };

		/// <summary>
		/// Most recent message from the device.
		/// </summary>
		public string Message { get; private set; }

		public void Read()
		{
			try
			{
				// Write to the device.
				// TODO:  Make the command settable from the GUI of any program using this class.
				_serialPort.WriteLine(Command);

				// Read from the serial port.
				Thread.Sleep(200);
				string message = string.Empty;
				while (_serialPort.BytesToRead != 0)
				{
					message += _serialPort.ReadExisting();
				}

				// Flush the port.
				_serialPort.DiscardInBuffer();

				// Save the whole string as a message to be logged.
				// Replace any newlines or tabs with spaces to avoid weird log files.
				Message = Regex.Replace(message, @"\t|\n|\r", " ");
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from Generic Serial Device."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from Generic Serial Device."
					+ Environment.NewLine + ex.Message);
			}
			catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
			{
				throw new DeviceCommunicationException("Invalid response from Generic Serial Device."
					+ Environment.NewLine + ex.Message);
			}
		}

		#endregion

		#region Serial Device Methods

		public override void Open(string portName, int baudRate)
		{
			try
			{
				// Set serial port settings.
				_serialPort.PortName = portName;
				_serialPort.BaudRate = baudRate;
				_serialPort.DataBits = DataBits;
				_serialPort.Parity = Parity;
				_serialPort.StopBits = StopBits;

				// Handshaking is not supported at this time.
				_serialPort.Handshake = Handshake.None;

				// Messages are terminated with a line feed and carriage return.
				_serialPort.NewLine = "\r\n";

				// Open the serial port.
				_serialPort.Open();
			}
			catch (SystemException ex)
			{
				throw new DevicePortException("Could not open streaming device's serial port."
					+ Environment.NewLine + ex.Message);
			}
		}

		public override void WriteSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
		{
			// Since this is a generic device, all settings are supported.
			// So there is nothing to do here except update the properties.
			DataBits = dataBits;
			Parity = parity;
			StopBits = stopBits;
		}

		#endregion
	}
}
