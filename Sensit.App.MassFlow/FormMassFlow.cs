using System;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.MassFlow
{
	public partial class FormMassFlow : Form
	{
		// mass flow controller
		private readonly AlicatMFC _massFlowController = new();

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormMassFlow()
		{
			// Initialize the form.
			InitializeComponent();

			// Find all available serial ports.
			comboBoxSerialPort.Items.AddRange(SerialPort.GetPortNames());

			// Select the most recently used port.
			// The most recently used port is fetched from applications settings.
			comboBoxSerialPort.Text = Properties.Settings.Default.Port;

			// Populate the Gas combo box.
			foreach (Gas gas in Enum.GetValues(typeof(Gas)))
			{
				comboBoxGas.Items.Add(gas);
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
						toolStripStatusLabel.Text = "Opening serial port...";

						// Open the Mass Flow Controller (and let it know what serial port to use).
						_massFlowController.Open(Properties.Settings.Default.Port);

						// Update the user interface.
						comboBoxSerialPort.Enabled = false;
						groupBoxMassFlowControl.Enabled = true;
						toolStripStatusLabel.Text = "Port open.";
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel.Text = "Closing serial port...";

						// Close the serial port.
						_massFlowController.Close();

						// Update user interface.
						comboBoxSerialPort.Enabled = true;
						groupBoxMassFlowControl.Enabled = false;
						toolStripStatusLabel.Text = "Port closed.";
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
		private void FormMassFlow_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the mass flow controller.
			_massFlowController.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When the "Update" button is clicked, fetch readings/settings from the mass flow controller.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonReadAll_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel.Text = "Reading from mass flow controller...";

				// Read status from the mass flow controller.
				_massFlowController.WriteThenRead();

				// Update the form.
				textBoxPressure.Text = _massFlowController.Readings[VariableType.Pressure].ToString(CultureInfo.CurrentCulture);
				textBoxTemperature.Text = _massFlowController.Readings[VariableType.Temperature].ToString(CultureInfo.CurrentCulture);
				textBoxVolumetricFlow.Text = _massFlowController.Readings[VariableType.VolumeFlow].ToString(CultureInfo.CurrentCulture);
				textBoxMassFlow.Text = _massFlowController.Readings[VariableType.MassFlow].ToString(CultureInfo.CurrentCulture);
				comboBoxGas.Text = _massFlowController.GasSelection.ToString();
				toolStripStatusLabel.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				toolStripStatusLabel.Text = ex.Message;
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
				toolStripStatusLabel.Text = "Writing gas selection...";

				// Find the selected gas.
				Enum.TryParse(comboBoxGas.Text, out Gas gas);

				// Send the gas selection to the mass flow controller.
				_massFlowController.GasSelection = gas;
				_massFlowController.SetGas();

				// Alert the user.
				toolStripStatusLabel.Text = "Success.";
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				toolStripStatusLabel.Text = ex.Message;
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
				// Convert the setpoint to a number.
				decimal setpoint = Convert.ToDecimal(textBoxSetpoint.Text);

				// Write setpoint to the mass flow controller.
				_massFlowController.Write(VariableType.MassFlow, setpoint);

				// Alert the user.
				toolStripStatusLabel.Text = "Success.";
			}
			catch (FormatException ex)
			{
				// If the user didn't enter a valid number, prompt the user.
				MessageBox.Show(ex.Message + Environment.NewLine + Environment.NewLine +
					"Did you type a valid setpoint?",
					ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				toolStripStatusLabel.Text = ex.Message;
			}
			catch (Exception ex)
			{
				// If an error occurs, alert the user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
				toolStripStatusLabel.Text = ex.Message;
			}
		}
	}
}
