using System.Collections.Generic;
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
	public class Simulator : IDevice
	{
		public Dictionary<VariableType, decimal> Readings { get; } = new Dictionary<VariableType, decimal>()
		{
			{ VariableType.MassFlow, 0.0M },
			{ VariableType.Pressure, 0.0M },
			{ VariableType.Temperature, 0.0M },
			{ VariableType.Velocity, 0.0M },
			{ VariableType.VolumeFlow, 0.0M }
		};

		public Dictionary<VariableType, decimal> Setpoints => Readings;

		public string Message { get; }

		// Since there's nothing to communicate with, none of the methods
		// have anything to do unless they get/set a property.

		public void WriteThenRead()
		{
			// Nothing to do here.
		}

		public void SetControlMode(ControlMode mode)
		{
			// Nothing to do here.
		}

		public void Write(VariableType variable, decimal value)
		{
			// Save the new value.
			Setpoints[variable] = value;
		}
	}
}
