using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;
using System.Xml.Serialization;
using System.Xml;

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
	public class DeviceSettings
	{
		[Category("Devices"), Description("Settings for Mass Flow Controller.")]
		public SerialPortSetting ColeParmerMFC { get; set; } = new SerialPortSetting();

		[Category("Devices"), Description("Settings for Power Supply.")]
		public SerialPortSetting PowerSupply { get; set; } = new SerialPortSetting()
		{
			SerialPort = "COM3",
			BaudRate = 9600
		};
	}

	/// <summary>
	/// Configuration for a variable being controlled during a test.
	/// </summary>
	[Serializable]
	public class TestControlledVariable
	{
		[Category("Test Variable"), Description("Type of the variable.")]
		public VariableType VariableType { get; set; }

		[Category("Test Variable"), Description("Error tolerance around setpoints [% full scale].  If exceeded, Stability Time will reset.")]
		public double ErrorTolerance { get; set; } = 5.0;

		[Category("Test Variable"), Description("Tolerated rate of change of setpoints [% full scale / s].  If exceeded, Stability Time will reset.")]
		public double RateTolerance { get; set; } = 0.5;

		[Category("Test Variable"), Description("Setpoints [% full scale].")]
		public List<double> Setpoints { get; set; }

		// TimeSpans aren't serializable, see this for workaround:
		// https://stackoverflow.com/questions/637933/how-to-serialize-a-timespan-to-xml
		[Category("Test Variable"), Description("Required time to be at setpoint before continuing test."), XmlIgnore]
		public TimeSpan DwellTime { get; set; } = new TimeSpan(0, 0, 0);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "DwellTime")]
		public string DwellTimeString
		{
			get { return XmlConvert.ToString(DwellTime); }
			set { DwellTime = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}

		// TimeSpans aren't serializable, so ignore.
		[Category("Test Variable"), Description("Timeout before aborting control."), XmlIgnore]
		public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 30);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "Timeout")]
		public string TimeoutString
		{
			get { return XmlConvert.ToString(Timeout); }
			set { Timeout = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}

		[Category("Test Component"), Description("Number of samples taken at each setpoint.")]
		public int Samples { get; set; } = 0;

		// TimeSpans aren't serializable, so ignore.
		[Category("Test Component"), Description("Time to wait between taking samples."), XmlIgnore]
		public TimeSpan Interval { get; set; } = new TimeSpan(0, 0, 1);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "Interval")]
		public string IntervalString
		{
			get { return XmlConvert.ToString(Interval); }
			set { Interval = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}
	}

	/// <summary>
	/// Configuration for a component of a test.
	/// </summary>
	[Serializable]
	public class TestComponent
	{
		#region Constructors

		// Default constructor.
		public TestComponent() { }

		// Initializer with label.
		public TestComponent(string label)
		{
			Label = label;
		}

		#endregion

		[Category("Test Component"), Description("Name for this part of the test.")]
		public string Label { get; set; } = "";

		[Category("Test Component"), Description("Actions to perform during this test component.")]
		public List<Test.Command> Commands { get; set; }

		[Category("Test Component"), Description("Controlled variables for this part of the test.")]
		public List<TestControlledVariable> ControlledVariables { get; set; }
	}

	/// <summary>
	/// Tests that may be performed
	/// </summary>
	[Serializable]
	public class TestSetting
	{
		#region Constructors

		// Default constructor.
		public TestSetting() { }

		// Initializer with label.
		public TestSetting(string label)
		{
			Label = label;
		}

		#endregion

		[Category("Test Settings"), Description("Name of the test (as it will appear to the operator).")]
		public string Label { get; set; } = "";

		[Category("Test Settings"), Description("Actions performed during the test.")]
		public List<TestComponent> Components { get; set; }

		[Category("Test Settings"), Description("Variables measured (with reference devices) during the test.")]
		public List<VariableType> References { get; set; }
	}
}
