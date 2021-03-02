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
			Port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
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
	}
}
