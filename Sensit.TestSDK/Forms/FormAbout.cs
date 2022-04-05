using System.Reflection;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	/// <summary>
	/// Generic About Box that can be used in any application.
	/// </summary>
	/// <remarks>
	/// This form is similar to the stock "AboutBox" form, which you get from
	/// Right click --> Add --> New Item --> About Box.
	/// Assembly Attribute Accessors have been replaced with normal properties
	/// so they can be written by the calling app.
	/// "GetExecutingAssembly" has been replaced with "GetEntryAssembly" as the
	/// source of default values for the form.
	/// </remarks>
	public partial class FormAbout : Form
	{
		string _title;
		string _version;

		public FormAbout()
		{
			InitializeComponent();

			// Get the assembly title.
			object[] titleAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
			if (titleAttributes.Length != 0)
			{
				AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)titleAttributes[0];

				// If a title string exists...
				if (string.IsNullOrEmpty(titleAttribute.Title) == false)
				{
					Title = titleAttribute.Title;
				}
			}
			else
			{
				Title = System.IO.Path.GetFileNameWithoutExtension(Assembly.GetEntryAssembly().Location);
			}

			// Get the assembly version.
			Version = Assembly.GetEntryAssembly().GetName().Version.ToString();

			// Get the assembly description.
			object[] descriptionAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
			if (descriptionAttributes.Length != 0)
			{
				Description = ((AssemblyDescriptionAttribute)descriptionAttributes[0]).Description;
			}

			// Get the assembly product.
			object[] productAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
			if (productAttributes.Length != 0)
			{
				Product = ((AssemblyProductAttribute)productAttributes[0]).Product;
			}

			// Get the assembly copyright.
			object[] copyrightAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
			if (copyrightAttributes.Length != 0)
			{
				Copyright = ((AssemblyCopyrightAttribute)copyrightAttributes[0]).Copyright;
			}

			// Get the assembly company.
			object[] companyAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
			if (companyAttributes.Length != 0)
			{
				Company = ((AssemblyCompanyAttribute)companyAttributes[0]).Company;
			}
		}

		public string Title
		{
			get => _title;
			set
			{
				_title = value;

				Text = $"About {Title}";
			}
		}

		public string Version
		{
			get => _version;
			set
			{
				_version = value;

				labelVersion.Text = $"Version {Version}";
			}
		}

		public string Description
		{
			get => textBoxDescription.Text;
			set => textBoxDescription.Text = value;
		}

		public string Product
		{
			get => labelProductName.Text;
			set => labelProductName.Text = value;
		}

		public string Copyright
		{
			get => labelCopyright.Text;
			set => labelCopyright.Text = value;
		}

		public string Company
		{
			get => labelCompanyName.Text;
			set => labelCompanyName.Text = value;
		}
	}
}
