using System;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.GasConcentration
{
	public partial class FormGasConcentration : Form
	{
		// mass flow controllers
		// You need two to mix gasses and control gas concentration.
		private ColeParmerMFC _mfcGasUnderTest = new ColeParmerMFC();
		private ColeParmerMFC _mfcDilutent = new ColeParmerMFC();

		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormGasConcentration()
		{
			// Initialize the form.
			InitializeComponent();

			// Find all available serial ports.
			foreach (string s in SerialPort.GetPortNames())
			{
				comboBoxSerialPortGasUnderTest.Items.Add(s);
				comboBoxSerialPortDilutent.Items.Add(s);
			}

			// Select the most recently used port.
			// The most recently used port is fetched from application settings.
			comboBoxSerialPortGasUnderTest.Text = Properties.Settings.Default.PortGasUnderTest;
			comboBoxSerialPortDilutent.Text = Properties.Settings.Default.PortDilutent;

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
						if (comboBoxSerialPortGasUnderTest.Text.Equals(comboBoxSerialPortDilutent.Text))
						{
							throw new ArgumentException("Both ports can't be the same.");
						}

						// Open the Mass Flow Controllers (and let it know what serial port to use).
						_mfcGasUnderTest.Open(Properties.Settings.Default.PortGasUnderTest);
						_mfcDilutent.Open(Properties.Settings.Default.PortDilutent);

						// Update the user interface.
						comboBoxSerialPortGasUnderTest.Enabled = false;
						comboBoxSerialPortDilutent.Enabled = false;
						// TODO:  Add other controls here.
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Close the serial port.
						_mfcGasUnderTest.Close();
						_mfcDilutent.Close();

						// Update the user interface.
						comboBoxSerialPortGasUnderTest.Enabled = true;
						comboBoxSerialPortDilutent.Enabled = true;
						// TODO:  Add other controls here.
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
			Properties.Settings.Default.PortGasUnderTest = comboBoxSerialPortGasUnderTest.Text;
		}

		/// <summary>
		/// Remember the most recently selected serial port (for dilutent).
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBoxSerialPortDilutent_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortDilutent = comboBoxSerialPortDilutent.Text;
		}

		/// <summary>
		/// When the application closes, save settings and close serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormGasConcentration_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the mass flow controllers.
			_mfcDilutent.Close();
			_mfcGasUnderTest.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}
	}
}
