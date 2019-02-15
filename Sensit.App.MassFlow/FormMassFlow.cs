using System;
using System.Deployment.Application;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.MassFlow
{
	public partial class FormMassFlow : Form
	{
		// mass flow controller
		private ColeParmerMFC _massFlowController = new ColeParmerMFC();

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormMassFlow()
		{
			// Initialize the form.
			InitializeComponent();

			// Add version string to title bar.
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				Text += " " + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
			}

			// Find all available serial ports.
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxSerialPort.Items.Add(s);
			}

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
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Open the serial port.
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
						toolStripStatusLabel1.Text = "Opening serial port...";

						// Open the Mass Flow Controller (and let it know what serial port to use).
						_massFlowController.Open(Properties.Settings.Default.Port);

						// Update the user interface.
						comboBoxSerialPort.Enabled = false;
						groupBoxMassFlow.Enabled = true;
						toolStripStatusLabel1.Text = "Port open.";
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// Close the serial port.
						_massFlowController.Close();

						// Update user interface.
						comboBoxSerialPort.Enabled = true;
						groupBoxMassFlow.Enabled = false;
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
		private void buttonReadAll_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Reading from mass flow controller...";

				// Read status from the mass flow controller.
				_massFlowController.Read();

				// Update the form.
				textBoxPressure.Text = _massFlowController.Pressure.ToString();
				textBoxTemperature.Text = _massFlowController.Temperature.ToString();
				textBoxVolumetricFlow.Text = _massFlowController.VolumeFlow.ToString();
				textBoxMassFlow.Text = _massFlowController.MassFlow.ToString();
				textBoxSetpoint.Text = _massFlowController.MassFlowSetpoint.ToString();
				comboBoxGas.Text = _massFlowController.GasSelection.ToString();
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
		private void buttonWriteGas_Click(object sender, EventArgs e)
		{
			try
			{
				// Alert the user.
				toolStripStatusLabel1.Text = "Writing gas selection...";

				// Find the selected gas.
				Enum.TryParse(comboBoxGas.Text, out Gas gas);

				// Send the gas selection to the mass flow controller.
				_massFlowController.GasSelection = gas;
				_massFlowController.Configure();

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
		private void buttonWrite_Click(object sender, EventArgs e)
		{
			try
			{
				// Convert the setpoint to a number.
				float setpoint = Convert.ToSingle(textBoxSetpoint.Text);

				// Write setpoint to the mass flow controller.
				_massFlowController.WriteMassFlowSetpoint(setpoint);

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
	}
}
