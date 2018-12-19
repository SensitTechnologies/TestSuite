using System;
using System.IO.Ports;                  // serial port access

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Communication driver for Cole-Parmer Mass Flow Controller.
	/// </summary>
	/// <remarks>
	/// Product website:
	/// https://www.coleparmer.com/p/cole-parmer-mass-flow-controllers-for-gas/43456
	/// </remarks>
	public class MFC
	{
		// port used to communicate with mass flow controller
		private SerialPort _serialPort = new SerialPort();

		// ID used to access device
		private char _address = 'A';

		// Commands sent to the device
		private static class Command
		{
			public const string SetAddress = "*@=";		// set the device address; set polling/streaming mode
			public const string SetSetpoint = "S";		// set the flow setpoint
			public const string ReadRegister = "*R";	// read a register (low-level; not typically used)
			public const string WriteRegister = "*W";	// write a register (low-level; not typically used)
			public const string GasSelect = "$$";		// select gas (for conversion from volume flow to mass flow)
		}

		/// <summary>
		/// Gas Selection Setting
		/// </summary>
		/// <remarks>
		/// The gas selection is used in the conversion from volume flow to mass flow.
		/// The controller also supports custom gasses, but that functionality is not implemented here.
		/// </remarks>
		public enum GasSelection
		{
			Air = 0,
			Argon = 1,
			Methane = 2,
			CarbonMonoxide = 3,
			CarbonDioxide = 4,
			Ethane = 5,
			Hydrogen = 6,
			Helium = 7,
			Nitrogen = 8,
			NitrousOxide = 9,
			Neon = 10,
			Oxygen = 11,
			Propane = 12,
			normalButane = 13,
			Acetylene = 14,
			Ethylene = 15,
			isoButane = 16,
			Krypton = 17,
			Xenon = 18,
			SulfurHexafluoride = 19,
			C25 = 20,					// 75% Argon / 25% CO2
			C10 = 21,					// 90% Argon / 10% CO2
			C8 = 22,					// 92% Argon / 8% CO2
			C2 = 23,					// 98% Argon / 2% CO2
			C75 = 24,					// 75% CO2 / 25% Argon
			HE75 = 25,					// 75% Argon / 25% Helium
			HE25 = 26,					// 75% Helium / 25% Argon
			A1025 = 27,					// 90% Helium / 7.5% Argon / 2.5% CO2 (Praxair - Helistar® A1025)
			Star29 = 28,				// 90% Argon / 8% CO2 / 2% Oxygen (Praxair - Stargon® CS)
			P5 = 29,					// 95% Argon / 5% Methane
		}

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

				// "*@=A" sets address = A (and puts device into polling mode).
				_serialPort.WriteLine(Command.SetAddress + _address);

				// Read from the serial port (until we get a \r character).
				string message = _serialPort.ReadLine();

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				// Check the address.
				if (string.Compare(words[0], _address.ToString()) != 0)
				{
					throw new Exception("Could not update mass flow controller address.");
				}
			}
		}

		/// <summary>
		/// Open the serial port with the correct settings; set default address (and polling mode).
		/// </summary>
		/// <param name="portName">com port name (i.e. "COM3")</param>
		/// <param name="baudRate">baud rate (9600 and 19200 are supported)</param>
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

			// Messages are terminated with a carriage return.
			_serialPort.NewLine = "\r";

			// Assign a method to handle reading data from the serial port.
			//_serialPort.DataReceived += new SerialDataReceivedEventHandler(_serialPort_DataReceived);

			// Open the serial port.
			_serialPort.Open();

			// Set polling mode (by assigning a device address).
			Address = 'A';
		}

		/// <summary>
		/// Set the volumetric flow setpoint.
		/// </summary>
		/// <param name="setpoint">desired setpoint [SCCM]</param>
		public void SetSetpoint(float setpoint)
		{
			// "AS4.54" = Set setpoint to 4.54 on device A.
			_serialPort.WriteLine(_address + Command.SetSetpoint + setpoint.ToString());

			// Read the response from the serial port (until we get a \r character).
			string message = _serialPort.ReadLine();

			// Split the string using spaces to separate each word.
			char[] separators = new char[] { ' ' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			// Check the setpoint.
			if (Convert.ToSingle(words[5]).Equals(setpoint) == false)
			{
				throw new Exception("Could not write setpoint to mass flow controller.");
			}
		}

		/// <summary>
		/// Set gas type (needed for accurate conversion between volumetric and mass flow).
		/// </summary>
		/// <param name="gas">enumerated gas type</param>
		public void SetGas(GasSelection gas)
		{
			// "A$$12" selects propane gas for device A.
			_serialPort.WriteLine(_address + Command.GasSelect + gas.ToString());

			// Read the response from the serial port (until we get a \r character).
			string message = _serialPort.ReadLine();

			// Split the string using spaces to separate each word.
			char[] separators = new char[] { ' ' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			// Check the gas selection.
			if (string.Compare(words[6], nameof(gas)) != 0)
			{
				throw new Exception("Could not write gas selection to mass flow controller.");
			}
		}

		/// <summary>
		/// Fetch the mass flow controller's current readings/settings.
		/// </summary>
		/// <param name="pressure"></param>
		/// <param name="temperature"></param>
		/// <param name="volumetricFlow"></param>
		/// <param name="massFlow"></param>
		/// <param name="setpoint"></param>
		/// <param name="gas"></param>
		public void Read(out string pressure, out string temperature,
			out string volumetricFlow, out string massFlow,
			out string setpoint, out string gas)
		{
			// Read (when in polling mode) by sending the device address.
			_serialPort.WriteLine(_address.ToString());

			// Read from the serial port (until we get a \r character).
			string message = _serialPort.ReadLine();

			// Split the string using spaces to separate each word.
			char[] separators = new char[] { ' ' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			// Check the address.
			if (string.Compare(words[0], _address.ToString()) != 0)
			{
				throw new Exception("Unexpected device ID");
			}

			// Figure out which is which.
			pressure = words[1];
			temperature = words[2];
			volumetricFlow = words[3];
			massFlow = words[4];
			setpoint = words[5];
			gas = words[6];
		}

		/// <summary>
		/// Enable the mass flow controller's streaming mode.
		/// </summary>
		public void SetStreaming()
		{
			// "*@=@" sets the device into streaming mode.
			_serialPort.WriteLine(Command.SetAddress + '@');

			// TODO:  Validate streaming mode.
		}

		/// <summary>
		/// Close the mass flow controller's serial port (if it's open).
		/// </summary>
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
