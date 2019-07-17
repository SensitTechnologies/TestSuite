using System;
using System.Deployment.Application;
using System.IO.Ports;
using System.Windows.Forms;

namespace Sensit.App.G2GLT
{
	public partial class FormG2GLT : Form
	{
		public FormG2GLT()
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
				comboBoxSerialPortRx.Items.Add(s);
				comboBoxSerialPortTx.Items.Add(s);
			}

			// Select the most recently used ports.
			// The most recently used ports are fetched from applications settings.
			comboBoxSerialPortRx.Text = Properties.Settings.Default.PortRx;
			comboBoxSerialPortTx.Text = Properties.Settings.Default.PortTx;
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

						// TODO:  Open the G2 (and let it know what serial ports to use).
						//_sensitG3.Open(Properties.Settings.Default.PortRx, Properties.Settings.Default.PortTx);

						// TODO:  Update the user interface.
						comboBoxSerialPortRx.Enabled = false;
						comboBoxSerialPortTx.Enabled = false;
						//groupBoxConsoleCommands.Enabled = true;
						toolStripStatusLabel1.Text = "Port open.";
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel1.Text = "Closing serial port...";

						// TODO:  Close the serial port.
						//_sensitG3.Close();

						// TODO:  Update user interface.
						comboBoxSerialPortRx.Enabled = true;
						comboBoxSerialPortTx.Enabled = true;
						//groupBoxConsoleCommands.Enabled = false;
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
		/// Remember the most recently selected "transmit" serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxSerialPortTx_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortTx = comboBoxSerialPortTx.Text;
		}

		/// <summary>
		/// Remember the most recently selected "receive" serial port.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ComboBoxSerialPortRx_SelectedIndexChanged(object sender, EventArgs e)
		{
			// Save the serial port selection in the application settings.
			Properties.Settings.Default.PortRx = comboBoxSerialPortRx.Text;
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
	}
}
