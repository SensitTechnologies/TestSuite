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

	[Serializable]
	public class GasMixerSetting
	{
		[Category("Mass Flow Controllers"), Description("Serial port used by device.")]
		public SerialPortSetting AnalyteMFC { get; set; }

		[Category("Mass Flow Controllers"), Description("Serial port used by device.")]
		public SerialPortSetting DiluentMFC { get; set; }

		[Category("Gas"), Description("Analyte gas.")]
		public Gas Analyte { get; set; }

		[Category("Gas"), Description("Diluent gas.")]
		public Gas Diluent { get; set; }
	}

	[Serializable]
	public class EquipmentSettings
	{
		[Category("Control Devices"), Description("Settings for Gas Mixer, which is really two Mass Flow Controllers working together.")]
		public GasMixerSetting GasMixer { get; set; } = new GasMixerSetting()
		{
			AnalyteMFC = new SerialPortSetting() { SerialPort = "COM7" },
			DiluentMFC = new SerialPortSetting() { SerialPort = "COM6" }
		};

		[Category("Control Devices"), Description("Settings for Mass Flow Controller.")]
		public SerialPortSetting ColeParmerMFC { get; set; } = new SerialPortSetting();

		[Category("Control Devices"), Description("Settings for Power Supply.")]
		public SerialPortSetting PowerSupply { get; set; } = new SerialPortSetting()
		{
			SerialPort = "COM3",
			BaudRate = 9600
		};
	}
}
