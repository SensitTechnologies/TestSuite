using System.Collections.Generic;
using System.ComponentModel;

namespace Sensit.TestSDK.Interfaces
{
	public enum VariableType
	{
		[Description("Mass Flow")]
		MassFlow,
		[Description("Volume Flow")]
		VolumeFlow,
		Velocity,
		Pressure,
		Temperature,
		Current,
		Voltage,
		Channel
	}

	/// <summary>
	/// What the device should try to do.
	/// </summary>
	public enum ControlMode
	{
		Active,     // actively controlling the test environment
		Passive     // passively measuring the test environment
	}

	/// <summary>
	/// Represents a physical piece of equipment.
	/// </summary>
	public interface IDevice
	{
		/// <summary>
		/// Generic message from device.
		/// </summary>
		string Message { get; }

		/// <summary>
		/// Supported readings and their values.
		/// </summary>
		Dictionary<VariableType, decimal> Readings { get; }

		/// <summary>
		/// Fetch new values from the device.
		/// </summary>
		void Read();

		/// <summary>
		/// Change the device's control mode.
		/// </summary>
		/// <param name="mode">desired mode</param>
		void SetControlMode(ControlMode mode);

		/// <summary>
		/// Write setpoint(s) to the device.
		/// </summary>
		/// <param name="variable">which variable to write</param>
		/// <param name="value">desired value</param>
		void Write(VariableType variable, decimal value);
	}
}
