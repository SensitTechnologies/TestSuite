using Sensit.TestSDK.Calculations;      // define unit of measure

namespace Sensit.TestSDK.Interfaces
{
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
		void SetSetpoint(float setpoint);

		float GetSetpoint();

		void SetControlMode(ControlMode mode);
	}
}
