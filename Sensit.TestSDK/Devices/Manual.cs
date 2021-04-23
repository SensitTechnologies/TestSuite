using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Utilities;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// A virtual device.
	/// </summary>
	/// <remarks>
	/// Useful for testing software and test equipment, or as a DUT to make manual
	/// data entries.
	/// </remarks>
	public class Manual : IMassFlowDevice, IVolumeFlowDevice, IVelocityDevice, IPressureDevice,
		ITemperatureDevice, ICurrentDevice, IVoltageDevice,
		IControlDevice
	{
		/// <summary>
		/// Used to determine what type of variables this controller will store.
		/// </summary>
		private VariableType _type;

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

		public UnitOfMeasure.Current CurrentUnit { get; set; }

		public UnitOfMeasure.Voltage VoltageUnit { get; set; }

		#endregion

		#region Control Device Properties

		public double AnalyteBottleConcentration { get; set; }

		public int Channel { get; set; }

		#endregion

		// Since there's nothing to communicate with, none of the methods
		// have anything to do unless they get/set a property.

		#region Reference Device Methods

		public void Read()
		{
			// Prompt user to enter a value.
			double value = 0.0;
			DialogResult result = InputDialog.Numeric("Enter " + _type.GetDescription() + ".", ref value, 0.0, 100.0);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not read from DUT.");

			// Store the result.
			Readings[_type] = value;
		}

		#endregion

		#region Control Device Methods

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void WriteSetpoint(VariableType type, double setpoint)
		{
			// A hack to determine what kind of device this class represents.
			_type = type;

			Readings[type] = setpoint;
		}

		public double ReadSetpoint(VariableType type)
		{
			return Readings[type];
		}

		#endregion
	}
}
