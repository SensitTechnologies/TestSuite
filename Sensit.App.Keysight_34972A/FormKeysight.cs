using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Devices;

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

			// Find all available instruments.
			Find();
		}

		/// <summary>
		/// When the "Refresh" button is clicked, update instrument list.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			Find();
		}

		/// <summary>
		/// Find all available instruments.
		/// </summary>
		private void Find()
		{
			// Find all available VISA-over-USB devices.
			IEnumerable<string> devices = VisaDevice.Find(VisaPattern.USB);

			// Remove all items.
			comboBoxResources.Items.Clear();

			// Add found items.
			foreach (string d in devices)
			{
				comboBoxResources.Items.Add(d);
			}

			// Select the first item.
			comboBoxResources.SelectedIndex = 0;
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
						toolStripStatusLabel1.Text = "Opening VISA connection...";

						// Open the connection.
						_datalogger.Open(comboBoxResources.Text);

						// Update the user interface.
						toolStripStatusLabel1.Text = "VISA open.";
					}
					// If the "Closed" radio button has been checked...
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// Close the connection.
						_datalogger.Close();

						// Update user interface.
						toolStripStatusLabel1.Text = "VISA closed.";
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
