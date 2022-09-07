using System;
using System.Collections.Generic;
using System.Linq;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Programmer
{
	/// <summary>
	/// Base class for smart sensor data.
	/// </summary>
	public class SensorDataLibrary : FormProgrammer
	{
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

		#region Base Record Deviation Classes (pages 0 -3)

		/// <summary>
		/// Class for Base Records: Oxygen
		/// </summary>
		public class OxygenBaseRecord
		{
			public OxygenBaseRecord() { }
			/*TODO: HLD has:
			 * A, B, C, D, and Offset as defines. 
			 *Peter's email has them as:
			 * Min Span, Unused, Unused, Unused, and Zero Calibration
			 * Using the names from Peter's email for now with respective
			 * letters denoting which Unused is which
			 */
			public Validity BaseRecordValidity { get; set; } = Validity.Valid; //1 byte
			public SensorType SensorType { get; set; } = SensorType.Oxygen; //1 byte
			public byte SensorRev { get; set; } = 1; //1 byte
			public byte BaseRecordFormat { get; set; } = 2; //1 byte
			public int CalScale { get; set; } = 0; //4 byte
			public byte CalGasOne { get; set; } = 0; //1 byte
			public int CalPointOne { get; set; } = 0; //4 byte
			public int CalMaxOne { get; set; } = 0; //4 byte
			public int CalMinOne { get; set; } = 0; //4 byte
			public byte CalGasTwo { get; set; } = 0; //1 byte  
			public int MinSpan { get; set; } = 1000; //4 byte
			public int UnusedB { get; set; } = 0; //4 byte
			public int UnusedC { get; set; } = 0;//4 byte
			public byte UnusedD { get; set; } = 0; //4 byte
			public int ZeroCalibration { get; set; } = 19699; //***7*** byte
			public int CalDate { get; set; } = 0x00140302; //4 byte
			public byte UnusedTwo { get; set; } = 0; //1 byte
			public int AutoZero { get; set; } = 0; //4 byte
			public int ZeroMax { get; set; } = 26000; //4 byte. "Linear" = 0. O2 = 26000.
			public int ZeroMin { get; set; } = 26000; //4 byte. "Linear" = 0. O2 = 26000.
			public int CheckSum { get; set; } //TODO: calculate Checksum based on sensor data


			public List<byte> BaseRecord()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(BaseRecordFormat);
				data.AddRange(BitConverter.GetBytes(CalScale));
				data.Add(CalGasOne);
				data.AddRange(BitConverter.GetBytes(CalPointOne));
				data.AddRange(BitConverter.GetBytes(CalMaxOne));
				data.AddRange(BitConverter.GetBytes(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(BitConverter.GetBytes(MinSpan));
				data.AddRange(BitConverter.GetBytes(UnusedB));
				data.AddRange(BitConverter.GetBytes(UnusedC));
				data.Add(UnusedD);
				data.AddRange(BitConverter.GetBytes(ZeroCalibration)); //***7 bytes***
				data.AddRange(BitConverter.GetBytes(CalDate));
				data.Add(UnusedTwo);
				data.AddRange(BitConverter.GetBytes(AutoZero));
				data.AddRange(BitConverter.GetBytes(ZeroMax));
				data.AddRange(BitConverter.GetBytes(ZeroMin));
				data.AddRange(BitConverter.GetBytes(CheckSum));

				return data;
			}

		}

		/// <summary>
		/// Class for Base Records: Carbon Monoxide
		/// </summary>
		public class CarbonMonoxideBaseRecord
		{
			//Properties
			public Validity BaseRecordValidity { get; set; } = Validity.Valid; //1 byte
			public SensorType SensorType { get; set; } = SensorType.CarbonMonoxide; //1 byte
			public byte SensorRev { get; set; } = 1; //1 byte
			public byte BaseRecordFormat { get; set; } = 0; //1 byte
			public int CalScale { get; set; } = 0x36C90; //4 byte
			public byte CalGasOne { get; set; } = 0; //1 byte
			public int CalPointOne { get; set; } = 0x00000064; //4 byte
			public int CalMaxOne { get; set; } = 0; //4 byte
			public int CalMinOne { get; set; } = 0; //4 byte
			public byte CalGasTwo { get; set; } = 0; //1 byte  
			public int CalPointTwo { get; set; } = 0; //4 byte
			public int CalMaxTwo { get; set; } = 0; //4 byte
			public int CalMinTwo { get; set; } = 0; //4 byte
			public byte CalGasThree { get; set; } = 0; //Only CO has define. 00
			public List<byte> UnusedOne { get; set; } //7 byte
			public int CalDate { get; set; } = 0x140302; //4 byte
			public byte UnusedTwo { get; set; } = 0; //1 byte
			public int AutoZero { get; set; } = 0; //4 byte
			public int ZeroMax { get; set; } = 0; //4 byte. "Linear" = 0. O2 = 26000.
			public int ZeroMin { get; set; } = 0; //4 byte. "Linear" = 0. O2 = 26000.
			public int CheckSum { get; set; } //TODO: calculate Checksum based on sensor data

			public List<byte> BaseRecord()
			{
				List<byte> UnusedOne = new() { 0, 0, 0, 0, 0, 0, 0 };

				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(BaseRecordFormat);
				data.AddRange(BitConverter.GetBytes(CalScale));
				data.Add(CalGasOne);
				data.AddRange(BitConverter.GetBytes(CalPointOne));
				data.AddRange(BitConverter.GetBytes(CalMaxOne));
				data.AddRange(BitConverter.GetBytes(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(BitConverter.GetBytes(CalPointTwo));
				data.AddRange(BitConverter.GetBytes(CalMaxTwo));
				data.AddRange(BitConverter.GetBytes(CalMinTwo));
				data.Add(CalGasThree);
				data.AddRange(UnusedOne); //7
				data.AddRange(BitConverter.GetBytes(CalDate));
				data.Add(UnusedTwo);
				data.AddRange(BitConverter.GetBytes(AutoZero));
				data.AddRange(BitConverter.GetBytes(ZeroMax));
				data.AddRange(BitConverter.GetBytes(ZeroMin));
				data.AddRange(BitConverter.GetBytes(CheckSum));

				return data;
			}
		}

		/// <summary>
		/// Class for Base Records: Hydrogen Sulfide
		/// </summary>
		public class HydrogenSulfideBaseRecord
		{
			//Properties
			public Validity BaseRecordValidity { get; set; } = Validity.Valid; //1 byte
			public SensorType SensorType { get; set; } = SensorType.HydrogenSulfide; //1 byte
			public byte SensorRev { get; set; } = 1; //1 byte
			public byte BaseRecordFormat { get; set; } = 0; //1 byte
			public int CalScale { get; set; } = 0x1FD920; //4 byte
			public byte CalGasOne { get; set; } = 0; //1 byte
			public int CalPointOne { get; set; } = 0; //4 byte
			public int CalMaxOne { get; set; } = 0; //4 byte
			public int CalMinOne { get; set; } = 0; //4 byte
			public byte CalGasTwo { get; set; } = 0; //1 byte  
			public int CalPointTwo { get; set; } = 0; //4 byte
			public int CalMaxTwo { get; set; } = 0; //4 byte
			public int CalMinTwo { get; set; } = 0; //4 byte
			public byte CalGasThree { get; set; } = 0; //Only CO has define. 00
			public int UnusedOne { get; set; } = 0; //4 byte
			public int CalDate { get; set; } = 0x00140302; //4 byte
			public byte UnusedTwo { get; set; } = 0; //1 byte
			public int AutoZero { get; set; } = 0; //4 byte
			public int ZeroMax { get; set; } = 0; //4 byte. "Linear" = 0. O2 = 26000.
			public int ZeroMin { get; set; } = 0; //4 byte. "Linear" = 0. O2 = 26000.
			public int CheckSum { get; set; } //TODO: calculate Checksum based on sensor data

			public List<byte> BaseRecord()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(BaseRecordFormat);
				data.AddRange(BitConverter.GetBytes(CalScale));
				data.Add(CalGasOne);
				data.AddRange(BitConverter.GetBytes(CalPointOne));
				data.AddRange(BitConverter.GetBytes(CalMaxOne));
				data.AddRange(BitConverter.GetBytes(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(BitConverter.GetBytes(CalPointTwo));
				data.AddRange(BitConverter.GetBytes(CalMaxTwo));
				data.AddRange(BitConverter.GetBytes(CalMinTwo));
				data.Add(CalGasThree);
				data.AddRange(BitConverter.GetBytes(UnusedOne));
				data.AddRange(BitConverter.GetBytes(CalDate));
				data.Add(UnusedTwo);
				data.AddRange(BitConverter.GetBytes(AutoZero));
				data.AddRange(BitConverter.GetBytes(ZeroMax));
				data.AddRange(BitConverter.GetBytes(ZeroMin));
				data.AddRange(BitConverter.GetBytes(CheckSum));

				return data;
			}
		}

		/// <summary>
		/// Class for Base Records: Hydrogen Cyanide
		/// </summary>
		public class HydrogenCyanideBaseRecord
		{
			//Properties
			public Validity BaseRecordValidity { get; set; } = Validity.Valid; //1 byte
			public SensorType SensorType { get; set; } = SensorType.HydrogenCyanide; //1 byte
			public byte SensorRev { get; set; } = 1; //1 byte
			public byte BaseRecordFormat { get; set; } = 0; //1 byte
			public int CalScale { get; set; } = 0xDE2B0; //4 byte
			public byte CalGasOne { get; set; } = 0; //1 byte
			public int CalPointOne { get; set; } = 0; //4 byte
			public int CalMaxOne { get; set; } = 0; //4 byte
			public int CalMinOne { get; set; } = 0; //4 byte
			public byte CalGasTwo { get; set; } = 0; //1 byte  
			public int CalPointTwo { get; set; } = 0; //4 byte
			public int CalMaxTwo { get; set; } = 0; //4 byte
			public int CalMinTwo { get; set; } = 0; //4 byte
			public byte CalGasThree { get; set; } = 0; //Only CO has define. 00
			public int UnusedOne { get; set; } = 0; //4 byte
			public int CalDate { get; set; } = 0x00140302; //4 byte
			public byte UnusedTwo { get; set; } = 0; //1 byte
			public int AutoZero { get; set; } = 0; //4 byte
			public int ZeroMax { get; set; } = 0; //4 byte. "Linear" = 0. O2 = 26000.
			public int ZeroMin { get; set; } = 0; //4 byte. "Linear" = 0. O2 = 26000.
			public int CheckSum { get; set; } //TODO: calculate Checksum based on sensor data

			public List<byte> BaseRecord()
			{
				List<byte> data = new();
				data.Add((byte)BaseRecordValidity);
				data.Add((byte)SensorType);
				data.Add(SensorRev);
				data.Add(BaseRecordFormat);
				data.AddRange(BitConverter.GetBytes(CalScale));
				data.Add(CalGasOne);
				data.AddRange(BitConverter.GetBytes(CalPointOne));
				data.AddRange(BitConverter.GetBytes(CalMaxOne));
				data.AddRange(BitConverter.GetBytes(CalMinOne));
				data.Add(CalGasTwo);
				data.AddRange(BitConverter.GetBytes(CalPointTwo));
				data.AddRange(BitConverter.GetBytes(CalMaxTwo));
				data.AddRange(BitConverter.GetBytes(CalMinTwo));
				data.Add(CalGasThree);
				data.AddRange(BitConverter.GetBytes(UnusedOne));
				data.AddRange(BitConverter.GetBytes(CalDate));
				data.Add(UnusedTwo);
				data.AddRange(BitConverter.GetBytes(AutoZero));
				data.AddRange(BitConverter.GetBytes(ZeroMax));
				data.AddRange(BitConverter.GetBytes(ZeroMin));
				data.AddRange(BitConverter.GetBytes(CheckSum));

				return data;
			}
		}

		#endregion

		/// <summary>
		/// Abstract class for Device ID (page 4)
		/// </summary>
		public class DeviceID
		{
			//page 4 on the EEPROM
			public Validity DeviceIDValidity { get; set; } = Validity.Valid;
			public SensorType IDClass { get; set; }
			public byte UnusedID { get; set; } = 0;
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
				List<byte> data = new()
			{
				(byte)DeviceIDValidity,
				(byte)IDClass,
				UnusedID,
				RecordFormat,
				(byte)DateCode,
				(byte)SSDate,
				//TODO: serial number
				(byte)MaxExposure,
				(byte)MaxRange,
				(byte)MinRange,
				(byte)Issue,
				(byte)PointRelease,
				(byte)Checksum
			};

				return data;
			}
		}

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
	}
}


