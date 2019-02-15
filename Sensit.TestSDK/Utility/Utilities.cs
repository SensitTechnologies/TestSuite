using System;
using System.ComponentModel;
using System.Reflection;

namespace Sensit.TestSDK.Utility
{
	public static class Utilities
	{
		/// <summary>
		/// Extension method to read a description attribute associated with an Enumeration
		/// </summary>
		/// <remarks>
		/// If no description attribute exists, we return the enum string itself.
		/// How to associate "friendly strings" with enumerations:
		/// https://stackoverflow.com/questions/1415140/can-my-enums-have-friendly-names
		/// https://stackoverflow.com/questions/479410/enum-tostring-with-user-friendly-strings
		/// </remarks>
		/// <param name="value">description of the enumeration</param>
		/// <returns></returns>
		public static string GetDescription(this Enum value)
		{
			Type type = value.GetType();

			string description = null;
			string name = Enum.GetName(type, value);
			if (name != null)
			{
				FieldInfo field = type.GetField(name);
				if (field != null)
				{
					DescriptionAttribute attribute = Attribute.GetCustomAttribute(field,
						typeof(DescriptionAttribute)) as DescriptionAttribute;
					if (attribute != null)
					{
						// If a description exists, use that.
						description = attribute.Description;
					}
					else
					{
						// If no description exists, return the enum's string representation.
						description = value.ToString();
					}
				}
			}

			return description;
		}
	}
}
