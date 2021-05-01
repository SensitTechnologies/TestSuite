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
	/// Useful for testing software.
	/// TODO:  Manual:  Make this device more useful.
	/// </remarks>
	public class Manual : IMassFlowDevice, IVolumeFlowDevice, IVelocityDevice, IPressureDevice,
		ITemperatureDevice, ICurrentDevice, IVoltageDevice
	{
		public Dictionary<VariableType, double> Readings { get; } = new Dictionary<VariableType, double>
		{
			{ VariableType.MassFlow, 0.0 },
		};

		public Dictionary<VariableType, double> Setpoints { get; } = new Dictionary<VariableType, double>
		{
			{ VariableType.MassFlow, 0.0 },
		};

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
			// Prompt user to enter a value.
			double value = 0.0;
			DialogResult result = InputDialog.Numeric("Enter value.", ref value, 0.0, 100.0);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not read from DUT.");

			// Store the result.
			Readings[VariableType.MassFlow] = value;
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
