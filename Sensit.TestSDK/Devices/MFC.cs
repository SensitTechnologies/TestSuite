using System;
using System.IO.Ports;                  // serial port access
using Sensit.TestSDK.Calculations;		// define units of measure
using Sensit.TestSDK.Interfaces;        // define control, serial, mass flow interfaces
using Sensit.TestSDK.Exceptions;		// define device exceptions
using System.Collections.Generic;		// dictionary

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

		// unit of temperature
		private UnitOfMeasure.Temperature _temperatureUnit = UnitOfMeasure.Temperature.Celsius;

		// gas used by device to calculate mass flow from volumetric flow
		private Gas _gasSelection = Gas.Air;

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

		public Gas GasSelection
		{
			get { return _gasSelection; }
		}

		public void Config(UnitOfMeasure.Flow flowUnit, UnitOfMeasure.Temperature temperatureUnit,
			double low, double high)
		{
			// TODO:  Ask Cole-Parmer if the device supports setting units of measure over the serial connection.
			throw new NotImplementedException();
		}

		/// <summary>
		/// Commands to set and query gas selection.
		/// </summary>
		/// <remarks>
		/// The "Index" is the code sent to the device to set the gas.
		/// The "Code" is what the device sends back when queried to indicate the current setting.
		/// Inspiration for this dictionary with a tuple:
		/// https://stackoverflow.com/questions/569903/multi-value-dictionary
		/// https://stackoverflow.com/questions/8002455/how-to-easily-initialize-a-list-of-tuples
		/// Note this may require .NET framework 7.0 or later to compile.
		/// </remarks>
		private static readonly Dictionary<Gas, (int Index, string Code)> GasCommand = new Dictionary<Gas, (int Index, string Code)>
		{
			{ Gas.Air,                  (0, "Air") },
			{ Gas.Argon,                (1, "Ar") },
			{ Gas.Methane,              (2, "CH4") },
			{ Gas.CarbonMonoxide,       (3, "CO") },
			{ Gas.CarbonDioxide,        (4, "CO2") },
			{ Gas.Ethane,               (5, "C2H6") },
			{ Gas.Hydrogen,             (6, "H2") },
			{ Gas.Helium,               (7, "He") },
			{ Gas.Nitrogen,             (8, "N2") },
			{ Gas.NitrousOxide,         (9, "N2O") },
			{ Gas.Neon,                 (10, "Ne") },
			{ Gas.Oxygen,               (11, "O2") },
			{ Gas.Propane,              (12, "C3H8") },
			{ Gas.normalButane,         (13, "nC4H10") },
			{ Gas.Acetylene,            (14, "C2H2") },
			{ Gas.Ethylene,             (15, "C2H4") },
			{ Gas.isoButane,            (16, "iC4H10") }, // (code in manual has typo)
			{ Gas.Krypton,              (17, "Kr") },
			{ Gas.Xenon,                (18, "Xe") },
			{ Gas.SulfurHexafluoride,   (19, "SF6") },
			{ Gas.C25,                  (20, "C25") },
			{ Gas.C10,                  (21, "C10") },
			{ Gas.C8,                   (22, "C8") },
			{ Gas.C2,                   (23, "C2") },
			{ Gas.C75,                  (24, "C75") },
			{ Gas.He25,                 (25, "He25") }, // (code in manual has typo)
			{ Gas.He75,                 (26, "He75") }, // (code in manual has typo)
			{ Gas.A1025,                (27, "A1025") },
			{ Gas.Star29,               (28, "Star29") },
			{ Gas.P5,                   (29, "P5") },
		};

		/// <summary>
		/// Set gas type (needed for accurate conversion between volumetric and mass flow).
		/// </summary>
		/// <param name="gas">enumerated gas type</param>
		public void SetGas(Gas gas)
		{
			// Note the way we access the "GasSelection" Dictionary/Tuple.
			string msg = _address + Command.GasSelect + GasCommand[gas].Index;

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
			// Note (again) the way we access the "GasSelection" Dictionary/Tuple.
			string gasRequest = GasCommand[gas].Code;
			if (string.Compare(gasResult, gasRequest) != 0)
			{
				throw new Exception("Could not write gas selection to mass flow controller.");
			}
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

		public void SetControlMode(ControlMode mode)
		{
			throw new NotImplementedException();
		}

		#endregion

		/// <summary>
		/// Enable the mass flow controller's streaming mode.
		/// </summary>
		public void SetStreaming()
		{
			// "*@=@" sets the device into streaming mode.
			_serialPort.WriteLine(Command.SetAddress + '@');

			// TODO:  Validate streaming mode.
		}

		public double GetReading()
		{
			throw new NotImplementedException();
		}
	}
}
