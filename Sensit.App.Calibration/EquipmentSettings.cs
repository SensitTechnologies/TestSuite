using System;
using System.ComponentModel;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class EquipmentSettings
	{
		[Category("Hardware"), Description("Serial Port")]
		public string MassFlowControllerPort { get; set; } = "COM18";
	}
}
