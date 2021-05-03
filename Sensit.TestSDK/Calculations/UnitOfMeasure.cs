using System.Collections.Generic;
using System.ComponentModel;

namespace Sensit.TestSDK.Calculations
{
	/// <summary>
	/// Enumerations for units of measurement
	/// </summary>
	[DisplayName("Unit Of Measure")]
	public static class UnitOfMeasure
	{
		public enum Length
		{
			Meters,
			Centimeters,
			Feet,
			Inches,
		}

		public enum Pressure
		{
			Kilopascals,
			Hectopascals,
			Millibar,
			Pascals,
			[Description("Inches of Water")]
			InchesOfWater,
			[Description("Feet of Water")]
			FeetOfWater,
			[Description("Inches of Mercury")]
			InchesOfMercury,
			PSI,
			[Description("Ounce Inches")]
			OunceInches,
			[Description("Millimeters of Water")]
			MillimetersOfWater,
			[Description("Centimeters of Water")]
			CentimetersOfWater,
			[Description("Millimeters of Mercury")]
			MillimetersOfMercury,
		}

		public enum Velocity
		{
			[Description("Meters per Second")]
			MetersPerSecond,
			[Description("Meters per Hour")]
			MetersPerHour,
			[Description("Kilometers per Hour")]
			KilometersPerHour,
			Knot,
			[Description("Miles per Hour")]
			MilesPerHour,
			[Description("Feet per Minute")]
			FeetPerMinute,
			[Description("Feet per Second")]
			FeetPerSecond,
		}

		public enum Flow
		{
			[Description("Cubic Meters per Second")]
			CubicMetersPerSecond,
			[Description("Cubic Meters per Hour")]
			CubicMetersPerHour,
			[Description("Cubic Feet per Minute")]
			CubicFeetPerMinute,
		}

		public enum Concentration
		{
			[Description("Parts per Billion")]
			PartsPerBillion,
			[Description("Parts per Million")]
			PartsPerMillion,
			[Description("Parts per Trillion")]
			PartsPerTrillion,
			[Description("Percent Volume")]
			PercentVolume
		}

		public enum Temperature
		{
			Celsius,
			Kelvin,
			Rankine,
			Fahrenheit,
		}

		public enum Current
		{
			Amp,
			Milliamp
		}

		public enum Voltage
		{
			Volt,
			Millivolt
		}

		#region Constants

		public static readonly double OFFSET_F_TO_R = 459.67;  // offset between °F and °R
		public static readonly double OFFSET_C_TO_K = 273.15;  // offset between °C and K
		public static readonly double OFFSET_C_TO_F = 32.0;    // offset between °C and °F

		#endregion Constants

		#region Conversion Factors

		// Conversion factors for length; the base unit is meters.
		private static readonly Dictionary<Length, double> LengthConversion =
			new Dictionary<Length, double>()
		{
			{ Length.Meters, 1.0 },
			{ Length.Centimeters, 100.0 },
			{ Length.Feet, 3.2808399 },
			{ Length.Inches, 39.370079}
		};

		// Conversion factors for pressure; KPA is the base unit.
		private static readonly Dictionary<Pressure, double> PressureConversion =
			new Dictionary<Pressure, double>()
		{
			{ Pressure.Kilopascals, 1.0 },
			{ Pressure.Hectopascals, 10.0 },
			{ Pressure.Millibar, 10.0 },
			{ Pressure.Pascals, 1000.0 },
			{ Pressure.InchesOfWater, 4.0146308 },
			{ Pressure.FeetOfWater, 0.33455256 },
			{ Pressure.InchesOfMercury, 0.29529987 },
			{ Pressure.PSI, 0.14503774 },
			{ Pressure.OunceInches, 2.3206038 },
			{ Pressure.MillimetersOfWater, 101.971621 },
			{ Pressure.CentimetersOfWater, 10.1971621 },
			{ Pressure.MillimetersOfMercury, 7.5006168 }
		};

		// Conversion factors for velocity; m/s is the base unit.
		private static readonly Dictionary<Velocity, double> VelocityConversion
			= new Dictionary<Velocity, double>()
		{
			{ Velocity.MetersPerSecond, 1.0 },
			{ Velocity.MetersPerHour, 3600.0 },
			{ Velocity.KilometersPerHour, 3.6 },
			{ Velocity.Knot, 1.9438445 },
			{ Velocity.MilesPerHour, 2.2369363 },
			{ Velocity.FeetPerMinute, 196.85039 },
			{ Velocity.FeetPerSecond, 3.2808399 }
		};

		// Conversion factors for volumetric flow; m^3/s is the base unit.
		private static readonly Dictionary<Flow, double> FlowConversion = new Dictionary<Flow, double>()
		{
			{ Flow.CubicMetersPerSecond, 1.0 },
			{ Flow.CubicMetersPerHour, 3600.0 },
			{ Flow.CubicFeetPerMinute, 2118.88 }
		};

		// Conversion factors for gas concentration; parts per million is the base unit.
		private static readonly Dictionary<Concentration, double> ConcentrationConversion = new Dictionary<Concentration, double>()
		{
			{ Concentration.PartsPerTrillion, 1000000.0 },
			{ Concentration.PartsPerBillion, 1000.0 },
			{ Concentration.PartsPerMillion, 1.0 },
			{ Concentration.PercentVolume, 1.0 / 10000.0 }
		};

