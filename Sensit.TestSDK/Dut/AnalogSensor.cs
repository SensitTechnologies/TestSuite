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
		IDutInterfaceDevice _dutInterface;

		public AnalogSensor(IDutInterfaceDevice interfaceDevice)
		{
			_dutInterface = interfaceDevice;
		}
			
		public int Index { get; set; }

		public string Model { get; set; }

		public string Version { get; set; }

		public bool Selected { get; set; }

		public DutStatus Status { get; set; }

		public string SerialNumber { get; set; }

		public string Message { get; set; }

		public List<DutCoefficient> Coefficients { get; set; }

		public void PowerOn()
		{
			_dutInterface.PowerOn(Index);
		}

		public void PowerOff()
		{
			_dutInterface.PowerOff(Index);
		}

		public int ReadRawCounts()
		{
			return _dutInterface.ReadCounts(Index);
		}

		public double ReadAnalog()
		{
			return _dutInterface.ReadAnalog(Index);
		}

		public void ComputeCoefficients()
		{
			throw new NotImplementedException();
		}
	}
}
