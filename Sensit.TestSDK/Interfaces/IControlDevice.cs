using System.ComponentModel;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// What the device should try to do.
	/// </summary>
	public enum ControlMode
	{
		Active,		// actively controlling the test environment
		Passive		// passively measuring the test environment
	}

	/// <summary>
	/// Device that controls one or more independent variables in a test.
	/// </summary>
	[Description("Control Device")]
	public interface IControlDevice
	{
		/// <summary>
		/// Change the device's control mode.
		/// </summary>
		/// <param name="mode"></param>
		void SetControlMode(ControlMode mode);

		/// <summary>
		/// Write the setpoint to the device.
		/// </summary>
		/// <remarks>
		/// Some processes need to control multiple variables at a time,
		/// but only one variable needs to vary.
		/// So this interface supports sending each setpoint individually.
		/// </remarks>
		/// <param name="type">variable of interest</param>
		/// <param name="setpoint"></param>
		void WriteSetpoint(VariableType type, double setpoint);

		/// <summary>
		/// Read the setpoint from the device.
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		double ReadSetpoint(VariableType type);
	}
}
