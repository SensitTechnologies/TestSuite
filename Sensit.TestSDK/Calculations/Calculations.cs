using System;
using System.Collections.Generic;

namespace Sensit.TestSDK.Calculations
{
	public class Calculations
	{
		#region Constants

		public static readonly double R_AIR = 0.2870;			// specific gas constant for air [kJ/(kg*K)]
		public static readonly double STD_P = 100;				// standard barometric air pressure [kPa]
		public static readonly double STD_T = 25;               // standard temperature [°C]

		#endregion Constants

		#region General Math

		/// <summary>
		/// Converts a scaled value from one scale to another.
		/// </summary>
		/// 
		/// <param name="X"></param>
		/// <param name="X1"></param>
		/// <param name="X2"></param>
		/// <param name="Y1"></param>
		/// <param name="Y2"></param>
		/// 
		/// <remarks>
		/// X1, X2 is the range of the original scale.
		/// Y1, Y2 is the range of the new scale.
		/// </remarks>
		/// 
		/// <returns>the result of the conversion (0.0 if error)</returns>
		public static double Scale(double X, double X1, double X2, double Y1, double Y2)
		{
			double denominator = X2 - X1;		// size of old scale

			// Don't divide by zero!
			double result;
			if (denominator == 0.0)
			{
				// If we're dividing by zero, just return 0.0.
				result = 0.0;
			}
			else
			{
				result = ((Y2 * (X - X1)) + (Y1 * (X2 - X))) / denominator;
			}

			return result;
		}

		/// <summary>
		/// Calculates the output of a polynomial of the form
		/// y = C_n * (x^n) + C_n-1 * (x^(n-1)) ... + C0
		/// </summary>
		/// <param name="c">list of coefficients</param>
		/// <param name="x">the independent variable</param>
		/// <returns>the dependent variable</returns>
		public static double Polynomial(List<double> c, double x)
		{
			// Start with the first coefficient.
			double y = c[c.Count];

			// For each coefficient...
			foreach (var v in c)
			{
				// Multiply by x.
				y *= x;

				// Add next coefficient.
				y += v;
			}

			// Return the result.
			return y;
		}

		/// <summary>
		/// Calculates area of a shape given the type of shape, its width, and length.
		/// </summary>
		/// 
		/// <remarks>
		/// If the function doesn't recognize the type of shape, it assumes an ellipse.
		/// </remarks>
		/// 
		/// <param name="shape">enumerated type of shape</param>
		/// <param name="xDim">x dimension of the shape</param>
		/// <param name="yDim">y dimension of the shape</param>
		/// <returns></returns>
		public static double Area(UnitOfMeasure.Shape shape, double xDim, double yDim)
		{
			double area;

			// RECTANGLE:  A = (x)(y)
			if (shape == UnitOfMeasure.Shape.Rectangle)
			{
				area = xDim * yDim;
			}
			// CIRCLE & ELLIPSE:  A = PI(r1)(r2)
			else
			{
				area = Math.PI * (xDim / 2) * (yDim / 2);
			}

			return area;
		}

		/// <summary>
		/// Calculates a moving average (without a buffer).
		/// </summary>
		/// 
		/// <remarks>
		/// See Wikipedia entry for "Modified Moving Average".
		/// </remarks>
		/// 
		/// <param name="avgPrev">the previous average; use newSample the first time the function is run</param>
		/// <param name="newSample">a new value to be added to the average</param>
		/// <param name="numSamples">the number of samples to be averaged</param>
		/// 
		/// <returns>the new average</returns>
		public static double ModifiedMovingAvarage(double avgPrev, double newSample, uint numSamples)
		{
			return (avgPrev * (numSamples - 1) + newSample) / numSamples;
		}

		/// <summary>
		/// Calculates an exponentially weighted average.
		/// </summary>
		/// 
		/// <remarks>
		/// Calculates an exponentially weighted average according to the formula
		/// 
		/// y(t+1) = y(t) + k(x(t) - y(t)), where
		/// 
		/// y(t) is current averaged output,
		/// y(t+1) is the next output,
		/// k is the damping factor according to
		///		k = 1 - e^(-1/(r*t), where
		///			r = sample rate [samples/second]
		///			t = filter time constant [seconds]
		///		or k = 1 - e^(-p/t), where
		///			p = sample period [seconds/sample], and
		///			t = filter time constant [seconds].
		///	
		/// The time constant (t) represents the time it takes this function's
		/// step response to reach 1 - 1/e (or 63.2) percent of it's final
		/// value.  5 time constants gives about 99% of the final value.  See
		/// Wikipedia entry for "Time constant."
		/// 
		/// For most applications, we want the average to get close to the
		/// final value within a certain time period.  For example, we may wish
		/// to take 10 seconds to get within 1% of the new value.  1 - 1/e^5
		/// gives close to 99%, so divide 10 seconds by 5 to get a time constant
		/// of 2 seconds.
		/// </remarks>
		/// 
		/// <param name="avgPrev">the previous average; use newSample the first time the method is called</param>
		/// <param name="newSample">a new value to be added to the average</param>
		/// <param name="period">the time period to be added to the average</param>
		/// <param name="tau">time constant for filter</param>
		/// 
		/// <returns>the new average</returns>
		public static double ExpAverage(double avgPrev, double newSample, double period, double tau)
		{
			double k = 1.0 - Math.Exp((-1.0 * period) / tau);

			return avgPrev + k * (newSample - avgPrev);
		}

