using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Protocols;

namespace Sensit.TestSDK.Devices
{
	[DisplayName("EZT-570S Environmental Chamber"), Description("Temperature/Humidity Chamber")]
	public class EZT570S : SerialDevice, IDevice
	{
		// Mobbus serial device
		//private ModbusMasterSerial _mbMaster = new(ModbusSerialType.RTU, );

		// Settings supported by the environmental chamber
		public override List<int> SupportedBaudRates { get; } = [9600];
		public override List<Parity> SupportedParity { get; } = [Parity.Even, Parity.Odd, Parity.None];
		public override List<int> SupportedDataBits { get; } = [8];
		public override List<StopBits> SupportedStopBits { get; } = [StopBits.One];
		public override List<Handshake> SupportedHandshake { get; } = [Handshake.None];

		// Not used by the environmental chamber
		public string Message { get; }

		public Dictionary<VariableType, decimal> Readings { get; } = new Dictionary<VariableType, decimal>
		{
			{ VariableType.Temperature, 0.0M },
		};

		public Dictionary<VariableType, decimal> Setpoints { get; } = new Dictionary<VariableType, decimal>
		{
			{ VariableType.Temperature, 0.0M }
		};

		public void SetControlMode(ControlMode mode)
		{
			throw new NotImplementedException();
		}

		public void Write(VariableType variable, decimal value)
		{
			throw new NotImplementedException();
		}

		public void WriteThenRead()
		{
			throw new NotImplementedException();
		}
	}
}
