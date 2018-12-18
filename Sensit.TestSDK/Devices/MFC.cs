using System.IO.Ports;                  // serial port access
using System.Threading;

namespace Sensit.TestSDK.Devices
{
	public class MFC
	{
		// Commands sent to the device
		private static class Command
		{
			public const string SetAddress = "*@=";
			public const string SetSetpoint = "S";
			public const string ReadRegister = "*R";
			public const string WriteRegister = "*W";
			public const string GasSelect = "SS";
		}

		/// <summary>
		/// Gas Selection Setting
		/// </summary>
		public enum GasSelection
		{
			Air = 0,
			Argon = 1,
			Methane = 2,
			CarbonMonoxide = 3,
			// TODO:  fill in the rest of the gasses
		}

		// port used to communicate with mass flow controller
		private SerialPort _serialPort = new SerialPort();

		// ID used to access device
		private char _address = 'A';

		/// <summary>
		/// Specifier for a specific device on the serial port
		/// </summary>
		/// <remarks>
		/// Must be set when no other devices are on the bus, or it will
		/// affect all devices at the same time.
		/// </remarks>
		public char Address
		{
			get { return _address; }
			set
			{
				_address = value;

				// "@=A" sets address = A (and puts device into polling mode).
				_serialPort.WriteLine(Command.SetAddress + _address);
			}
		}

		public void Open(string portName, int baudRate = 19200)
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
			_serialPort.NewLine = "\n";

			// Assign a method to handle reading data from the serial port.
			//_serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

			// Open the serial port.
			_serialPort.Open();

			// Set polling mode (by assigning a device address).
			Address = 'A';
		}

		public void SetStreaming()
		{
			// "@=@" sets the device into streaming mode.
			_serialPort.WriteLine(Command.SetAddress + '@');
		}

		public void SetSetpoint(float setpoint)
		{
			// "AS4.54" = Set setpoint to 4.54.
			//_serialPort.WriteLine(_address + Command.SetSetpoint + setpoint.ToString());
			_serialPort.Write("AS0.0" + _serialPort.NewLine);
		}

		public void SetGas(GasSelection gas)
		{
			_serialPort.WriteLine(_address + Command.GasSelect + gas);
		}

		public string Read()
		{
			// Read (when in polling mode) by sending the device address.
			_serialPort.WriteLine(_address.ToString());

			// Pause a bit.
			Thread.Sleep(500);

			char[] buffer = new char[10];

			// Read from the serial port.
			_serialPort.Read(buffer, 0, 10);

			return buffer.ToString();
		}

		public void Close()
		{
			// If the serial port is open, close it.
			if (_serialPort.IsOpen)
			{
				_serialPort.Close();
			}
		}
	}
}
