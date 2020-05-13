using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace Sensit.TestSDK.Utilities
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
		/// <param name="value">enumeration of interest</param>
		/// <returns></returns>
		public static string GetDescription(this Enum value)
		{
			Type type = value?.GetType();

			string description = null;
			string name = Enum.GetName(type, value);
			if (name != null)
			{
				FieldInfo field = type.GetField(name);
				if (field != null)
				{
					if (Attribute.GetCustomAttribute(field,
						typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
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

		/// <summary>
		/// Extension method to read a description attribute associated with a type.
		/// </summary>
		/// <param name="type">type of interest</param>
		/// <returns></returns>
		public static string GetDescription(this Type type)
		{
			DescriptionAttribute description = (DescriptionAttribute)type.GetCustomAttribute(typeof(DescriptionAttribute));

			if (description == null)
			{
				return type?.Name;
			}
			else
			{
				return description.Description;
			}
		}

		/// <summary>
		/// Extension method to read a category attribute associated with a type.
		/// </summary>
		/// <param name="type">type of interest</param>
		/// <returns></returns>
		public static string GetCategory(this Type type)
		{
			CategoryAttribute category = (CategoryAttribute)type.GetCustomAttribute(typeof(CategoryAttribute));

			if (category == null)
			{
				return type?.Name;
			}
			else
			{
				return category.Category;
			}
		}

		/// <summary>
		/// Find classes that implement an interface or extend a base class.
		/// </summary>
		/// <remarks>
		/// Inspiration:
		/// https://stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface
		/// </remarks>
		/// <example><code>
		/// FindDeviceTypes(typeof(IControlDevice));
		/// </code></example>
		/// <param name="type">base type</param>
		/// <returns></returns>
		public static List<Type> FindClasses(Type type)
		{
			IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p) && p.IsClass);

			return types.ToList();
		}

		/// <summary>
		/// Find interfaces based on another interface.
		/// </summary>
		/// <param name="type">base interface</param>
		/// <returns></returns>
		public static List<Type> FindInterfaces(Type type)
		{
			IEnumerable<Type> types = AppDomain.CurrentDomain.GetAssemblies()
				.SelectMany(s => s.GetTypes())
				.Where(p => type.IsAssignableFrom(p) && p.IsInterface && p != type);

			return types.ToList();
		}
	}
}
