using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensit.TestSDK.Communication
{
	/// <summary>
	/// Construct SCPI command strings
	/// </summary>
	/// <remarks>
	/// This class is an attempt at creating an extendable way to construct
	/// SCPI command strings.  However, I don't know how to do this properly,
	/// so I'm leaving this here until I can find help or figure it out.
	/// In the meantime, I'm going to use a pre-packaged class from Keysight
	/// that is specific to my instrument.
	/// </remarks>
	public static class SCPI
	{
		// Mandated Commands
		public const string CLS = "*CLS";
		public const string ESE = "*ESE";
		public const string ESR = "*ESR";
		public const string IDN = "*IDN";
		public const string OPC = "*OPC";
		public const string PSC = "*PSC";

		// Top level
		public const string ABORt = "ABOR";
		public const string CALCulate = "CALC";
		public const string CALibrate = "CAL";
		public const string CONFigure = "CONF";
		public const string DATA = "DATA";
		public const string DIAGnostic = "DIAG";

		public static class DISPlay
		{
			public const string TEXT = "DISP:TEXT";
		}
	}
}
