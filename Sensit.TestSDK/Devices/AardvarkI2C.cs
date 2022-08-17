using System;
using System.Runtime.InteropServices;

namespace Sensit.TestSDK.Devices
{
    /// <summary>
    /// Class to communicate with the electrochemical sensors with I2C communication on the Aardvark
    /// </summary>
    public class AardvarkI2C
    {

        private int Aardvark;
        private byte[] data;
        private byte status;
        private ushort address;
        private ushort cat24AddNum;
        private ushort cat24AddLen;
        private ushort cat24addr = 0x57;//Cat24C256 Address

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
        public byte eepromWrite(ushort AddressLoc, ushort totalLength, byte[] data)
        {
            byte[] buffer = new byte[66];

            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
            AardvarkApi.aa_i2c_free_bus(Aardvark);

            for (ushort i = 0, add = AddressLoc, len = totalLength; (i <= (ushort)(totalLength / 64)); i++, add += 64, len -= 64)
            {
                //adding in the address two the write buffer
                //MSB first and LSB second
                buffer[0] = (byte)(add >> 8);
                buffer[1] = (byte)(add & 0xff);

                //put data in fullwrite buffer
                for (ushort j = 0; (j < 64) && (j < len); j++)
                {
                    buffer[j + 2] = data[(i * 64) + j];
                }

                status = 0;
                if (len < 64)//Do a remainder write
                {
                    status = eeI2CWrite(add, buffer, (ushort)(len + 2));
                }
                else //Do a full write
                {
                    status = eeI2CWrite(add, buffer, 66);
                }
                //need the ms time in between or there will be an ack error (3)
                AardvarkApi.aa_sleep_ms(1);

                if (status > 0)
                {
                    AardvarkApi.aa_i2c_free_bus(Aardvark);
                    AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);
                    return status;
                }
            }
            AardvarkApi.aa_i2c_free_bus(Aardvark);
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);
            return 0;
        }

        /// <summary>
        /// Reads the memory from the Electrochemical Sensor's EEPROM
        /// </summary>
        /// <param name="AddressLoc"></param>
        /// <param name="totalLength"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        ///
        public byte eepromRead(ushort AddressLoc, ushort totalLength, byte[] data)
        {
            byte[] buffer = new byte[64];

            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
            AardvarkApi.aa_i2c_free_bus(Aardvark);

            for (ushort i = 0, add = AddressLoc, len = totalLength; (i <= ((ushort)(totalLength / 64))); i++, add += 64, len -= 64)
            {

                if (len < 64)
                {
                    status = eeI2CRead(add, buffer, len);
                }
                else
                {
                    status = eeI2CRead(add, buffer, 64);
                }

                if (status > 0)
                {
                    AardvarkApi.aa_i2c_free_bus(Aardvark);
                    AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);
                    return 1;
                }

                for (ushort j = 0; (j < 64) && (j < len) && (j < data.Length); j++)
                {
                    data[(i * 64) + j] = buffer[j];
                }
                AardvarkApi.aa_sleep_ms(1);
            }

            AardvarkApi.aa_i2c_free_bus(Aardvark);
            AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);
            return 0;
        }
        /// <summary>
        /// Using I2C on Aardvark to read from EEPROM
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte eeI2CRead(ushort addr, byte[] data, ushort length)
        {
            byte[] address = { ((byte)(addr >> 8)), ((byte)addr) };
            ushort num_written = 0;
            ushort num_read = 0;
            int status;

            //access address
            status = AardvarkApi.aa_i2c_write_read(Aardvark, cat24addr, AardvarkI2cFlags.AA_I2C_NO_FLAGS, 2, address, ref num_written, length, data, ref num_read);

            if (((ushort)status) > 0)
            {
            }

            if ((status >> 8) > 0)
            {
                return 1;
            }



            return 0;

        }

        /// <summary>
        /// Using I2C on Aardvark to write from EEPROM
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="data"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        private byte eeI2CWrite(ushort addr, byte[] data, ushort length)
        {
            byte[] address = { ((byte)(addr >> 8)), ((byte)addr) };
            int status;
            ushort written = 0;

            status = AardvarkApi.aa_i2c_write_ext(Aardvark, cat24addr, AardvarkI2cFlags.AA_I2C_NO_FLAGS, length, data, ref written);

            if (written == length)
            {
                //no errors
                return 0;
            }
            else
            {
                return 1;
            }
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