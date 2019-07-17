using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Sensit.App.WebSensors
{
	public enum SensorStatus
	{
		Offline,
		Online,
		[Description("Not Found")]
		NotFound,
		Error,
	}

	public class SensorData
	{
		public TimeSpan? ElapsedTime { get; set; }
		public double? Value { get; set; }
	}

	/// <summary>
	/// A sensor we can collect data from.
	/// </summary>
	public class Sensor
	{
		#region Properties

		/// <summary>
		/// Data collected from the sensor.
		/// </summary>
		public List<SensorData> Data { get; set; } = new List<SensorData>();

		/// <summary>
		/// Serial number or other descriptor
		/// </summary>
		public string Description { get; set; } = string.Empty;

		/// <summary>
		/// State of the device (online, error, etc.)
		/// </summary>
		public SensorStatus Status { get; set; } = SensorStatus.Offline;
		
		#endregion

		public void Open()
		{

		}

		public void Close()
		{

		}
	}
}
