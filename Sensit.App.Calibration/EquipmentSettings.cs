using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class ReferenceSetting
	{
		[Category("Reference Setting"), Description("Variable that device measures.")]
		public VariableType DeviceType { get; set; }

		[Category("Reference Setting"), Description("Serial ports used by device.")]
		public List<string> SerialPorts { get; set; }

		[Category("Reference Setting"), Description("Gas measured by device.")]
		public List<Gas> GasSelection { get; set; }
	}

	[Serializable]
	public class ControlSetting
	{
		[Category("Control Setting"), Description("Interface used by control device.")]
		public VariableType DeviceType { get; set; }

		[Category("Control Setting"), Description("Serial ports used by device.")]
		public List<string> SerialPorts { get; set; }

		[Category("Control Setting"), Description("Gas controlled by device.")]
		public List<Gas> GasSelection { get; set; }

		[Category("Control Setting"), Description("Devices used to form a composite device (i.e. gas mixer using two mass flow controllers).")]
		public List<ReferenceSetting> SubDevice { get; set; }
	}

	[Serializable]
	public class EquipmentSettings : Attribute
	{
		[Category("Equipment Settings"), Description("Settings for control devices.")]
		public List<ControlSetting> ControlSettings { get; set; }

		[Category("Equipment Settings"), Description("Settings for reference devices.")]
		public List<ReferenceSetting> ReferenceSettings { get; set; }

		[Category("Equipment Settings"), Description("Serial Port for Analyte Mass Flow Controller")]
		public string AnalyteControllerPort { get; set; } = "COM7";

		[Category("Equipment Settings"), Description("Serial Port for Diluent Mass Flow Controller")]
		public string DiluentControllerPort { get; set; } = "COM6";
	}
}
