using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

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

		#region Table Layout Panel Helper Methods

		/// <summary>
		/// Remove all controls from a table layout panel.
		/// </summary>
		/// <param name="panel">table layout panel to act upon</param>
		public static void TableLayoutPanelClear(TableLayoutPanel panel)
		{
			// Check for null argument.
			if (panel is null)
			{
				throw new ArgumentNullException(nameof(panel));
			}

			// Stop the GUI from looking weird while we update it.
			panel.SuspendLayout();

			// For each column in the panel...
			for (int i = 0; i < panel.ColumnCount; i++)
			{
				// Remove all controls except for those in the header row.
				for (int j = 1; j < panel.RowCount; j++)
				{
					Control control = panel.GetControlFromPosition(i, j);
					panel.Controls.Remove(control);
				}
			}

			// Make the GUI act normally again.
			panel.ResumeLayout();
		}

		/// <summary>
		/// Remove a row from a table layout panel.
		/// </summary>
		/// <remarks>
		/// source:  https://stackoverflow.com/questions/6202144/is-there-a-way-to-remove-all-controls-from-a-row-in-tablelayoutpanel/6202242
		/// </remarks>
		/// <param name="panel">table layout panel to act upon</param>
		/// <param name="rowIndex">index of the row to remove</param>
		public static void TableLayoutPanelRemoveRow(this TableLayoutPanel panel, int rowIndex)
		{
			// Check for null argument.
			if (panel is null)
			{
				throw new ArgumentNullException(nameof(panel));
			}

			// Stop the GUI from looking weird while we update it.
			panel.SuspendLayout();

			// Remove the row's row style.
			panel.RowStyles.RemoveAt(rowIndex);

			// For each column in the panel...
			for (int columnIndex = 0; columnIndex < panel.ColumnCount; columnIndex++)
			{
				// Remove the control in that position.
				var control = panel.GetControlFromPosition(columnIndex, rowIndex);
				panel.Controls.Remove(control);
			}

			// For each row after the one being removed...
			for (int i = rowIndex + 1; i < panel.RowCount; i++)
			{
				// Move each control up a row.
				for (int columnIndex = 0; columnIndex < panel.ColumnCount; columnIndex++)
				{
					var control = panel.GetControlFromPosition(columnIndex, i);
					panel.SetRow(control, i - 1);
				}
			}

			// Delete the last row in the panel.
			panel.RowCount--;

			// Make the GUI act normally again.
			panel.ResumeLayout();
		}

		#endregion
	}
}
