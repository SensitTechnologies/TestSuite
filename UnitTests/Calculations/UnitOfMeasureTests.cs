using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Calculations;

namespace UnitTests.Calculations
{
	[TestClass]
	public class UnitOfMeasureTests
	{
		[TestMethod]
		public void TestConvertLength()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1 meter to 1 meter.
			Assert.AreEqual(1.0000000, UnitOfMeasure.ConvertLength(1.0, UnitOfMeasure.Length.Meters, UnitOfMeasure.Length.Meters), tolerance);

			// Convert 1 meter to centimeters.
			Assert.AreEqual(100.0000000, UnitOfMeasure.ConvertLength(1.0, UnitOfMeasure.Length.Meters, UnitOfMeasure.Length.Centimeters), tolerance);

			// Convert 1 meter to feet.
			Assert.AreEqual(3.2808399, UnitOfMeasure.ConvertLength(1.0, UnitOfMeasure.Length.Meters, UnitOfMeasure.Length.Feet), tolerance);

			// Convert 1 meter to inches.
			Assert.AreEqual(39.370079, UnitOfMeasure.ConvertLength(1.0, UnitOfMeasure.Length.Meters, UnitOfMeasure.Length.Inches), tolerance);
		}

		[TestMethod]
		public void TestConvertPressure()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1 kPa to kPa.
			Assert.AreEqual(1.0, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.Kilopascals), tolerance);

			// Convert 1 kPa to hPa.
			Assert.AreEqual(10.0, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.Hectopascals), tolerance);

			// Convert 1 kPa to mbar.
			Assert.AreEqual(10.0, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.Millibar), tolerance);

			// Convert 1 kPa to Pa.
			Assert.AreEqual(1000.0, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.Pascals), tolerance);

			// Convert 1 kPa to inwc.
			Assert.AreEqual(4.0146308, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.InchesOfWater), tolerance);

			// Convert 1 kPa to ftwc.
			Assert.AreEqual(0.33455256, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.FeetOfWater), tolerance);

			// Convert 1 kPa to inHg.
			Assert.AreEqual(0.29529987, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.InchesOfMercury), tolerance);

			// Convert 1 kPa to PSI.
			Assert.AreEqual(0.14503774, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.PSI), tolerance);

			// Convert 1 kPa to ozin.
			Assert.AreEqual(2.3206038, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.OunceInches), tolerance);

			// Convert 1 kPa to mmwc.
			Assert.AreEqual(101.971621, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.MillimetersOfWater), tolerance);

			// Convert 1 kPa to cmwc.
			Assert.AreEqual(10.1971621, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.CentimetersOfWater), tolerance);

			// Convert 1 kPa to mmHg.
			Assert.AreEqual(7.5006168, UnitOfMeasure.ConvertPressure(1.0, UnitOfMeasure.Pressure.Kilopascals, UnitOfMeasure.Pressure.MillimetersOfMercury), tolerance);
		}

		[TestMethod]
		public void TestConvertVelocity()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1 m/s to m/s.
			Assert.AreEqual(1.0, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.MetersPerSecond), tolerance);

			// Convert 1 m/s to m/h.
			Assert.AreEqual(3600.0, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.MetersPerHour), tolerance);

			// Convert 1 m/s to kph.
			Assert.AreEqual(3.6, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.KilometersPerHour), tolerance);

			// Convert 1 m/s to knot.
			Assert.AreEqual(1.9438445, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.Knot), tolerance);

			// Convert 1 m/s to mph.
			Assert.AreEqual(2.2369363, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.MilesPerHour), tolerance);

			// Convert 1 m/s to ft/min.
			Assert.AreEqual(196.85039, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.FeetPerMinute), tolerance);

			// Convert 1 m/s to ft/s.
			Assert.AreEqual(3.2808399, UnitOfMeasure.ConvertVelocity(1.0, UnitOfMeasure.Velocity.MetersPerSecond, UnitOfMeasure.Velocity.FeetPerSecond), tolerance);
		}

		[TestMethod]
		public void TestConvertFlow()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1.0 m^3/s to m^3/s.
			Assert.AreEqual(1.0, UnitOfMeasure.ConvertFlow(1.0, UnitOfMeasure.Flow.CubicMetersPerSecond, UnitOfMeasure.Flow.CubicMetersPerSecond), tolerance);

			// Convert 1.0 m^3/s to m^3/h.
			Assert.AreEqual(3600, UnitOfMeasure.ConvertFlow(1.0, UnitOfMeasure.Flow.CubicMetersPerSecond, UnitOfMeasure.Flow.CubicMetersPerHour), tolerance);

			// Convert 1.0 m^3/s to ft^3/min.
			Assert.AreEqual(2118.88, UnitOfMeasure.ConvertFlow(1.0, UnitOfMeasure.Flow.CubicMetersPerSecond, UnitOfMeasure.Flow.CubicFeetPerMinute), tolerance);
		}

		[TestMethod]
		public void TestConvertConcentration()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1.0 ppb to ppb.
			Assert.AreEqual(1.0, UnitOfMeasure.ConvertConcentration(1.0, UnitOfMeasure.Concentration.PartsPerBillion, UnitOfMeasure.Concentration.PartsPerBillion), tolerance);

			// Convert 1.0 ppb to ppm.
			Assert.AreEqual(0.001, UnitOfMeasure.ConvertConcentration(1.0, UnitOfMeasure.Concentration.PartsPerBillion, UnitOfMeasure.Concentration.PartsPerMillion), tolerance);

			// Convert 1.0 ppb to ppt.
			Assert.AreEqual(1000.0, UnitOfMeasure.ConvertConcentration(1.0, UnitOfMeasure.Concentration.PartsPerBillion, UnitOfMeasure.Concentration.PartsPerTrillion), tolerance);

			// Convert 1.0 ppb to %V.
			Assert.AreEqual(0.0000001, UnitOfMeasure.ConvertConcentration(1.0, UnitOfMeasure.Concentration.PartsPerBillion, UnitOfMeasure.Concentration.PercentVolume), tolerance);
		}

		[TestMethod]
		public void TestConvertTemperature()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.005;

			// Convert 1°C to 33.8°F.
			Assert.AreEqual(33.8, UnitOfMeasure.ConvertTemp(1.0, UnitOfMeasure.Temperature.Celsius, UnitOfMeasure.Temperature.Fahrenheit), tolerance);

			// Convert 1°C to 493.47°R.
			Assert.AreEqual(493.47, UnitOfMeasure.ConvertTemp(1.0, UnitOfMeasure.Temperature.Celsius, UnitOfMeasure.Temperature.Rankine), tolerance);

			// Convert 1°C to 274.15K.
			Assert.AreEqual(274.15, UnitOfMeasure.ConvertTemp(1.0, UnitOfMeasure.Temperature.Celsius, UnitOfMeasure.Temperature.Kelvin), tolerance);

			// Convert 1°C to 1°C.
			Assert.AreEqual(1.0, UnitOfMeasure.ConvertTemp(1.0, UnitOfMeasure.Temperature.Celsius, UnitOfMeasure.Temperature.Celsius), tolerance);

			// Convert 1°F to -17.22°C.
			Assert.AreEqual(-17.22, UnitOfMeasure.ConvertTemp(1.0, UnitOfMeasure.Temperature.Fahrenheit, UnitOfMeasure.Temperature.Celsius), tolerance);
		}
	}
}
