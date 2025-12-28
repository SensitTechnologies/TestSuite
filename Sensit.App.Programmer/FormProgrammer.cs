using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Runtime.Versioning;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;
using static Sensit.App.Programmer.SensorDataLibrary;

namespace Sensit.App.Programmer
{
	// This class contains calls that are only supported on Windows.
	[SupportedOSPlatform("windows")]
	public partial class FormProgrammer : Form
	{
		private readonly ushort I2C_ADDRESS_EEPROM = 0x57; // CAT24C256 EEPROM I2C address
		private readonly ushort I2C_ADDRESS_SENSOR = 0x48; // Sensor's ADC I2C address; (A0 is 8-bit) if it doesn't work

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
				SensorDataLibrary.SensorType sensorType = ReadBaseRecord();

				// Read Device ID (and make sure sensor type matches).
				UpdateProgress("Reading device ID...", 50);
				ReadDeviceID();

				// Read manufacturing record (and make sure serial number matches).
				UpdateProgress("Reading manufacturing record...", 75);
				ReadManufacturingRecord();

				// Read sensor ADC to verify communication.
				UpdateProgress("Checking sensor...", 85);
				CheckSensor(sensorType);

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

				// Read sensor ADC to verify communication.
				UpdateProgress("Checking sensor...", 85);
				CheckSensor(sensorType);

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

		//Create an instance of aardvark.
		readonly AardvarkI2C aardvarkI2C = new();

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
		/// <returns>sensor type</returns>
		private SensorDataLibrary.SensorType ReadBaseRecord()
		{
			//Retrieve byte list from EEPROM's Base Record
			List<byte> readData = aardvarkI2C.EepromRead(I2C_ADDRESS_EEPROM, ADDRESS_BASE_RECORD, PAGE_SIZE);

			//Determine Record Format from data
			SensorDataLibrary.BaseRecordFormat0 baseRecordFormat = new();
			baseRecordFormat.SetBytes(readData);

			// Determine sensor type.
			switch (baseRecordFormat.SensorType)
			{
				case SensorType.Oxygen:
					textBoxSensorType.Text = "O2";
					break;
				case SensorType.CarbonMonoxide:
					textBoxSensorType.Text = "CO";
					break;
				case SensorType.HydrogenSulfide:
					textBoxSensorType.Text = "H2S";
					break;
				case SensorType.HydrogenCyanide:
					textBoxSensorType.Text = "HCN";
					break;
				default:
					textBoxSensorType.Text = "Invalid";

					//Close the aardvark
					aardvarkI2C.Close();

					throw new DeviceSettingNotSupportedException("Invalid sensor type");
			}

			return baseRecordFormat.SensorType;
		}