		#endregion

		#region Metrology

		/// <summary>
		/// Calculate velocity from pressure, temperature, and k-factor.
		/// </summary>
		/// 
		/// <param name="pressure"> differential pitot tube pressure</param>
		/// <param name="temperature">ambient temperature [°C]</param>
		/// <param name="kFact">k-factor (hopefully of the duct under test)</param>
		/// 
		/// <remarks>
		/// Note that temperature is used here...cause it's possible to
		/// compensate the pressure sensor for temperature effects yet ignore
		/// temperature effects on the density of air when finding velocity.  I
		/// choose not to ignore such things.  This function does, however,
		/// ignore effects of barometric pressure, since I've no way to measure
		/// it, and assumes a barametric pressure of 100 kPa.
		/// 
		/// We start with this equation:
		/// 
		/// V = k * sqrt[2(Rs)(P)(T)/Pb], where
		/// 
		/// V = velocity [m/s]
		/// Rs = specific gas constant for air [0.2870 kJ/(kg*K)]
		/// P = pressure [Pa]
		/// T = temperature [K]
		/// Pb = barametric pressure [100 kPa]
		/// k = true velocity / measured velocity [unitless]
		/// 
		/// ...but we convert from initial values in degrees C and kPa.
		/// 
		/// The "k-factor" is necessary because of duct parameters like throw
		/// pattern, shape, size, construction materials, and proximity of
		/// dampers or elbows to the measurement site.  All these variables can
		/// make the measured velocity at one point in the duct different than
		/// the velocity in the rest of the system.  The k-factor, supplied by
		/// the duct manufacturer, is a unitless ratio of velocity in the
		/// system to the velocity measured at a point the user can access.
		/// </remarks>
		/// 
		/// <returns>air velocity, compensated for temperature</returns>
		public static double Velocity(double pressure, double temperature, double kFact)
		{
			// Convert temperature from Celsius to Kelvin.
			temperature += UnitOfMeasure.OFFSET_C_TO_K;

			// Convert pressure from kPa to Pa.
			pressure *= 1000.0;

			// Calculate the square of velocity from pressure.
			double velocitySquared = 2 * R_AIR * pressure * temperature / STD_P;

			// Make sure argument of sqrt() is not negative, but preserve the sign.
			int sign;
			if (velocitySquared < 0.0)
			{
				velocitySquared *= -1;
				sign = -1;
			}
			else
			{
				sign = 1;
			}

			// Take the square root and multiple by kFact to complete the equation.
			return Math.Sqrt(velocitySquared) * kFact * sign;
		}

		/// <summary>
		/// Calculates volumetric flow from velocity and area.
		/// </summary>
		/// <param name="velocity">air velocity</param>
		/// <param name="area">area of duct</param>
		/// <returns>area of the shape</returns>
		public static double Flow(double velocity, double area)
		{
			return velocity * area;
		}

		/// <summary>
		/// Calculate Actual air velocity given standard air velocity, ambient temperature,
		/// dew point temperature and barometeric pressure. 
		/// (Output velocity unit same as input velocity unit)
		/// </summary>
		/// <param name="std_velocity">Standard velocity</param>
		/// <param name="ambient_temp">Ambient temperature in °C</param>
		/// <param name="dewpoint_temp">Dew Point temperature in °C</param>
		/// <param name="bp">Barometeric pressure in mmHg</param>
		/// <returns>Actual air velocity</returns>
		public static double ActualVelocity(double std_velocity, double ambient_temp, double dewpoint_temp, double bp)
		{
			// Correct for Temperature and Pressure
			double velocity_dry = std_velocity * ((273 + ambient_temp) / (273 + 21.1)) * (760 / bp);

			// Correct for Humidity
			return bp * velocity_dry / (bp - VaporPressure(dewpoint_temp));
		}

		/// <summary>
		/// Calculate the Wet Bulb temperature given the dry bulb (ambient)
		/// temperature, relative humidity and barometric pressure.
		/// </summary>
		/// <param name="db_temp">Dry Bulb (ambient) temperature in °C</param>
		/// <param name="rh">Relative Humidity in % (e.g. 50% = 50)</param>
		/// <param name="bp">Barometric Pressure in mb/hPa</param>
		/// <returns>Wet Bulb temperature in °C</returns>
		public static double Wetbulb(double db_temp, double rh, double bp)
		{
			// Initialize constants for above water
			double B = 0.00066;
			double alpha = 6.112;
			double beta = 17.62;
			double lamda = 243.12;

			if (db_temp < 0)
			{
				// Constants for above ice
				beta = 22.46;
				lamda = 272.62;
			}

			return db_temp - (alpha/(B * bp) * Math.Pow(Math.E, beta * db_temp/(lamda + db_temp)) * (1 - (rh / 100)));
		}

		/// <summary>
		/// Generic function to calculate saturated or actual vapor pressure of air
		/// given dew point or ambient temperature respectively.
		/// </summary>
		/// <param name="temperature">Dew point or Ambient temperature in °C</param>
		/// <returns>Saturated or actual vapor pressure in millibars(mb)/hPa</returns>
		private static double VaporPressure(double temperature)
		{
			return 6.11 * Math.Pow(10, (7.5 * temperature) / (237.7 + temperature));
		}

		#endregion
	}
}
