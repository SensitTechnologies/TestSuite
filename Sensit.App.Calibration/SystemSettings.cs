using System;
using System.ComponentModel;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class SystemSettings
	{
		[Category("Hardware"), Description("Serial Port")]
		public string MassFlowControllerPort { get; set; } = "COM18";
	}
}
