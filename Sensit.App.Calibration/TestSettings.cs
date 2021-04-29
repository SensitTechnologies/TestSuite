using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;
using System.Xml.Serialization;
using System.Xml;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class DeviceSetting
	{
		public string Name { get; set; }

		public string Type { get; set; }

		[DisplayName("Serial Port")]
		public string SerialPort { get; set; }
	}

	[Serializable]
	public class EventSetting
	{
		public string DeviceName { get; set; }

		public VariableType Variable { get; set; }

		public double Value { get; set; }

		// Duration of the event (in seconds).
		public uint Duration { get; set; }

		[Description("Error tolerance around setpoints [% full scale].  If exceeded, Stability Time will reset.")]
		public double ErrorTolerance { get; set; } = 5.0;

		[Description("Tolerated rate of change of setpoints [% full scale / s].  If exceeded, Stability Time will reset.")]
		public double RateTolerance { get; set; } = 0.5;

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
		[Description("Timeout before aborting control."), XmlIgnore]
		public TimeSpan Timeout { get; set; } = new TimeSpan(0, 0, 30);

		// XmlSerializer does not support TimeSpan, so use this property for serialization instead.
		[Browsable(false), XmlElement(DataType = "duration", ElementName = "Timeout")]
		public string TimeoutString
		{
			get { return XmlConvert.ToString(Timeout); }
			set { Timeout = string.IsNullOrEmpty(value) ? TimeSpan.Zero : XmlConvert.ToTimeSpan(value); }
		}

		// TimeSpans aren't serializable, so ignore.
		[Description("Time to wait between taking samples."), XmlIgnore]
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
	/// Test configuration
	/// </summary>
	[Serializable]
	public class TestSetting
	{
		public List<DeviceSetting> Devices { get; } = new List<DeviceSetting>();

		public List<EventSetting> Events { get; } = new List<EventSetting>();
	}
}
