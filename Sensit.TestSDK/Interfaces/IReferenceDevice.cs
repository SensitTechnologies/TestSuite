﻿using Sensit.TestSDK.Calculations;      // define units of measure

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that measures one or more dependent variables in a test.
	/// </summary>
	public interface IReferenceDevice
	{
		/// <summary>
		/// Send configuration (set through properties) to device.
		/// </summary>
		void Configure();

		/// <summary>
		/// Fetch the device's current readings/settings (accessible through properties).
		/// </summary>
		void Read();

		// TODO:  Are "Prompt" or "SetReading" methods necessary to support manual reference?
		// Or maybe instead of returning a variable, ref it instead?
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
	/// Device that measures mass flow and volumetric flow.
	/// </summary>
	/// <remarks>
	/// May wish to split into two interfaces (mass and volumetric flow) in the future.
	/// </remarks>
	public interface IFlowReference : IReferenceDevice
	{
		UnitOfMeasure.Flow FlowUnit { get; set; }

		/// <summary>
		/// Gas used by device to calculate mass flow from volumetric flow.
		/// </summary>
		Gas GasSelection { get; set; }

		float VolumeFlow { get; }
		float MassFlow { get; }
	}

	public interface IPressureReference : IReferenceDevice
	{
		UnitOfMeasure.Pressure PressureUnit { get; set; }

		float Pressure { get; }
	}

	/// <summary>
	/// Device that measures temperature.
	/// </summary>
	public interface ITemperatureReference : IReferenceDevice
	{
		UnitOfMeasure.Temperature TemperatureUnit { get; set; }

		float Temperature { get; }
	}
}