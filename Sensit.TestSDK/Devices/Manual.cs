using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	public class Manual : IGasMixReference, IMassFlowReference, IVolumeFlowReference, IVelocityReference, IPressureReference, ITemperatureReference,
		IGasMixController, IMassFlowController, IVolumeFlowController, IVelocityController, IPressureController, ITemperatureController
	{
		private double _gasMix;
		private double _massFlow;
		private double _volumeFlow;
		private double _velocity;
		private double _pressure;
		private double _temperature;

		#region Reference Device Properties

		public UnitOfMeasure.Flow FlowUnit { get; set; }

		public Gas GasSelection { get; set; } = Gas.Air;

		// TODO:  Move user prompts out of property getters.
		// Will likely mean refactoring IReferenceDevice.

		public double GasMix
		{
			get
			{
				InputDialog.Numeric("Gas Mix", ref _gasMix);
				return _gasMix;
			}
		}

		public double MassFlow
		{
			get
			{
				InputDialog.Numeric("Mass Flow", ref _massFlow);
				return _massFlow;
			}
		}

		public double VolumeFlow
		{
			get
			{
				InputDialog.Numeric("Volume Flow", ref _volumeFlow);
				return _volumeFlow;
			}
		}

		public UnitOfMeasure.Velocity VelocityUnit { get; set; }

		public double Velocity
		{
			get
			{
				InputDialog.Numeric("Velocity", ref _velocity);
				return _velocity;
			}
		}

		public UnitOfMeasure.Pressure PressureUnit { get; set; }

		public double Pressure
		{
			get
			{
				InputDialog.Numeric("Pressure", ref _pressure);
				return _pressure;
			}
		}

		public UnitOfMeasure.Temperature TemperatureUnit { get; set; }

		public double Temperature
		{
			get
			{
				InputDialog.Numeric("Temperature", ref _temperature);
				return _temperature;
			}
		}

		#endregion

		#region Control Device Properties

		public double AnalyteBottleConcentration { get; set; }

		public double GasMixSetpoint { get; set; }

		public double MassFlowSetpoint { get; set; }

		public double VolumeFlowSetpoint { get; set; }

		public double VelocitySetpoint { get; set; }

		public double PressureSetpoint { get; set; }

		public double TemperatureSetpoint { get; set; }

		#endregion

		// Since there's nothing to communicate with, none of the methods
		// have anything to do unless they get/set a property.

		#region Reference Device Methods
		
		public void Configure()
		{
			// Nothing to do here.
		}

		public void Read()
		{
			// Nothing to do here.
		}

		#endregion

		#region Control Device Methods

		public double ReadGasMixSetpoint()
		{
			return GasMixSetpoint;
		}

		public double ReadMassFlowSetpoint()
		{
			return MassFlowSetpoint;
		}

		public double ReadPressureSetpoint()
		{
			return PressureSetpoint;
		}

		public double ReadTemperatureSetpoint()
		{
			return TemperatureSetpoint;
		}

		public double ReadVelocitySetpoint()
		{
			return VelocitySetpoint;
		}

		public double ReadVolumeFlowSetpoint()
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

		public void WriteMassFlowSetpoint(double setpoint)
		{
			MassFlowSetpoint = setpoint;
		}

		public void WritePressureSetpoint()
		{
			// Nothing to do here.
		}

		public void WritePressureSetpoint(double setpoint)
		{
			PressureSetpoint = setpoint;
		}

		public void WriteTemperatureSetpoint()
		{
			// Nothing to do here.
		}

		public void WriteTemperatureSetpoint(double setpoint)
		{
			TemperatureSetpoint = setpoint;
		}

		public void WriteVelocitySetpoint()
		{
			// Nothing to do here.
		}

		public void WriteVelocitySetpoint(double setpoint)
		{
			VelocitySetpoint = setpoint;
		}

		public void WriteVolumeFlowSetpoint()
		{
			// Nothing to do here.
		}

		public void WriteVolumeFlowSetpoint(double setpoint)
		{
			VolumeFlowSetpoint = setpoint;
		}

		public void WriteGasMixSetpoint()
		{
			// Nothing to do here.
		}

		public void WriteGasMixSetpoint(double concentration, double massFlow)
		{
			MassFlowSetpoint = massFlow;
			GasMixSetpoint = concentration;
		}

		#endregion
	}
}
