using System;
using System.Collections.Generic;
using System.ComponentModel;
using Sensit.TestSDK.Interfaces;
using System.Xml.Serialization;
using System.Xml;

namespace Sensit.App.Automate
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
		[DisplayName("Device Name")]
		public string DeviceName { get; set; }

		public VariableType Variable { get; set; }

		public decimal Value { get; set; }

		// Duration of the event (in seconds).
		public uint Duration { get; set; }

		[DisplayName("Error Tolerance"), Description("Error tolerance around setpoints [% full scale].  If exceeded, Stability Time will reset.")]
		public decimal ErrorTolerance { get; set; } = 5.0M;

		[DisplayName("Rate Tolerance"), Description("Tolerated rate of change of setpoints [% full scale / s].  If exceeded, Stability Time will reset.")]
		public decimal RateTolerance { get; set; } = 0.5M;

		[DisplayName("Dwell Time"), Category("Test Variable"), Description("Required time (in seconds) to be at setpoint before continuing test.")]
		public uint DwellTime { get; set; } = 0;

		[Description("Timeout (in seconds) before aborting control.")]
		public uint Timeout { get; set; } = 30;

		[Description("Time (in seconds) to wait between taking samples.")]
		public uint Interval { get; set; } = 1;
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
