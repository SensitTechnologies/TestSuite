using System;
using Sensit.TestSDK.Devices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Sensit.TestSDK.Exceptions;
using System.Globalization;
using System.Text;

namespace Sensit.App.Aardvark
{
    public partial class ElectrochemForm : Form
    {
        #region Fields
        public AardvarkI2C aardvark;

        ///////////								Smart Sensor Device ID Record										 ////////////
        public ushort SS_ID_REC_VALID = 0xAA;
        public ushort SS_ID_REC_VALID_LOC = 0x00;
        public ushort SS_ID_REC_CLASS = 0x01;
        public ushort SS_ID_REC_ID = 0x02;
        public ushort SS_ID_REC_FORMAT = 0x03;
        public int SS_ID_REC_DATE_CODE = 0x04;
        public int SS_ID_REC_SS_DATE = 0x07;
        public int SS_ID_REC_SERIAL_NUM = 0x10;
        public int SS_ID_REC_MAX_EXPOS = 0x30;
        public int SS_ID_REC_MAX_RANGE = 0x32;
        public int SS_ID_REC_MIN_RANGE = 0x34;
        public int SS_ID_REC_ISSUE = 0x36;
        public int SS_ID_REC_REV = 0x38;
        public int SS_ID_REC_CHECKSUM = 0x3C;
        public int SS_ID_REC_RELEASE = 0x3A;

        ///////////						Smart Sensor Device Manufacturing Record						 ////////////
        public int SS_MAN_REC_VALID = 0xAA;
        public int SS_MAN_REC_VALID_LOC = 0x00;
        public int SS_MAN_REC_CLASS = 0x01;
        public int SS_MAN_REC_ID = 0x02;
        public int SS_MAN_REC_FORMAT = 0x03;
        public int SS_MAN_REC_UNUSED_1 = 0x04;
        public int SS_MAN_REC_SS_DATE = 0x07;
        public int SS_MAN_REC_SERIAL_NUM = 0x10;
        public int SS_MAN_REC_UNUSED_2 = 0x30;
        public int SS_MAN_REC_ISSUE = 0x36;
        public int SS_MAN_REC_REV = 0x38;
        public int SS_MAN_REC_CHECKSUM = 0x3C;
        public int SS_MAN_REC_RELEASE = 0x3A;

        #endregion
        public ElectrochemForm()
        {
            InitializeComponent();

            aardvark = new AardvarkI2C();
        }

        /// <summary>
        /// When ButtonWrite is clicked, write data to EEPROM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            try
            {
                aardvark.Open();
                //adding Two more bytes to have the address written to it at first
                List<byte> data = Encoding.ASCII.GetBytes(textBoxData.Text).ToList();

                //Setting Address to Write
                ushort address = ushort.Parse(textBoxWriteAddress.Text);

                //Check for valid start address
                if (address > 32768)
                {
                    throw new TestException("Please enter an address that is less than 32,768.");
                }

                //Check for valid end address
                if ((address + data.Count) > 32768)
                {
                    throw new TestException("Data exceeds maximum address");
                }

                //Writes data to the EEPROM
                aardvark.EepromWrite(address, data.ToList());

                aardvark.Close();
            }
            catch (Exception ex)
            {
                // Alert user that a sensor failed.
                MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
            }
        }

        /// <summary>
        /// When ButtonRead is clicked, read data from EEPROM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRead_Click(object sender, EventArgs e)
        {
            try
            {
                aardvark.Open();

                //Clear Output Text Box
                textBoxOutput.Text = "";

                ushort address = ushort.Parse(textBoxReadAddress.Text);
                if (address > 32768)
                {
                    throw new TestException("Please enter an address that is less than 32,768.");
                }
                textBoxOutput.Text += "Address is " + address.ToString() + Environment.NewLine;

                //Length at EEPROM read
                ushort length = ushort.Parse(textBoxReadLength.Text);

                //Make the Read List
                List<byte> readList = aardvark.EepromRead(address, length);

                //Reset progress bar limits

                progressBarRead.Minimum = 0;
                progressBarRead.Maximum = length;

                foreach (byte data in readList)
                {
                    textBoxOutput.Text += ($"{data} \r\n");
                    progressBarRead.Increment(1);
                }
                progressBarRead.Equals(0);

                aardvark.Close();
            }
            catch (Exception ex)
            {
                // Alert user that a sensor failed.
                MessageBox.Show(ex.Message, ex.GetType().Name.ToString(CultureInfo.CurrentCulture));
            }
        }

        private void ManufactureValidityInput_Click(object sender, EventArgs e)
        {

        }

        private void ManufactureIdInput_Click(object sender, EventArgs e)
        {

        }

        private void ManufactureRecordInput_Click(object sender, EventArgs e)
        {

        }

        private void ManufactureSsDateInput_Click(object sender, EventArgs e)
        {

        }

        private void ManufactureSensorTypeInput_Click(object sender, EventArgs e)
        {

        }

        private void ManufactureRevisionInput_Click(object sender, EventArgs e)
        {

        }
    }
}