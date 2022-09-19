using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Programmer
{
	public class SensorDataLibrary
	{
		#region Constants

		//EEPROM's page size 
		public static readonly ushort PAGE_SIZE = 64;

		//Byte address locations for each record type
		public static readonly ushort ADDRESS_BASE_RECORD = (ushort)(0 * PAGE_SIZE);
		public static readonly ushort ADDRESS_DEVICE_ID = (ushort)(4 * PAGE_SIZE);
		public static readonly ushort ADDRESS_MANUFACTURING_ID = (ushort)(5 * PAGE_SIZE);

		//Oxygen Sensor
		public static readonly int ZERO_MAX_OXYGEN = 26000;
		public static readonly int ZERO_MIN_OXYGEN = 22000;
		public static readonly int CAL_SCALE_OXYGEN = 0;

		//Carbon Monoxide Sensor
		public static readonly int CARBONMONOXIDE_CAL_SCALE = 0x36C90;
		public static readonly int CARBONMONOXIDE_CAL_POINT_ONE = 0x64000000; //only CO has different Cal Point (flipped number peter gave)

		//Hydrogen Sulfide Sensor
		public static readonly int HYDROGENSULFIDE_CAL_SCALE = 0x1FD920;

		//Hydrogen Cyanide Sensor
		public static readonly int HYDROGENCYANIDE_CAL_SCALE = 0xde2b0;

		#endregion

		#region Enumerations

		/// <summary>
		/// Enum for smart sensor type code.
		/// </summary>
		public enum SensorType
		{
			Oxygen = 0x01,
			OxygenPb = 0x02,
			CarbonMonoxide = 0x03,
			HydrogenSulfide = 0x04,
			HydrogenCyanide = 0x05,
			SulfurDioxide = 0x06,
			Chlorine = 0x07,
			NitrogenDioxide = 0x08,
			Phosphine = 0x09,
			EthyleneOxide = 0x0A,
			CarbonDioxide = 0x0B,
			Methane = 0x0C,
			Propane = 0x0D,
			Methane2611 = 0x0E,
			MethaneIR = 0x0F,
			DualCOH2S = 0x10
		}

		/// <summary>
		/// Enum for Validity (Base Record, Device ID, and Manufacturing Record)
		/// </summary>
		public enum Validity
		{
			Valid = 0xAA,
			Erased = 0xFF,
			//anything else is Invalid
		}

		#endregion

		#region BaseRecordClasses

		/// <summary>
		/// Abstract class for shared values between sensor record formats.
		/// </summary>
		public abstract class BaseRecord
		{
			public Validity BaseRecordValidity { get; set; } = Validity.Valid; //1 byte
			public SensorType SensorType { get; set; } //1 byte VARIABLE
			public byte SensorRev { get; set; } = 1; //1 byte
			public abstract byte RecordFormat { get; set; } //1 byte. Number variable
			public int CalScale { get; set; } //4 byte VARIABLE
			public byte CalGasOne { get; set; } = 0; //1 byte
			public int CalPointOne { get; set; } //4 byte VARIABLE: only not zero is on CO sensor
			public int CalMaxOne { get; set; } = 0; //4 byte
			public int CalMinOne { get; set; } = 0; //4 byte
			public byte CalGasTwo { get; set; } = 0; //1 byte  
			public ushort Year { get; set; } = 0x0014;
			public byte Month { get; set; } = 0x03;
			public byte Day { get; set; } = 0x02;
			public int AutoZero { get; set; } = 0; //4 byte
			public int ZeroMax { get; set; } = 0; //4 byte. VARIABLE: Format0 = 0. Format2 = 26000.
			public int ZeroMin { get; set; } = 0; //4 byte. VARIABLE: Format0 = 0. Format2 = 26000.

			/// <summary>
			/// Get info from Sensor Data Library to put onto EEPROM.
			/// </summary>
			/// <returns>List of bytes to program onto EEPROM.</returns>
			public abstract List<byte> GetBytes();

			/// <summary>
			/// Get info from EEPROM to set variables in Sensor Data Library.
			/// </summary>
			/// <param name="data">List of bytes from EEPROM</param>
			public abstract void SetBytes(List<byte> data);
		}

		/// <summary>
		/// Record Library for sensors with format 0.
		/// (HCN, CO, H2S)
		/// </summary>
		public class BaseRecordFormat0 : BaseRecord
		{
			public int CalPointTwo { get; set; } = 0; //4 byte
			public int CalMaxTwo { get; set; } = 0; //4 byte
			public int CalMinTwo { get; set; } = 0; //4 byte
			public byte CalGasThree { get; set; } = 0; //Only CO has define. 00
			public override byte RecordFormat { get; set; } = 0;

			public override List<byte> GetBytes()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(RecordFormat);

				List<byte> flippedCalScale = new(ToBigEndianArray(CalScale));
				flippedCalScale.Reverse();
				data.AddRange(flippedCalScale);
				data.Add(CalGasOne);
				data.AddRange(ToBigEndianArray(CalPointOne));
				data.AddRange(ToBigEndianArray(CalMaxOne));
				data.AddRange(ToBigEndianArray(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(ToBigEndianArray(CalPointTwo));
				data.AddRange(ToBigEndianArray(CalMaxTwo));
				data.AddRange(ToBigEndianArray(CalMinTwo));
				data.Add(CalGasThree);
				data.AddRange(new List<byte> { 0, 0, 0, 0, 0, 0, 0 });
				data.Add(Day);
				data.Add(Month);
				data.AddRange(ToBigEndianArray(Year));
				data.Add(0);
				data.AddRange(ToBigEndianArray(AutoZero));
				data.AddRange(ToBigEndianArray(ZeroMax));
				data.AddRange(ToBigEndianArray(ZeroMin));
				data.Add(0);

				// Generate a checksum (then convert to byte array).
				byte[] crc = BitConverter.GetBytes(CalcCRC(data));

				// Ensure CRC is big endian.
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(crc);
				}

				// Add checksum to message.
				data.AddRange(crc);

				return data;
			}

			public override void SetBytes(List<byte> data)
			{
				BaseRecordValidity = (Validity)data[0];
				SensorType = (SensorType)data[1];
				SensorRev = data[2];
				RecordFormat = data[3];
				CalScale = FromBigEndianArray(data.ToArray(), 4);
				CalGasOne = data[8];
				CalPointOne = FromBigEndianArray(data.ToArray(), 9);
				CalMaxOne = FromBigEndianArray(data.ToArray(), 13);
				CalMinOne = FromBigEndianArray(data.ToArray(), 17);
				CalGasTwo = data[21];
				CalPointTwo = FromBigEndianArray(data.ToArray(), 22);
				CalMaxTwo = FromBigEndianArray(data.ToArray(), 26);
				CalMinTwo = FromBigEndianArray(data.ToArray(), 30);
				CalGasThree = data[34];
				Day = data[42];
				Month = data[43];
				Year = FromBigEndianArrayUshort(data.ToArray(), 44);
				AutoZero = FromBigEndianArray(data.ToArray(), 47);
				ZeroMax = FromBigEndianArray(data.ToArray(), 51);
				ZeroMin = FromBigEndianArray(data.ToArray(), 55);

				//Check crc.
				if (CheckCrc(data) == false)
				{
					throw new DeviceCommandFailedException("Bad CRC from sensor BR0.");
				}
			}
		}

		/// <summary>
		/// Record Library for sensors with format 2 (O2)
		/// </summary>
		public class BaseRecordFormat2 : BaseRecord
		{
			public int MinSpan { get; set; } = 1000; //4 byte
			public ushort ZeroCalibration { get; set; }
			public override byte RecordFormat { get; set; } = 2;

			public override List<byte> GetBytes()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(RecordFormat);
				List<byte> flippedCalScale = new(ToBigEndianArray(CalScale));
				flippedCalScale.Reverse();
				data.AddRange(flippedCalScale);
				data.Add(CalGasOne);
				data.AddRange(ToBigEndianArray(CalPointOne));
				data.AddRange(ToBigEndianArray(CalMaxOne));
				data.AddRange(ToBigEndianArray(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(ToBigEndianArray(MinSpan));

				//9 unused bytes
				data.AddRange(new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });

				data.AddRange(BitConverter.GetBytes(ZeroCalibration));
				data.Add(Day);
				data.Add(Month);
				data.AddRange(ToBigEndianArray(Year));
				data.Add(0);
				data.AddRange(ToBigEndianArray(AutoZero));
				data.AddRange(ToBigEndianArray(ZeroMax));
				data.AddRange(ToBigEndianArray(ZeroMin));
				data.Add(0);

				// Generate a checksum (then convert to byte array).
				byte[] crc = BitConverter.GetBytes(CalcCRC(data));

				// Ensure CRC is big endian.
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(crc);
				}

				// Add checksum to message.
				data.AddRange(crc);
				return data;
			}

			public override void SetBytes(List<byte> data)
			{
				BaseRecordValidity = (Validity)data[0];
				SensorType = (SensorType)data[1];
				SensorRev = data[2];
				RecordFormat = data[3];
				CalScale = FromBigEndianArray(data.ToArray(), 4);
				CalGasOne = data[8];
				CalPointOne = FromBigEndianArray(data.ToArray(), 9);
				CalMaxOne = FromBigEndianArray(data.ToArray(), 13);
				CalMinOne = FromBigEndianArray(data.ToArray(), 17);
				CalGasTwo = data[21];
				MinSpan = FromBigEndianArray(data.ToArray(), 22);
				ZeroCalibration = FromBigEndianArrayUshort(data.ToArray(), 35);
				Day = data[42];
				Month = data[43];
				Year = FromBigEndianArrayUshort(data.ToArray(), 44);
				AutoZero = FromBigEndianArray(data.ToArray(), 47);
				ZeroMax = FromBigEndianArray(data.ToArray(), 51);
				ZeroMin = FromBigEndianArray(data.ToArray(), 55);

				// Check CRC.
				if (CheckCrc(data) == false)
				{
					throw new DeviceCommandFailedException("Bad CRC from sensor BR2.");
				}

			}
		}

		#endregion

		#region DeviceID

		/// <summary>
		/// Class for Device ID (page 4 of EEPROM)
		/// </summary>
		public class DeviceID
		{
			public Validity DeviceIDValidity { get; set; } = Validity.Valid;
			public SensorType SensorType { get; set; }
			public byte RecordFormat { get; set; }
			public ushort Day { get; set; }
			public ushort Month { get; set; }
			public int Year { get; set; }
			public string SerialNumber { get; set; } //ASCII data
			public ushort MaxExposure { get; set; } = 0; //bytes 0x30 - 0x31
			public ushort MaxRange { get; set; } = 0; //bytes 0x32 - 0x33
			public ushort MinRange { get; set; } = 0; //bytes 0x34 - 0x35
			public ushort Issue { get; set; } = 0; //bytes 0x36 - 0x37
			public ushort Revision { get; set; } = 0; //bytes 0x38 - 0x39
			public ushort PointRelease { get; set; } = 0; //bytes 0x3A - 0x3B
			public int Checksum { get; set; } //bytes 0x3C - 0x3F

			/// <summary>
			/// Get info from Sensor Data Library to put onto EEPROM.
			/// </summary>
			/// <returns>List of bytes to program onto EEPROM.</returns>
			public List<byte> GetBytes()
			{
				List<byte> data = new();

				data.Add((byte)DeviceIDValidity);
				data.Add((byte)SensorType);
				data.Add(0);
				data.Add(RecordFormat);
				data.AddRange(new List<byte> { 0, 0, 0 });
				data.AddRange(BreakIntIntoDigits(Day));
				data.AddRange(BreakIntIntoDigits(Month));
				data.AddRange(BreakIntoDigits(Year));
				data.Add(0);
				data.AddRange(ToBigEndianArray(SerialNumber));
				data.AddRange(ToBigEndianArray(MaxExposure));
				data.AddRange(ToBigEndianArray(MaxRange));
				data.AddRange(ToBigEndianArray(MinRange));
				data.AddRange(ToBigEndianArray(Issue));
				data.AddRange(ToBigEndianArray(Revision));
				data.AddRange(ToBigEndianArray(PointRelease));

				// Generate a checksum (then convert to byte array).
				byte[] crc = BitConverter.GetBytes(CalcCRC(data));

				// Ensure CRC is big endian.
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(crc);
				}

				// Add checksum to message.
				data.AddRange(crc);

				return data;
			}

			/// <summary>
			/// Get info from EEPROM to set variables in Sensor Data Library.
			/// </summary>
			/// <param name="data">List of bytes from EEPROM</param>
			public void SetBytes(List<byte> data)
			{
				DeviceIDValidity = (Validity)data[0];
				SensorType = (SensorType)data[1];
				RecordFormat = data[3];
				Day = DigitsIntoUshort(data.ToArray(), 7);
				Month = DigitsIntoUshort(data.ToArray(), 9);
				Year = DigitsIntoInt(data.ToArray(), 11);

				byte[] serialNumberArray = data.GetRange(16, 32).ToArray();

				SerialNumber = Encoding.UTF8.GetString(serialNumberArray);

				MaxExposure = FromBigEndianArrayUshort(data.ToArray(), 48);
				MaxRange = FromBigEndianArrayUshort(data.ToArray(), 50);
				MinRange = FromBigEndianArrayUshort(data.ToArray(), 52);
				Issue = FromBigEndianArrayUshort(data.ToArray(), 54);
				Revision = FromBigEndianArrayUshort(data.ToArray(), 56);
				PointRelease = FromBigEndianArrayUshort(data.ToArray(), 58);

				// Check CRC.
				if (CheckCrc(data) == false)
				{
					throw new DeviceCommandFailedException("Bad CRC from sensor D_ID.");
				}
			}
		}
		#endregion

		#region Manufacturing Record

		/// <summary>
		/// Class for Manufacturing ID Records (page 5)
		/// </summary>
		public class ManufactureID
		{
			public Validity Validity { get; set; } = Validity.Valid;
			public SensorType SensorType { get; set; } //Variable
			public byte RecordFormat { get; set; }
			public ushort Day { get; set; }
			public ushort Month { get; set; }
			public int Year { get; set; }
			public string SerialNumber { get; set; } //ASCII data
			public ushort Issue { get; set; } = 0;
			public ushort Revision { get; set; } = 0;
			public ushort PointRelease { get; set; } = 0;
			public int CheckSum { get; set; } //Calculation

			/// <summary>
			/// Get info from Sensor Data Library to put onto EEPROM.
			/// </summary>
			/// <returns>List of bytes to program onto EEPROM.</returns>
			public List<byte> GetBytes()
			{
				List<byte> data = new();
				data.Add((byte)Validity);
				data.Add((byte)SensorType);
				data.Add(0);
				data.Add(RecordFormat);
				data.AddRange(new List<byte> { 0, 0, 0 });
				data.AddRange(BreakIntIntoDigits(Day));
				data.AddRange(BreakIntIntoDigits(Month));
				data.AddRange(BreakIntoDigits(Year));
				data.Add(0);
				data.AddRange(ToBigEndianArray(SerialNumber));
				data.AddRange(new List<byte> { 0, 0, 0, 0, 0, 0 });
				data.AddRange(ToBigEndianArray(Issue));
				data.AddRange(ToBigEndianArray(Revision));
				data.AddRange(ToBigEndianArray((PointRelease)));
				// Generate a checksum (then convert to byte array).
				byte[] crc = BitConverter.GetBytes(CalcCRC(data));

				// Ensure CRC is big endian.
				if (BitConverter.IsLittleEndian)
				{
					Array.Reverse(crc);
				}
				// Add checksum to message.
				data.AddRange(crc);
				return data;
			}

			/// <summary>
			/// Get info from EEPROM to set variables in Sensor Data Library.
			/// </summary>
			/// <param name="data">List of bytes from EEPROM</param>
			public void SetBytes(List<byte> data)
			{
				Validity = (Validity)data[0];
				SensorType = (SensorType)data[1];
				RecordFormat = data[3];
				Day = DigitsIntoUshort(data.ToArray(), 7);
				Month = DigitsIntoUshort(data.ToArray(), 9);
				Year = DigitsIntoInt(data.ToArray(), 11);
				SerialNumber = Encoding.UTF8.GetString(data.ToArray(), 16, 32);
				Issue = FromBigEndianArrayUshort(data.ToArray(), 50);
				Revision = FromBigEndianArrayUshort(data.ToArray(), 52);
				PointRelease = FromBigEndianArrayUshort(data.ToArray(), 54);

				// Check CRC.
				if (CheckCrc(data) == false)
				{
					throw new DeviceCommandFailedException("Bad CRC from sensor MR.");
				}
			}
		}
		#endregion

		#region Methods

		/// <summary>
		/// Calculate the checksum.
		/// </summary>
		/// <remarks>
		/// Add extra bytes to get to a 32-bit boundary.
		/// Calculate the CRC.
		/// (Do not send the extra bytes.)
		/// </remarks>
		/// <returns>checksum</returns>
		private static uint CalcCRC(List<byte> message)
		{
			// Create a temporary copy of the message to manipulate.
			List<byte> msgCopy = new(message);

			// Measure the length of the message (without the checksum).
			ushort length = (ushort)(message.Count);

			// Increment to next full 32-byte boundary.
			while (length % 4 != 0)
			{
				// Add a byte (to length and message).
				length++;
				msgCopy.Add(0x00);
			}

			// Convert byte array to UInt32 array.
			byte[] byteArray = msgCopy.ToArray();
			uint[] uintArray = new uint[byteArray.Length / 4];
			Buffer.BlockCopy(byteArray, 0, uintArray, 0, byteArray.Length);

			// Generate a checksum.
			return Checksum.Crc32Custom(uintArray);
		}

		/// <summary>
		/// Check for valid CRC
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static bool CheckCrc(List<byte> message)
		{
			// Check for valid message.
			if (message == null)
			{
				throw new ArgumentNullException(nameof(message));
			}
			else if (message.Count == 0)
			{
				throw new ArgumentOutOfRangeException(nameof(message));
			}

			// Parse the CRC from the message.
			byte[] crc = message.Skip(message.Count - 4).Take(4).ToArray();

			// Ensure CRC is big endian.
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(crc);
			}

			uint crcReceived = BitConverter.ToUInt32(crc, 0);

			// Calculate the expected CRC.
			List<byte> msg = new(message.Take(message.Count - 4));
			uint crcCalc = CalcCRC(msg);

			// If the CRCs match, return true.
			return (crcReceived == crcCalc);
		}

		/// <summary>
		/// Switch info gotten from G3 to LittleEndianArray
		/// </summary>
		/// <param name="data">byte list of data</param>
		/// <param name="startIndex">int address of data</param>
		/// <returns>int of converted values from data</returns>
		private static int FromBigEndianArray(byte[] data, int startIndex)
		{
			return BitConverter.ToInt32(data, startIndex);
		}

		/// <summary>
		/// Switch info gotten from G3 to LittleEndianArray
		/// </summary>
		/// <param name="data">byte list of data</param>
		/// <param name="startIndex">int address of data</param>
		/// <returns>ushort of converted values from data</returns>
		private static ushort FromBigEndianArrayUshort(byte[] data, int startIndex)
		{
			return BitConverter.ToUInt16(data, startIndex);
		}

		/// <summary>
		/// Switch info gotten from Sensor Data Library to BigEndianArray for G3.
		/// </summary>
		/// <param name="value">value to switch into a big endian array</param>
		/// <returns>Big endian list of bytes holding value</returns>
		private static List<byte> ToBigEndianArray(int value)
		{
			List<byte> bytes = BitConverter.GetBytes(value).ToList();

			byte[] redoneBytes = new byte[4];

			redoneBytes[0] = bytes[0];
			redoneBytes[1] = bytes[1];
			redoneBytes[2] = bytes[2];
			redoneBytes[3] = bytes[3];

			return redoneBytes.ToList();
		}

		/// <summary>
		/// Switch info gotten from Sensor Data Library to BigEndianArray for G3.
		/// </summary>
		/// <param name="value">value to switch into a big endian array</param>
		/// <returns>Big endian list of bytes holding value</returns>
		private static List<byte> ToBigEndianArray(ushort value)
		{
			List<byte> bytes = BitConverter.GetBytes(value).ToList();

			if (BitConverter.IsLittleEndian)
			{
				bytes.Reverse();
			}

			return bytes;
		}

		/// <summary>
		/// Switch info gotten from Sensor Data Library to BigEndianArray for G3.
		/// </summary>
		/// <param name="value">value to switch into a big endian array</param>
		/// <returns>Big endian list of bytes holding value</returns>
		private static List<byte> ToBigEndianArray(string value)
		{
			List<byte> bytes = new(Encoding.ASCII.GetBytes(value));

			//Serial Number is the only string in the library. Add bytes until it is the correct size.
			while (bytes.Count != 32)
			{
				bytes.Add(0);
			}

			return bytes;
		}

		private static List<byte> BreakIntoDigits(int value)
		{
			List<byte> digits = new List<byte>(value.ToString().Select(t => byte.Parse(t.ToString())));
			while (digits.Count < 4)
			{
				digits.Insert(0, 0);
			}
			return digits;
		}

		private static List<byte> BreakIntIntoDigits(ushort value)
		{
			List<byte> digits = new List<byte>(value.ToString().Select(t => byte.Parse(t.ToString())));
			while (digits.Count < 2) 
			{ 
				digits.Insert(0, 0);
			}
			return digits;
		}

		private static ushort DigitsIntoUshort(byte[] digits, int startIndex)
		{
			string s = $"{digits[startIndex]}{digits[startIndex + 1]}";

			ushort output = UInt16.Parse(s);

			return output;
		}
		private static int DigitsIntoInt(byte[] digits, int startIndex)
		{
			string s = $"{digits[startIndex]}{digits[startIndex + 1]}{digits[startIndex + 2]}{digits[startIndex + 3]}";

			int output = Int32.Parse(s);

			return output;
		}

		#endregion
	}
}


