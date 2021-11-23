using System;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Serial
{
	public partial class FormProgrammer : Form
	{
		// colors indicating sensor status
		private readonly Color COLOR_IDLE = DefaultBackColor;
		private readonly Color COLOR_PASS = Color.Green;
		private readonly Color COLOR_FAIL = Color.Red;
		private readonly Color COLOR_ACTIVE = Color.Yellow;

		// serial device to control programmer
		private readonly GenericSerialDevice _programmer = new GenericSerialDevice();

		// which sensor is being used (start with sensor 1)
		private ushort _sensor = 1;

		/// <summary>
		/// Run when the application starts.
		/// </summary>
		public FormProgrammer()
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
		/// When the refresh button is clicked, search for serial ports.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonPortRefresh_Click(object sender, EventArgs e)
		{
			// Clear the serial port combo box.
			comboBoxSerialPort.Items.Clear();

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
						toolStripStatusLabel.Text = "Opening serial port...";

						// Open the Mass Flow Controller (and let it know what serial port to use).
						_programmer.BaudRate = 115200;
						_programmer.Open(Properties.Settings.Default.Port);

						// Update the user interface.
						comboBoxSerialPort.Enabled = false;
						groupBoxBarcode.Enabled = true;
						groupBoxStatus.Enabled = true;
						toolStripStatusLabel.Text = "Scan sensor 1.";

						// Give focus to barcode textbox.
						textBoxBarcode.Focus();
					}
					else if (((RadioButton)sender) == radioButtonClosed)
					{
						// Alert the user.
						toolStripStatusLabel.Text = "Closing serial port...";

						// Close the serial port.
						_programmer.Close();

						// Update user interface.
						comboBoxSerialPort.Enabled = true;
						groupBoxBarcode.Enabled = false;
						groupBoxStatus.Enabled = false;
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
		private void FormProgrammer_FormClosed(object sender, FormClosedEventArgs e)
		{
			// Close the serial port.
			_programmer.Close();

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// If the "Sensor 1" button is clicked, set that sensor as active.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSensor1_Click(object sender, EventArgs e)
		{
			UpdateSensorIdle(1);
		}

		/// <summary>
		/// If the "Sensor 2" button is clicked, set that sensor as active.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSensor2_Click(object sender, EventArgs e)
		{
			UpdateSensorIdle(2);
		}

		/// <summary>
		/// If the "Sensor 3" button is clicked, set that sensor as active.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSensor3_Click(object sender, EventArgs e)
		{
			UpdateSensorIdle(3);
		}

		/// <summary>
		/// If the "Sensor 4" button is clicked, set that sensor as active.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonSensor4_Click(object sender, EventArgs e)
		{
			UpdateSensorIdle(4);
		}

		/// <summary>
		/// When the "Program" button is clicked, program a sensor.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonProgram_Click(object sender, EventArgs e)
		{
			// Disable the text box.
			textBoxBarcode.Enabled = false;

			// Ensure the active sensor is obvious to the user.
			UpdateSensorActive(_sensor);

			try
			{
				// Parse the barcode text.
				string[] words = textBoxBarcode.Text.Split(' ');

				// Use the first character to determine the sensor type.
				UpdateProgress("Writing base record...", 5);
				WriteBaseRecord(Convert.ToUInt16(words[0].Substring(0, 1)));

				// Manufacturing Record Validity = 0
				UpdateProgress("Writing validity...", 10);
				WriteG3Console("mrv0");

				// Manufacturing Record Issue = 0
				UpdateProgress("Writing issue...", 20);
				WriteG3Console("mris0");

				// Manufacturing Record ID = C
				UpdateProgress("Writing ID...", 30);
				WriteG3Console("mridC");

				// Manufacturing Record Revision = 0
				UpdateProgress("Writing revision", 40);
				WriteG3Console("mrre0");

				// Manufacturing Record Read
				UpdateProgress("Writing read(?)...", 50);
				WriteG3Console("mrrr" + _sensor);

				// Manufacturing Record Point Release = 0
				UpdateProgress("Writing point release...", 60);
				WriteG3Console("mrp0");

				// Manufacturing Record Date
				UpdateProgress("Writing date...", 70);
				string date = DateTime.Today.ToString("MMddyyyy", CultureInfo.InvariantCulture);
				WriteG3Console("mrd" + date);

				// Manufacturing Record Sensor Type
				UpdateProgress("Writing sensor type...", 80);
				WriteSensorType(Convert.ToUInt16(words[0].Substring(0, 1)));

				// Serial Number
				UpdateProgress("Writing serial number...", 90);
				WriteG3Console("mrs" + _sensor + words[0]);

				// Write manufacturing record to sensor EEPROM.
				UpdateProgress("Saving to EEPROM...", 95);
				WriteG3Console("mrw" + _sensor);

				// Sensor PASS and select the next sensor.
				SelectNextSensor(true);
			}
			catch (Exception ex)
			{
				// Alert user that a sensor failed.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));

				// Sensor FAIL and select the next sensor.
				SelectNextSensor(false);
			}

			// Clear text box for next scanned barcode.
			textBoxBarcode.Text = "";

			// Enable the text box.
			textBoxBarcode.Enabled = true;

			// Give focus to barcode textbox.
			textBoxBarcode.Focus();
		}

		#region Programmer Commands

		private void WriteSensorType(ushort sensorTypeCode)
		{
			string command = "mrc";
			switch (sensorTypeCode)
			{
				case 0:
					// Oxygen sensor
					command += '1';
					break;
				case 1:
					// Carbon monoxide sensor
					command += '3';
					break;
				case 2:
					// Hydrogen sulfide sensor
					command += '4';
					break;
				case 5:
					// Hydrogen cyanide sensor
					command += '4';
					break;
			}

			// Send sensor type to G3.
			WriteG3Console(command);
		}

		private void WriteBaseRecord(ushort sensorTypeCode)
		{
			string command = "br";
			switch (sensorTypeCode)
			{
				case 0:
					// Oxygen sensor
					command += '1';
					break;
				case 1:
					// Carbon monoxide sensor
					command += '2';
					break;
				case 2:
					// Hydrogen sulfide sensor
					command += '3';
					break;
				case 4:
					// Hydrogen cyanide sensor
					command += '4';
					break;
				default:
					throw new DeviceSettingNotSupportedException(
						"Invalid sensor type: " + sensorTypeCode);
			}

			// Send base record info to G3.
			WriteG3Console(command);

			// Write base record to sensor EEPROM.
			WriteG3Console("brw" + _sensor);
		}

		#endregion

		#region Helper Methods

		private void WriteG3Console(string command)
		{
			// Send command to programmer (and terminate with a carriage return).
			_programmer.WriteThenRead(command + "\r");

			// Response should be an echo of the command.
			if (_programmer.Message != command)
			{
				throw new DeviceCommandFailedException("Could not set sensor type");
			}
		}

		private void SelectNextSensor(bool pass)
		{
			// Current sensor should be either green or red
			Color resultColor = pass ? COLOR_PASS : COLOR_FAIL;

			// Change the color.
			// Remember the selected sensor.
			switch (_sensor)
			{
				case 1:
					buttonSensor1.BackColor = resultColor;
					_sensor = 2;
					UpdateProgress("Scan sensor " + _sensor + ".", 100);
					break;
				case 2:
					buttonSensor2.BackColor = resultColor;
					_sensor = 3;
					UpdateProgress("Scan sensor " + _sensor + ".", 100);
					break;
				case 3:
					buttonSensor3.BackColor = resultColor;
					_sensor = 4;
					UpdateProgress("Scan sensor " + _sensor + ".", 100);
					break;
				case 4:
					buttonSensor4.BackColor = resultColor;
					_sensor = 1;
					UpdateProgress("Done! Scan sensor 1 to start again.", 100);
					break;
			}
		}

		/// <summary>
		/// Update the GUI to show the currently selected sensor.
		/// </summary>
		/// <param name="sensor"></param>
		private void UpdateSensorIdle(ushort sensor)
		{
			// Change the previously selected sensor's color.
			switch (sensor)
			{
				case 1:
					buttonSensor1.BackColor = COLOR_IDLE;
					break;
				case 2:
					buttonSensor2.BackColor = COLOR_IDLE;
					break;
				case 3:
					buttonSensor3.BackColor = COLOR_IDLE;
					break;
				case 4:
					buttonSensor4.BackColor = COLOR_IDLE;
					break;
			}

			// Remember the selected sensor.
			_sensor = sensor;

			// Give focus to barcode textbox.
			textBoxBarcode.Focus();

			// Update status message.
			UpdateProgress("Scan sensor " + _sensor, 0);
		}

		private void UpdateSensorActive(ushort sensor)
		{
			// Change the new selected sensor's color.
			switch (sensor)
			{
				case 1:
					buttonSensor1.BackColor = COLOR_ACTIVE;
					break;
				case 2:
					buttonSensor2.BackColor = COLOR_ACTIVE;
					break;
				case 3:
					buttonSensor3.BackColor = COLOR_ACTIVE;
					break;
				case 4:
					buttonSensor4.BackColor = COLOR_ACTIVE;
					break;
			}

			// Remember the selected sensor.
			_sensor = sensor;
		}

		private void UpdateProgress(string message, int progress)
		{
			toolStripStatusLabel.Text = message;
			toolStripProgressBar.Value = progress;
			this.Update();
		}

		#endregion
	}
}
