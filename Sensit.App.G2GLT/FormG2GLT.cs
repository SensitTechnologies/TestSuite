using System;
using System.Deployment.Application;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.G2GLT
{
	public partial class FormG2GLT : Form
	{
		// Sensit G2-GLT instrument
		private SensitG2GLT _sensitG2 = new SensitG2GLT();

		public FormG2GLT()
		{
			// Initialize the form.
			InitializeComponent();

			// If the application has been published...
			if (ApplicationDeployment.IsNetworkDeployed)
			{
				// Add version string to title bar.
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
		/// When a radio button is clicked, open or close the serial ports.
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

						// Open the G2 (and let it know what serial port to use).
						_sensitG2.Open(Properties.Settings.Default.Port);

						// Update the user interface.
						comboBoxSerialPort.Enabled = false;
						groupBoxCommands.Enabled = true;
						toolStripStatusLabel1.Text = "Port open.";
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// Close the serial port.
						_sensitG2.Close();

						// Update user interface.
						comboBoxSerialPort.Enabled = true;
						groupBoxCommands.Enabled = false;
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
		private void ComboBoxSerialPort_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.Port = comboBoxSerialPort.Text;
		}

		/// <summary>
		/// When the application closes, save settings and close serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormG2GLT_FormClosed(object sender, FormClosedEventArgs e)
		{
			// TODO:  Close the device.


			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		private void ButtonReadMethane_Click(object sender, EventArgs e)
		{
			try
			{
				// Select the desired gas.
				_sensitG2.GasSelection = Gas.Methane;

				// Fetch sensor data from instrument.
				_sensitG2.Read();

				// Fetch the readings.
				textBoxMethane.Text = _sensitG2.Readings[VariableType.GasConcentration].ToString();
			}
			catch (DeviceException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ButtonReadOxygen_Click(object sender, EventArgs e)
		{
			try
			{
				// Select the desired gas.
				_sensitG2.GasSelection = Gas.Oxygen;

				// Fetch sensor data from instrument.
				_sensitG2.Read();

				// Fetch the readings.
				textBoxOxygen.Text = _sensitG2.Readings[VariableType.GasConcentration].ToString();
			}
			catch (DeviceException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ButtonReadCarbonMonoxide_Click(object sender, EventArgs e)
		{
			try
			{
				// Select the desired gas.
				_sensitG2.GasSelection = Gas.CarbonMonoxide;

				// Fetch sensor data from instrument.
				_sensitG2.Read();

				// Fetch the readings.
				textBoxCarbonMonoxide.Text = _sensitG2.Readings[VariableType.GasConcentration].ToString();
			}
			catch (DeviceException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ButtonReadHydrogenSulfide_Click(object sender, EventArgs e)
		{
			try
			{
				// Select the desired gas.
				_sensitG2.GasSelection = Gas.HydrogenSulfide;

				// Fetch sensor data from instrument.
				_sensitG2.Read();

				// Fetch the readings.
				textBoxHydrogenSulfide.Text = _sensitG2.Readings[VariableType.GasConcentration].ToString();
			}
			catch (DeviceException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void ButtonReadHydrogenCyanide_Click(object sender, EventArgs e)
		{
			try
			{
				// Select the desired gas.
				_sensitG2.GasSelection = Gas.HydrogenCyanide;

				// Fetch sensor data from instrument.
				_sensitG2.Read();

				// Fetch the readings.
				textBoxHydrogenCyanide.Text = _sensitG2.Readings[VariableType.GasConcentration].ToString();
			}
			catch (DeviceException ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
