using System;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class EquipmentSettings : Attribute
	{
		[Category("Analyte Mass Flow Controller"), Description("Serial Port")]
		public string AnalyteControllerPort { get; set; } = "COM4";

		[Category("Diluent Mass Flow Controller"), Description("Serial Port")]
		public string DiluentControllerPort { get; set; } = "COM3";

		[Category("Analyte Mass Flow Controller"), Description("Gas Selection")]
		public Gas AnalyteGasSelection { get; set; }

		[Category("Diluent Mass Flow Controller"), Description("Gas Selection")]
		public Gas DiluentGasSelection { get; set; }
	}
}
