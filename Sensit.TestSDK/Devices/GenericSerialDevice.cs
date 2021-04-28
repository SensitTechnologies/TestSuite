using System;
using System.Collections.Generic;
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
	public class GenericSerialDevice : SerialDevice, IMessageDevice
	{
		public string Command { get; set; } = string.Empty;

		/// <summary>
		/// List of supported baud rates
		/// </summary>
		public override List<int> SupportedBaudRates { get; } = new List<int> { 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };

		// This device type has no supported readings.
		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double> { };

		// This device type has no supported setpoints.
		public Dictionary<VariableType, double> Setpoints { get; } = new Dictionary<VariableType, double> { };

		/// <summary>
		/// Most recent message from the device.
		/// </summary>
		public string Message { get; private set; }

		public void Read()
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

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void Write()
		{
			// Nothing to do here.
		}
	}
}
