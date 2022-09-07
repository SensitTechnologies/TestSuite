using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;
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
			HydrogenSulfide,    // H2S-A1, H2S-B1
			CarbonMonoxide,     // CO-AF
			HydrogenCyanide,    // HCN-A1
			SulfurDioxide       // SO2-AF
		}

		/// <summary>
		/// Run when the application starts.
		/// </summary>
		public FormProgrammer()
		{
			// Initialize the form.
			InitializeComponent();
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
		/// When the application closes, save settings.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FormProgrammer_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				//Close the aardvark.
				CloseAardvark();
			}
			catch (Exception ex)
			{
				// Alert user.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}

			// Store the current values of the application settings properties.
			// If this call is omitted, then the settings will not be saved after the application quits.
			Properties.Settings.Default.Save();
		}

		/// <summary>
		/// When "Read" button is clicked, read data from sensor and display to user.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonRead_Click(object sender, EventArgs e)
		{
			// Update the user interface.
			ClearStatus();

			try
			{
				// Initialize the aardvark.
				UpdateProgress("Initializing aardvark...", 5);
				OpenAardvark();

				// Read base record.
				UpdateProgress("Reading base record...", 25);
				ReadBaseRecord();

				// Read Device ID (and make sure sensor type matches).
				UpdateProgress("Reading device ID...", 50);
				ReadDeviceID();

				// Read manufacturing record (and make sure serial number matches).
				UpdateProgress("Reading manufacturing record...", 75);
				ReadManufacturingRecord();

				// Close the aardvark.
				UpdateProgress("Closing aardvark...", 95);
				CloseAardvark();

				// Inform user that test passed.
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				toolStripStatusLabel.ForeColor = Color.Green;
				UpdateProgress("PASS", 100);
			}
			catch (Exception ex)
			{
				// Inform user that test failed.
				toolStripStatusLabel.Text = "FAIL";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				toolStripStatusLabel.ForeColor = Color.Red;

				// Alert user that a sensor failed.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}

			// Update barcode textbox and give focus to it.
			textBoxBarcode.Text = "";
			textBoxBarcode.Enabled = true;
			textBoxBarcode.Focus();
		}

		/// <summary>
		/// When "Write" button is clicked, parse data from serial number and program sensor.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonWrite_Click(object sender, EventArgs e)
		{
			// Update the user interface.
			ClearStatus();

			try
			{
				// Parse the barcode text.
				string[] words = textBoxBarcode.Text.Split(' ');

				// Determine sensor type from serial number.
				SensorType sensorType = ParseAlphasenseBarcode(words[0]);

				// Initialize the aardvark.
				UpdateProgress("Initializing aardvark...", 5);
				OpenAardvark();

				// Write base record.
				UpdateProgress("Writing base record...", 25);
				WriteBaseRecord(sensorType);

				// Write Device ID.
				UpdateProgress("Writing device ID...", 50);
				WriteDeviceID(sensorType, words[0]);

				// Write manufacturing record.
				UpdateProgress("Writing manufacturing record...", 75);
				WriteManufacturingRecord(words[0]);

				// Close the aardvark.
				UpdateProgress("Closing aardvark...", 95);
				CloseAardvark();

				// Inform user that test passed.
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				toolStripStatusLabel.ForeColor = Color.Green;
				UpdateProgress("PASS", 100);
			}
			catch (Exception ex)
			{
				// Inform user that test failed.
				toolStripStatusLabel.Text = "FAIL";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				toolStripStatusLabel.ForeColor = Color.Red;

				// Alert user that a sensor failed.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}

			// Update barcode textbox and give focus to it.
			textBoxBarcode.Text = "";
			textBoxBarcode.Enabled = true;
			textBoxBarcode.Focus();
		}

		#region Programmer Commands

		AardvarkI2C aardvarkI2C = new();

		private void OpenAardvark()
		{
			aardvarkI2C.Open();
		}

		private void CloseAardvark()
		{
			aardvarkI2C.Close();
		}

		private void ReadBaseRecord()
		{
			aardvarkI2C.EepromRead(0, 256); //all four pages
		}

		/// <summary>
		/// Write base record data to sensor EEPROM.
		/// </summary>
		/// <param name="sensorType"></param>
		/// <exception cref="DeviceSettingNotSupportedException"></exception>
		private void WriteBaseRecord(SensorType sensorType)
		{
			List<byte> returnData = new();
			// TODO: Create a sensor base record object based on sensor type.
			// TODO: Convert base record to List<byte>.
			// TODO: Write List<byte> to sensor EEPROM.
			
			switch (sensorType)
			{
				case SensorType.LeadFreeOxygen:
					textBoxSensorType.Text = "O2";
					SensorDataLibrary.OxygenBaseRecord oxygenBaseRecord = new();
					returnData.AddRange(oxygenBaseRecord.BaseRecord());
					break;
				case SensorType.CarbonMonoxide:
					textBoxSensorType.Text = "CO";
					SensorDataLibrary.CarbonMonoxideBaseRecord carbonMonoxideBaseRecord = new();
					returnData.AddRange((carbonMonoxideBaseRecord.BaseRecord()));
					break;
				case SensorType.HydrogenSulfide:
					textBoxSensorType.Text = "H2S";
					SensorDataLibrary.HydrogenSulfideBaseRecord hydrogenSulfideBaseRecord = new();
					returnData.AddRange((hydrogenSulfideBaseRecord.BaseRecord()));
					break;
				case SensorType.HydrogenCyanide:
					textBoxSensorType.Text = "HCN";
					SensorDataLibrary.HydrogenCyanideBaseRecord hydrogenCyanideBaseRecord = new();
					returnData.AddRange((hydrogenCyanideBaseRecord.BaseRecord()));
					break;
				default:
					textBoxSensorType.Text = "Invalid";
					throw new DeviceSettingNotSupportedException("Invalid sensor type");
			}

			//TODO: delete after validating byte list return is correct. Currently 4 byte data is backwards...
			foreach (byte b in returnData) { Debug.WriteLine(b); }

			aardvarkI2C.EepromWrite(0, returnData); //write just once
		}

		private void ReadDeviceID()
		{
			aardvarkI2C.EepromRead(256, 64);
		}

		/// <summary>
		/// Write device ID to sensor EEPROM.
		/// </summary>
		/// <param name="sensorType"></param>
		/// <param name="serialNumber"></param>
		private void WriteDeviceID(SensorType sensorType, string serialNumber)
		{
			// We need the date.
			string date = DateTime.Today.ToString("MMddyyyy", CultureInfo.InvariantCulture);

			// TODO:  Write device ID to sensor EEPROM.
			
		}

		private void ReadManufacturingRecord()
		{
			aardvarkI2C.EepromRead(320, 64);
		}

		/// <summary>
		/// Write manufacturing record to sensor EEPROM.
		/// </summary>
		/// <param name="serialNumber"></param>
		private void WriteManufacturingRecord(string serialNumber)
		{
			// TODO:  Write manufacturing record to sensor EEPROM.

			// Add serial number to button.
			textBoxSerialNumber.Text += Environment.NewLine + serialNumber;
		}

		#endregion

		#region Helper Methods

		/// <summary>
		/// Parse an Alphasense electrochemical sensor's serial number.
		/// </summary>
		/// <param name="serialNumber"></param>
		/// <returns></returns>
		private static SensorType ParseAlphasenseBarcode(string serialNumber)
		{
			// Get number of digits.
			int numDigits = serialNumber.Length;

			// Parse the serial number.  It follows format “TTTBBBBNN”
			// TTT = Sensor type (this could be only two digits if the first number is 0).
			// BBBB = Batch Number
			// NN = Number in Batch
			uint sensorTypeCode;
			uint sensorBatch;
			uint sensorNum;
			if (numDigits == 10)
			{
				sensorTypeCode = uint.Parse(serialNumber.Substring(0, 4));
				sensorBatch = uint.Parse(serialNumber.Substring(4, 4));
				sensorNum = uint.Parse(serialNumber.Substring(8, 2));
			}
			else if (numDigits == 9)
			{
				sensorTypeCode = uint.Parse(serialNumber.Substring(0, 3));
				sensorBatch = uint.Parse(serialNumber.Substring(3, 4));
				sensorNum = uint.Parse(serialNumber.Substring(7, 2));
			}
			else if (numDigits == 8)
			{
				sensorTypeCode = uint.Parse(serialNumber.Substring(0, 2));
				sensorBatch = uint.Parse(serialNumber.Substring(2, 4));
				sensorNum = uint.Parse(serialNumber.Substring(6, 2));
			}
			else throw new TestException("Invalid serial number format.");

			// Translate code into sensor type.
			SensorType sensorType;
			switch (sensorTypeCode)
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

			return sensorType;
		}

		/// <summary>
		/// Update user interface status strip.
		/// </summary>
		/// <param name="message"></param>
		/// <param name="progress"></param>
		private void UpdateProgress(string message, int progress)
		{
			toolStripStatusLabel.Text = message;
			toolStripProgressBar.Value = progress;
			Update();
		}

		/// <summary>
		/// Reset the user interface prior to reading or writing.
		/// </summary>
		private void ClearStatus()
		{
			// Disable barcode textbox while reading or writing.
			textBoxBarcode.Enabled = false;

			// Set status bar label to normal color and font.
			toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Regular);
			toolStripStatusLabel.ForeColor = SystemColors.ControlText;

			// Clear status data.
			textBoxSerialNumber.Text = string.Empty;
			textBoxSensorType.Text = string.Empty;
			textBoxSensorDateCode.Text = string.Empty;
			textBoxDateProgrammed.Text = string.Empty;
		}

		#endregion
	}
}
