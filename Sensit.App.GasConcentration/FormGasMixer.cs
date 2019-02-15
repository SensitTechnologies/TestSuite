﻿using System;
using System.Deployment.Application;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.GasConcentration
{
	public partial class FormGasMixer : Form
	{
		// mass flow controllers
		// You need two to mix gasses and control gas concentration.
		private ColeParmerMFC _mfcAnalyte = new ColeParmerMFC();
		private ColeParmerMFC _mfcDiluent = new ColeParmerMFC();
		private GasMixingDevice _gasMixer;

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormGasMixer()
		{
			// Initialize the form.
			InitializeComponent();

			// Add version string to title bar.
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text += " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}

			// This has to be created in the constructor, because it references
			// non-static objects.
			_gasMixer = new GasMixingDevice(
				_mfcDiluent, _mfcDiluent, _mfcAnalyte, _mfcAnalyte);

			// Find all available serial ports.
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxAnalytePort.Items.Add(s);
				comboBoxDiluentPort.Items.Add(s);
			}

			// Select the most recently used port.
			// The most recently used port is fetched from application settings.
			comboBoxAnalytePort.Text = Properties.Settings.Default.PortAnalyte;
			comboBoxDiluentPort.Text = Properties.Settings.Default.PortDiluent;

			// Populate the Gas combo box.
			foreach (Gas gas in Enum.GetValues(typeof(Gas)))
			{
				comboBoxAnalyteGas.Items.Add(gas);
				comboBoxDiluentGas.Items.Add(gas);
			}
		}

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Open the serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButton_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			// (Otherwise the actions will run twice.)
			if (((RadioButton)sender).Checked)
			{
				try
				{
					// If the "Open" radio button has been checked...
					if (((RadioButton)sender) == radioButtonOpen)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Opening serial ports...";

						// If both ports are the same, send an error.
						if (comboBoxAnalytePort.Text.Equals(comboBoxDiluentPort.Text))
						{
							throw new ArgumentException("Both ports can't be the same.");
						}

						// Open the Mass Flow Controllers (and let it know what serial port to use).
						_mfcAnalyte.Open(Properties.Settings.Default.PortAnalyte);
						_mfcDiluent.Open(Properties.Settings.Default.PortDiluent);

						// Update the user interface.
						comboBoxAnalytePort.Enabled = false;
						comboBoxDiluentPort.Enabled = false;
						groupBoxMassFlow.Enabled = true;
						groupBoxGasConcentration.Enabled = true;
						toolStripStatusLabel1.Text = "Port open.";
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Close the serial port.
						_mfcAnalyte.Close();
						_mfcDiluent.Close();

						// Update the user interface.
						comboBoxAnalytePort.Enabled = true;
						comboBoxDiluentPort.Enabled = true;
						groupBoxMassFlow.Enabled = false;
						groupBoxGasConcentration.Enabled = false;
						toolStripStatusLabel1.Text = "Port closed.";
					}
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// Alert the user.
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString());

					// Undo the user action.
					radioButtonClosed.Checked = true;
				}
			}
		}

		/// <summary>
		/// Remember the most recently selected serial port (for gas under test).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxSerialPortGasUnderTest_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortAnalyte = comboBoxAnalytePort.Text;
		}

		/// <summary>
		/// Remember the most recently selected serial port (for dilutent).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxSerialPortDiluent_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortDiluent = comboBoxDiluentPort.Text;
		}

		/// <summary>
		/// When the application closes, save settings and close serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormGasConcentration_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the mass flow controllers.
			_mfcDiluent.Close();
			_mfcAnalyte.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When the "Update" button is clicked, fetch readings/settings from the mass flow controllers.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonReadAll_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Reading from mass flow controllers...";

				// Read status from the mass flow controllers.
				_mfcAnalyte.Read();
				_mfcDiluent.Read();

				// Update the form.
				textBoxAnalytePressure.Text = _mfcAnalyte.Pressure.ToString();
				textBoxDiluentPressure.Text = _mfcDiluent.Pressure.ToString();
				textBoxAnalyteTemperature.Text = _mfcAnalyte.Temperature.ToString();
				textBoxDiluentTemperature.Text = _mfcDiluent.Temperature.ToString();
				textBoxAnalyteVolumetricFlow.Text = _mfcAnalyte.VolumeFlow.ToString();
				textBoxDiluentVolumetricFlow.Text = _mfcDiluent.VolumeFlow.ToString();
				textBoxAnalyteMassFlow.Text = _mfcAnalyte.MassFlow.ToString();
				textBoxDiluentMassFlow.Text = _mfcDiluent.MassFlow.ToString();
				textBoxAnalyteSetpoint.Text = _mfcAnalyte.MassFlowSetpoint.ToString();
				textBoxDiluentSetpoint.Text = _mfcDiluent.MassFlowSetpoint.ToString();
				comboBoxAnalyteGas.Text = _mfcAnalyte.GasSelection.ToString();
				comboBoxDiluentGas.Text = _mfcDiluent.GasSelection.ToString();
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		/// <summary>
		/// When the "Write Gas" button is clicked, send the gas selection to the mass flow controller.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonWriteGas_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Writing gas selections...";

				// Find the selected gas.
				Enum.TryParse(comboBoxAnalyteGas.Text, out Gas analyteGas);
				Enum.TryParse(comboBoxDiluentGas.Text, out Gas diluentGas);

				// Send the gas selection to the mass flow controller.
				_mfcAnalyte.GasSelection = analyteGas;
				_mfcDiluent.GasSelection = diluentGas;
				_mfcAnalyte.Configure();
				_mfcDiluent.Configure();

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		/// <summary>
		/// When the "Write SP" button is clicked, send the setpoint to the mass flow controller.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonWrite_Click(object sender, EventArgs e)
		{
			try
			{
				// Convert the setpoints to numbers.
				double analyteSetpoint = Convert.ToDouble(textBoxAnalyteSetpoint.Text);
				double diluentSetpoint = Convert.ToDouble(textBoxDiluentSetpoint.Text);

				// Write setpoints to mass flow controllers.
				_mfcAnalyte.WriteMassFlowSetpoint(analyteSetpoint);
				_mfcDiluent.WriteMassFlowSetpoint(diluentSetpoint);

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (FormatException ex)
			{
				// If the user didn't enter a valid number, prompt the user.
				MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
					"Did you type a valid setpoint?", ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		private void ButtonReadConcentration_Click(object sender, EventArgs e)
		{
			try
			{
				// Fetch new values from the mass flow controllers.
				_gasMixer.Read();

				// Update the form.
				textBoxGasConcentration.Text = _gasMixer.GasMix.ToString();
				textBoxGasConcentrationSetpoint.Text = _gasMixer.GasMixSetpoint.ToString();
				textBoxMassFlowSetpoint.Text = _gasMixer.MassFlowSetpoint.ToString();
				textBoxAnalyteBottleConcentration.Text = _gasMixer.AnalyteBottleConcentration.ToString();
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		private void ButtonWriteGasConcentrationSetpoint_Click(object sender, EventArgs e)
		{
			try
			{
				// Convert the setpoints to numbers.
				double analyteConcentration = Convert.ToDouble(textBoxGasConcentrationSetpoint.Text);
				double massFlowSetpoint = Convert.ToDouble(textBoxMassFlowSetpoint.Text);
				double bottleConcentration = Convert.ToDouble(textBoxAnalyteBottleConcentration.Text);

				// Write the properties.
				_gasMixer.GasMixSetpoint = analyteConcentration;
				_gasMixer.MassFlowSetpoint = massFlowSetpoint;
				_gasMixer.AnalyteBottleConcentration = bottleConcentration;

				// Write to mass flow controllers.
				_gasMixer.WriteGasMixSetpoint();
			}
			catch (FormatException ex)
			{
				// If the user didn't enter a valid number, prompt the user.
				MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
					"Did you type a valid setpoint?", ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.Message;
			}
		}
	}
}