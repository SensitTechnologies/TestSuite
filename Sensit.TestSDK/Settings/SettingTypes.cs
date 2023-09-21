using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
		/// Convert setting to bytes.
		/// </summary>
		/// <returns>code that represents the setting</returns>
		public abstract List<byte> GetBytes();

		/// <summary>
		/// Convert bytes to setting.
		/// </summary>
		/// <remarks>
		/// First bytes in the list are assumed to be for the setting.
		/// Remaining bytes are returned back to the user.
		/// </remarks>
		/// <param name="bytes">list of bytes</param>
		/// <returns>list minus the byte(s) converted to the setting</returns>
		public abstract List<byte> SetBytes(List<byte> bytes);
	}

	/// <summary>
	/// Setting with a string value that translates to a 24-byte code
	/// </summary>
	[Serializable]
	public class String24Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public String24Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user.</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public String24Setting(string label, string initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public string Value { get; set; }

		public override List<byte> GetBytes()
		{
			// Convert the first 24 bytes of the string to bytes.
			byte[] bytes = Encoding.ASCII.GetBytes(Value, 0, 24);

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes.ToList();
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Convert the first 24 bytes from the list to an array.
			byte[] values = bytes.Take(24).ToArray();

			// If our machine is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make the array little-endian.
				Array.Reverse(values);
			}

			// Convert the array to a string.
			Value = Encoding.UTF8.GetString(values, 0, values.Length);

			// Remove the first 24 bytes from the list.
			bytes.RemoveRange(0, 24);

			// Return the updated list.
			return bytes;
		}
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

		public override List<byte> GetBytes()
		{
			// Convert the value into a byte array.
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt32(Value));

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes.ToList();
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Convert the first four bytes from the list to an array.
			byte[] values = bytes.Take(4).ToArray();

			// If our machine is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make the array little-endian.
				Array.Reverse(values);
			}

			// Convert the array to an integer.
			Value = BitConverter.ToInt32(values, 0);

			// Remove the first four bytes from the list.
			bytes.RemoveRange(0, 4);

			// Return the updated list.
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

		public override List<byte> GetBytes()
		{
			// Convert the value into a byte array.
			byte[] bytes = BitConverter.GetBytes(Convert.ToInt16(Value));

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes.ToList();
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Convert the first two bytes from the list to an array.
			byte[] values = bytes.Take(2).ToArray();

			// If our machine is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make the array little-endian.
				Array.Reverse(values);
			}

			// Convert the array to an integer.
			Value = BitConverter.ToInt16(values, 0);

			// Remove the first two bytes from the list.
			bytes.RemoveRange(0, 2);

			// Return the updated list.
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

		public override List<byte> GetBytes()
		{
			// Convert the value into a byte array and return as a list.
			return new List<byte> { (byte)Value };
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Convert the first byte in the list.
			Value = (sbyte)bytes.First();

			// Remove the first byte from the list.
			bytes.RemoveAt(0);

			// Return the updated list.
			return bytes;
		}
	}

	/// <summary>
	/// Setting with a decimal value that translates to a 32-bit code.
	/// </summary>
	public class Decimal32Setting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public Decimal32Setting() { }

		/// <summary>
		/// Constructor with label and value.
		/// </summary>
		/// <param name="label">the name of the setting as it appears to the user</param>
		/// <param name="initialValue">the initial value of the setting</param>
		public Decimal32Setting(string label, decimal initialValue)
		{
			Label = label;

			Value = initialValue;
		}

		/// <summary>
		/// The setting's value.
		/// </summary>
		public decimal Value { get; set; } = 0.0M;

		public override List<byte> GetBytes()
		{
			// Multiply the value by 10 and convert to integer.
			int value = Convert.ToInt32(Value * 10.0M);

			// Convert the value into a byte array.
			byte[] bytes = BitConverter.GetBytes(value);

			// If our array is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make it big-endian.
				Array.Reverse(bytes);
			}

			return bytes.ToList();
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			byte[] values = bytes.Take(4).ToArray();

			// If our machine is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make the array little-endian.
				Array.Reverse(values);
			}

			// Convert the first four bytes in the list to a decimal value.
			// Divide by 10 to undo the multiplication when it was converted to bytes.
			Value = BitConverter.ToInt32(values, 0) / 10.0M;

			// Remove the first four bytes from the list.
			bytes.RemoveRange(0, 4);

			// Return the updated list.
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

		public override List<byte> GetBytes()
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

			return bytes.ToList();
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			byte[] values = bytes.Take(2).ToArray();

			// If our machine is little-endian...
			if (BitConverter.IsLittleEndian)
			{
				// Make the array little-endian.
				Array.Reverse(values);
			}

			// Convert the first two bytes in the list to a decimal value.
			// Divide by 10 to undo the multiplication when it was converted to bytes.
			Value = BitConverter.ToInt16(values, 0) / 10.0M;

			// Remove the first two bytes from the list.
			bytes.RemoveRange(0, 2);

			// Return the updated list.
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

		public override List<byte> GetBytes()
		{
			// Multiply the value by 10 and convert to integer.
			byte value = Convert.ToByte(Value * 10.0M);

			// Convert the value into a byte array.
			return new List<byte> { value };
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Convert the first byte to a value.
			Value = Convert.ToDecimal(bytes.First()) / 10.0M;

			// Remove the first byte from the list.
			bytes.RemoveAt(0);

			// Return the updated list.
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

		public override List<byte> GetBytes()
		{
			// Convert value to byte.
			byte value = Value ? (byte)0x01 : (byte)0x00;

			// Return list with the new byte.
			return new List<byte> { value };
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Convert the first byte in the list.
			Value = Convert.ToBoolean(bytes.First());

			// Remove the byte from the list.
			bytes.RemoveAt(0);

			// Return the updated list.
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

		public override List<byte> GetBytes()
		{
			// Convert the enumeration to its byte value, and return as a list.
			return new List<byte> { Values[Value].Code };
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Save the first byte in the list.
			byte code = bytes.First();

			// Find the value with the corresponding code.
			// https://stackoverflow.com/questions/43021/how-do-you-get-the-index-of-the-current-iteration-of-a-foreach-loop
			foreach ((EnumValue e, int i) in Values.Select((e, i) => (e, i)))
			{
				// If we've found the code we're searching for...
				if (e.Code == code)
				{
					// Save the enumeration index.
					Value = i;
				}
			}

			// Remove the byte from the list.
			bytes.RemoveAt(0);

			// Return the updated list.
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

	public class CategorySetting : Setting
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Constructor with no parameters is required for serialization.
		/// </remarks>
		public CategorySetting() { }

		/// <summary>
		/// Constructor with label.
		/// </summary>
		/// <param name="label"></param>
		public CategorySetting(string label)
		{
			Label = label;
		}

		public override List<byte> GetBytes()
		{
			// Since this is a category, it contains no data.
			return new List<byte>();
		}

		public override List<byte> SetBytes(List<byte> bytes)
		{
			// Do not tamper with the list of bytes.
			// Just pass it through.
			return bytes;
		}
	}
}
