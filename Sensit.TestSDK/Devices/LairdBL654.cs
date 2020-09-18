using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Structure representing a Bluetooth device, containing info needed to connect to it.
	/// </summary>
	public struct BluetoothDevice : IEquatable<BluetoothDevice>
	{
		public string MacAddress { get; set; }

		public string Name { get; set; }

		public override bool Equals(object obj)
		{
			return obj is BluetoothDevice && Equals((BluetoothDevice)obj);
		}

		public bool Equals(BluetoothDevice other)
		{
			return MacAddress == other.MacAddress;
		}

		public static bool operator ==(BluetoothDevice left, BluetoothDevice right)
		{
			return left.Equals(right);
		}

		public static bool operator !=(BluetoothDevice left, BluetoothDevice right)
		{
			return !(left == right);
		}

		/// <summary>
		/// Generate a hash code (in case we ever put Bluetooth devices in a hash table).
		/// </summary>
		/// <remarks>
		/// Visual Studio suggested this be implemented.  See here:
		/// https://stackoverflow.com/questions/7425142/what-is-hashcode-used-for-is-it-unique/35217051
		/// </remarks>
		/// <returns></returns>
		public override int GetHashCode()
		{
			int hashCode = 257514462;
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MacAddress);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
			return hashCode;
		}
	}

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

		#endregion

		public override void Open(string portName, int baudRate = 115200)
		{
			try
			{
				// Set serial port settings.
				Port.PortName = portName;
				Port.BaudRate = baudRate;
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

		public override void WriteSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
		{
			// This device only supports its default settings,
			// so there is nothing to do here except update the properties.
			DataBits = dataBits;
			Parity = parity;
			StopBits = stopBits;
		}

		/// <summary>
		/// Find available Bluetooth devices.
		/// </summary>
		/// <remarks>
		/// Uses a local function that can be subscribed to and unsubscribed from.
		/// See https://stackoverflow.com/questions/2051357/adding-and-removing-anonymous-event-handler/30763657
		/// for how to add and remove anonymous event handlers.
		/// I did this because otherwise the handler may still receive full lines after this method returns.
		/// If that happens, it will cause an invalid operation exception.
		/// </remarks>
		/// <param name="seconds"></param>
		/// <returns></returns>
		public List<BluetoothDevice> Scan(int seconds)
		{
			// list of Bluetooth devices found
			List<BluetoothDevice> results = new List<BluetoothDevice>();

			// Local function:  When serial data is received, pass it to the line splitter.
			void ScanDataReceived(object sender, SerialDataReceivedEventArgs e)
			{
				_lineSplitter.OnIncomingBinaryBlock(Encoding.ASCII.GetBytes(Port.ReadExisting()));
			}

			// Local function:  Save full lines that are received.
			void SaveFullLines(byte[] bytes)
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

					BluetoothDevice device = new BluetoothDevice()
					{
						MacAddress = mac[1],
						Name = words[2]
					};

					results.Add(device);
				}
			}

			// Subscribe to event handlers.
			// When serial data is received, call the line scanner.
			// When full lines are received, save them.
			Port.DataReceived += ScanDataReceived;
			_lineSplitter.LineReceived += bytes => SaveFullLines(bytes);

			// Start scanning.
			Port.WriteLine("scan");

			// Pause for results to be received.
			while (seconds > 0)
			{
				Thread.Sleep(1000);

				seconds--;
			}

			// Stop scanning.
			Port.WriteLine("stop");

			// Unsubscribe from event handlers.
			// This prevents our return value from being edited after this method returns.
			Port.DataReceived -= ScanDataReceived;
			_lineSplitter.LineReceived -= SaveFullLines;

			// Remove duplicate results.
			results = results.Distinct().ToList();

			return results;
		}

		public string Write(string command)
		{
			// return value
			string response = string.Empty;

			try
			{
				// Write to the serial port.
				Port.WriteLine(command);

				// Read from the serial port.
				Thread.Sleep(200);
				string message = string.Empty;
				while (Port.BytesToRead != 0)
				{
					message += Port.ReadExisting();
				}

				// Flush the port.
				Port.DiscardInBuffer();
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

			return response;
		}
	}
}
