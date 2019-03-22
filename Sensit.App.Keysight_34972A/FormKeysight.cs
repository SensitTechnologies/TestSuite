using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Windows.Forms;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;

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

			// Add version string to title bar.
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text += " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}

			// Set up the data view.
			dataGridViewMeasurements.ColumnCount = 2;
			dataGridViewMeasurements.Columns[0].Name = "Channel";
			dataGridViewMeasurements.Columns[1].Name = "Measurement";

			// Populate options from saved settings.
			numericUpDownBank.Value = Properties.Settings.Default.Bank;
			numericUpDownNumChannels.Value = Properties.Settings.Default.Channels;

			// Find all available instruments.
			Find();
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

		/// <summary>
		/// When the application closes, save current settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormKeysight_FormClosing(object sender, FormClosingEventArgs e)
		{
			Properties.Settings.Default.Bank = Convert.ToUInt32(numericUpDownBank.Value);
			Properties.Settings.Default.Channels = Convert.ToUInt32(numericUpDownNumChannels.Value);
			Properties.Settings.Default.Save();
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
						groupBoxConfiguration.Enabled = true;
						toolStripStatusLabel1.Text = "VISA connection opened.";
					}
					// If the "Closed" radio button has been checked...
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// Close the connection.
						_datalogger.Close();

						// Update user interface.
						groupBoxConfiguration.Enabled = false;
						toolStripStatusLabel1.Text = "VISA connection closed.";
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
		/// When the "Configure" button is clicked, set up the instrument.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonConfigure_Click(object sender, EventArgs e)
		{
			List<bool> channels = new List<bool>();

			for(int i = 0; i < numericUpDownNumChannels.Value; i++)
			{
				channels.Add(true);
			}

			_datalogger.Configure((int)numericUpDownBank.Value, channels);
		}

		/// <summary>
		/// When the "Measure" button is clicked, read from all channels.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonMeasure_Click(object sender, EventArgs e)
		{
			try
			{
				// Read from datalogger.
				List<double> readings = _datalogger.Read();

				// Update GUI.
				dataGridViewMeasurements.Rows.Clear();
				for (int i = 0; i < readings.Count; i++)
				{
					string[] row = { (i + 1).ToString(), readings[i].ToString() };
					dataGridViewMeasurements.Rows.Add(row);
				}

			}
			catch (DeviceSettingNotSupportedException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
