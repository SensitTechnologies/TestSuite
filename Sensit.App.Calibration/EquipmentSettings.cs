using System;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class SerialPortSetting
	{
		[Category("Serial Port"), Description("Serial port used by device.")]
		public string SerialPort { get; set; }

		[Category("Serial Port"), Description("Baud rate used by device.")]
		public int BaudRate { get; set; }
	}

	public class GasMixerSetting
	{
		[Category("Mass Flow Controllers"), Description("Serial port used by device.")]
		public SerialPortSetting AnalyteMFC { get; set; } = new SerialPortSetting()
		{
			SerialPort = "COM7",	// COM10
		};

		[Category("Mass Flow Controllers"), Description("Serial port used by device.")]
		public SerialPortSetting DiluentMFC { get; set; } = new SerialPortSetting()
		{
			SerialPort = "COM6"	// COM11
		};

		[Category("Gas"), Description("Analyte gas.")]
		public Gas Analyte { get; set; }

		[Category("Gas"), Description("Diluent gas.")]
		public Gas Diluent { get; set; }
	}

	public class DataloggerSetting
	{
		[Description("Datalogger bank used to interface with DUTs.")]
		public int Bank { get; set; } = 3;
	}

	[Serializable]
	public class EquipmentSettings : Attribute
	{
		[Category("Control Devices"), Description("Settings for Gas Mixer, which is really two Mass Flow Controllers working together.")]
		public GasMixerSetting GasMixer { get; set; } = new GasMixerSetting();

		[Category("Control Devices"), Description("Settings for Mass Flow Controller.")]
		public SerialPortSetting ColeParmerMFC { get; set; } = new SerialPortSetting();

		[Category("DUT Interface Devices"), Description("Settings for datalogger.")]
		public DataloggerSetting Datalogger { get; set; } = new DataloggerSetting();

		[Category("Reference Devices"), Description("Settings for Sensit G3 Console.")]
		public SerialPortSetting G3Setting { get; set; } = new SerialPortSetting()
		{
			SerialPort = "COM9",
			BaudRate = 115200
		};
	}
}
