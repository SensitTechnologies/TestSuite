using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class ReferenceSetting
	{
		[Category("Device Type"), Description("Variable that device measures.")]
		public Test.VariableType DeviceType { get; set; }

		[Category("Serial Ports"), Description("Serial ports used by device.")]
		public List<string> SerialPorts { get; set; }

		[Category("Gas Selection"), Description("Gas measured by device.")]
		public List<Gas> GasSelection { get; set; }
	}

	[Serializable]
	public class ControlSetting
	{
		[Category("Device Type"), Description("Interface used by control device.")]
		public Test.VariableType DeviceType { get; set; }

		[Category("Serial Ports"), Description("Serial ports used by device.")]
		public List<string> SerialPorts { get; set; }

		[Category("Gas"), Description("Gas controlled by device.")]
		public List<Gas> GasSelection { get; set; }

		[Category("Sub-device"), Description("Devices used to form a composite device (i.e. gas mixer using two mass flow controllers).")]
		public List<ReferenceSetting> SubDevice { get; set; }
	}

	[Serializable]
	public class EquipmentSettings : Attribute
	{
		[Category("Control Device Settings"), Description("Settings for control devices.")]
		public List<ControlSetting> ControlSettings { get; set; }

		[Category("Reference Device Settings"), Description("Settings for reference devices.")]
		public List<ReferenceSetting> ReferenceSettings { get; set; }

		[Category("Analyte Mass Flow Controller"), Description("Serial Port")]
		public string AnalyteControllerPort { get; set; } = "COM7";

		[Category("Diluent Mass Flow Controller"), Description("Serial Port")]
		public string DiluentControllerPort { get; set; } = "COM6";
	}
}
