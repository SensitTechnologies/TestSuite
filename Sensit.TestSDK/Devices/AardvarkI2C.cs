using System;
using System.Collections.Generic;
using Sensit.TestSDK;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Exceptions;
using System.Diagnostics;
using System.Linq;

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
        /// Write to the EEPROM on the electrochemical sensor.
        /// </summary>
        /// <param name="address">starting address of the location to pull bytes from</param>
        /// <param name="length">number of bytes to pull</param>
        /// <returns>list of requested bytes</returns>
        public List<byte> EepromWrite(ushort address, ushort length)
        {
            //Helps avoid errors when aardvark gets unplugged
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
            AardvarkApi.aa_i2c_free_bus(Aardvark);
            // ********* ^^^^ Was this even here before??? This corrupted everything has me very lost.

            //Creates the byte List the method will return
            List<byte> eepromData = new();

            //Attempt to Write to the EEPROM
            try
            {
                //Writes can only be done at the start of a page address. Create 64 byte pages
                //Confirm with Everett that it's 66 bytes as a 2 byte buffer
                List<byte> page = new() { Capacity = 66 };

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
            //If attempt fails, throw Device Exception
            catch (DeviceException e)
            {
                //Data got corrupted, will reiterate as best as I can. Helps avoid errors when aardvark gets unplugged
                AardvarkApi.aa_i2c_free_bus(Aardvark);
                AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);

                //Check with Adam to make sure I did this exception right
                throw new DeviceCommandFailedException();
            }

            //Helps avoid errors when aardvark gets unplugged
            AardvarkApi.aa_i2c_free_bus(Aardvark);
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);

            return eepromData;
        }

        /// <summary>
        /// Reads the current memory from the sensor's EEPROM
        /// </summary>
        /// <param name="address">address location to start reading from</param>
        /// <param name="length">number of bytes to read</param>
        /// <returns>list of requested bytes</returns>
        public List<byte> EepromRead(ushort address, ushort length)
        {
            //Helps avoid errors when aardvark gets unplugged
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
            AardvarkApi.aa_i2c_free_bus(Aardvark);

            //List of bytes to return
            List<byte> eepromData = new();

            //Attempt to read from EEPROM
            try
            {
                //Check with Adam and Everett
                /* If I remember what Peter said correctly, you can read from anywhere on a page.
                 * You just have to start the Write at the start of the page. So is breaking it 
                 * up into pages necessary for reading from the EEPROM? I'm not sure on how this
                 * works quite yet so I don't know. If it doesn't need pages though, removing the page 
                 * spacing would make the code cleaner and more efficient.
                 */
                List<byte> page = new(){Capacity = 64};

                //Pretty sure this breaks up the length into page lengths
                for (ushort i = 0, add = address, len = length; 
                    (i <= ((ushort)(length / 64))); i++, add += 64, len -= 64)
                {
                    if (len < 64)
                    {
                        page.AddRange(EeI2CRead(add, len));
                    }
                    else
                    {
                        page.AddRange(EeI2CRead(add, 64));
                    }
                
                    AardvarkApi.aa_sleep_ms(1); //what is this??

                    //Add page to bottom of the list of read data.
                    eepromData.AddRange(page);

                    //Remove all elements from the page
                    page.Clear();
                }
            }
            catch (DeviceException e)
            {
                //Helps avoid errors when aardvark gets unplugged
                AardvarkApi.aa_i2c_free_bus(Aardvark);
                AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);

                throw new DeviceCommandFailedException();
            }
            return eepromData;
        }

        /// <summary>
        /// Uses the I2C to read data from the EEPROM
        /// </summary>
        /// <param name="addr">address to start reading bytes from</param>
        /// <param name="length">number of bytes to read</param>
        /// <returns>a list of requested data</returns>
        private List<byte> EeI2CRead(ushort addr, ushort length)
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
                throw new DeviceCommunicationException();
            }

            //convert data array to list
            List<byte> readData = data.ToList();

            return readData;
        }

        /// <summary>
        /// Use the IC2 to write to the EEPROM.
        /// </summary>
        /// <param name="addr">address to start writing on</param>
        /// <param name="length">nunmber of bytes to write</param>
        /// <returns>a list of requested data</returns>
      private List<byte> EeI2CWrite(ushort addr, ushort length)
        {
            byte[] address = { ((byte)(addr >> 8)), (byte)addr };
            ushort written = 0;
            byte[] data = new byte[length];

            int status = AardvarkApi.aa_i2c_write_ext(Aardvark, EEPROM_I2C_ADDRESS, AardvarkI2cFlags.AA_I2C_NO_FLAGS, length, data, ref written);

           if (written != length)
            {
                throw new DeviceException("Can't write to EEPROM");
            }

           //Converts the data array into a list
            List<byte> dataList = data.ToList();

            return dataList;
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