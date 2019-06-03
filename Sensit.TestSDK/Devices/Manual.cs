﻿using System.Collections.Generic;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	public class Manual : IGasConcentrationReference, IMassFlowReference, IVolumeFlowReference, IVelocityReference, IPressureReference, ITemperatureReference,
		IGasMixController, IMassFlowController, IVolumeFlowController, IVelocityController, IPressureController, ITemperatureController
	{
		#region Reference Device Properties

		public Dictionary<VariableType, double> Readings { get; private set; }
			= new Dictionary<VariableType, double>
			{
				{ VariableType.GasConcentration, 0.0 },
				{ VariableType.MassFlow, 0.0 },
				{ VariableType.Pressure, 0.0 },
				{ VariableType.Temperature, 0.0 },
				{ VariableType.Velocity, 0.0 },
				{ VariableType.VolumeFlow, 0.0 }
			};

		public UnitOfMeasure.Flow FlowUnit { get; set; }

		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; }


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

		public void Read()
		{
			// Nothing to do here.
		}

		#endregion

		#region Control Device Methods

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void WriteSetpoint(VariableType type, double setpoint)
		{
			Readings[type] = setpoint;
		}

		public double ReadSetpoint(VariableType type)
		{
			return Readings[type];
		}

		#endregion
	}
}
