﻿using System.ComponentModel;
using Sensit.TestSDK.Calculations;

namespace Sensit.TestSDK.Interfaces
{
	public enum VariableType
	{
		[Description("Gas Mix")]
		GasConcentration,
		[Description("Mass Flow")]
		MassFlow,
		[Description("Volume Flow")]
		VolumeFlow,
		Velocity,
		Pressure,
		Temperature
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
	/// Device that measures one or more dependent variables in a test.
	/// </summary>
	/// <remarks>
	/// Don't implement this interface directly.
	/// Devices should implement one of the more specific interfaces below.
	/// </remarks>
	[Description("Reference Device")]
	public interface IReferenceDevice
	{
		/// <summary>
		/// Fetch new values from the device.
		/// </summary>
		/// <remarks>
		/// Some devices read out several variables in a single communication.
		/// For those devices, this method is where that single communication should happen,
		/// and then the Read command can fetch the individual values separately as needed.
		/// </remarks>
		void Update();

		/// <summary>
		/// Fetch the device's current readings/settings.
		/// </summary>
		/// <remarks>
		/// For convenience, this method returns the specified variable.
		/// </remarks>
		/// /// <param name="type">variable of interest</param>
		double Read(VariableType type);
	}

	/// <summary>
	/// Device that measures gas concentration.
	/// </summary>
	[Description("Gas Mix Reference")]
	public interface IGasMixReference : IMassFlowReference
	{
	}

	/// <summary>
	/// Device that measures gas mass flow.
	/// </summary>
	/// <remarks>
	/// May wish to split into two interfaces (mass and volumetric flow) in the future.
	/// </remarks>
	[Description("Gas Mass Flow Reference")]
	public interface IMassFlowReference : IReferenceDevice
	{
		UnitOfMeasure.Flow FlowUnit { get; set; }

		/// <summary>
		/// Gas used by device to calculate mass flow from volumetric flow.
		/// </summary>
		Gas GasSelection { get; set; }
	}

	/// <summary>
	/// Device that measures gas volumetric flow.
	/// </summary>
	[Description("Gas Volume Flow Reference")]
	public interface IVolumeFlowReference : IReferenceDevice
	{
		UnitOfMeasure.Flow FlowUnit { get; set; }
	}

	/// <summary>
	/// Device that measures gas velocity.
	/// </summary>
	[Description("Velocity Reference")]
	public interface IVelocityReference : IReferenceDevice
	{
		UnitOfMeasure.Velocity VelocityUnit { get; set; }
	}

	/// <summary>
	/// Device that measures pressure.
	/// </summary>
	[Description("Pressure Reference")]
	public interface IPressureReference : IReferenceDevice
	{
		UnitOfMeasure.Pressure PressureUnit { get; set; }
	}

	/// <summary>
	/// Device that measures temperature.
	/// </summary>
	[Description("Temperature Reference")]
	public interface ITemperatureReference : IReferenceDevice
	{
		UnitOfMeasure.Temperature TemperatureUnit { get; set; }
	}
}
