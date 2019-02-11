using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	// This class is an attempt to make the "InputDialog.cs" look nicer by using the form designer.
	// It was set aside because it wasn't worth the time commitment at the time.
	// If you decide to work on it, implement this class as a messagebox which returns a dialog result, then use this class instead of the "InputDialog.cs" class in the SDK.
	// TODO:  Either improve InputDialog (make the form autosize), or replace with FormInputDialog (must support read-only messages to display manual setpoints to user).
	public partial class FormInputDialog : Form
	{
		public FormInputDialog()
		{
			InitializeComponent();
			FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		public FormInputDialog(string caption)
		{
			// Set the form's caption.
			Text = caption;
			FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		public FormInputDialog(string caption, string label)
		{
			Text = caption;
			Label = label;
			FormBorderStyle = FormBorderStyle.FixedDialog;
		}

		/// <summary>
		/// Text displayed to the user above the input control.
		/// </summary>
		/// <remarks>
		/// Blank by default.
		/// </remarks>
		public string Label
		{
			get => label1.Text;
			set => label1.Text = value;
		}


	}
}
