using System;
using System.Collections.Generic;

namespace Sensit.TestSDK.Calculations
{
	public class LeastSquaresFitLinear
	{
		public class ValuePair
		{

			public double Reference { get; set; }
			public double Measured { get; set; }

			public ValuePair(double reference, double measured)
			{
				Reference = reference;
				Measured = measured;
			}
		}

		public double Slope
		{
			get { return _slope; }
		}
		double _slope;

		public double Intercept
		{
			get { return _intercept; }

		}
		double _intercept;


		/// <summary>
		/// Performs least squares fit on data list and calculates slope and intercept
		/// </summary>
		/// <param name="points"></param>
		public LeastSquaresFitLinear(List<ValuePair> points)
		{
			// Gives best fit of data to line Y = MX + B
			int numPoints = points.Count;

			if (numPoints == 0)
			{
				_slope = 0;
				_intercept = 0;
			}
			else if (numPoints == 1)
			{
				_slope = 1;
				_intercept = points[0].Reference - points[0].Measured;
			}
			else
			{
				double x1 = 0.0;
				double y1 = 0.0;
				double xy = 0.0;
				double x2 = 0.0;

				for (int i = 0; i < numPoints; i++)
				{
					x1 += points[i].Reference;
					y1 += points[i].Measured;
					xy += points[i].Reference * points[i].Measured;
					x2 += points[i].Reference * points[i].Reference;
				}

				double j = (numPoints * x2) - (x1 * x1);
				if (j.Equals(0.0) == false)
				{
					double f1 = ((numPoints * xy) - (x1 * y1)) / j;
					_slope = (Math.Floor(1.0E3 * f1 + 0.5) / 1.0E3);
					double off1 = ((y1 * x2) - (x1 * xy)) / j;
					_intercept = (Math.Floor(1.0E3 * off1 + 0.5) / 1.0E3);
				}
				else
				{
					_slope = 0.0;
					_intercept = 0.0;
				}
			}
		}
	}
}
