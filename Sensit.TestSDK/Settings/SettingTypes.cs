using System;
using System.Collections.Generic;

namespace Sensit.TestSDK.Settings
{
	/// <summary>
	/// Base class for any type of setting.
	/// </summary>
	public abstract class Setting
	{
		/// <summary>
		/// Constructor with no arguments.
		/// </summary>
		public Setting() { }

		/// <summary>
		/// Constructor with label.
		/// </summary>
		/// <param name="label"></param>
		public Setting(string label)
		{
			Label = label;
		}

		/// <summary>
		/// The name of the setting as it appears to the user.
		/// </summary>
		public string Label { get; set; } = string.Empty;

		/// <summary>
		/// Calculate the byte code for the setting.
		/// </summary>
		/// <returns>code that represents the setting</returns>
		public abstract byte[] GetBytes();
	}

	/// <summary>
	/// Setting with an integer value that translates into a 32-bit code.
	/// </summary>
	[Serializable]
	public class Int32Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public Int32Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user.</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public Int32Setting(string label, int initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public int Value { get; set; }

		/// <summary>
		/// Return the setting's value, converted to a 4-byte array.
		/// </summary>
		/// <returns>byte array representing the setting</returns>
		public override byte[] GetBytes()
		{
			// Convert the value into a byte array.
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Value));

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes;
		}
	}

	/// <summary>
	/// Setting with an integer value that translates into a 16-bit code.
	/// </summary>
	[Serializable]
	public class Int16Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public Int16Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user.</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public Int16Setting(string label, int initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public int Value { get; set; }

		/// <summary>
		/// Return the setting's value, converted to a 2-byte array.
		/// </summary>
		/// <returns>byte array representing the setting</returns>
		public override byte[] GetBytes()
		{
			// Convert the value into a byte array.
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt16(Value));

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes;
		}
	}

	/// <summary>
	/// Setting with an integer value that translates into a 8-bit code.
	/// </summary>
	public class Int8Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public Int8Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user.</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public Int8Setting(string label, int initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public int Value { get; set; }

		/// <summary>
		/// Return the setting's value, converted to a 1-byte array.
		/// </summary>
		/// <returns>byte array representing the setting</returns>
		public override byte[] GetBytes()
		{
			// Convert the value into a byte array.
			byte[] bytes = { (byte)Value };

			return bytes;
		}
	}

	/// <summary>
	/// Setting with a decimal value that translates to a 16-bit code.
	/// </summary>
	public class Decimal16Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public Decimal16Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public Decimal16Setting(string label, decimal initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public decimal Value { get; set; } = 0.0M;

		/// <summary>
		/// Return the setting's value as a 2-byte array.
		/// </summary>
		/// <returns></returns>
		public override byte[] GetBytes()
		{
			// Multiply the value by 10 and convert to integer.
			short value = Convert.ToInt16(Value * 10.0M);

			// Convert the value into a byte array.
			byte[] bytes = BitConverter.GetBytes(value);

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes;
		}
	}

	/// <summary>
	/// Setting with a decimal value that translates to an 8-bit code.
	/// </summary>
	public class Decimal8Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public Decimal8Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public Decimal8Setting(string label, decimal initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public decimal Value { get; set; } = 0.0M;

		/// <summary>
		/// Return the setting's value as a 1-byte array.
		/// </summary>
		/// <returns></returns>
		public override byte[] GetBytes()
		{
			// Multiply the value by 10 and convert to integer.
			byte value = Convert.ToByte(Value * 10.0M);

			// Convert the value into a byte array.
			byte[] bytes = { value };

			return bytes;
		}
	}

	/// <summary>
	/// A boolean setting (to enable/disable something).
	/// </summary>
	public class BoolSetting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public BoolSetting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public BoolSetting(string label, bool initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		public bool Value { get; set; }

		/// <summary>
		/// Return the setting's value, converted to a 1-byte array.
		/// </summary>
		/// <returns></returns>
		public override byte[] GetBytes()
		{
			byte[] bytes = { 0x00 };

			if (Value == true)
			{
				bytes[0] = 0x01;
			}

			return bytes;
		}
	}

	/// <summary>
	/// Setting with custom enumerated values that translates to an 8-bit value.
	/// </summary>
	public class EnumSetting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public EnumSetting() { }

		/// <summary>
		/// Constructor with label and enumerated values.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user</param>
		/// <param name="settingValues">list of all possible values the setting can have</param>
		public EnumSetting(string label, List<EnumValue> settingValues)
		{
			Label = label;

			foreach (EnumValue g in settingValues ?? new List<EnumValue>())
			{
				Values.Add(g);
			}
		}

		/// <summary>
		/// Constructor with label, enumerated values, and the default value
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user</param>
		/// <param name="settingValues">list of all possible values the setting can have</param>
		/// <param name="initialValue">0-based index of the setting's initial value</param>
		public EnumSetting(string label, List<EnumValue> settingValues, int initialValue)
		{
			Label = label;

			foreach (EnumValue g in settingValues ?? new List<EnumValue>())
			{
				Values.Add(g);
			}

			Value = initialValue;
		}

		/// <summary>
		/// List of all possible values the setting can have.
		/// </summary>
		public List<EnumValue> Values { get; } = new List<EnumValue>();

		/// <summary>
		/// 0-based index of the setting's current value.
		/// </summary>
		public int Value { get; set; }

		/// <summary>
		/// Return the setting's value, converted to a 1-byte array.
		/// </summary>
		/// <returns></returns>
		public override byte[] GetBytes()
		{
			byte[] bytes = { Values[Value].Code };

			return bytes;
		}
	}

	/// <summary>
	/// Enumerated value for an EnumSetting.
	/// </summary>
	public class EnumValue
	{
		/// <summary>
		/// Constructor with no arguments.
		/// </summary>
		public EnumValue() { }

		/// <summary>
		/// Constructor with label.
		/// </summary>
		/// <param name="label">The name of the value as it appears to the user</param>
		public EnumValue(string label)
		{
			Label = label;
		}

		/// <summary>
		/// Constructor with label and byte code.
		/// </summary>
		/// <param name="label">the name of the value as it appears to the user</param>
		/// <param name="code">the byte code corresponding to the value</param>
		public EnumValue(string label, byte code)
		{
			Label = label;

			Code = code;
		}

		/// <summary>
		/// The name of the selection as it appears to the user.
		/// </summary>
		public string Label { get; set; } = string.Empty;

		/// <summary>
		/// The byte code that corresponds to the selection.
		/// </summary>
		public byte Code { get; }
	}
}
