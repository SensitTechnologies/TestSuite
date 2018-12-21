﻿using System;
using System.Windows.Forms;
using System.IO.Ports;                  // serial port access
using Sensit.TestSDK.Devices;			// mass flow controller

namespace Sensit.App.MassFlow
{
	public partial class FormMassFlow : Form
	{
		// mass flow controller
		private MFC _mfc = new MFC();

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormMassFlow()
		{
			// Initialize the form.
			InitializeComponent();

			// Find all available serial ports.
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxSerialPort.Items.Add(s);
			}

			// Select the most recently used port.
			// The most recently used port is fetched from applications settings.
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;

			// Populate the Gas combo box.
			foreach (MFC.GasSelection gas in Enum.GetValues(typeof(MFC.GasSelection)))
			{
				comboBoxGas.Items.Add(gas);
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

		/// <summary>
		/// Open the serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButtonOpen_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			// (This prevents weird user behavior.  Try removing this line
			// in both radioButton methods, then run the app and click the buttons.)
			if (((RadioButton)sender).Checked)
			{
				try
				{
					// Alert the user.
					toolStripStatusLabel1.Text = "Opening serial port...";

					// Open the Mass Flow Controller (and let it know what serial port to use).
					_mfc.Open(Properties.Settings.Default.Port);

					// Update the user interface.
					comboBoxSerialPort.Enabled = false;
					comboBoxGas.Enabled = true;
					textBoxSetpoint.Enabled = true;
					buttonReadAll.Enabled = true;
					buttonWriteGas.Enabled = true;
					buttonWrite.Enabled = true;
					toolStripStatusLabel1.Text = "Success.";
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
		/// Close the serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButtonClosed_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			if (((RadioButton)sender).Checked)
			{
				try
				{
					// Alert the user.
					toolStripStatusLabel1.Text = "Closing serial port...";

					// Close the serial port.
					_mfc.Close();

					// Update user interface.
					comboBoxSerialPort.Enabled = true;
					comboBoxGas.Enabled = false;
					textBoxSetpoint.Enabled = false;
					buttonReadAll.Enabled = false;
					buttonWriteGas.Enabled = false;
					buttonWrite.Enabled = false;
					toolStripStatusLabel1.Text = "Success.";
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// If an error occurs, alert the user.
					MessageBox.Show(ex.Message, "Error");
					toolStripStatusLabel1.Text = ex.Message;

					// Undo the user action.
					radioButtonOpen.Checked = true;
				}
			}
		}

		/// <summary>
		/// Remember the most recently selected serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.Port = comboBoxSerialPort.Text;
		}

		/// <summary>
		/// When the application closes, save settings and close serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the mass flow controller.
			_mfc.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When the "Update" button is clicked, fetch readings/settings from the mass flow controller.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonReadAll_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Reading from mass flow controller...";

				// Read status from the mass flow controller.
				_mfc.Read(out string pressure, out string temperature,
					out string volumetricFlow, out string massFlow,
					out string setpoint, out string gas);

				// Update the form.
				textBoxPressure.Text = pressure;
				textBoxTemperature.Text = temperature;
				textBoxVolumetricFlow.Text = volumetricFlow;
				textBoxMassFlow.Text = massFlow;
				textBoxSetpoint.Text = setpoint;
				comboBoxGas.Text = gas;
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, "Error");
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		/// <summary>
		/// When the "Write" button is clicked, send the setpoint to the mass flow controller.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonWrite_Click(object sender, EventArgs e)
		{
			try
			{
				// Convert the setpoint to a number.
				float setpoint = Convert.ToSingle(textBoxSetpoint.Text);

				// Write setpoint to the mass flow controller.
				_mfc.SetSetpoint(setpoint);
			}
			catch (FormatException ex)
			{
				// If the user didn't enter a valid number, prompt the user.
				MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
					"Did you type a valid setpoint?", "Error");
				toolStripStatusLabel1.Text = ex.Message;
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, "Error");
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		private void buttonWriteGas_Click(object sender, EventArgs e)
		{
			// Find the selected gas.
			Enum.TryParse(comboBoxGas.Text, out MFC.GasSelection gas);

			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Writing gas selection...";

				// Send the gas selection to the mass flow controller.
				_mfc.SetGas(gas);

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, "Error");
				toolStripStatusLabel1.Text = ex.Message;
			}
		}
	}
}
