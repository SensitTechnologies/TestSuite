using System;
using System.Globalization;
using System.Text;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Calculations
{
	public static class SerialNumber
	{
		private static readonly uint BASE_YEAR = 2019;
		private static readonly uint MAX_YEAR = BASE_YEAR + ((26 * 26) - 1);

		public static string YearCode(uint year)
		{
			if ((year < BASE_YEAR) || (year > MAX_YEAR))
			{
				throw new TestException("Invalid year " + year.ToString());
			}

			// Base 26 representation:  A = 0, Z = 25
			uint offset0 = (year - BASE_YEAR) / 26;
			uint offset1 = (year - BASE_YEAR) % 26;

			StringBuilder code = new StringBuilder();
			if (offset1 > 0)
			{
				code.Append((char)('A' + offset1 - 1));
			}

			code.Append((char)('A' + offset0));

			return code.ToString();
		}
	}
}
