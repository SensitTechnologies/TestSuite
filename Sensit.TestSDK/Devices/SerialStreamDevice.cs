using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Interface with any device which streams data over a serial port
	/// (as opposed to a device which sends data after a read command).
	/// </summary>
	/// <remarks>
	/// Since we don't know what kind of device this is, we don't know what kind
	/// of data it will send.  So this class is a generic reference device, and
	/// will have a generic variable type which will be accessible as a string.
	/// </remarks>
	public class SerialStreamDevice : SerialDevice, IMessageReference
	{
		#region Reference Device Properties

		public Dictionary<VariableType, double> Readings { get; private set; }

		#endregion

		/// <summary>
		/// This will parse lines received from the serial port using the newline delimiter.
		/// </summary>
		private LineSplitter lineSplitter = new LineSplitter()
		{
			Delimiter = (byte)'\n',
		};

		/// <summary>
		/// Most recent message from the device.
		/// </summary>
		public string Message { get; private set; }

		#region Constructor

		SerialStreamDevice()
		{
			// Subscribe to the message parser's message received event.
			lineSplitter.LineReceived += MessageReceived;

			// Subscribe to serial port's data received event.
			SerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
		}

		#endregion

		/// <summary>
		/// Called when any data bytes are received over the serial port.
		/// </summary>
		/// <remarks>
		/// This method calls the message parser class, which will call the
		/// MessageReceived delegate in this class.
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			int dataLength = SerialPort.BytesToRead;
			byte[] data = new byte[dataLength];
			int nbrDataRead = SerialPort.Read(data, 0, dataLength);
			if (nbrDataRead != 0)
			{
				lineSplitter.OnIncomingBinaryBlock(data);
			}
		}

		/// <summary>
		/// Called when a full message is received and parsed.
		/// </summary>
		/// <param name="buffer">the received message</param>
		void MessageReceived(byte[] buffer)
		{
			// Convert the byte array to a string.
			string converted = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

			// TODO:  Add converted message to Readings.
		}

		#region Reference Device Methods

		public void Read()
		{
			// Nothing to do here; the serial port handles receiving data on its own.
		}

		#endregion

		#region Serial Device Methods

		public override void Open(string portName, int baudRate)
		{
			try
			{
				// Set serial port settings.
				SerialPort.PortName = portName;
				SerialPort.BaudRate = baudRate;
				SerialPort.DataBits = DataBits;
				SerialPort.Parity = Parity;
				SerialPort.StopBits = StopBits;

				// Handshaking is not supported at this time.
				SerialPort.Handshake = Handshake.None;

				// Messages are terminated with a line feed and carriage return.
				SerialPort.NewLine = "\r\n";

				// Open the serial port.
				SerialPort.Open();
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
