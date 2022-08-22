using System;
using System.Collections.Generic;
using Sensit.TestSDK;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;

namespace Sensit.App.Aardvark
{
    /// <summary>
    /// Class to communicate with the electrochemical sensors with I2C communication on the Aardvark
    /// </summary>
    public class AardvarkI2C
    {
        #region Fields

        private int Aardvark;
        private ushort EEPROM_I2C_ADDRESS = 0x57;//Cat24C256

        #endregion

        /// <summary>
        /// Aardvark communication for Eeprom on the Electrochem Sensor
        /// </summary>
        /// 
        public AardvarkI2C()
        {
            int maxDev;
            int testNum = 16;//maximum amount of devices previously AARDVARK_PORTS equaled 16 so I tried that
            ushort[] devices = new ushort[testNum];//device arrays

            //Find maximum amount of devices
            maxDev = AardvarkApi.aa_find_devices(testNum, devices);

            for (int i = 0; i < maxDev; i++)
            {
                if ((devices[i] & ((ushort)0x8000)) != 0x8000)
                {
                    Aardvark = devices[i];
                    if ((Aardvark = AardvarkApi.aa_open(Aardvark)) <= 0)
                    {
                        AardvarkApi.aa_close(Aardvark);
                    }
                    else
                    {
                        break;//assuming that the return is successful opening
                    }
                }
            }

            // Ensure that the I2C subsystem is enabled
            AardvarkApi.aa_configure(Aardvark, AardvarkConfig.AA_CONFIG_SPI_I2C);

            // This command is only effective on v2.0 hardware or greater.
            // The power pins on the v1.02 hardware are not enabled by default.
            //AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);

            // Enable the I2C bus pullup resistors (2.2k resistors).
            // This command is only effective on v2.0 hardware or greater.
            // The pullup resistors on the v1.02 hardware are enabled by default.
            AardvarkApi.aa_i2c_pullup(Aardvark, AardvarkApi.AA_I2C_PULLUP_BOTH);

            // Set the bitrate the number is amount in kHz
            AardvarkApi.aa_i2c_bitrate(Aardvark, 400);
        }

        /// <summary>
        /// Write to the EEPROM on the electrochem sensor
        /// </summary>
        /// <returns></returns>
        public List<byte> EepromWrite(ushort address, ushort length)
        {
            //Data got corrupted, will reiterate as best as I can. Helps avoid errors when aardvark gets unplugged
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
            AardvarkApi.aa_i2c_free_bus(Aardvark);
            // ^Was this even here before??? This corrupted everything has me very lost.

            List<byte> eepromData = new();
            try
            {
                byte[] page = new byte[66];
                for (ushort i = 0, add = address, len = length; (i <= (ushort)(length / 64)); i++, add += 64, len -= 64)
                {
                    //adding in the address two the write buffer
                    //MSB first and LSB second
                    page[0] = (byte)(add >> 8);
                    page[1] = (byte)(add & 0xff);

                    //put data in fullwrite buffer
                    for (ushort j = 0; (j < 64) && (j < len); j++)
                    {
                        page[j + 2] = page[(i * 64) + j];
                    }

                    if (len < 64)//Do a remainder write
                    {
                        page = EeI2CWrite(add, (ushort)(len + 2));
                    }
                    else //Do a full write
                    {
                        page = EeI2CWrite(add, 66);
                    }
                    //need the ms time in between or there will be an ack error (3)
                    AardvarkApi.aa_sleep_ms(1);
                }
            }
            catch (DeviceException e)
            {
                //Data got corrupted, will reiterate as best as I can. Helps avoid errors when aardvark gets unplugged
                AardvarkApi.aa_i2c_free_bus(Aardvark);
                AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);

                throw e;
            }

            //Data got corrupted, will try to reiterate. Helps avoid errors when aardvark gets unplugged
            AardvarkApi.aa_i2c_free_bus(Aardvark);
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);

            return eepromData;
        }

        /// <summary>
        /// Reads the memory from the Electrochemical Sensor's EEPROM
        /// </summary>
        /// <param name="AddressLoc"></param>
        /// <param name="totalLength"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        ///
        public List<byte> EepromRead(ushort address, ushort length)
        {
            //Helps avoid errors when aardvark gets unplugged
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
            AardvarkApi.aa_i2c_free_bus(Aardvark);

            List<byte> eepromData = new();
            try
            {
                byte[] page = new byte[64];
                for (ushort i = 0, add = address, len = length; (i <= ((ushort)(length / 64))); i++, add += 64, len -= 64)
                {

                    if (len < 64)
                    {
                        page = EeI2CRead(add, len);
                    }
                    else
                    {
                        page = EeI2CRead(add, 64);
                    }

                    for (ushort j = 0; (j < 64) && (j < len) && (j < eepromData.Count); j++)
                    {
                        eepromData[(i * 64) + j] = page[j];
                    }
                    AardvarkApi.aa_sleep_ms(1); //what is this??
                }
            }
            catch (DeviceException e)
            {
                //Helps avoid errors when aardvark gets unplugged
                AardvarkApi.aa_i2c_free_bus(Aardvark);
                AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);

                throw e;
            }
            return eepromData;
        }

        /// <summary>
        /// Using I2C on Aardvark to read from EEPROM
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte[] EeI2CRead(ushort addr, ushort length)
        {
            byte[] address = { ((byte)(addr >> 8)), ((byte)addr) };
            ushort num_written = 0;

            byte[] data = new byte[length];
            ushort num_read = 0;
            //access address
            int status = AardvarkApi.aa_i2c_write_read(Aardvark, EEPROM_I2C_ADDRESS,
                AardvarkI2cFlags.AA_I2C_NO_FLAGS, 2, address, ref num_written, length, data, ref num_read);
            if (status != 0)
            {
                throw new DeviceException("Couldn't read from EEPROM.");
            }    
            return data;
        }
        /// <summary>
        /// Using I2C on Aardvark to write from EEPROM
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
      private byte[] EeI2CWrite(ushort addr, ushort length)
        {
            byte[] address = { ((byte)(addr >> 8)), (byte)addr };
            ushort written = 0;
            byte[] data = new byte[length];

            int status = AardvarkApi.aa_i2c_write_ext(Aardvark, EEPROM_I2C_ADDRESS, AardvarkI2cFlags.AA_I2C_NO_FLAGS, length, data, ref written);

           if (written != length)
            {
                throw new DeviceException("Can't write to EEPROM");
            }

            return data;
        }
        /// <summary>
        /// Deconstructer for AardvarkI2C class
        /// </summary>
        ~AardvarkI2C()
        {
            AardvarkApi.aa_close(Aardvark);
        }
    }
}