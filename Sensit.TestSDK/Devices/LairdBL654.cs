using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Text;
using System.Threading;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Driver for Laird BL654 USB with smartBasic Bluetooth Dongle.
	/// </summary>
	/// <remarks>
	/// The Laird module must be programmed with the application "$autorun$.VSP.UART.bridge.outgoing.sb"
	/// Source code:
	/// https://github.com/LairdCP/BL654-Applications.git
	/// Documentation:
	/// https://www.lairdconnect.com/wireless-modules/bluetooth-modules/bluetooth-5-modules/bl654-series-bluetooth-module-nfc
	/// See also the readme file in the source code repository listed above.
	/// </remarks>
	[DisplayName("Laird BL654")]
	public class LairdBL654 : SerialDevice
	{
		#region Fields

		// Use the line splitter class to parse the Laird module's results.
		private readonly LineSplitter _lineSplitter = new LineSplitter()
		{
			// Laird module separates lines with newline character.
			Delimiter = (byte)'\n',
		};

		#endregion

		#region Properties

		public bool IsOpen => Port.IsOpen;

		public override List<int> SupportedBaudRates { get; } = new List<int> { 115200 };
		public override List<int> SupportedDataBits { get; } = new List<int> { 8 };
		public override List<Parity> SupportedParity { get; } = new List<Parity> { Parity.None };
		public override List<StopBits> SupportedStopBits { get; } = new List<StopBits> { StopBits.One };
		public override List<Handshake> SupportedHandshake { get; } = new List<Handshake> { Handshake.RequestToSend };

		#endregion

		#region Helper Methods

		// When serial data is received, pass it to the line splitter.
		private void DataReceived(object sender, SerialDataReceivedEventArgs e)
		{
			_lineSplitter.OnIncomingBinaryBlock(Encoding.ASCII.GetBytes(Port.ReadExisting()));
		}

		/// <summary>
		/// Transmit a command, wait, then read a response.
		/// </summary>
		/// <param name="command">message to transmit</param>
		/// <param name="delay">time to wait (ms)</param>
		/// <returns></returns>
		private List<string> WriteThenRead(string command, int delay)
		{
			// list of responses from Laird device
			List<string> responses = new List<string>();

			// Local function:  Save responses from the Laird Bluetooth module.
			void LineReceived(byte[] bytes)
			{
				// Convert the bytes into a string
				responses.Add(Encoding.ASCII.GetString(bytes));
			}

			// Clear anything from previous communication.
			Port.DiscardInBuffer();
			_lineSplitter.Clear();

			// Subscribe to event handlers.
			// When serial data is received, call the line scanner.
			// When full lines are received, save them.
			Port.DataReceived += DataReceived;
			_lineSplitter.LineReceived += bytes => LineReceived(bytes);

			// Write the command to the Laird device.
			Port.Write(command);

			// Pause for results to be received.
			Thread.Sleep(delay);

			// Unsubscribe from event handlers.
			// This prevents our return value from being edited after this method returns.
			Port.DataReceived -= DataReceived;
			_lineSplitter.LineReceived -= LineReceived;

			return responses;
		}

		#endregion

		public override void Open()
		{
			try
			{
				// Set serial port settings.
				Port.BaudRate = 115200;
				Port.DataBits = 8;
				Port.Parity = Parity.None;
				Port.StopBits = StopBits.One;
				Port.Handshake = Handshake.RequestToSend;
				Port.ReadTimeout = 500;
				Port.WriteTimeout = 500;

				// Messages are terminated with a line feed and carriage return.
				Port.NewLine = "\n\r";

				// Open the serial port.
				Port.Open();
			}
			catch (SystemException ex)
			{
				throw new DevicePortException("Could not open serial port."
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Find available Bluetooth devices.
		/// </summary>
		/// <remarks>
		/// Note that this is a blocking method.
		/// 
		/// Uses local functions that can be subscribed to and unsubscribed from.
		/// See https://stackoverflow.com/questions/2051357/adding-and-removing-anonymous-event-handler/30763657
		/// for how to add and remove anonymous event handlers.
		/// I did this because otherwise the handler may still receive full lines after this method returns.
		/// If that happens, it will cause an invalid operation exception.
		/// </remarks>
		/// <param name="delay">number of milliseconds to scan before stopping</param>
		/// <returns>a dictionary of detected devices; Key = mac address; Value = device name (if one exists)</returns>
		public SortedDictionary<string, string> Scan(int delay)
		{
			// list of Bluetooth devices found
			SortedDictionary<string, string> bluetoothDevices = new SortedDictionary<string, string>();

			// Local function:  Save full lines that are received.
			void LineReceived(byte[] bytes)
			{
				// Convert the bytes into a string
				string line = Encoding.ASCII.GetString(bytes);

				// Parse the line.
				string[] words = line.Split(new char[] { '"', ':', });

				// Discard any partial lines.
				if (words.Length > 2)
				{
					// Parse the MAC address from signal strength.
					string[] mac = words[1].Split(new char[] { ' ' });

					// If the device has not already been detected...
					if (!bluetoothDevices.ContainsKey(mac[1]))
					{
						// Add to dictionary.
						// Key = mac address; Value = device name (if one exists).
						bluetoothDevices.Add(key: mac[1], value: words[2]);
					}
				}
			}

			// Clear anything from previous communication.
			Port.DiscardInBuffer();
			_lineSplitter.Clear();

			// Subscribe to event handlers.
			// When serial data is received, call the line scanner.
			// When full lines are received, save them.
			Port.DataReceived += DataReceived;
			_lineSplitter.LineReceived += bytes => LineReceived(bytes);

			// Start scanning.
			Port.WriteLine("scan");

			// Pause for results to be received.
			Thread.Sleep(delay);

			// Stop scanning.
			Port.WriteLine("stop");

			// Unsubscribe from event handlers.
			// This prevents our return value from being edited after this method returns.
			Port.DataReceived -= DataReceived;
			_lineSplitter.LineReceived -= LineReceived;

			return bluetoothDevices;
		}

		/// <summary>
		/// Connect to Bluetooth device (and enter "passthrough" mode).
		/// </summary>
		/// <param name="macAddress"></param>
		public void Connect(string macAddress)
		{
			// Tell the Laird module to connect to device with specified mac address.
			List<string> responses = WriteThenRead("connect " + macAddress + "\r\n", 3000);

			// Responses should be "Connected!" "Ready to transmit/receive!" "" "OK"
			if ((responses.Count < 4) ||
				(!responses[0].Equals("Connected!\n")) ||
				(!responses[1].Equals("Ready to transmit/receive!\n")) ||
				(!responses[2].Equals("\n")) ||
				(!responses[3].Equals("OK\n")))
			{
				string response = string.Empty;
				foreach (string s in responses)
				{
					response += s;
				}
				throw new DeviceCommandFailedException("BL654 failed to connect.");
			}
		}

		/// <summary>
		/// Exit "passthrough" mode, then disconnect from the Bluetooth device.
		/// </summary>
		public void Disconnect()
		{
			// Exit passthrough mode.
			WriteThenRead("^", 1000);
			WriteThenRead("^", 1000);
			List<string> responses = WriteThenRead("^", 1000);

			// Responses should be "OK" ">".
			if ((responses.Count < 2) ||
				(!responses[2].Equals("OK\r\n")))
			{
				string response = string.Empty;
				foreach (string s in responses)
				{
					response += s;
				}
				throw new DeviceCommandFailedException("BL654 failed to exit passthrough mode."
					+ Environment.NewLine
					+ "Please unplug the dongle, then reconnect it.");
			}

			// Disconnect from the paired device.
			responses = WriteThenRead("disconnect\r\n", 1000);

			// Responses should be "OK" "Disconnected!".
			if ((responses.Count < 2) ||
				(!responses[1].Equals("OK\n")) ||
				(!responses[2].Equals("Disconnected!\n")) ||
				(!responses[4].Equals("OK\r\n")))
			{
				string response = string.Empty;
				foreach (string s in responses)
				{
					response += s;
				}
				throw new DeviceCommandFailedException("BL654 failed to disconnect.");
			}
		}

		/// <summary>
		/// Transmit a list of bytes, collect responses for 1 second, then return them.
		/// </summary>
		/// <param name="command">list of bytes to transmit</param>
		/// <returns></returns>
		/// <exception cref="DeviceOutOfRangeException"></exception>
		/// <exception cref="DevicePortException"></exception>
		/// <exception cref="DeviceCommunicationException"></exception>
		public List<byte> Write(List<byte> command)
		{
			// return value
			List<byte> response = new List<byte>();

			try
			{
				if (command == null)
				{
					throw new DeviceOutOfRangeException("Command must contain at least one byte.");
				}

				// Write to the serial port.
				Port.Write(command.ToArray(), 0, command.Count);

				// Read from the serial port.
				Thread.Sleep(1000);
				if (Port.BytesToRead != 0)
				{
					byte[] buffer = new byte[Port.BytesToRead];
					Port.Read(buffer, 0, Port.BytesToRead);
					response.AddRange(buffer);
				}

				// Flush the port.
				Port.DiscardInBuffer();
			}
			catch (InvalidOperationException ex)
			{
				throw new DevicePortException("Could not read from serial port."
					+ Environment.NewLine + ex.Message);
			}
			catch (TimeoutException ex)
			{
				throw new DeviceCommunicationException("No response from serial port."
					+ Environment.NewLine + ex.Message);
			}
			catch (Exception ex) when (ex is FormatException || ex is IndexOutOfRangeException)
			{
				throw new DeviceCommunicationException("Invalid response from device."
					+ Environment.NewLine + ex.Message);
			}

			return response;
		}
	}
}
