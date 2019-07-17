using System.Collections.Generic;
using System.IO.Ports;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	public class SensitG2GLT : SerialDevice, IGasConcentrationReference
	{
		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; } = UnitOfMeasure.Concentration.PartsPerMillion;

		public Gas GasSelection { get; set; }

		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double>
		{
			{ VariableType.GasConcentration, 0.0 }
		};

		public override void Open(string portName, int baudRate)
		{
			throw new System.NotImplementedException();
		}

		public void Read()
		{
			throw new System.NotImplementedException();
		}

		public override void WriteSerialProperties(int dataBits = 8, Parity parity = Parity.None, StopBits stopBits = StopBits.One)
		{
			throw new System.NotImplementedException();
		}
	}
}