		/// <summary>
		/// Write base record data to sensor EEPROM.
		/// </summary>
		/// <param name="sensorType"></param>
		/// <exception cref="DeviceSettingNotSupportedException"></exception>
		private void WriteBaseRecord(SensorDataLibrary.SensorType sensorType)
		{
			List<byte> returnData = [];

			//Set and retrieve info for sensor type based off serial number
			switch (sensorType)
			{
				case SensorType.Oxygen:
					textBoxSensorType.Text = "O2";
					SensorDataLibrary.BaseRecordFormat2 oxygenBaseRecord = new()
					{
						SensorRev = 1,
						CalScale = CAL_SCALE_OXYGEN,
						ZeroCalibration = CAL_ZERO_OXYGEN,
						SensorType = SensorType.Oxygen,
						ZeroMax = ZERO_MAX_OXYGEN,
						ZeroMin = ZERO_MIN_OXYGEN
					};
					returnData.AddRange(oxygenBaseRecord.GetBytes());
					break;
				case SensorType.CarbonMonoxide:
					textBoxSensorType.Text = "CO";
					SensorDataLibrary.BaseRecordFormat0 carbonMonoxideBaseRecord = new()
					{
						SensorRev = 1,
						SensorType = SensorType.CarbonMonoxide,
						CalScale = CARBONMONOXIDE_CAL_SCALE,
						CalPointOne = CARBONMONOXIDE_CAL_POINT_ONE
					};
					returnData.AddRange((carbonMonoxideBaseRecord.GetBytes()));
					break;
				case SensorType.HydrogenSulfide:
					textBoxSensorType.Text = "H2S";
					SensorDataLibrary.BaseRecordFormat0 hydrogenSulfideBaseRecord = new()
					{
						SensorRev = 1,
						SensorType = SensorType.HydrogenSulfide,
						CalScale = HYDROGENSULFIDE_CAL_SCALE
					};
					returnData.AddRange((hydrogenSulfideBaseRecord.GetBytes()));
					break;
				case SensorType.HydrogenCyanide:
					textBoxSensorType.Text = "HCN";
					SensorDataLibrary.BaseRecordFormat0 hydrogenCyanideBaseRecord = new()
					{
						SensorRev = 1,
						SensorType = SensorType.HydrogenCyanide,
						CalScale = HYDROGENCYANIDE_CAL_SCALE
					};
					returnData.AddRange((hydrogenCyanideBaseRecord.GetBytes()));
					break;
				default:
					//Close the aardvark
					aardvarkI2C.Close();

					textBoxSensorType.Text = "Invalid";
					throw new DeviceSettingNotSupportedException("Invalid sensor type.");
			}

			//Write data to sensor's EEPROM
			aardvarkI2C.EepromWrite(I2C_ADDRESS_EEPROM, ADDRESS_BASE_RECORD, returnData);
		}

		/// <summary>
		/// Reads Device ID from sensor's EEPROM.
		/// </summary>
		private void ReadDeviceID()
		{
			//Read Device ID from sensor's EEPROM
			List<byte> readData = aardvarkI2C.EepromRead(I2C_ADDRESS_EEPROM, ADDRESS_DEVICE_ID, PAGE_SIZE);
			SensorDataLibrary.DeviceID deviceID = new();
			deviceID.SetBytes(readData);

			//Write Serial Number to form
			textBoxSerialNumber.Text = deviceID.SerialNumber;

			//Write Date Programmed to form
			DateTime date = new(deviceID.Year, deviceID.Month, deviceID.Day);
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

			//Set record format based off of sensor type.
			if (sensorType == SensorType.Oxygen)
			{
				deviceID.RecordFormat = 2;
			}
			else
			{
				deviceID.RecordFormat = 0;
			}

			//Write Device ID to EEPROM
			aardvarkI2C.EepromWrite(I2C_ADDRESS_EEPROM, ADDRESS_DEVICE_ID, deviceID.GetBytes());
		}

		/// <summary>
		/// Reads Manufacturing Record from sensor's EEPROM.
		/// </summary>
		private void ReadManufacturingRecord()
		{
			//Read from EEPROM
			aardvarkI2C.EepromRead(I2C_ADDRESS_EEPROM, ADDRESS_MANUFACTURING_ID, PAGE_SIZE);
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

			//Set record format based off of sensor type.
			if (sensorType == SensorType.Oxygen)
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
			aardvarkI2C.EepromWrite(I2C_ADDRESS_EEPROM, ADDRESS_MANUFACTURING_ID, manufactureID.GetBytes());
		}

