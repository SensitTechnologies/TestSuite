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
	/// Instruction manual:
	/// https://pim-resources.coleparmer.com/instruction-manual/cole-parmer-mass-flow-controller-manual.pdf
	/// 
	/// TODO:  Add support for 2nd mass flow controller; probably as a second class.
	/// Once that's possible, you can regulate gas concentration (in addition to gas flow).
	/// 
	/// TODO:  Figure out how to set control variable over serial interface.
	/// Once that's possible, this class can be extended to implement
	/// IVolumeFlowController, IPressureController. This should be low priority.
	/// </remarks>
	public class MFC : ISerialDevice, IMassFlowController, 
		IMassFlowReference, IVolumeFlowReference, ITemperatureReference, IPressureReference
	{
		/// <summary>
		/// Commands sent to the device
		/// </summary>
		private static class Command
		{
			public static readonly string SetAddress = "*@=";   // set the device address; set polling/streaming mode
			public static readonly string SetSetpoint = "S";    // set the flow setpoint
			public static readonly string ReadRegister = "*R";  // read a register (low-level; not typically used)
			public static readonly string WriteRegister = "*W"; // write a register (low-level; not typically used)
			public static readonly string GasSelect = "$$";     // select gas (for conversion from volume flow to mass flow)
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
			{ Gas.C25,                  (20, "C-25") },
			{ Gas.C10,                  (21, "C-10") },
			{ Gas.C8,                   (22, "C-8") },
			{ Gas.C2,                   (23, "C-2") },
			{ Gas.C75,                  (24, "C-75") },
			{ Gas.He25,                 (25, "He-25") }, // (code in manual has typo)
			{ Gas.He75,                 (26, "He-75") }, // (code in manual has typo)
			{ Gas.A1025,                (27, "A1025") },
			{ Gas.Star29,               (28, "Star29") },
			{ Gas.P5,                   (29, "P-5") },
		};

		// port used to communicate with mass flow controller
		private SerialPort _serialPort = new SerialPort();

		// specifier for a specific device on the serial port
		private static readonly char ADDRESS = 'A';

		/// <summary>
		/// Enable the mass flow controller's streaming mode.
		/// </summary>
		/// <remarks>
		/// Not used; but I wrote a method for it so it's documented.
		/// </remarks>
		private void SetStreaming()
		{
			try
			{
				// "*@=@" sets the device into streaming mode.
				_serialPort.WriteLine(Command.SetAddress + '@');

				// TODO:  Validate streaming mode.
			}
			catch (Exception ex)
			{
				throw new DevicePortException("Could not set mass flow controller streaming mode:"
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Set gas type (needed for accurate conversion between volumetric and mass flow).
		/// </summary>
		private void SetGas()
		{
			// Note the way we access the "GasSelection" Dictionary/Tuple.
			string msg = ADDRESS + Command.GasSelect + GasCommand[GasSelection].Index;

			try
			{
				// "A$$12" selects propane gas for device A.
				_serialPort.WriteLine(msg);

				// Read the response from the serial port (until we get a \r character).
				string message = _serialPort.ReadLine();

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);
				string gasResult = words[6];

				// Check the gas selection.
				// Note (again) the way we access the "GasSelection" Dictionary/Tuple.
				string gasRequest = GasCommand[GasSelection].Code;
				if (string.Compare(gasResult, gasRequest) != 0)
				{
					throw new Exception("Value returned from instrument was incorrect.");
				}
			}
			catch (Exception ex)
			{
				throw new DeviceCommunicationException("Could not write gas selection to mass flow controller."
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Set the device address
		/// </summary>
		/// <remarks>
		/// Must be set when no other devices are on the bus, or it will
		/// affect all devices at the same time.  This class supports only one
		/// device per bus, so a constant address is used.
		/// </remarks>
		private void WriteAddress()
		{
			try
			{
				// "*@=A" sets address = A (and puts device into polling mode).
				_serialPort.WriteLine(Command.SetAddress + ADDRESS);

				// Read from the serial port (until we get a \r character).
				string message = _serialPort.ReadLine();

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				// Check the address.
				if (string.Compare(words[0], ADDRESS.ToString()) != 0)
				{
					throw new Exception("Value returned from instrument was incorrect.");
				}
			}
			catch (Exception ex)
			{
				throw new DeviceCommunicationException("Could not update mass flow controller address."
					+ Environment.NewLine + ex.Message);
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
			try
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
				WriteAddress();
			}
			catch (Exception ex)
			{
				throw new DevicePortException("Could not open mass flow controller's serial port."
					+ Environment.NewLine + ex.Message);
			}
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

		#region Reference Device Methods

		public UnitOfMeasure.Flow FlowUnit { get; set; } = UnitOfMeasure.Flow.CubicFeetPerMinute;

		public Gas GasSelection { get; set; } = Gas.Air;

		public float VolumeFlow { get; private set; }

		public float MassFlow { get; private set; }

		public UnitOfMeasure.Temperature TemperatureUnit { get; set; } = UnitOfMeasure.Temperature.Celsius;

		public float Temperature { get; private set; }

		public UnitOfMeasure.Pressure PressureUnit { get; set; } = UnitOfMeasure.Pressure.PSI;

		public float Pressure { get; private set; }

		public void Configure()
		{
			// This device has only one settable property.
			SetGas();

			// TODO:  Figure out how to set units of measure programmatically.
			// TODO:  Until you can set units of meaure programmatically, throw an error if it's not a default unit.
		}

		public void Read()
		{
			try
			{
				// Read (when in polling mode) by sending the device address.
				_serialPort.WriteLine(ADDRESS.ToString());

				// Read from the serial port (until we get a \r character).
				string message = _serialPort.ReadLine();

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				// Check the address.
				if (string.Compare(words[0], ADDRESS.ToString()) != 0)
				{
					throw new Exception("Incorrect device ID");
				}

				// Figure out which is which and update class properties.
				Pressure = Convert.ToSingle(words[1]);
				Temperature = Convert.ToSingle(words[2]);
				VolumeFlow = Convert.ToSingle(words[3]);
				MassFlow = Convert.ToSingle(words[4]);

				// Probably don't update the control properties.
				//Setpoint = Convert.ToSingle(words[5]);
				//GasSelection = words[6];
			}
			catch (Exception ex)
			{
				throw new DeviceCommandFailedException("Could not read from mass flow controller."
					+ Environment.NewLine + ex.Message);
			}
		}

		#endregion

		#region Control Device Methods

		public float MassFlowSetpoint { set; get; }

		public void WriteMassFlowSetpoint()
		{
			try
			{
				// "AS4.54" = Set setpoint to 4.54 on device A.
				_serialPort.WriteLine(ADDRESS + Command.SetSetpoint + MassFlowSetpoint.ToString());

				// Read the response from the serial port (until we get a \r character).
				string message = _serialPort.ReadLine();

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				// Check the setpoint.
				if (Convert.ToSingle(words[5]).Equals(MassFlowSetpoint) == false)
				{
					throw new Exception("Value read from instrument was incorrect.");
				}
			}
			catch (Exception ex)
			{
				throw new DeviceCommandFailedException("Could not write setpoint to mass flow controller."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void WriteMassFlowSetpoint(float setpoint)
		{
			MassFlowSetpoint = setpoint;

			WriteMassFlowSetpoint();
		}

		public float ReadMassFlowSetpoint()
		{
			try
			{
				// Read (when in polling mode) by sending the device address.
				_serialPort.WriteLine(ADDRESS.ToString());

				// Read from the serial port (until we get a \r character).
				string message = _serialPort.ReadLine();

				// Split the string using spaces to separate each word.
				char[] separators = new char[] { ' ' };
				string[] words = message.Split(separators, StringSplitOptions.RemoveEmptyEntries);

				// Convert the setpoint to a number and set the property.
				MassFlowSetpoint = Convert.ToSingle(words[5]);

				// Return the setpoint in case the user wants it.
				return MassFlowSetpoint;
			}
			catch (Exception ex)
			{
				throw new DeviceCommandFailedException("Could not read setpoint from mass flow controller."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void SetControlMode(ControlMode mode)
		{
			// This mass flow controller only supports control mode,
			// so all this method does is throw exceptions if you try to change them.
			if (mode != ControlMode.Control)
				throw new DeviceSettingNotSupportedException("The device only supports Control mode.");
		}

		#endregion
	}
}
