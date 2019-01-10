using System;
using Sensit.TestSDK.Communication;

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
	public class Keysight_34972A : VisaDevice
	{
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
	}
}
