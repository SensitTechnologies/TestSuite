using System;
using Sensit.TestSDK.Devices;
using System.Runtime.InteropServices;


namespace ElectrochemComm
{
    public partial class ElectrochemComm: Form
    {

        public AardvarkI2C Aardvark;

        ///////////								Smart Sensor Device ID Record										 ////////////
        public ushort SS_ID_REC_VALID = 0xAA;
        public ushort SS_ID_REC_VALID_LOC = 0x00;
        public ushort SS_ID_REC_CLASS = 0x01;
        public ushort SS_ID_REC_ID	= 0x02;
        public ushort SS_ID_REC_FORMAT =	0x03;
        public int SS_ID_REC_DATE_CODE =	0x04;
        public int SS_ID_REC_SS_DATE =	0x07;
        public int SS_ID_REC_SERIAL_NUM=	0x10;
        public int SS_ID_REC_MAX_EXPOS	=	0x30;
        public int SS_ID_REC_MAX_RANGE = 0x32;
        public int SS_ID_REC_MIN_RANGE	=	0x34;
        public int SS_ID_REC_ISSUE	=	0x36;
        public int SS_ID_REC_REV =	0x38;
        public int SS_ID_REC_CHECKSUM	=	0x3C;
        public int SS_ID_REC_RELEASE	=	0x3A;

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
        public List<byte> cat24Data; 
        public ushort adsAddNum;

        public ElectrochemComm()
        {
            InitializeComponent();

            cat24Str = String.Empty;
            adsStr = String.Empty;

            cat24AddNum = 0;
            cat24AddLen = 0;
            cat24Data = new List<byte>();

            adsAddNum = 0;

            Aardvark = new AardvarkI2C();
        }

        /// <summary>
        /// Write to EEPROM
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
            textBoxOutput.Text += "Address is " + cat24AddNum.ToString() + "\r\n";
            
            //places maxmum limit on text length
            if ((cat24AddNum + cat24AddLen) > 32768)
            {
                cat24AddLen = (ushort)(32768 - cat24AddNum);
            }
            textBoxOutput.Text += "Length is " + data.Length.ToString() + "\r\n";


            Aardvark.eepromWrite(cat24AddNum,cat24AddLen,data);
        }

        //public byte eepromWrite(ushort addr, byte[] data, ushort length) 
        //{
        //    byte[] address = { ((byte)(addr >> 8)), ((byte)addr) };
        //    int status;
        //    ushort written = 0;

        //    status = AardvarkApi.aa_i2c_write_ext(Aardvark, cat24addr, AardvarkI2cFlags.AA_I2C_NO_FLAGS, length, data, ref written);

        //    if (written == length)
        //    {
        //        //no errors
        //        return 0;
        //    }
        //    else
        //    {
        //        textBoxOutput.Text += "Addressing Error ... Status " + ((ushort)status).ToString() +" Length is "+length.ToString()+ " written is " + written.ToString() + "\r\n";
        //        return 1;
        //    }
        //}

        /*
         addr - address in memory to read from
         data - buffer to store memory
         length - length of memory stored
         */
        //public byte eepromRead(ushort addr, byte[] data, ushort length) 
        //{
        //    byte[] address = {((byte)(addr >> 8)),((byte)addr)};
        //    ushort num_written = 0;        
        //    ushort num_read = 0;
        //    int status;

        //    //access address
        //    status = AardvarkApi.aa_i2c_write_read(Aardvark, cat24addr, AardvarkI2cFlags.AA_I2C_NO_FLAGS, 2, address,ref num_written,length,data, ref num_read);

        //    if (((ushort)status)>0)
        //    {
        //        textBoxOutput.Text += "Addressing Error " + ((ushort)status).ToString() + "\r\n";
        //    }
            
        //    if ((status >> 8)>0) 
        //    {
        //        textBoxOutput.Text += "Read Error " + (status >> 8).ToString() + "\r\n";
        //        return 1;
        //    }



        //    return 0; 
            
        //}
        /// <summary>
        /// Read From the EEPROM after button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            /**********************///EEPROM Read//*************************/
            byte status;
            int parsed;
            byte[] buffer = new byte[64];//the buffer to separate the data textboxes into 64 bytes

            //Address at EEPROM read
            cat24Str = textBoxRAddress.Text;
            Int32.TryParse(cat24Str, out parsed);
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
            if ((cat24AddNum+cat24AddLen) > 32768) {
                cat24AddLen = (ushort)(32768 - cat24AddNum);
            }
            textBoxOutput.Text += "Length is " + cat24AddLen.ToString() + "\r\n";

            byte[] data = new byte[cat24AddLen];

            status = Aardvark.eepromRead(cat24AddNum,cat24AddLen,data);

            if (status > 0) {
                textBoxOutput.Text += "Read Error is " + status.ToString() + "\r\n";
            }

            for (ushort i = 0, address = cat24AddNum; i<cat24AddLen ;i++,address++) {
                textBoxOutput.Text += "Address " + address.ToString() + " = " + ((char)data[i]) + "\r\n";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ElectrochemComm_Load(object sender, EventArgs e)
        {

        }

        private void ElectrochemComm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBoxRAddress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}