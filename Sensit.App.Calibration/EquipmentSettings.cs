using System;
using System.ComponentModel;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class EquipmentSettings
	{
		[Category("Mass Flow Controller"), Description("Serial Port")]
		public string MassFlowControllerPort { get; set; } = "COM4";
		// TODO:  Add form to view/change settings from GUI.
	}
}
