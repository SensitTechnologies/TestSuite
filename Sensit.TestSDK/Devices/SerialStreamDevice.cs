using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using Sensit.TestSDK.Communication;
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
	[DisplayName("Serial Stream Device")]
	public class SerialStreamDevice : SerialDevice
	{
		// generic device supports all common settings
		public override List<int> SupportedBaudRates { get; } = new List<int> { 300, 600, 1200, 2400, 4800, 9600, 19200, 38400, 57600, 115200, 230400, 460800, 921600 };
		public override List<int> SupportedDataBits { get; } = new List<int> { 5, 6, 7, 8 };
		public override List<Parity> SupportedParity { get; } = new List<Parity> { Parity.None, Parity.Odd, Parity.Even, Parity.Mark, Parity.Space };
		public override List<StopBits> SupportedStopBits { get; } = new List<StopBits> { StopBits.None, StopBits.One, StopBits.Two, StopBits.OnePointFive };
		public override List<Handshake> SupportedHandshake { get; } = new List<Handshake> { Handshake.None, Handshake.XOnXOff, Handshake.RequestToSend, Handshake.RequestToSendXOnXOff };

		#region Delegates

		/// <summary>
		/// Notify the user that a message has been received.
		/// </summary>
		public Action<string> MessageReceived { get; set; }

		#endregion

		/// <summary>
		/// This will parse lines received from the serial port using the newline delimiter.
		/// </summary>
		private readonly LineSplitter lineSplitter = new()
		{
			Delimiter = (byte)'\n',
		};

		public SerialStreamDevice()
		{
			// Subscribe to the message parser's message received event.
			lineSplitter.LineReceived += LineReceived;

			// Subscribe to serial port's data received event.
			Port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
		}

		/// <summary>
		/// Called when any data bytes are received over the serial port.
		/// </summary>
		/// <remarks>
		/// This method calls the message parser class, which will call the
		/// MessageReceived delegate in this class.
		/// </remarks>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			int dataLength = Port.BytesToRead;
			byte[] data = new byte[dataLength];
			int nbrDataRead = Port.Read(data, 0, dataLength);
			if (nbrDataRead != 0)
			{
				lineSplitter.OnIncomingBinaryBlock(data);
			}
		}

		/// <summary>
		/// Called when a full message is received and parsed.
		/// </summary>
		/// <param name="buffer">the received message</param>
		private void LineReceived(byte[] buffer)
		{
			// Convert the byte array to a string.
			string message = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

			// Notify the user that a message has been received.
			// Run actions required when test is completed (i.e. update GUI).
			MessageReceived?.Invoke(message);
		}
	}
}
