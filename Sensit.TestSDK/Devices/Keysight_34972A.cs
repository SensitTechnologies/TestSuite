﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa;					// sent SCPI commands using VISA

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Communication driver for a Keysight 34970A/34972A.
	/// </summary>
	/// <remarks>
	/// Product Website:
	/// https://www.keysight.com/en/pd-1756491-pn-34972A/lxi-data-acquisition-data-logger-switch-unit
	/// This is a three-slot mainframe with a built-in 6.5 digit multimeter.  Choose from eight
	/// optional plug-in modules to create a compact data logger, full-featured data acquisition
	/// system or low-cost switching unit.
	/// </remarks>
	public class Keysight_34972A
	{
		// IVI VISA object used to communicate with the device
		private IMessageBasedFormattedIO _instrument;

		private static class SCPICommand
		{
			// Universal Commands
			public const string Clear = "*CLS";
			public const string EventStandardEnable = "*ESE";
			public const string EventStandardRegister = "*ESR";
			public const string Identification = "*IDN?";
			public const string OperationComplete = "*OPC";
			public const string PowerOnStatusClear = "*PSC";

			// Top level
			public const string Abort = "ABOR";
			public const string Calculate = "CALC";
			public const string Calibrate = "CAL";
			public const string Configure = "CONF";
			public const string Data = "DATA";
			public const string Diagnostic = "DIAG";
			public const string Display = "DISP";
		}

		public void Open()
		{
			// Open a connection to the instrument.
			// TODO:  Find available instrument address instead of hardcoding.
			_instrument = GlobalResourceManager.Open("USB0::0x0957::0x2007::MY49018108::0::INSTR") as IMessageBasedFormattedIO;

			// Once we're connected, make sure we close things correctly.
			try
			{
				// Send the *IDN query to the instrument.
				_instrument.WriteLine(SCPICommand.Identification);

				// Read back the response.
				string result = _instrument.ReadString();
			}
			finally
			{
				// Close the connection to the instrument.
				// TODO:  This line does not compile!
				//_instrument.Close();

				// Free the reference to the session.
				_instrument = null;
			}
		}

		public void Close()
		{
			// TODO:  This line does not compile!
			//_instrument.Close();
		}
	}
}