		private void CheckSensor(SensorType sensorType)
		{
			// packet of data to write to ADC
			List<byte> writeData = [0x00, 0x00, 0x00];

			// Configure ADC based on sensor type.
			switch (sensorType)
			{
				case SensorType.Oxygen:
					writeData[0] = ADS111x.AddressRegister(ADS111x.AddressPointer.ConfigRegister);
					writeData[1] = ADS111x.ConfigRegister(
						ADS111x.ConfigFlags.MUX_AIN0 |
						ADS111x.ConfigFlags.PGA_FSR_2_048V |
						ADS111x.ConfigFlags.MODE_Continuous |
						ADS111x.ConfigFlags.DR_SPS_3300 |
						ADS111x.ConfigFlags.COMP_MODE_Traditional |
						ADS111x.ConfigFlags.COMP_POL_Low);
					break;
				case SensorType.HydrogenCyanide:
				case SensorType.SulfurDioxide:
					// TODO
					break;
				case SensorType.HydrogenSulfide:
				case SensorType.CarbonMonoxide:
					// TODO
					break;
				default:
					throw new DeviceSettingNotSupportedException("Invalid sensor type.");
			}

			// Read ADC value from sensor.
			// TODO: debug this I2C read from sensor.
			// TODO:  If 100 ms is not long enough, can do write, then pause, then read separately.
			// Once you write config, you can read continuously every 50 ms.
			List<byte> readData = aardvarkI2C.I2CWriteThenRead(I2C_ADDRESS_SENSOR, writeData, 2);

			// Convert byte list to integer.
			int adcValue = (readData[0] << 8) | readData[1];

			// Update user interface.
			textBoxSensorCounts.Text = adcValue.ToString(CultureInfo.InvariantCulture);

			// TODO:  Check against count values (different for each sensor type).
			// TODO:  16-bit value, but device acts like it's two bytes.
			// First byte is MSB, 2nd is LSB; no gas should be 0 to 50 counts except for O2,
			// which gives about 4,700 counts.
			// Check that ADC value is within expected range
			switch (sensorType)
			{
				case SensorType.Oxygen:
					if (adcValue < 0 || adcValue > 65535)
					{
						//Close the aardvark
						aardvarkI2C.Close();
						throw new DeviceCommunicationException("Sensor ADC value out of range.");
					}
					break;
				case SensorType.CarbonMonoxide:
					if (adcValue < 0 || adcValue > 65535)
					{
						//Close the aardvark
						aardvarkI2C.Close();
						throw new DeviceCommunicationException("Sensor ADC value out of range.");
					}
					break;
				case SensorType.HydrogenSulfide:
					if (adcValue < 0 || adcValue > 65535)
					{
						//Close the aardvark
						aardvarkI2C.Close();
						throw new DeviceCommunicationException("Sensor ADC value out of range.");
					}
					break;
				case SensorType.HydrogenCyanide:
					if (adcValue < 0 || adcValue > 65535)
					{
						//Close the aardvark
						aardvarkI2C.Close();
						throw new DeviceCommunicationException("Sensor ADC value out of range.");
					}
					break;
				default:
					//Close the aardvark
					aardvarkI2C.Close();
					throw new DeviceSettingNotSupportedException("Invalid sensor type.");
			}
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
			//uint sensorBatch;
			//uint sensorNum;
			if (numDigits == 10)
			{
				sensorTypeCode = uint.Parse(serialNumber[..4]);
				//sensorBatch = uint.Parse(serialNumber.Substring(4, 4));
				//sensorNum = uint.Parse(serialNumber.Substring(8, 2));
			}
			else if (numDigits == 9)
			{
				sensorTypeCode = uint.Parse(serialNumber[..3]);
				//sensorBatch = uint.Parse(serialNumber.Substring(3, 4));
				//sensorNum = uint.Parse(serialNumber.Substring(7, 2));
			}
			else if (numDigits == 8)
			{
				sensorTypeCode = uint.Parse(serialNumber[..2]);
				//sensorBatch = uint.Parse(serialNumber.Substring(2, 4));
				//sensorNum = uint.Parse(serialNumber.Substring(6, 2));
			}
			else throw new TestException("Invalid serial number format.");

			// Translate code into sensor type.
			var sensorType = sensorTypeCode switch
			{
				185 => SensorType.Oxygen,
				20 or 21 or 22 => SensorType.HydrogenSulfide,
				11 or 15 => SensorType.CarbonMonoxide,
				55 => SensorType.HydrogenCyanide,
				51 => throw new TestException("SO2 sensors are not supported yet."),//sensorType = SensorDataLibrary.SensorType.SulfurDioxide;
				_ => throw new TestException("Unknown sensor type."),
			};
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

		private void FormProgrammer_Load(object sender, EventArgs e)
		{

		}
	}
}
