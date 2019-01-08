using System;
using System.Collections.Generic;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Dut
{
	/// <summary>
	/// Analog sensor
	/// </summary>
	public class AnalogSensor : IAnalogDUT
	{
		public string Model { get; set; }

		public string Version { get; set; }

		public bool Selected { get; set; }

		public DutStatus Status { get; set; }

		public string SerialNumber { get; set; }

		public string Message { get; set; }

		public List<DutCoefficient> Coefficients { get; set; }

		public int ReadRawCounts()
		{
			throw new NotImplementedException();
		}

		public void ComputeCoefficients()
		{
			throw new NotImplementedException();
		}
	}
}
