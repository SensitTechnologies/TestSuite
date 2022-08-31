using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;
using System.Linq;
using System.Text;

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
		/// When the application closes, save settings and close serial port.
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
		/// When the "Program" button is clicked, program the sensor.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ButtonProgram_Click(object sender, EventArgs e)
		{
			string input = textBoxBarcode.Text;
			List<char> userInput = input.ToCharArray().ToList();

			try
			{
				//Disable Barcode
				textBoxBarcode.Enabled = false;

				//Make sure length is equal to valid serial number length
				//TODO: confirm these are the correct input lengths
				if (userInput.Count == 8 || userInput.Count == 9)
				{
					toolStripProgressBar.Increment(5);
				}
				else
				{
					throw new TestException(userInput + " is not the length of a valid serial number.");
				}
			}
			catch
			{
				throw new TestException($"\"{userInput}\" is not a valid serial number.");
			}

			//Disable Program Button
			buttonProgram.Enabled = false;

			//Instantiate new instance of Aardvark
			AardvarkI2C aardvark;

			//Break user input into needed parts
			ParseSensorSerialNumber(userInput);
		}

		#region Programmer Commands
		/* 1.Get user input.
		 * 2.Break user input into needed info.
		 * 3.Give info to SensorDataLibrary, return data for EEPROM
		 * 4.Convert data into complete byte list.
		 * 5.Return byte list to program button click. (or write from method directly) */

		#endregion

		#region Helper Methods

		/// <summary>
		/// Breaks the serial number down into type, batch, and quantity.
		/// </summary>
		/// <param name="data">user inputted serial number</param>
		internal void ParseSensorSerialNumber(List<char> data)
		{
			// PULLED FROM OLD VERSION
			// Parse the serial number. It follows format “TTTBBBBNN”
			// TTT	= Sensor type (this could be only two digits if the first number is 0).
			// BBBB	= Batch Number
			// NN	= Number in Batch
			//string sensorType = $"{data[0]}{data[1]}{data[2]})";
			string sensorType = (data.Count == 8) ? $"{data[0]}{data[1]}" : $"{data[0]}{data[1]}{data[2]}";
			string batchNumber = $"{data[3]}{data[4]}{data[5]})";
			string batchQuantity = $"{data[6]}{data[7]})";
		}

		#endregion
	}
	/* // Translate code into sensor type.
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

	        public enum SensorType
        {
            LeadFreeOxygen,     // LFO2-A4
            HydrogenSulfide,    // H2S-A1, H2S-B1
            CarbonMonoxide,     // CO-AF
            HydrogenCyanide,    // HCN-A1
            SulfurDioxide       // SO2-AF
        }
	 */
}
