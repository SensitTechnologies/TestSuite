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
		[Description("Ch 1 Current")]
		Current1,
		[Description("Ch 1 Voltage")]
		Voltage1,
		[Description("Ch 2 Current")]
		Current2,
		[Description("Ch 2 Voltage")]
		Voltage2,
		[Description("Ch 3 Current")]
		Current3,
		[Description("Ch 3 Voltage")]
		Voltage3,
		[Description("Ch 4 Current")]
		Current4,
		[Description("Ch 4 Voltage")]
		Voltage4
	}

	/// <summary>
	/// Gas Selection for Mass Flow Controllers
	/// </summary>
	public enum Gas
	{
		Air,
		Argon,
		Methane,
		[Description("Carbon Monoxide")]
		CarbonMonoxide,
		[Description("Carbon Dioxide")]
		CarbonDioxide,
		Ethane,
		Hydrogen,
		[Description("Hydrogen Sulfide")]
		HydrogenSulfide,
		[Description("Hydrogen Cyanide")]
		HydrogenCyanide,
		Helium,
		Nitrogen,
		[Description("Nitrous Oxide")]
		NitrousOxide,
		Neon,
		Oxygen,
		Propane,
		[Description("Normal Butane")]
		normalButane,
		Acetylene,
		Ethylene,
		isoButane,
		Krypton,
		Xenon,
		[Description("Sulfur Hexafluoride")]
		SulfurHexafluoride,
		[Description("75% Argon / 25% CO2")]
		C25,
		[Description("90% Argon / 10% CO2")]
		C10,
		[Description("92% Argon / 8% CO2")]
		C8,
		[Description("98% Argon / 2% CO2")]
		C2,
		[Description("75% CO2 / 25% Argon")]
		C75,
		[Description("75% Argon / 25% Helium")]
		He25,
		[Description("75% Helium / 25% Argon")]
		He75,
		[Description("90% Helium / 7.5% Argon / 2.5% CO2 (Praxair - Helistar® A1025)")]
		A1025,
		[Description("90% Argon / 8% CO2 / 2% Oxygen (Praxair - Stargon® CS)")]
		Star29,
		[Description("95% Argon / 5% Methane")]
		P5,
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
		/// Supported setpoints and their values.
		/// </summary>
		/// <remarks>
		/// Intended to be used to read, not write, setpoints.
		/// </remarks>
		Dictionary<VariableType, decimal> Setpoints { get; }

		/// <summary>
		/// Fetch new values from the device.
		/// </summary>
		void WriteThenRead();

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
