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
	/// <remarks>
	/// Don't implement this interface directly.
	/// Devices should implement one of the more specific interfaces below.
	/// </remarks>
	public interface IControlDevice
	{
		/// <summary>
		/// Change the device's control mode.
		/// </summary>
		/// <param name="mode"></param>
		void SetControlMode(ControlMode mode);
	}

	/// <summary>
	/// Device that controls gas mass flow.
	/// </summary>
	public interface IMassFlowController : IControlDevice
	{
		/// <summary>
		/// Value the device should try to achieve when in Control Mode.
		/// </summary>
		float MassFlowSetpoint { get; set; }

		/// <summary>
		/// Write the setpoint to the device.
		/// </summary>
		/// <remarks>
		/// Some processes need to control multiple variables at a time,
		/// but only one variable needs to vary.
		/// So this interface supports sending each setpoint individually.
		/// </remarks>
		void WriteMassFlowSetpoint();

		/// <summary>
		/// Write the setpoint to the device.
		/// </summary>
		/// <remarks>
		/// For convenience, this method sets the property and writes it to the device.
		/// So we can write one line of code instead of two.
		/// </remarks>
		/// <param name="setpoint"></param>
		void WriteMassFlowSetpoint(float setpoint);

		/// <summary>
		/// Read the setpoint from the device.
		/// </summary>
		float ReadMassFlowSetpoint();
	}

	/// <summary>
	/// Device that controls gas volume flow.
	/// </summary>
	public interface IVolumeFlowController : IControlDevice
	{
		float VolumeFlowSetpoint { get; set; }

		void WriteVolumeFlowSetpoint();

		void WriteVolumeFlowSetpoint(float setpoint);

		float ReadVolumeFlowSetpoint();
	}

	/// <summary>
	/// Device that controls gas velocity (i.e. a wind tunnel).
	/// </summary>
	public interface IVelocityController : IControlDevice
	{
		float VelocitySetpoint { get; set; }

		void WriteVelocitySetpoint();

		void WriteVelocitySetpoint(float setpoint);

		float ReadVelocitySetpoint();
	}

	/// <summary>
	/// Device that controls pressure.
	/// </summary>
	public interface IPressureController : IControlDevice
	{
		float PressureSetpoint { get; set; }

		void WritePressureSetpoint();

		void WritePressureSetpoint(float setpoint);

		float ReadPressureSetpoint();
	}

	/// <summary>
	/// Device that controls temperature.
	/// </summary>
	public interface ITemperatureController : IControlDevice
	{
		float TemperatureSetpoint { get; set; }

		void WriteTemperatureSetpoint();

		void WriteTemperatureSetpoint(float setpoint);

		float ReadTemperatureSetpoint();
	}
}
