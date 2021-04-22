using System;
using System.Deployment.Application;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.GasConcentration
{
	public partial class FormGasMixer : Form
	{
		// mass flow controllers
		// You need two to mix gasses and control gas concentration.
		private ColeParmerMFC _mfcAnalyte = new ColeParmerMFC();
		private ColeParmerMFC _mfcDiluent = new ColeParmerMFC();

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

			// Find all available serial ports.
			string[] portNames = SerialPort.GetPortNames();
			comboBoxAnalytePort.Items.AddRange(portNames);
			comboBoxDiluentPort.Items.AddRange(portNames);

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

			// Select the most recently used gas, or the first if that's not available.
			int index = comboBoxAnalyteGas.FindStringExact(Properties.Settings.Default.GasAnalyte);
			comboBoxAnalyteGas.SelectedIndex = index == -1 ? 0 : index;

			// Select the most recently used gas, or the first if that's not available.
			index = comboBoxDiluentGas.FindStringExact(Properties.Settings.Default.GasDiluent);
			comboBoxDiluentGas.SelectedIndex = index == -1 ? 0 : index;
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
		/// Open the serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void radioButton_CheckedChanged(object sender, EventArgs e)
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
						groupBoxGasses.Enabled = true;
						groupBoxFlowAndMixture.Enabled = true;
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
						groupBoxGasses.Enabled = false;
						groupBoxFlowAndMixture.Enabled = false;
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
		private void comboBoxSerialPortGasUnderTest_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortAnalyte = comboBoxAnalytePort.Text;
		}

		/// <summary>
		/// Remember the most recently selected serial port (for dilutent).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxSerialPortDiluent_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortDiluent = comboBoxDiluentPort.Text;
		}

		/// <summary>
		/// Remember the most recently selected analyte gas.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxAnalyteGas_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the gas selection in the application settings.
			Properties.Settings.Default.GasAnalyte = comboBoxAnalyteGas.Text;
		}

		/// <summary>
		/// Remember the most recently selected diluent gas.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxDiluentGas_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the gas selection in the application settings.
			Properties.Settings.Default.GasDiluent = comboBoxDiluentGas.Text;
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
		/// When the "Write Gas" button is clicked, send the gas selection to the mass flow controller.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void buttonWriteGas_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Writing gas selections...";

				// Find the selected gas.
				Enum.TryParse(comboBoxAnalyteGas.Text, out Gas analyteGas);
				Enum.TryParse(comboBoxDiluentGas.Text, out Gas diluentGas);

				// Send the gas selection to the mass flow controller.
				_mfcAnalyte.SetGas(analyteGas);
				_mfcDiluent.SetGas(diluentGas);

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.GetType().ToString();
			}
		}

		private void buttonReadConcentration_Click(object sender, EventArgs e)
		{
			try
			{
				// Fetch new values from the mass flow controllers.
				_mfcAnalyte.Read();
				_mfcDiluent.Read();

				// Calculate total mass flow.
				double massFlow = _mfcDiluent.Readings[VariableType.MassFlow] + _mfcAnalyte.Readings[VariableType.MassFlow];

				// Calculate analyte concentration.
				double analyteConcentration;
				if (massFlow.Equals(0.0))
				{
					analyteConcentration = 0.0;
				}
				else
				{
					analyteConcentration = _mfcAnalyte.Readings[VariableType.MassFlow] / massFlow * 100;
				}

				// Update the form.
				textBoxGasConcentration.Text = analyteConcentration.ToString();
				textBoxMassFlow.Text = massFlow.ToString();

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.GetType().ToString();
			}
		}

		private void buttonWriteGasConcentrationSetpoint_Click(object sender, EventArgs e)
		{
			try
			{
				// Convert the setpoints to numbers.
				double analyteConcentration = Convert.ToDouble(textBoxGasConcentration.Text);
				double massFlowSetpoint = Convert.ToDouble(textBoxMassFlow.Text);

				// Check for valid mass flow.
				if (massFlowSetpoint < 0.0)
				{
					throw new DeviceOutOfRangeException("Total Flow Setpoint must be greater than or equal to 0.0.");
				}

				// Check for valid gas concentration.
				if ((analyteConcentration < 0.0) || (analyteConcentration > 100.0))
				{
					throw new DeviceOutOfRangeException("Gas Mix Setpoint must be between 0.0% and 100.0%, inclusive."
						+ Environment.NewLine + "Attempted Gas Mix Setpoint was:  " + massFlowSetpoint);
				}

				// For analyte:  mass Flow = desired flow rate / original concentration.
				_mfcAnalyte.WriteSetpoint(VariableType.MassFlow, massFlowSetpoint * (analyteConcentration / 100));

				// For diluent:  mass flow = desired flow - gas under test flow.
				_mfcDiluent.WriteSetpoint(VariableType.MassFlow, massFlowSetpoint - _mfcAnalyte.ReadSetpoint(VariableType.MassFlow));

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (FormatException ex)
			{
				// If the user didn't enter a valid number, prompt the user.
				MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
					"Did you type a valid setpoint?", ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.GetType().ToString();
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString());
				toolStripStatusLabel1.Text = ex.GetType().ToString();
			}
		}
	}
}
