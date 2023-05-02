using System;
using System.Text;

namespace Sensit.TestSDK.Calculations
{
	/// <summary>
	/// Perform cyclic redundancy checks.
	/// </summary>
	public static class Checksum
	{
		/// <summary>
		/// base poly used for CRC algorithm
		/// </summary>
		private const ushort POLY = 0xA001;

		/// <summary>
		/// table used for the CRC-16 calculation
		/// </summary>
		/// <remarks>
		/// One application that can generate this table:
		/// pycrc v0.7.6, http://www.tty1.net/pycrc/
		/// using the configuration:
		/// Width        = 16
		/// Poly         = 0x8005
		/// XorIn        = 0x0000
		/// ReflectIn    = True
		/// XorOut = 0x0000
		/// ReflectOut = True
		/// Algorithm = table - driven
		/// </remarks>
		private static ushort[] crcTable;

		/// <summary>
		/// Initialize the table used for CRC-16 calculation.
		/// </summary>
		private static void InitCRC16Table()
		{
			// Create a new array.
			crcTable = new ushort[256];

			// For each element in the array...
			for (int i = 0; i < 256; i++)
			{
				ushort crc = 0;
				ushort c = (ushort)i;

				for (int j = 0; j < 8; j++)
				{

					if (((crc ^ c) & 0x0001) == 0x0001)
						crc = (ushort)((crc >> 1) ^ POLY);
					else
						crc = (ushort)(crc >> 1);

					c = (ushort)(c >> 1);
				}

				crcTable[i] = crc;
			}
		}

		/// <summary>
		/// Calculate a 16-bit CRC value.
		/// </summary>
		/// <param name="data">array of bytes to calculate a CRC of</param>
		/// <returns>checksum</returns>
		public static ushort Crc16(byte[] data)
		{
			// Validate data before using.
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data), Properties.Resources.Checksum_Calculate);
			}

			// If the CRC table hasn't been populated...
			if (crcTable == null)
			{
				// Create the CRC table.
				InitCRC16Table();
			}

			ushort crc = 0xFFFF;

			foreach (byte datum in data)
			{
				crc = (ushort)((crc >> 8) ^ crcTable[(crc ^ datum) & 0xFF]);
			}

			return crc;
		}

		/// <summary>
		/// Calculates the Ethernet CRC32 (aka crc32/mpeg2) of a byte stream.
		/// </summary>
		/// <remarks>
		/// Ported from this example in C:
		/// https://stackoverflow.com/questions/54339800/how-to-modify-crc-32-to-crc-32-mpeg-2
		/// </remarks>
		/// <param name="data">array of bytes to calculate a CRC of</param>
		/// <returns>checksum</returns>
		public static uint Crc32Mpeg2(byte[] data)
		{
			// Validate data before using.
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data), Properties.Resources.Checksum_Calculate);
			}

			uint msb;

			uint crc = 0xFFFFFFFF;

			foreach (byte b in data)
			{
				// xor next byte to upper bits of crc
				crc ^= ((uint)b) << 24;

				// For each bit in the byte...
				for (int j = 0; j < 8; j++)
				{
					msb = crc >> 31;
					crc <<= 1;
					crc ^= (0 - msb) & 0x04C11DB7;
				}
			}

			// don't complement crc on output
			return crc;
		}

		/// <summary>
		/// This is a custom CRC-32 that matches the checksum in STM32 microcontroller hardware.
		/// </summary>
		/// <param name="data"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		public static uint Crc32Custom(uint[] data)
		{
			// Validate data before using.
			if (data == null)
			{
				throw new ArgumentNullException(nameof(data), Properties.Resources.Checksum_Calculate);
			}

			uint crc = 0xFFFFFFFF;

			foreach (uint datum in data)
			{
				// xor next UInt32 to crc
				crc ^= datum;

				// For each of the 32 bits...
				for (int index = 0; index < 32; index++)
				{
					if ((crc & 0x80000000) == 0x80000000)
					{
						// Polynomial used in STM32
						crc = (crc << 1) ^ 0x04C11DB7;
					}
					else
					{
						crc <<= 1;
					}
				}
			}

			return crc;
		}

		/// <summary>
		/// Longitudinal Redundancy Check (LRC) (used in MODBUS ASCII)
		/// </summary>
		/// <remarks>
		/// The LRC is calculated by adding together each byte in the data,
		/// discarding any carries, then two's complementing the result.
		/// It can also be implemented by subtracting each byte.
		/// </remarks>
		/// <see cref="https://stackoverflow.com/questions/12799122/how-can-i-calculate-longitudinal-redundancy-check-lrc"/>
		/// <param name="data">data buffer</param>
		/// <returns>Computed LRC</returns>
		public static byte LRC(byte[] data)
		{
			// Start with a value of zero.
			byte lrc = 0;

			// Subtract each byte.
			foreach (byte datum in data)
			{
				lrc -= datum;
			}

			return lrc;
		}
	}
}
