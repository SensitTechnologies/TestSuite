using Sensit.TestSDK.Calculations;      // define units of measure

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that measures one or more dependent variables in a test.
	/// </summary>
	/// <remarks>
	/// Don't implement this interface directly.
	/// Devices should implement one of the more specific interfaces below.
	/// </remarks>
	public interface IReferenceDevice
	{
		/// <summary>
		/// Send configuration (set through properties) to device.
		/// </summary>
		void Configure();

		/// <summary>
		/// Fetch the device's current readings/settings (accessible through properties).
		/// </summary>
		/// <remarks>
		/// Some processes need fast reads, and some devices measure multiple parameters
		/// with a single query.  So this interface supports reading all parameters
		/// at once.
		/// </remarks>
		void Read();
	}

	/// <summary>
	/// Gas Selection for Mass Flow Controllers
	/// </summary>
	public enum Gas
	{
		Air,
		Argon,
		Methane,
		CarbonMonoxide,
		CarbonDioxide,
		Ethane,
		Hydrogen,
		Helium,
		Nitrogen,
		NitrousOxide,
		Neon,
		Oxygen,
		Propane,
		normalButane,
		Acetylene,
		Ethylene,
		isoButane,
		Krypton,
		Xenon,
		SulfurHexafluoride,
		C25,					// 75% Argon / 25% CO2
		C10,					// 90% Argon / 10% CO2
		C8,						// 92% Argon / 8% CO2
		C2,						// 98% Argon / 2% CO2
		C75,					// 75% CO2 / 25% Argon
		He25,					// 75% Argon / 25% Helium
		He75,					// 75% Helium / 25% Argon
		A1025,					// 90% Helium / 7.5% Argon / 2.5% CO2 (Praxair - Helistar® A1025)
		Star29,					// 90% Argon / 8% CO2 / 2% Oxygen (Praxair - Stargon® CS)
		P5,						// 95% Argon / 5% Methane
	}

	/// <summary>
	/// Device that measures gas concentration.
	/// </summary>
	public interface IGasConcentrationReference : IReferenceDevice
	{
		/// <summary>
		/// Percent gas concentration.
		/// </summary>
		double Concentration { get; }
	}

	/// <summary>
	/// Device that measures gas mass flow.
	/// </summary>
	/// <remarks>
	/// May wish to split into two interfaces (mass and volumetric flow) in the future.
	/// </remarks>
	public interface IMassFlowReference : IReferenceDevice
	{
		UnitOfMeasure.Flow FlowUnit { get; set; }

		/// <summary>
		/// Gas used by device to calculate mass flow from volumetric flow.
		/// </summary>
		Gas GasSelection { get; set; }

		double MassFlow { get; }
	}

	/// <summary>
	/// Device that measures gas volumetric flow.
	/// </summary>
	public interface IVolumeFlowReference : IReferenceDevice
	{
		UnitOfMeasure.Flow FlowUnit { get; set; }

		double VolumeFlow { get; }
	}

	/// <summary>
	/// Device that measures gas velocity.
	/// </summary>
	public interface IVelocityReference : IReferenceDevice
	{
		UnitOfMeasure.Velocity VelocityUnit { get; set; }

		double Velocity { get; }
	}

	/// <summary>
	/// Device that measures pressure.
	/// </summary>
	public interface IPressureReference : IReferenceDevice
	{
		UnitOfMeasure.Pressure PressureUnit { get; set; }

		double Pressure { get; }
	}

	/// <summary>
	/// Device that measures temperature.
	/// </summary>
	public interface ITemperatureReference : IReferenceDevice
	{
		UnitOfMeasure.Temperature TemperatureUnit { get; set; }

		double Temperature { get; }
	}
}
