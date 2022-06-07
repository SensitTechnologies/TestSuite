using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Calculations;

namespace UnitTests.Calculations
{
	[TestClass]
	public class CalculationsTests
	{
		[TestMethod]
		public void ScaleTest()
		{
			// Arrange.
			const double x1 = 1;
			const double x2 = 50;
			const double y1 = 50;
			const double y2 = 1;
			const double x = 2;

			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Act.
			double scaledValue = Calculate.Scale(x, x1, x2, y1, y2);

			// Assert.
			Assert.AreEqual(49, scaledValue, tolerance);
		}

		[TestMethod]
		public void PolynomialTest()
		{
			// Arrange.
			// Test polynomial is y = x^2 + 2x + 3, where x = 5.
			// Result is y = 25 + 10 + 3 = 38.
			List<double> coefficients = new() { 1, 2, 3 };
			const double x = 5;

			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.00000005;

			// Act.
			double result = Calculate.Polynomial(coefficients, x);

			// Assert.
			Assert.AreEqual(38, result, tolerance);
		}

		[TestMethod]
		public void ExpAverageTest()
		{
			// Arrange.
			// Create a list of data that represents a step response from 0 to 100% over 10 seconds.
			List<double> data = new() { 0, 100, 100, 100, 100, 100, 100, 100, 100, 100, 100 };

			// Pretend the data was taken once per second.
			double period = 1.0;

			// We wish to take 10 seconds to get within 1% of final value (100%).
			// Divide by 5 to give time constant of 2 seconds.
			double tau = 2.0;

			// Since we want to be within 1% of our final value after two seconds,
			// our tolerance for the test is 1%.
			double tolerance = 1.0;

			// Initial average is the first data point.
			double average = data[0];

			// Act and assert.
			// Input each data point into the exponential averaging method.
			// Check the results against known values that make an exponential curve.
			List<double> expectedResults = new() { 0.0, 39.3, 63.2, 77.7, 86.5, 91.8, 95.0, 97.0, 98.2, 98.9, 99.3 };
			for (int i = 0; i < data.Count; i++)
			{
				average = Calculate.ExpAverage(average, data[i], period, tau);
				Assert.AreEqual(expectedResults[i], average, tolerance);
			}
		}

		[TestMethod]
		public void VelocityTest()
		{
			// Arrange.
			double pressure = 100.0;
			double temperature = 25.0;
			double kFactor = 2.0;
			// amount of error allowed (half the value of the least significant digit of precision)
			const double tolerance = 0.005;

			// Act.
			double velocity = Calculate.Velocity(pressure, temperature, kFactor);

			// Assert.
			Assert.AreEqual(2 * 413.688, velocity, tolerance);
		}
	}
}
