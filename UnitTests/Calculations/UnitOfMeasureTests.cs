using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Sensit.TestSDK.Calculations.UnitOfMeasure;

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
			Assert.AreEqual(1.0000000, ConvertLength(1.0, Length.Meters, Length.Meters), tolerance);

			// Convert 1 meter to centimeters.
			Assert.AreEqual(100.0000000, ConvertLength(1.0, Length.Meters, Length.Centimeters), tolerance);

			// Convert 1 meter to feet.
			Assert.AreEqual(3.2808399, ConvertLength(1.0, Length.Meters, Length.Feet), tolerance);

			// Convert 1 meter to inches.
			Assert.AreEqual(39.370079, ConvertLength(1.0, Length.Meters, Length.Inches), tolerance);
		}

		[TestMethod]
		public void TestConvertPressure()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1 kPa to kPa.
			Assert.AreEqual(1.0, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.Kilopascals), tolerance);

			// Convert 1 kPa to hPa.
			Assert.AreEqual(10.0, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.Hectopascals), tolerance);

			// Convert 1 kPa to mbar.
			Assert.AreEqual(10.0, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.Millibar), tolerance);

			// Convert 1 kPa to Pa.
			Assert.AreEqual(1000.0, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.Pascals), tolerance);

			// Convert 1 kPa to inwc.
			Assert.AreEqual(4.0146308, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.InchesOfWater), tolerance);

			// Convert 1 kPa to ftwc.
			Assert.AreEqual(0.33455256, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.FeetOfWater), tolerance);

			// Convert 1 kPa to inHg.
			Assert.AreEqual(0.29529987, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.InchesOfMercury), tolerance);

			// Convert 1 kPa to PSI.
			Assert.AreEqual(0.14503774, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.PSI), tolerance);

			// Convert 1 kPa to ozin.
			Assert.AreEqual(2.3206038, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.OunceInches), tolerance);

			// Convert 1 kPa to mmwc.
			Assert.AreEqual(101.971621, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.MillimetersOfWater), tolerance);

			// Convert 1 kPa to cmwc.
			Assert.AreEqual(10.1971621, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.CentimetersOfWater), tolerance);

			// Convert 1 kPa to mmHg.
			Assert.AreEqual(7.5006168, ConvertPressure(1.0, Pressure.Kilopascals, Pressure.MillimetersOfMercury), tolerance);
		}

		[TestMethod]
		public void TestConvertVelocity()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1 m/s to m/s.
			Assert.AreEqual(1.0, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.MetersPerSecond), tolerance);

			// Convert 1 m/s to m/h.
			Assert.AreEqual(3600.0, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.MetersPerHour), tolerance);

			// Convert 1 m/s to kph.
			Assert.AreEqual(3.6, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.KilometersPerHour), tolerance);

			// Convert 1 m/s to knot.
			Assert.AreEqual(1.9438445, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.Knot), tolerance);

			// Convert 1 m/s to mph.
			Assert.AreEqual(2.2369363, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.MilesPerHour), tolerance);

			// Convert 1 m/s to ft/min.
			Assert.AreEqual(196.85039, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.FeetPerMinute), tolerance);

			// Convert 1 m/s to ft/s.
			Assert.AreEqual(3.2808399, ConvertVelocity(1.0, Velocity.MetersPerSecond, Velocity.FeetPerSecond), tolerance);
		}

		[TestMethod]
		public void TestConvertFlow()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1.0 m^3/s to m^3/s.
			Assert.AreEqual(1.0, ConvertFlow(1.0, Flow.CubicMetersPerSecond, Flow.CubicMetersPerSecond), tolerance);

			// Convert 1.0 m^3/s to m^3/h.
			Assert.AreEqual(3600, ConvertFlow(1.0, Flow.CubicMetersPerSecond, Flow.CubicMetersPerHour), tolerance);

			// Convert 1.0 m^3/s to ft^3/min.
			Assert.AreEqual(2118.88, ConvertFlow(1.0, Flow.CubicMetersPerSecond, Flow.CubicFeetPerMinute), tolerance);
		}

		[TestMethod]
		public void TestConvertConcentration()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Convert 1.0 ppb to ppb.
			Assert.AreEqual(1.0, ConvertConcentration(1.0, Concentration.PartsPerBillion, Concentration.PartsPerBillion), tolerance);

			// Convert 1.0 ppb to ppm.
			Assert.AreEqual(0.001, ConvertConcentration(1.0, Concentration.PartsPerBillion, Concentration.PartsPerMillion), tolerance);

			// Convert 1.0 ppb to ppt.
			Assert.AreEqual(1000.0, ConvertConcentration(1.0, Concentration.PartsPerBillion, Concentration.PartsPerTrillion), tolerance);

			// Convert 1.0 ppb to %V.
			Assert.AreEqual(0.0000001, ConvertConcentration(1.0, Concentration.PartsPerBillion, Concentration.PercentVolume), tolerance);
		}

		[TestMethod]
		public void TestConvertTemperature()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.005;

			// Convert 1°C to 33.8°F.
			Assert.AreEqual(33.8, ConvertTemp(1.0, Temperature.Celsius, Temperature.Fahrenheit), tolerance);

			// Convert 1°C to 493.47°R.
			Assert.AreEqual(493.47, ConvertTemp(1.0, Temperature.Celsius, Temperature.Rankine), tolerance);

			// Convert 1°C to 274.15K.
			Assert.AreEqual(274.15, ConvertTemp(1.0, Temperature.Celsius, Temperature.Kelvin), tolerance);

			// Convert 1°C to 1°C.
			Assert.AreEqual(1.0, ConvertTemp(1.0, Temperature.Celsius, Temperature.Celsius), tolerance);

			// Convert 1°F to -17.22°C.
			Assert.AreEqual(-17.22, ConvertTemp(1.0, Temperature.Fahrenheit, Temperature.Celsius), tolerance);
		}

		[TestMethod]
		public void TestConvertCurrent()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.005;

			// Convert 1 mA to 0.001 A.
			Assert.AreEqual(0.001, ConvertCurrent(1.0, Current.Milliamp, Current.Amp), tolerance);

			// Convert 1 mA to 1 mA.
			Assert.AreEqual(1.0, ConvertCurrent(1.0, Current.Milliamp, Current.Milliamp), tolerance);
		}

		[TestMethod]
		public void TestConvertVoltage()
		{
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.005;

			// Convert 1 mV to 0.001 V.
			Assert.AreEqual(0.001, ConvertVoltage(1.0, Voltage.Millivolt, Voltage.Volt), tolerance);

			// Convert 1 mV to 1 mV.
			Assert.AreEqual(1.0, ConvertVoltage(1.0, Voltage.Volt, Voltage.Volt), tolerance);
		}
	}
}
