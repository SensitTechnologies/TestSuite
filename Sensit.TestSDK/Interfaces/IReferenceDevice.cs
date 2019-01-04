using Sensit.TestSDK.Calculations;      // define units of measure

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that measures one or more dependent variables in a test.
	/// </summary>
	public interface IReferenceDevice
	{
		double GetReading();

		// TODO:  Are "Prompt" or "SetReading" methods necessary to support manual reference?
		// Or maybe instead of returning a variable, ref it instead?
	}

	/// <summary>
	/// Device that measures temperature.
	/// </summary>
	public interface ITemperatureReference : IReferenceDevice
	{
		UnitOfMeasure.Temperature TemperatureUnit { get; }

		void Config(UnitOfMeasure.Temperature unit, double low, double high);
	}
	
	// TODO:  Make this work with MFC.cs and IReferenceDevice.cs!
	public enum Gas
	{
		Air,
		Ar,						// Argon
		CH4,					// Methane
		CO,						// Carbon Monoxide
		CO2,					// Carbon Dioxide
		C2H6,					// Ethane
		H2,						// Hydrogen
		He,						// Helium
		N2,						// Nitrogen
		N2O,					// Nitrous Oxide
		Ne,						// Neon
		O2,						// Oxygen
		C3H8,					// Propane
		nC4H10,					// normal-Butane
		C2H2,					// Acetylene
		C2H4,					// Ethylene
		iC4H10,					// isoButane (code in manual has typo)
		Kr,						// Krypton
		Xe,						// Xenon
		SF6,					// Sulfur Hexafluoride
		C25,					// 75% Argon / 25% CO2
		C10,					// 90% Argon / 10% CO2
		C8,						// 92% Argon / 8% CO2
		C2,						// 98% Argon / 2% CO2
		C75,					// 75% CO2 / 25% Argon
		He25,					// 75% Argon / 25% Helium (code in manual has typo)
		He75,					// 75% Helium / 25% Argon (code in manual has typo)
		A1025,					// 90% Helium / 7.5% Argon / 2.5% CO2 (Praxair - Helistar® A1025)
		Star29,					// 90% Argon / 8% CO2 / 2% Oxygen (Praxair - Stargon® CS)
		P5,						// 95% Argon / 5% Methane
	}

	/// <summary>
	/// Device that measures mass flow and volumetric flow.
	/// </summary>
	/// <remarks>
	/// May wish to split into two interfaces (mass and volumetric flow) in the future.
	/// </remarks>
	public interface IFlowReference : IReferenceDevice
	{
		UnitOfMeasure.Temperature TemperatureUnit { get; }
		UnitOfMeasure.Flow FlowUnit { get; }

		// TODO:  GasSelection gas { get; }

		void Config(UnitOfMeasure.Flow flowUnit, UnitOfMeasure.Temperature temperatureUnit,
			double low, double high);
	}


}
