using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ivi.Visa.Interop;					// sent SCPI commands using VISA

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
		// TODO:  Use this address:  
		// IVI VISA object used to communicate with the datalogger
		private ResourceManager _resourceManager = new ResourceManager();

		// VISA SCPI command formatter
		private FormattedIO488 _io = new FormattedIO488();

		public void Open()
		{
			_io.IO = (IMessage)_resourceManager.Open("USB0::0x0957::0x2007::MY49018108::0::INSTR");
		}
	}
}
