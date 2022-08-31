using System.Collections.Generic;

namespace Sensit.App.Programmer
{
	/// <summary>
	/// Base class for smart sensor data.
	/// </summary>
	public abstract class SensorDataLibrary
	{
		#region Enumerations

		/// <summary>
		/// Enum for smart sensor type code.
		/// </summary>
		public enum TypeCode
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
			//anything else is other?
		}

		/// <summary>
		/// Enum for Base Record Format
		///"Initial G3 release will support two sensor types."
		/// 00 <- Linear (CO, H2S, HCN)
		/// 02 <- Polynomial (O2)
		/// </summary>
		public enum RecordFormat
		{
			Linear = 00, //CO, H2S, HCN
			Polynomial = 02 //O2
			//Potentially more in the future
		}

		#endregion


		/// <summary>
		/// Empty Constructor.
		/// </summary>
		public SensorDataLibrary(){}

		/// <summary>
		/// Constructor with serial number.
		/// </summary>
		/// <param name="serialNumber"></param>
		public SensorDataLibrary(string serialNumber){}

		/// <summary>
		/// Convert library data to bytes.
		/// </summary>
		/// <returns>code that represents the setting</returns>
		public abstract List<byte> GetBytes();

		/// <summary>
		/// Convert bytes to library data.
		/// </summary>
		/// <remarks>
		/// First bytes in the list are assumed to be for the setting.
		/// Remaining bytes are returned back to the user.
		/// </remarks>
		/// <param name="bytes">list of bytes</param>
		/// <returns>list minus the byte(s) converted to the setting</returns>
		public abstract List<byte> SetBytes(List<byte> bytes);
	}

	public abstract class BaseRecords : SensorDataLibrary
	{
		//Empty Constructor
		public BaseRecords(){}

		//Properties
		public Validity BaseRecordValidity { get; set; } = Validity.Valid;
		public TypeCode SensorType { get; set; }
		public byte SensorRev { get; set; } = 1;

		/// <summary>
		/// Determines "Linear"/O2
		/// </summary>
		public RecordFormat BaseRecordFormat { get; set; }

		public int CalScale { get; set; } //4 bytes
		public byte CalGasOne { get; set; } = 0;
		public int CalPointOne { get; set; } //4 byte. CO = 100 (decimal). Others = 1.
		public int CalMaxOne { get; set; } = 0; //4 byte
		public int CalMinOne { get; set; } = 0; //4 byte
		public byte CalGasTwo { get; set; } = 0; //only CO and O2 have define. 00 for both     

		//---table deviates here for "Linear" CO/H2S/HCN vs. O2. they reconvene at byte 42.

		public int CalDate { get; set; } = 0x140302;

		public byte UnusedTwo { get; set; } = 0;
		public int AutoZero { get; set; } = 0; //4 byte
		public int ZeroMax { get; set; } //4 byte. "Linear" = 0. O2 = 26000.
		public int ZeroMin { get; set; } //4 byte. "Linear" = 0. O2 = 26000.
		public int CheckSum { get; set; } //TODO: calculate Checksum based on sensor data
	}

	/// <summary>
	/// Abstract class for deviation in variables
	/// from Base Records for "Linear" smart sensors.
	/// CO/H2S/HCN
	/// </summary>
	public abstract class Linear : BaseRecords
	{
		public Linear()
		{
			//set to linear value
		}

		public int CalPointTwo { get; set; } = 0; //4 byte
		public int CalMaxTwo { get; set; } = 0; //4 byte
		public int CalMinTwo { get; set; } = 0; //4 byte
		public byte CalGasThree { get; set; } = 0; //Only CO has define. 00
		public int UnusedOne { get; set; } = 0; //4 byte

		public override List<byte> GetBytes()
		{
			List<byte> data = new()
			{
				(byte)BaseRecordValidity,
				(byte)SensorType, 
				SensorRev,
				(byte)BaseRecordFormat,
				(byte) CalScale,
				CalGasOne,
				(byte)CalPointOne,
				(byte)CalMaxOne,
				(byte)CalMinOne,
				CalGasTwo,
				(byte)CalPointTwo,
				(byte)CalMaxTwo,
				(byte)CalMinTwo,
				CalGasThree,
				(byte)UnusedOne,
				(byte)CalDate,
				UnusedTwo,
				(byte)AutoZero,
				(byte)ZeroMax,
				(byte)ZeroMin,
				(byte)CheckSum

			};

			return data;
		}
	}

	/// <summary>
	/// Abstract class for deviation in variables 
	/// from Base Records for polynomial (dual gas)
	/// smart sensors.
	/// </summary>
	public abstract class O2 : BaseRecords
	{ 
		/*TODO: HLD has:
		 * A, B, C, D, and Offset as defines. 
		 *Peter's email has them as:
		 * Min Span, Unused, Unused, Unused, and Zero Calibration
		 * Using the names from Peter's email for now with respective
		 * letters denoting which Unused is which
		 */
		public int MinSpan { get; set; } //4 byte
		public int UnusedB { get; set; } //4 byte
		public int UnusedC { get; set; } //4 byte
		public int UnusedD { get; set; } //4 byte
		public int Offset { get; set; } //4 byte

		public override List<byte> GetBytes()
		{
			List<byte> data = new()
			{
				(byte)BaseRecordValidity,
				(byte)SensorType,
				SensorRev,
				(byte)BaseRecordFormat,
				(byte) CalScale,
				CalGasOne,
				(byte)CalPointOne,
				(byte)CalMaxOne,
				(byte)CalMinOne,
				CalGasTwo,
				(byte)MinSpan,
				(byte)UnusedB,
				(byte)UnusedC,
				(byte)UnusedD,
				(byte)Offset,
				(byte)CalDate,
				UnusedTwo,
				(byte)AutoZero,
				(byte)ZeroMin,
				(byte)ZeroMax,
				(byte)CheckSum

			};

			return data;
		}
	}

	/// <summary>
	/// Abstract class for Device ID (page 0x004) of
	/// smart sensor.
	/// </summary>
	public abstract class DeviceID : SensorDataLibrary
	{
		//page 4 on the EEPROM
		public Validity DeviceIDValidity { get; set; } = Validity.Valid;
		public TypeCode IDClass { get; set; } = TypeCode.Oxygen; //Wouldn't this change for each sensor?
		public byte UnusedID { get; set; } = 0;
		public RecordFormat DeviceIDRecordFormat { get; set; } = 0;
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

		public override List<byte> GetBytes()
		{
			List<byte> data = new()
			{
				(byte)DeviceIDValidity,
				(byte)IDClass,
				UnusedID,
				(byte)DeviceIDRecordFormat,
				(byte)DateCode,
				(byte)SSDate,
			//SERIAL NUMBER GOES HERE
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
	/// Abstract class for Manufacturing ID Records 
	/// (page 0x005) of smart sensor.
	/// </summary>
	public abstract class ManufactureID : SensorDataLibrary
	{
		//page 5 on the EEPROM
		public Validity ManufacturingValidity { get; set; } = Validity.Valid;
		public TypeCode ManufacturingClass { get; set; } //Variable
		public byte UnusedMROne { get; set; } = 0;
		public RecordFormat ManufacturingRecordFormat { get; set; } //Variable
		public int UnusedMRTwo { get; set; } = 0;
		public int SSDate { get; set; } //1 byte month, 1 byte day, 2 bytes year
		public int SerialNumber { get; set; } //ASCII data
		public int UnusedMRThree { get; set; } = 0;
		public int Issue { get; set; } = 0;
		public int Revision { get; set; } = 0;
		public int PointRelease { get; set; } = 0;
		public int CheckSum { get; set; } //Calculation

		public override List<byte> GetBytes() 
		{
			List<byte> data = new()
			{
				(byte)ManufacturingValidity,
				(byte)ManufacturingClass,
				UnusedMROne,
				(byte)ManufacturingRecordFormat,
				(byte)UnusedMRTwo,
				(byte)SSDate,
			//SERIAL NUMBER GOES HERE
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

