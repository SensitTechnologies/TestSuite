using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// A virtual device.
	/// </summary>
	/// <remarks>
	/// Useful for testing software and test equipment, or as a DUT to make manual
	/// data entries.
	/// </remarks>
	public class Simulator : IMassFlowDevice, IVolumeFlowDevice, IVelocityDevice, IPressureDevice,
		ITemperatureDevice, ICurrentDevice, IVoltageDevice
	{
		// Values used for both setpoints and readings.
		private Dictionary<VariableType, double> _values = new Dictionary<VariableType, double>()
		{
			{ VariableType.MassFlow, 0.0 },
			{ VariableType.Pressure, 0.0 },
			{ VariableType.Temperature, 0.0 },
			{ VariableType.Velocity, 0.0 },
			{ VariableType.VolumeFlow, 0.0 }
		};

		public Dictionary<VariableType, double> Readings => _values;

		public Dictionary<VariableType, double> Setpoints => _values;

		public UnitOfMeasure.Flow FlowUnit { get; set; }

		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; }

		public Gas GasSelection { get; set; } = Gas.Air;

		public UnitOfMeasure.Velocity VelocityUnit { get; set; }

		public UnitOfMeasure.Pressure PressureUnit { get; set; }

		public UnitOfMeasure.Temperature TemperatureUnit { get; set; }

		public UnitOfMeasure.Current CurrentUnit { get; set; }

		public UnitOfMeasure.Voltage VoltageUnit { get; set; }

		public int Channel { get; set; }

		// Since there's nothing to communicate with, none of the methods
		// have anything to do unless they get/set a property.

		public void Read()
		{
			// Nothing to do here.
		}

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void Write()
		{
			// Nothing to do here.
		}
	}
}
