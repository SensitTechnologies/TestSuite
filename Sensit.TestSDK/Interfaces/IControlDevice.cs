using System.ComponentModel;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// What the device should try to do.
	/// </summary>
	public enum ControlMode
	{
		Ambient,	// vent to external environment if possible
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

	/// <summary>
	/// Device that controls gas concentration (and mass flow).
	/// </summary>
	[Description("Gas Mixer")]
	public interface IGasMixController : IMassFlowController
	{
	}

	/// <summary>
	/// Device that controls gas mass flow.
	/// </summary>
	[Description("Mass Flow Controller")]
	public interface IMassFlowController : IControlDevice
	{
	}

	/// <summary>
	/// Device that controls gas volume flow.
	/// </summary>
	[Description("Volume Flow Controller")]
	public interface IVolumeFlowController : IControlDevice
	{
	}

	/// <summary>
	/// Device that controls gas velocity (i.e. a wind tunnel).
	/// </summary>
	[Description("Velocity Controller")]
	public interface IVelocityController : IControlDevice
	{
	}

	/// <summary>
	/// Device that controls pressure.
	/// </summary>
	[Description("Pressure Controller")]
	public interface IPressureController : IControlDevice
	{
	}

	/// <summary>
	/// Device that controls temperature.
	/// </summary>
	[Description("Temperature Controller")]
	public interface ITemperatureController : IControlDevice
	{
	}
}
