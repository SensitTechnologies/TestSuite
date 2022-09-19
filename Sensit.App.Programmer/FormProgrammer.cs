using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Programmer
{
	public partial class FormProgrammer : Form
	{
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
			buttonWrite.Enabled = false;
			buttonRead.Enabled = false;
			textBoxBarcode.Enabled = false;

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
				//Close the aardvark
				aardvarkI2C.Close();

				// Inform user that test failed.
				toolStripStatusLabel.Text = "FAIL";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				toolStripStatusLabel.ForeColor = Color.Red;

				// Alert user that a sensor failed.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
			//Update user interface
			buttonWrite.Enabled = true;
			buttonRead.Enabled = true;

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
			buttonWrite.Enabled = false;
			buttonRead.Enabled = false;
			textBoxBarcode.Enabled = false;

			try
			{
				// Parse the barcode text.
				string[] words = textBoxBarcode.Text.Split(' ');

				// Determine sensor type from serial number.
				SensorDataLibrary.SensorType sensorType = ParseAlphasenseBarcode(words[0]);

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
				WriteManufacturingRecord(sensorType, words[0]);

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
				//Close the aardvark
				aardvarkI2C.Close();

				// Inform user that test failed.
				toolStripStatusLabel.Text = "FAIL";
				toolStripStatusLabel.Font = new Font(toolStripStatusLabel.Font, FontStyle.Bold);
				toolStripStatusLabel.ForeColor = Color.Red;

				// Alert user that a sensor failed.
				MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
			}
			//Update user interface
			buttonWrite.Enabled = true;
			buttonRead.Enabled = true;

			// Update barcode textbox and give focus to it.
			textBoxBarcode.Text = "";
			textBoxBarcode.Enabled = true;
			textBoxBarcode.Focus();
		}

		#region Programmer Commands

		//Create object of aardvark.
		AardvarkI2C aardvarkI2C = new();

		/// <summary>
		/// Opens the Aardvark
		/// </summary>
		private void OpenAardvark()
		{
			aardvarkI2C.Open();
		}

		/// <summary>
		/// Closes the Aardvark.
		/// </summary>
		private void CloseAardvark()
		{
			aardvarkI2C.Close();
		}

		/// <summary>
		/// Read Base Record from sensor's EEPROM.
		/// </summary>
		/// <exception cref="DeviceSettingNotSupportedException">Sulfur Dioxide not implemented</exception>
		private void ReadBaseRecord()
		{
			//Retrieve byte list from EEPROM's Base Record
			List<byte> readData = aardvarkI2C.EepromRead(SensorDataLibrary.ADDRESS_BASE_RECORD, SensorDataLibrary.PAGE_SIZE);

			//Determine Record Format from data
			SensorDataLibrary.BaseRecordFormat0 baseRecordFormat = new SensorDataLibrary.BaseRecordFormat0();
			baseRecordFormat.SetBytes(readData);

			//Determine Sensor Type
			switch (baseRecordFormat.SensorType)
			{
				case SensorDataLibrary.SensorType.Oxygen:
					textBoxSensorType.Text = "O2";
					break;
				case SensorDataLibrary.SensorType.CarbonMonoxide:
					textBoxSensorType.Text = "CO";
					break;
				case SensorDataLibrary.SensorType.HydrogenSulfide:
					textBoxSensorType.Text = "H2S";
					break;
				case SensorDataLibrary.SensorType.HydrogenCyanide:
					textBoxSensorType.Text = "HCN";
					break;
				default:
					textBoxSensorType.Text = "Invalid";

					//Close the aardvark
					aardvarkI2C.Close();

					throw new DeviceSettingNotSupportedException("Invalid sensor type");
			}
		}

		/// <summary>
		/// Write base record data to sensor EEPROM.
		/// </summary>
		/// <param name="sensorType"></param>
		/// <exception cref="DeviceSettingNotSupportedException"></exception>
		private void WriteBaseRecord(SensorDataLibrary.SensorType sensorType)
		{
			List<byte> returnData = new();

			//Set and retrieve info for sensor type based off serial number
			switch (sensorType)
			{
				case SensorDataLibrary.SensorType.Oxygen:
					textBoxSensorType.Text = "O2";
					SensorDataLibrary.BaseRecordFormat2 oxygenBaseRecord = new();
					oxygenBaseRecord.SensorRev = 1;
					oxygenBaseRecord.CalScale = SensorDataLibrary.CAL_SCALE_OXYGEN;
					oxygenBaseRecord.ZeroCalibration = 19699;
					oxygenBaseRecord.SensorType = SensorDataLibrary.SensorType.Oxygen;
					oxygenBaseRecord.ZeroMax = SensorDataLibrary.ZERO_MAX_OXYGEN;
					oxygenBaseRecord.ZeroMin = SensorDataLibrary.ZERO_MIN_OXYGEN;
					returnData.AddRange(oxygenBaseRecord.GetBytes());
					break;
				case SensorDataLibrary.SensorType.CarbonMonoxide:
					textBoxSensorType.Text = "CO";
					SensorDataLibrary.BaseRecordFormat0 carbonMonoxideBaseRecord = new();
					carbonMonoxideBaseRecord.SensorRev = 1;
					carbonMonoxideBaseRecord.SensorType = SensorDataLibrary.SensorType.CarbonMonoxide;
					carbonMonoxideBaseRecord.CalScale = SensorDataLibrary.CARBONMONOXIDE_CAL_SCALE;
					carbonMonoxideBaseRecord.CalPointOne = SensorDataLibrary.CARBONMONOXIDE_CAL_POINT_ONE;
					returnData.AddRange((carbonMonoxideBaseRecord.GetBytes()));
					break;
				case SensorDataLibrary.SensorType.HydrogenSulfide:
					textBoxSensorType.Text = "H2S";
					SensorDataLibrary.BaseRecordFormat0 hydrogenSulfideBaseRecord = new();
					hydrogenSulfideBaseRecord.SensorRev = 1;
					hydrogenSulfideBaseRecord.SensorType = SensorDataLibrary.SensorType.HydrogenSulfide;
					hydrogenSulfideBaseRecord.CalScale = SensorDataLibrary.HYDROGENSULFIDE_CAL_SCALE;
					returnData.AddRange((hydrogenSulfideBaseRecord.GetBytes()));
					break;
				case SensorDataLibrary.SensorType.HydrogenCyanide:
					textBoxSensorType.Text = "HCN";
					SensorDataLibrary.BaseRecordFormat0 hydrogenCyanideBaseRecord = new();
					hydrogenCyanideBaseRecord.SensorRev = 1;
					hydrogenCyanideBaseRecord.SensorType = SensorDataLibrary.SensorType.HydrogenCyanide;
					hydrogenCyanideBaseRecord.CalScale = SensorDataLibrary.HYDROGENCYANIDE_CAL_SCALE;
					returnData.AddRange((hydrogenCyanideBaseRecord.GetBytes()));
					break;
				default:
					//Close the aardvark
					aardvarkI2C.Close();

					textBoxSensorType.Text = "Invalid";
					throw new DeviceSettingNotSupportedException("Invalid sensor type.");
			}

			//Write data to sensor's EEPROM
			aardvarkI2C.EepromWrite(SensorDataLibrary.ADDRESS_BASE_RECORD, returnData);
		}

		/// <summary>
		/// Reads Device ID from sensor's EEPROM.
		/// </summary>
		private void ReadDeviceID()
		{
			//Read Device ID from sensor's EEPROM
			List<byte> readData = aardvarkI2C.EepromRead(SensorDataLibrary.ADDRESS_DEVICE_ID, SensorDataLibrary.PAGE_SIZE);
			SensorDataLibrary.DeviceID deviceID = new();
			deviceID.SetBytes(readData);

			//Write Serial Number to form
			textBoxSerialNumber.Text = deviceID.SerialNumber;

			//Write Date Programmed to form
			DateTime date = new DateTime(deviceID.Year, deviceID.Month, deviceID.Day);
			textBoxDateProgrammed.Text = date.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);
		}

		/// <summary>
		/// Write device ID to sensor EEPROM.
		/// </summary>
		/// <param name="sensorType"></param>
		/// <param name="serialNumber"></param>
		private void WriteDeviceID(SensorDataLibrary.SensorType sensorType, string serialNumber)
		{
			// We need the date.
			string date = DateTime.Today.ToString("MMddyyyy", CultureInfo.InvariantCulture);

			//Write date to be programmed into EEPROM on form.
			textBoxDateProgrammed.Text = DateTime.Today.ToString("MM-dd-yyyy", CultureInfo.InvariantCulture);

			//Write device ID to sensor EEPROM.
			SensorDataLibrary.DeviceID deviceID = new()
			{
				SensorType = sensorType,
				Year = int.Parse(date.Substring(4, 4)),
				Month = ushort.Parse(date[..2]),
				Day = ushort.Parse(date.Substring(2, 2)),
				SerialNumber = serialNumber
			};

			if (sensorType == SensorDataLibrary.SensorType.Oxygen)
			{
				deviceID.RecordFormat = 2;
			}
			else
			{
				deviceID.RecordFormat = 0;
			}

			//Write Device ID to EEPROM
			aardvarkI2C.EepromWrite(SensorDataLibrary.ADDRESS_DEVICE_ID, deviceID.GetBytes());
		}

		/// <summary>
		/// Reads Manufacturing Record from sensor's EEPROM.
		/// </summary>
		private void ReadManufacturingRecord()
		{
			//Read from EEPROM
			aardvarkI2C.EepromRead(SensorDataLibrary.ADDRESS_MANUFACTURING_ID, SensorDataLibrary.PAGE_SIZE);
		}

		/// <summary>
		/// Write manufacturing record to sensor EEPROM.
		/// </summary>
		/// <param name="serialNumber"></param>
		private void WriteManufacturingRecord(SensorDataLibrary.SensorType sensorType, string serialNumber)
		{
			// We need the date.
			string date = DateTime.Today.ToString("MMddyyyy", CultureInfo.InvariantCulture);

			//Set info to Manufacture ID in SensorDataLibrary
			SensorDataLibrary.ManufactureID manufactureID = new()
			{
				SensorType = sensorType,
				Year = int.Parse(date.Substring(4, 4)),
				Month = ushort.Parse(date[..2]),
				Day = ushort.Parse(date.Substring(2, 2)),
				SerialNumber = serialNumber
			};

			if (sensorType == SensorDataLibrary.SensorType.Oxygen)
			{
				manufactureID.RecordFormat = 2;
			}
			else
			{
				manufactureID.RecordFormat = 0;
			}

			// Add serial number to form
			textBoxSerialNumber.Text += Environment.NewLine + serialNumber;

			//Write info to EEPROM
			aardvarkI2C.EepromWrite(SensorDataLibrary.ADDRESS_MANUFACTURING_ID, manufactureID.GetBytes());
		}

		#endregion

		#region Helper Methods

		/// <summary>
		/// Parse an Alphasense electrochemical sensor's serial number.
		/// </summary>
		/// <param name="serialNumber"></param>
		/// <returns></returns>
		private static SensorDataLibrary.SensorType ParseAlphasenseBarcode(string serialNumber)
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
			SensorDataLibrary.SensorType sensorType;
			switch (sensorTypeCode)
			{
				case 185:
					sensorType = SensorDataLibrary.SensorType.Oxygen;
					break;
				case 20:
				case 21:
				case 22:
					sensorType = SensorDataLibrary.SensorType.HydrogenSulfide;
					break;
				case 11:
				case 15:
					sensorType = SensorDataLibrary.SensorType.CarbonMonoxide;
					break;
				case 55:
					sensorType = SensorDataLibrary.SensorType.HydrogenCyanide;
					break;
				case 51:
					sensorType = SensorDataLibrary.SensorType.SulfurDioxide;
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
			textBoxDateProgrammed.Text = string.Empty;
		}


		#endregion
	}
}
