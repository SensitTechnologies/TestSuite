using System.Collections.Generic;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	public class Manual : IGasMixReference, IMassFlowReference, IVolumeFlowReference, IVelocityReference, IPressureReference, ITemperatureReference,
		IGasMixController, IMassFlowController, IVolumeFlowController, IVelocityController, IPressureController, ITemperatureController
	{
		private readonly Dictionary<VariableType, double> _values;

		public Manual()
		{
			_values = new Dictionary<VariableType, double>
			{
				{ VariableType.GasConcentration, 0.0 },
				{ VariableType.MassFlow, 0.0 },
				{ VariableType.Pressure, 0.0 },
				{ VariableType.Temperature, 0.0 },
				{ VariableType.Velocity, 0.0 },
				{ VariableType.VolumeFlow, 0.0 }
			};
		}

		#region Reference Device Properties

		public UnitOfMeasure.Flow FlowUnit { get; set; }

		public Gas GasSelection { get; set; } = Gas.Air;

		public UnitOfMeasure.Velocity VelocityUnit { get; set; }

		public UnitOfMeasure.Pressure PressureUnit { get; set; }

		public UnitOfMeasure.Temperature TemperatureUnit { get; set; }

		#endregion

		#region Control Device Properties

		public double AnalyteBottleConcentration { get; set; }

		#endregion

		// Since there's nothing to communicate with, none of the methods
		// have anything to do unless they get/set a property.

		#region Reference Device Methods

		public void Update()
		{
			// Nothing to do here.
		}

		public double Read(VariableType type)
		{
			// Prompt the user for a new value.
			double value = _values[type];
			InputDialog.Numeric(type.GetDescription(), ref value);

			// Remember the value.
			_values[type] = value;

			// Return the value.
			return _values[type];
		}

		#endregion

		#region Control Device Methods

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void WriteSetpoint(VariableType type, double setpoint)
		{
			_values[type] = setpoint;
		}

		public double ReadSetpoint(VariableType type)
		{
			return _values[type];
		}

		#endregion
	}
}
