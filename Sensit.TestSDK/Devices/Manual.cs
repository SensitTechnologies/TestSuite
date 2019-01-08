using System;
using System.Windows.Forms;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	class Manual : IMassFlowReference, IVolumeFlowReference, IVelocityReference, IPressureReference, ITemperatureReference,
		IMassFlowController, IVolumeFlowController, IVelocityController, IPressureController, ITemperatureController
	{
		#region Reference Device Properties

		public UnitOfMeasure.Flow FlowUnit { get; set; }

		public Gas GasSelection { get; set; } = Gas.Air;

		// TODO:  For every numeric property, generate a prompt to ask the user for input.
		public float MassFlow { get; }

		public float VolumeFlow { get; }

		public UnitOfMeasure.Velocity VelocityUnit { get; set; }

		public float Velocity { get; }

		public UnitOfMeasure.Pressure PressureUnit { get; set; }

		public float Pressure { get; }

		public UnitOfMeasure.Temperature TemperatureUnit { get; set; }

		public float Temperature { get; }

		#endregion

		#region Control Device Properties

		public float MassFlowSetpoint { get; set; }

		public float VolumeFlowSetpoint { get; set; }

		public float VelocitySetpoint { get; set; }

		public float PressureSetpoint { get; set; }

		public float TemperatureSetpoint { get; set; }

		#endregion

		// Since there's nothing to communicate with, none of these methods
		// have anything to do unless they get/set a property.

		public void Configure()
		{
			// Nothing to do here.
		}

		public void Read()
		{
			// Nothing to do here.
		}

		public float ReadMassFlowSetpoint()
		{
			return MassFlowSetpoint;
		}

		public float ReadPressureSetpoint()
		{
			return PressureSetpoint;
		}

		public float ReadTemperatureSetpoint()
		{
			return TemperatureSetpoint;
		}

		public float ReadVelocitySetpoint()
		{
			return VelocitySetpoint;
		}

		public float ReadVolumeFlowSetpoint()
		{
			return VolumeFlowSetpoint;
		}

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void WriteMassFlowSetpoint()
		{
			// Nothing to do here.
		}

		public void WriteMassFlowSetpoint(float setpoint)
		{
			MassFlowSetpoint = setpoint;
		}

		public void WritePressureSetpoint()
		{
			// Nothing to do here.
		}

		public void WritePressureSetpoint(float setpoint)
		{
			PressureSetpoint = setpoint;
		}

		public void WriteTemperatureSetpoint()
		{
			// Nothing to do here.
		}

		public void WriteTemperatureSetpoint(float setpoint)
		{
			TemperatureSetpoint = setpoint;
		}

		public void WriteVelocitySetpoint()
		{
			// Nothing to do here.
		}

		public void WriteVelocitySetpoint(float setpoint)
		{
			VelocitySetpoint = setpoint;
		}

		public void WriteVolumeFlowSetpoint()
		{
			// Nothing to do here.
		}

		public void WriteVolumeFlowSetpoint(float setpoint)
		{
			VolumeFlowSetpoint = setpoint;
		}
	}
}
