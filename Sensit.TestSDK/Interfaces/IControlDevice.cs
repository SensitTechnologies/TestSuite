using Sensit.TestSDK.Calculations;      // define unit of measure

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// What the device should try to do.
	/// </summary>
	public enum ControlMode
	{
		Vent,		// no active effect on test environment
		Control,	// actively controlling the test environment
		Measure		// passively measuring the test environment
	}

	/// <summary>
	/// Device that controls one or more independent variables in a test.
	/// </summary>
	public interface IControlDevice
	{
		/// <summary>
		/// Value the device should try to achieve when in Control Mode.
		/// </summary>
		float Setpoint { get; set; }

		/// <summary>
		/// Write the setpoint to the device.
		/// </summary>
		void WriteSetpoint();

		/// <summary>
		/// Read the setpoint from the device.
		/// </summary>
		void ReadSetpoint();

		/// <summary>
		/// Change the device's control mode.
		/// </summary>
		/// <param name="mode"></param>
		void SetControlMode(ControlMode mode);
	}
}
