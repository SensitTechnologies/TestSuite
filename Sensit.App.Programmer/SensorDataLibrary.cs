using System;
using System.Collections.Generic;
using System.Linq;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Programmer
{
	public class SensorDataLibrary
	{
		#region Constants

		//Oxygen Sensor
		public static readonly int ZERO_MAX_OXYGEN = 26000;
		public static readonly int ZERO_MIN_OXYGEN = 26000;

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

		public abstract class BaseRecord
		{
			public Validity BaseRecordValidity { get; set; } = Validity.Valid; //1 byte
			public SensorType SensorType { get; set; } //1 byte VARIABLE
			public byte SensorRev { get; set; } = 1; //1 byte
			public byte BaseRecordFormat { get; set; } = 0; //1 byte
			public int CalScale { get; set; } //4 byte VARIABLE
			public byte CalGasOne { get; set; } = 0; //1 byte
			public int CalPointOne { get; set; } //4 byte VARIABLE: only not zero is on CO sensor
			public int CalMaxOne { get; set; } = 0; //4 byte
			public int CalMinOne { get; set; } = 0; //4 byte
			public byte CalGasTwo { get; set; } = 0; //1 byte  
			public int CalDate { get; set; } = 0x02031400; //month, day, 2 bytes for year
			public int AutoZero { get; set; } = 0; //4 byte
			public int ZeroMax { get; set; } = 0; //4 byte. VARIABLE: Format0 = 0. Format2 = 26000.
			public int ZeroMin { get; set; } = 0; //4 byte. VARIABLE: Format0 = 0. Format2 = 26000.

			public abstract List<byte> GetBytes();
			public abstract void SetBytes(List<byte> data);
		}

		public class BaseRecordFormat0 : BaseRecord
		{
			public int CalPointTwo { get; set; } = 0; //4 byte
			public int CalMaxTwo { get; set; } = 0; //4 byte
			public int CalMinTwo { get; set; } = 0; //4 byte
			public byte CalGasThree { get; set; } = 0; //Only CO has define. 00

			public override List<byte> GetBytes()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(BaseRecordFormat);
				data.AddRange(ToBigEndianArray(CalScale));
				data.Add(CalGasOne);
				data.AddRange(ToBigEndianArray(CalPointOne));
				data.AddRange(ToBigEndianArray(CalMaxOne));
				data.AddRange(ToBigEndianArray(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(ToBigEndianArray(CalPointTwo));
				data.AddRange(ToBigEndianArray(CalMaxTwo));
				data.AddRange(ToBigEndianArray(CalMinTwo));
				data.Add(CalGasThree);
				data.AddRange(new List<byte> { 0, 0, 0, 0, 0, 0, 0 }); //7
				data.AddRange(ToBigEndianArray(CalDate));
				data.Add((byte)0);
				data.AddRange(ToBigEndianArray(AutoZero));
				data.AddRange(ToBigEndianArray(ZeroMax));
				data.AddRange(ToBigEndianArray(ZeroMin));
				data.Add((byte)0);

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
				BaseRecordFormat = data[3];
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
				//Unused 7 bytes
				CalDate = FromBigEndianArray(data.ToArray(), 42);
				AutoZero = FromBigEndianArray(data.ToArray(), 47);
				ZeroMax = FromBigEndianArray(data.ToArray(), 51);
				ZeroMin = FromBigEndianArray(data.ToArray(), 55);

				//Check crc.
				if (CheckCrc(data) == false)
				{
					throw new DeviceCommandFailedException("Bad CRC from sensor EEPROM.");
				}
			}
		}

		public class BaseRecordFormat2 : BaseRecord
		{
			public int MinSpan { get; set; } = 1000; //4 byte
			public int ZeroCalibration { get; set; } = 19699; //***7*** byte

			public override List<byte> GetBytes()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(BaseRecordFormat);
				data.AddRange(ToBigEndianArray(CalScale));
				data.Add(CalGasOne);
				data.AddRange(ToBigEndianArray(CalPointOne));
				data.AddRange(ToBigEndianArray(CalMaxOne));
				data.AddRange(ToBigEndianArray(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(ToBigEndianArray(MinSpan));
				data.AddRange(new List<byte> { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 });
				data.AddRange(ToBigEndianArray(ZeroCalibration)); //***7 bytes***
				data.AddRange(ToBigEndianArray(CalDate));
				data.Add((byte)0);
				data.AddRange(ToBigEndianArray(AutoZero));
				data.AddRange(ToBigEndianArray(ZeroMax));
				data.AddRange(ToBigEndianArray(ZeroMin));
				data.Add((byte)0);

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
				BaseRecordFormat = data[3];
				CalScale = FromBigEndianArray(data.ToArray(), 4);
				CalGasOne = data[8];
				CalPointOne = FromBigEndianArray(data.ToArray(), 9);
				CalMaxOne = FromBigEndianArray(data.ToArray(), 13);
				CalMinOne = FromBigEndianArray(data.ToArray(), 17);
				CalGasTwo = data[21];
				MinSpan = FromBigEndianArray(data.ToArray(), 22);
				ZeroCalibration = FromBigEndianArray(data.ToArray(), 32);
				CalDate = FromBigEndianArray(data.ToArray(), 42);
				AutoZero = FromBigEndianArray(data.ToArray(), 47);
				ZeroMax = FromBigEndianArray(data.ToArray(), 51);
				ZeroMin = FromBigEndianArray(data.ToArray(), 55);

				// Check CRC.
				if (CheckCrc(data) == false)
				{
					throw new DeviceCommandFailedException("Bad CRC from sensor EEPROM.");
				}

			}
		}

		#endregion

		#region DeviceID

		/// <summary>
		/// Abstract class for Device ID (page 4)
		/// </summary>
		public class DeviceID
		{
			//page 4 on the EEPROM
			public Validity DeviceIDValidity { get; set; } = Validity.Valid;
			public SensorType IDClass { get; set; }
			public byte RecordFormat { get; set; }
			public int DateCode { get; set; } //1 byte week, 2 bytes year
			public int SSDate { get; set; } //1 byte month, 1 byte day, 2 bytes year
			public List<byte> SerialNumber { get; set; } //ASCII data
			public int MaxExposure { get; set; } = 0; //bytes 0x30 - 0x31
			public int MaxRange { get; set; } = 0; //bytes 0x32 - 0x33
			public int MinRange { get; set; } = 0; //bytes 0x34 - 0x35
			public int Issue { get; set; } = 0; //bytes 0x36 - 0x37
			public int Revision { get; set; } = 0; //bytes 0x38 - 0x39
			public int PointRelease { get; set; } = 0; //bytes 0x3A - 0x3B
			public int Checksum { get; set; } //bytes 0x3C - 0x3F

			public List<byte> GetBytes()
			{
				List<byte> data = new();
				data.Add((byte)DeviceIDValidity);
				data.Add((byte)IDClass);
				data.AddRange(ToBigEndianArray(RecordFormat));
				

				return data;
			}
		}
		#endregion

		#region ManufacturingRecord

		/// <summary>
		/// Abstract class for Manufacturing ID Records (page 5)
		/// </summary>
		public class ManufactureID
		{
			//page 5 on the EEPROM
			public Validity ManufacturingValidity { get; set; } = Validity.Valid;
			public SensorType ManufacturingClass { get; set; } //Variable
			public byte UnusedMROne { get; set; } = 0;
			public byte RecordFormat { get; set; } = 0; //Wouldn't this change based off sensor type?
			public int UnusedMRTwo { get; set; } = 0;
			public int SSDate { get; set; } //1 byte month, 1 byte day, 2 bytes year
			public int SerialNumber { get; set; } //ASCII data
			public int UnusedMRThree { get; set; } = 0;
			public int Issue { get; set; } = 0;
			public int Revision { get; set; } = 0;
			public int PointRelease { get; set; } = 0;
			public int CheckSum { get; set; } //Calculation

			public List<byte> GetBytes()
			{
				List<byte> data = new()
			{
				(byte)ManufacturingValidity,
				(byte)ManufacturingClass,
				UnusedMROne,
				RecordFormat,
				(byte)UnusedMRTwo,
				(byte)SSDate,
				//TODO: Serial number
				(byte)UnusedMRThree,
				(byte)Issue,
				(byte)Revision,
				(byte)PointRelease,
				(byte)CheckSum

			};

				return data;
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

		private static int FromBigEndianArray(byte[] data, int startIndex)
		{
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(data);
			}

			return BitConverter.ToInt32(data, startIndex);
		}

		private static byte[] ToBigEndianArray(int value)
		{
			byte[] bytes = BitConverter.GetBytes(value);

			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}

			return bytes;
		}


		#endregion
	}



	
}


