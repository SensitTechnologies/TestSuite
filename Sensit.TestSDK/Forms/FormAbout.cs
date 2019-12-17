using System;
using System.Reflection;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	/// <summary>
	/// Generic About Box that can be used in any application.
	/// </summary>
	/// <remarks>
	/// This form is the same as the stock "AboutBox" form, which you get from
	/// Right click --> Add --> New Item --> About Box, except that
	/// "GetExecutingAssembly" has been replaced with "GetEntryAssembly" in
	/// the Asembly Attribute Accessors, and the option to add to the description.
	/// </remarks>
	public partial class FormAbout : Form
	{
		#region Constructors

		public FormAbout()
		{
			Initialize();
		}

		public FormAbout(string description)
		{
			Initialize();

			textBoxDescription.Text += Environment.NewLine + description;
		}

		private void Initialize()
		{
			InitializeComponent();

			Text = $"About {AssemblyTitle}";
			labelProductName.Text = AssemblyProduct;
			labelVersion.Text = $"Version {AssemblyVersion}";
			labelCopyright.Text = AssemblyCopyright;
			labelCompanyName.Text = AssemblyCompany;
			textBoxDescription.Text = AssemblyDescription;
		}

		#endregion

		#region Assembly Attribute Accessors

		public string AssemblyTitle
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
				if (attributes.Length > 0)
				{
					AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];

					// If a title string exists...
					if (string.IsNullOrEmpty(titleAttribute.Title) == false)
					{
						return titleAttribute.Title;
					}
				}
				return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().CodeBase);
			}
		}

		public string AssemblyVersion
		{
			get
			{
				return Assembly.GetEntryAssembly().GetName().Version.ToString();
			}
		}

		public string AssemblyDescription
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyDescriptionAttribute)attributes[0]).Description;
			}
		}

		public string AssemblyProduct
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyProductAttribute)attributes[0]).Product;
			}
		}

		public string AssemblyCopyright
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
			}
		}

		public string AssemblyCompany
		{
			get
			{
				object[] attributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
				if (attributes.Length == 0)
				{
					return "";
				}
				return ((AssemblyCompanyAttribute)attributes[0]).Company;
			}
		}
		#endregion
	}
}
