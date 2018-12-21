using System;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;			// datalogger

namespace Sensit.App.Keysight
{

	public partial class FormKeysight : Form
	{
		// Keysight datalogger
		private Keysight_34972A _datalogger = new Keysight_34972A();

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormKeysight()
		{
			// Initialize the form.
			InitializeComponent();
		}

		/// <summary>
		/// Connect or disconnect from the instrument.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			// (Otherwise the action will run twice.)
			if (((RadioButton)sender).Checked)
			{
				try
				{
					// If the "Open" radio button has been checked...
					if (((RadioButton)sender) == radioButtonOpen)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Opening serial port...";

						// TODO:  Open the connection.

						// Update the user interface.
						toolStripStatusLabel1.Text = "Success.";
					}
					// If the "Closed" radio button has been checked...
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// TODO:  Close the connection.

						// Update user interface.
						toolStripStatusLabel1.Text = "Success.";
					}
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// Alert the user.
					MessageBox.Show(ex.Message, "Error");
					toolStripStatusLabel1.Text = ex.Message;

					// Undo the user action.
					radioButtonClosed.Checked = true;
				}
			}
		}

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