		// Conversion factors for temperature; Celsius is the base unit.
		private static readonly Dictionary<Temperature, double> TemperatureConversion = new Dictionary<Temperature, double>()
		{
			{ Temperature.Celsius, 1.0 },
			{ Temperature.Kelvin, 1.0 },
			{ Temperature.Rankine, 9.0 / 5.0 },
			{ Temperature.Fahrenheit, 9.0 / 5.0 }
		};

		// Conversion factors for current; Amp is the base unit.
		private static readonly Dictionary<Current, double> CurrentConversion = new Dictionary<Current, double>()
		{
			{ Current.Amp, 1.0 },
			{ Current.Milliamp, 1000.0 }
		};

		// Conversion factors for voltage; Volt is the base unit.
		private static readonly Dictionary<Voltage, double> VoltageConversion = new Dictionary<Voltage, double>()
		{
			{ Voltage.Volt, 1.0 },
			{ Voltage.Millivolt, 1000.0 }
		};

		#endregion

		#region Unit Conversion

		/// <summary>
		/// Converts between various units of length.
		/// </summary>
		/// 
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// 
		/// <returns>the converted value</returns>
		public static double ConvertLength(double oldVal, Length oldUnit, Length newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / LengthConversion[oldUnit] * LengthConversion[newUnit]);
		}

		/// <summary>
		/// Converts between various units of pressure.
		/// </summary>
		/// 
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// 
		/// <returns>the converted value</returns>
		public static double ConvertPressure(double oldVal, Pressure oldUnit, Pressure newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / PressureConversion[oldUnit] * PressureConversion[newUnit]);
		}

		/// <summary>
		/// Converts between various units of velocity.
		/// </summary>
		/// 
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// 
		/// <returns>the converted value</returns>
		public static double ConvertVelocity(double oldVal, Velocity oldUnit, Velocity newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / VelocityConversion[oldUnit] * VelocityConversion[newUnit]);
		}

		/// <summary>
		/// Converts between various units of volumetric flow.
		/// </summary>
		/// 
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// 
		/// <returns>the converted value</returns>
		public static double ConvertFlow(double oldVal, Flow oldUnit, Flow newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / FlowConversion[oldUnit] * FlowConversion[newUnit]);
		}

		/// <summary>
		/// Converts between various units of gas concentration.
		/// </summary>
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// <returns></returns>
		public static double ConvertConcentration(double oldVal, Concentration oldUnit, Concentration newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / ConcentrationConversion[oldUnit] * ConcentrationConversion[newUnit]);
		}

		/// <summary>
		/// Converts between various units of temperature.
		/// </summary>
		/// 
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// 
		/// <remarks>
		/// If you want to convert a TEMPERATURE INTERVAL, use only Kelvin and
		/// Rankine and you'll save lots of math.
		/// 
		/// This function was derived by setting up a 4x4 chart of all possible
		/// temperature conversion formulas.  Separate the formulas by order of
		/// operations.  Notice that all temperature conversions can be
		/// represented by an addition, then multiplication, then an addition.
		/// Add if/then statements to do the correct additions and you're done.
		/// </remarks>
		/// 
		/// <returns>the result of the conversion</returns>
		public static double ConvertTemp(double oldVal, Temperature oldUnit, Temperature newUnit)
		{
			double temp = oldVal;       // temporary temperature interval

			// FIRST ADDITION:  Convert Celsius or Fahrenheit to Kelvin or Rankine.
			if (oldUnit == Temperature.Celsius)
			{
				if ((newUnit == Temperature.Kelvin) || (newUnit == Temperature.Rankine))
					temp += OFFSET_C_TO_K;
			}

			else if (oldUnit == Temperature.Fahrenheit)
			{
				if ((newUnit == Temperature.Kelvin) || (newUnit == Temperature.Rankine))
					temp += OFFSET_F_TO_R;
				else if (newUnit == Temperature.Celsius)
					temp -= OFFSET_C_TO_F;
			}

			// MULTIPLICATION:  Convert between Kelvin and Rankine.
			temp = (temp / TemperatureConversion[oldUnit] * TemperatureConversion[newUnit]);

			// SECOND ADDITION:  Convert Kelvin or Rankine to Celsius or Fahrenheit.
			if (newUnit == Temperature.Celsius)
			{
				if ((oldUnit == Temperature.Kelvin) || (oldUnit == Temperature.Rankine))
					temp -= OFFSET_C_TO_K;
			}

			else if (newUnit == Temperature.Fahrenheit)
			{
				if ((oldUnit == Temperature.Kelvin) || (oldUnit == Temperature.Rankine))
					temp -= OFFSET_F_TO_R;
				else if (oldUnit == Temperature.Celsius)
					temp += OFFSET_C_TO_F;
			}

			return temp;
		}

		/// <summary>
		/// Converts between various units of electrical current.
		/// </summary>
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// <returns></returns>
		public static double ConvertCurrent(double oldVal, Current oldUnit, Current newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / CurrentConversion[oldUnit] * CurrentConversion[newUnit]);
		}

		/// <summary>
		/// Converts between various units of electrical voltage.
		/// </summary>
		/// <param name="oldVal">the value to be converted</param>
		/// <param name="oldUnit">the original unit of measure</param>
		/// <param name="newUnit">the new unit of measure</param>
		/// <returns></returns>
		public static double ConvertVoltage(double oldVal, Voltage oldUnit, Voltage newUnit)
		{
			// Look up conversion from old unit to new unit.
			return (oldVal / VoltageConversion[oldUnit] * VoltageConversion[newUnit]);
		}

		#endregion
	}
}
