using System;
using Sensit.TestSDK.Devices;
using System.Runtime.InteropServices;
using System.Diagnostics;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Aardvark
{
    public partial class ElectrochemForm : Form
    {
        #region Fields
        public AardvarkI2C Aardvark;

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

        //the last 7 bits are used for address
        public ushort cat24addr = 0x57;//Cat24C256 Address
        public ushort adsaddr = 0x48;//ADS1115 Address //still wrong

        public String cat24Str;
        public String adsStr;

        public ushort cat24AddNum;
        public ushort cat24AddLen;
        public ushort adsAddNum;
        #endregion
        public ElectrochemForm()
        {
            InitializeComponent();

            cat24Str = String.Empty;
            adsStr = String.Empty;

            cat24AddNum = 0;
            cat24AddLen = 0;

            adsAddNum = 0;

            Aardvark = new AardvarkI2C();
        }

        /// <summary>
        /// When ButtonWrite is clicked, write data to EEPROM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonWrite_Click(object sender, EventArgs e)
        {
            cat24Str = textBoxData.Text;

            //adding Two more bytes to have the address written to it at first
            byte[] data = new byte[textBoxData.Text.Length];

            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (byte)(textBoxData.Text.ElementAt<char>(i));
            }
            cat24AddLen = (ushort)(textBoxData.Text.Length);

            //Setting Address to Write
            cat24Str = textBoxWAddress.Text;
            Int32.TryParse(cat24Str, out int parsed);
            cat24AddNum = (ushort)parsed;

            //places maximum limit on address
            if (cat24AddNum > 32768)
            {
                cat24AddNum = 32768;
            }

            //places maxmum limit on text length
            if ((cat24AddNum + cat24AddLen) > 32768)
            {
                cat24AddLen = (ushort)(32768 - cat24AddNum);
            }

            //Writes data to the EEPROM
            List<byte> dataList = Aardvark.EepromWrite(cat24AddNum, cat24AddLen);
        }

        /// <summary>
        /// When ButtonRead is clicked, read data from EEPROM
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonRead_Click(object sender, EventArgs e)
        {
            //Clear Output Text Box
            textBoxOutput.Text = "";

            /**********************///EEPROM Read//*************************/
            //Don't know if we need this anymore
            byte[] buffer = new byte[64];//the buffer to separate the data textboxes into 64 bytes

            cat24Str = textBoxRAddress.Text;
            Int32.TryParse(cat24Str, out int parsed);
            cat24AddNum = (ushort)parsed;
            if (cat24AddNum > 32768)
            {
                cat24AddNum = 32768;
            }
            textBoxOutput.Text += "Address is " + cat24AddNum.ToString() + "\r\n";

            //Length at EEPROM read
            cat24Str = textBoxReadLength.Text;
            Int32.TryParse(cat24Str, out parsed);
            cat24AddLen = (ushort)parsed;

            //Make the Read List
            List<byte> readList = new(Aardvark.EepromRead(cat24AddNum, cat24AddLen));

            //Reset progress bar limits
            progressBarRead.Minimum = 0;
            progressBarRead.Maximum = cat24AddLen;

            foreach (byte data in readList)
            {
                textBoxOutput.Text += ($"{data} \r\n");
                progressBarRead.Increment(1);
            }
            progressBarRead.Equals(0);
            Debug.Print("Number of elements in cat24Data list is: " + readList.Count);
        }       
    }
}