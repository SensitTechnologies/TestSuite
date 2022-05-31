using System;
using System.Collections.Generic;
using System.ComponentModel;
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
	[DisplayName("Generic Serial Device")]
	public class GenericSerialDevice : SerialDevice, IDevice
	{
		public string Command { get; set; } = string.Empty;

		// generic device supports all common settings
		public override List<int> SupportedBaudRates { get; } = new List<int> { 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };
		public override List<int> SupportedDataBits { get; } = new List<int> { 5, 6, 7, 8 };
		public override List<Parity> SupportedParity { get; } = new List<Parity> { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
		public override List<StopBits> SupportedStopBits { get; } = new List<StopBits> { StopBits.None, StopBits.One, StopBits.Two, StopBits.OnePointFive };
		public override List<Handshake> SupportedHandshake { get; } = new List<Handshake> { Handshake.None, Handshake.XOnXOff, Handshake.RequestToSend, Handshake.RequestToSendXOnXOff };

		// This dictionary is purposefully empty so software knows this device does not support any readings.
		public Dictionary<VariableType, decimal> Readings { get; } = new Dictionary<VariableType, decimal>();

		// This device type has no supported setpoints.
		public Dictionary<VariableType, decimal> Setpoints { get; } = new Dictionary<VariableType, decimal> { };

		/// <summary>
		/// Most recent message from the device.
		/// </summary>
		public string Message { get; private set; }

		public void WriteThenRead()
		{
			try
			{
				// Write to the device.
				Port.Write(Command);

				// Read from the serial port.
				Thread.Sleep(200);
				string message = string.Empty;
				while (Port.BytesToRead != 0)
				{
					message += Port.ReadExisting();
				}

				// Flush the port.
				Port.DiscardInBuffer();

				// Save the whole string as a message to be logged.
				// Replace any newlines or tabs with spaces to avoid weird log files.
				// http://net-informations.com/q/faq/newline.html
				Message = Regex.Replace(message, @"\t|\n|\r", " ");
				Message = Message.Trim();
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

		public void WriteThenRead(string command)
		{
			Command = command;

			WriteThenRead();
		}

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void Write(VariableType variable, decimal value)
		{
			// Nothing to do here.
		}
	}
}
