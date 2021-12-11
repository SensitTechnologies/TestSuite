﻿using System;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO.Ports;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Programmer
{
	public partial class FormProgrammer : Form
	{
		private enum SensorType
		{
			LeadFreeOxygen,     // LFO2-A4
			HydrogenSulfide,	// H2S-A1, H2S-B1
			CarbonMonoxide,		// CO-AF
			HydrogenCyanide,	// HCN-A1
			SulfurDioxide		// SO2-AF
		}

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
						buttonPortRefresh.Enabled = false;
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
						buttonPortRefresh.Enabled = true;
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

				// Get number of digits.
				int numDigits = words[0].Length;

				// Parse the serial number.  It follows format “TTTBBBBNN”
				// TTT = Sensor type (this could be only two digits if the first number is 0).
				// BBBB = Batch Number
				// NN = Number in Batch
				uint sensorTypeCode;
				uint sensorBatch;
				uint sensorNum;
				if (numDigits == 10)
				{
					sensorTypeCode = uint.Parse(words[0].Substring(0, 4));
					sensorBatch = uint.Parse(words[0].Substring(4, 4));
					sensorNum = uint.Parse(words[0].Substring(8, 2));
				}
				else if (numDigits == 9)
				{
					sensorTypeCode = uint.Parse(words[0].Substring(0, 3));
					sensorBatch = uint.Parse(words[0].Substring(3, 4));
					sensorNum = uint.Parse(words[0].Substring(7, 2));
				}
				else if (numDigits == 8)
				{
					sensorTypeCode = uint.Parse(words[0].Substring(0, 2));
					sensorBatch = uint.Parse(words[0].Substring(2, 4));
					sensorNum = uint.Parse(words[0].Substring(6, 2));
				}
				else throw new TestException("Invalid serial number format.");

				// Translate code into sensor type.
				SensorType sensorType;
				switch(sensorTypeCode)
				{
					case 185:
						sensorType = SensorType.LeadFreeOxygen;
						break;
					case 20:
					case 21:
					case 22:
						sensorType = SensorType.HydrogenSulfide;
						break;
					case 11:
					case 15:
						sensorType = SensorType.CarbonMonoxide;
						break;
					case 55:
						sensorType = SensorType.HydrogenCyanide;
						break;
					case 51:
						sensorType = SensorType.SulfurDioxide;
						throw new TestException("SO2 sensors are not supported yet.");
					default:
						throw new TestException("Unknown sensor type.");
				}

				// Use the first character to determine the sensor type.
				UpdateProgress("Writing sensor " + _sensor + "...", 5);
				WriteBaseRecord(sensorType);

				// Manufacturing Record Validity = 0
				UpdateProgress("Writing sensor " + _sensor + "...", 10);
				WriteG3Console("mrv0");

				// Manufacturing Record Issue = 0
				UpdateProgress("Writing sensor " + _sensor + "...", 20);
				WriteG3Console("mris0");

				// Manufacturing Record ID = C
				UpdateProgress("Writing sensor " + _sensor + "...", 30);
				WriteG3Console("mridC");

				// Manufacturing Record Revision = 0
				UpdateProgress("Writing sensor " + _sensor + "...", 40);
				WriteG3Console("mrre0");

				// Manufacturing Record Read
				UpdateProgress("Writing sensor " + _sensor + "...", 50);
				WriteG3Console("mrrr" + _sensor);

				// Manufacturing Record Point Release = 0
				UpdateProgress("Writing sensor " + _sensor + "...", 60);
				WriteG3Console("mrp0");

				// Manufacturing Record Date
				UpdateProgress("Writing sensor " + _sensor + "...", 70);
				string date = DateTime.Today.ToString("MMddyyyy", CultureInfo.InvariantCulture);
				WriteG3Console("mrd" + date);

				// Manufacturing Record Sensor Type
				UpdateProgress("Writing sensor " + _sensor + "...", 80);
				WriteSensorType(sensorType);

				// Serial Number
				UpdateProgress("Writing sensor " + _sensor + "...", 90);
				WriteSerialNumber(words[0]);

				// Write manufacturing record to sensor EEPROM.
				UpdateProgress("Writing sensor " + _sensor + "...", 95);
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

		private void WriteSerialNumber(string serialNumber)
		{
			// Sens serial number to G3.
			WriteG3Console("mrs" + _sensor + serialNumber);

			// Add serial number to button.
			switch (_sensor)
			{
				case 1:
					buttonSensor1.Text += Environment.NewLine + serialNumber;
					break;
				case 2:
					buttonSensor2.Text += Environment.NewLine + serialNumber;
					break;
				case 3:
					buttonSensor3.Text += Environment.NewLine + serialNumber;
					break;
				case 4:
					buttonSensor4.Text += Environment.NewLine + serialNumber;
					break;
			}
		}

		private void WriteSensorType(SensorType sensorType)
		{
			string command = "mrc";
			switch (sensorType)
			{
				case SensorType.LeadFreeOxygen:
					command += '1';
					break;
				case SensorType.CarbonMonoxide:
					// Carbon monoxide sensor
					command += '3';
					break;
				case SensorType.HydrogenSulfide:
					// Hydrogen sulfide sensor
					command += '4';
					break;
				case SensorType.HydrogenCyanide:
					// Hydrogen cyanide sensor
					command += '5';
					break;
				default:
					throw new DeviceSettingNotSupportedException("Invalid sensor type");
			}

			// Send sensor type to G3.
			WriteG3Console(command);
		}

		private void WriteBaseRecord(SensorType sensorType)
		{
			string command = "br";
			string buttonText = Environment.NewLine;
			switch (sensorType)
			{
				case SensorType.LeadFreeOxygen:
					command += '1';
					buttonText += "O2";
					break;
				case SensorType.CarbonMonoxide:
					command += '2';
					buttonText += "CO";
					break;
				case SensorType.HydrogenSulfide:
					command += '3';
					buttonText += "H2S";
					break;
				case SensorType.HydrogenCyanide:
					// Hydrogen cyanide sensor
					command += '4';
					buttonText += "HCN";
					break;
				default:
					throw new DeviceSettingNotSupportedException("Invalid sensor type");
			}

			// Send base record info to G3.
			WriteG3Console(command);

			// Write base record to sensor EEPROM.
			WriteG3Console("brw" + _sensor);

			// Add sensor's type to button.
			switch (_sensor)
			{
				case 1:
					buttonSensor1.Text += buttonText;
					break;
				case 2:
					buttonSensor2.Text += buttonText;
					break;
				case 3:
					buttonSensor3.Text += buttonText;
					break;
				case 4:
					buttonSensor4.Text += buttonText;
					break;
			}
		}

		private void WriteG3Console(string command)
		{
			// Send command to programmer (and terminate with a carriage return).
			_programmer.WriteThenRead(command + "\r");

			// Response should be an echo of the command.
			if (_programmer.Message != command)
			{
				throw new DeviceCommandFailedException("No response from G3.");
			}
		}

		#endregion

		#region Helper Methods

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
					buttonSensor1.Text = "1";
					break;
				case 2:
					buttonSensor2.BackColor = COLOR_IDLE;
					buttonSensor2.Text = "2";
					break;
				case 3:
					buttonSensor3.BackColor = COLOR_IDLE;
					buttonSensor3.Text = "3";
					break;
				case 4:
					buttonSensor4.BackColor = COLOR_IDLE;
					buttonSensor4.Text = "4";
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
					buttonSensor1.Text = "1";
					break;
				case 2:
					buttonSensor2.BackColor = COLOR_ACTIVE;
					buttonSensor2.Text = "2";
					break;
				case 3:
					buttonSensor3.BackColor = COLOR_ACTIVE;
					buttonSensor3.Text = "3";
					break;
				case 4:
					buttonSensor4.BackColor = COLOR_ACTIVE;
					buttonSensor4.Text = "4";
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
