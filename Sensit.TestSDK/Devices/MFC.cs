using System;
using System.IO.Ports;                  // serial port access
using Sensit.TestSDK.Calculations;		// define units of measure
using Sensit.TestSDK.Interfaces;        // define control, serial, mass flow interfaces
using Sensit.TestSDK.Exceptions;		// define device exceptions

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Communication driver for Cole-Parmer Mass Flow Controller.
	/// </summary>
	/// <remarks>
	/// Product website:
	/// https://www.coleparmer.com/p/cole-parmer-mass-flow-controllers-for-gas/43456
	/// </remarks>
	public class MFC : IControlDevice, IFlowReference, ISerialDevice
	{
		// port used to communicate with mass flow controller
		private SerialPort _serialPort = new SerialPort();

		// ID used to access device
		private char _address = 'A';

		// units of mass flow (not actually sent to device)
		private UnitOfMeasure.Flow _flowUnit = UnitOfMeasure.Flow.CubicFeetPerMinute;

		// unit of 
		private UnitOfMeasure.Temperature _temperatureUnit = UnitOfMeasure.Temperature.Celsius;

		// Commands sent to the device
		private static class Command
		{
			public static readonly string SetAddress = "*@=";	// set the device address; set polling/streaming mode
			public static readonly string SetSetpoint = "S";	// set the flow setpoint
			public static readonly string ReadRegister = "*R";	// read a register (low-level; not typically used)
			public static readonly string WriteRegister = "*W";	// write a register (low-level; not typically used)
			public static readonly string GasSelect = "$$";		// select gas (for conversion from volume flow to mass flow)
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
			// TODO:  Replace this with a dictionary and use Calculations.Gas!
			Air = 0,
			Ar = 1,						// Argon
			CH4 = 2,					// Methane
			CO = 3,						// Carbon Monoxide
			CO2 = 4,					// Carbon Dioxide
			C2H6 = 5,					// Ethane
			H2 = 6,						// Hydrogen
			He = 7,						// Helium
			N2 = 8,						// Nitrogen
			N2O = 9,					// Nitrous Oxide
			Ne = 10,					// Neon
			O2 = 11,					// Oxygen
			C3H8 = 12,					// Propane
			nC4H10 = 13,				// normal-Butane
			C2H2 = 14,					// Acetylene
			C2H4 = 15,					// Ethylene
			iC4H10 = 16,				// isoButane (code in manual has typo)
			Kr = 17,					// Krypton
			Xe = 18,					// Xenon
			SF6 = 19,					// Sulfur Hexafluoride
			C25 = 20,					// 75% Argon / 25% CO2
			C10 = 21,					// 90% Argon / 10% CO2
			C8 = 22,					// 92% Argon / 8% CO2
			C2 = 23,					// 98% Argon / 2% CO2
			C75 = 24,					// 75% CO2 / 25% Argon
			He25 = 25,					// 75% Argon / 25% Helium (code in manual has typo)
			He75 = 26,					// 75% Helium / 25% Argon (code in manual has typo)
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

		#region Serial Device Methods

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

			// Open the serial port.
			_serialPort.Open();

			// Set polling mode (by assigning a device address).
			Address = 'A';
		}

		public void SetSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
		{
			// This mass flow controller only supports its default settings,
			// so all this method does is throw exceptions if you try to change them.
			if (dataBits != 8)
				throw new DeviceSettingNotSupportedException("The device only supports 8 data bits.");

			if (parity != Parity.None)
				throw new DeviceSettingNotSupportedException("The device does not support parity.");

			if (stopBits != StopBits.One)
				throw new DeviceSettingNotSupportedException("The device only supports one stop bit.");
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

		#endregion

		#region Flow Reference Methods

		public UnitOfMeasure.Flow FlowUnit
		{
			get { return _flowUnit; }
		}

		public UnitOfMeasure.Temperature TemperatureUnit
		{
			get { return _temperatureUnit; }
		}

		public void Config(UnitOfMeasure.Flow flowUnit, UnitOfMeasure.Temperature temperatureUnit,
			double low, double high)
		{
			// TODO:  Ask Cole-Parmer if the device supports setting units of measure over the serial connection.
			throw new NotImplementedException();
		}

		#endregion

		#region Control Device Methods

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
		/// Read the volumetric flow setpoint from the mass flow controller.
		/// </summary>
		/// <returns>active setpoint [SCCM]</returns>
		public float GetSetpoint()
		{
			// Read (when in polling mode) by sending the device address.
			_serialPort.WriteLine(_address.ToString());

			// Read from the serial port (until we get a \r character).
			string message = _serialPort.ReadLine();

			// Split the string using spaces to separate each word.
			char[] separators = new char[] { ' ' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

			return Convert.ToSingle(words[5]);
		}

		#endregion

		/// <summary>
		/// Set gas type (needed for accurate conversion between volumetric and mass flow).
		/// </summary>
		/// <param name="gas">enumerated gas type</param>
		public void SetGas(GasSelection gas)
		{
			string msg = _address + Command.GasSelect + (int)gas;

			// "A$$12" selects propane gas for device A.
			_serialPort.WriteLine(msg);

			// Read the response from the serial port (until we get a \r character).
			string message = _serialPort.ReadLine();

			// Split the string using spaces to separate each word.
			// Remove any "-" characters as they couldn't be used in enumeration names.
			char[] separators = new char[] { ' ' };
			string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
			string gasResult = words[6].Replace("-", String.Empty);

			// Check the gas selection.
			string gasRequest = Enum.GetName(typeof(GasSelection), gas);
			if (string.Compare(gasResult, gasRequest) != 0)
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
				throw new Exception("Incorrect device ID");
			}

			// Figure out which is which.
			pressure = words[1];
			temperature = words[2];
			volumetricFlow = words[3];
			massFlow = words[4];
			setpoint = words[5];
			gas = words[6].Replace("-", String.Empty);
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

		public void SetControlMode(ControlMode mode)
		{
			throw new NotImplementedException();
		}

		public double GetReading()
		{
			throw new NotImplementedException();
		}
	}
}
