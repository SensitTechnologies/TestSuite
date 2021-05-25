using System;
using System.Deployment.Application;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.PowerSupply
{
	public partial class FormPowerSupply : Form
	{
		// power supply
		private readonly GPDX303S _powerSupply = new GPDX303S();

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormPowerSupply()
		{
			// Initialize the form.
			InitializeComponent();

			// Add version string to title bar.
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text += " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}

			// Find all available serial ports.
			comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames());

			// Select the most recently used port.
			// The most recently used port is fetched from applications settings.
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;
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
		/// Open the serial port.
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
						toolStripStatusLabel1.Text = "Opening serial port...";

						// Open the Mass Flow Controller (and let it know what serial port to use).
						_powerSupply.Open(Properties.Settings.Default.Port, 9600);

						// Update the user interface.
						comboBoxSerialPort.Enabled = false;
						groupBoxOutput.Enabled = true;
						groupBoxPowerSupply.Enabled = true;
						toolStripStatusLabel1.Text = "Port open.";
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// Close the serial port.
						_powerSupply.Close();

						// Update user interface.
						comboBoxSerialPort.Enabled = true;
						groupBoxOutput.Enabled = false;
						groupBoxPowerSupply.Enabled = false;
						toolStripStatusLabel1.Text = "Port closed.";
					}
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// Alert the user.
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

					// Undo the user action.
					radioButtonClosed.Checked = true;
				}
			}
		}

		/// <summary>
		/// Remember the most recently selected serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.Port = comboBoxSerialPort.Text;
		}

		/// <summary>
		/// When the application closes, save settings and close serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormPowerSupply_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the mass flow controller.
			_powerSupply.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// Enable power supply output.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RadioButtonOutput_CheckedChanged(object sender, EventArgs e)
		{
			// Do stuff only if the radio button is checked.
			// (Otherwise the actions will run twice.)
			if (((RadioButton)sender).Checked)
			{
				try
				{
					// If the "Enabled" radio button has been checked...
					if (((RadioButton)sender) == radioButtonEnabled)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Enabling outputs...";

						// Enable power supply output.
						_powerSupply.SetControlMode(ControlMode.Active);

						// Update the user interface.
						toolStripStatusLabel1.Text = "Output ON.";
					}
					else if (((RadioButton)sender) == radioButtonDisabled)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Disabling outputs...";

						// Disable power supply output.
						_powerSupply.SetControlMode(ControlMode.Passive);

						// Update user interface.
						toolStripStatusLabel1.Text = "Output OFF.";
					}
				}
				// If an error occurs...
				catch (Exception ex)
				{
					// Alert the user.
					MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

					// Undo the user action.
					radioButtonClosed.Checked = true;
				}
			}
		}

		/// <summary>
		/// When the "Read" button is clicked, fetch readings from the power supply.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonRead_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Reading from power supply...";

				// Read status from power supply.
				_powerSupply.Read();

				// Update the form.
				numericUpDownCurrent.Value = Convert.ToDecimal(_powerSupply.Readings[VariableType.Current]);
				numericUpDownVoltage.Value = Convert.ToDecimal(_powerSupply.Readings[VariableType.Voltage]);
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				toolStripStatusLabel1.Text = ex.Message;
			}
		}

		/// <summary>
		/// When the "Write" button is clicked, write the current and voltage to the power supply.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonWrite_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Writing to power supply...";

				// Send data to power supply.
				_powerSupply.Setpoints[VariableType.Current] = Convert.ToDouble(numericUpDownCurrent.Value);
				_powerSupply.Setpoints[VariableType.Voltage] = Convert.ToDouble(numericUpDownVoltage.Value);
				_powerSupply.Write(VariableType.Current);
				_powerSupply.Write(VariableType.Voltage);

				// Alert the user.
				toolStripStatusLabel1.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				toolStripStatusLabel1.Text = ex.Message;
			}
		}
	}
}
