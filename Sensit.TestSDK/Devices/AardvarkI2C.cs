using System;
using System.Collections.Generic;
using System.Linq;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Devices
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
		/// Open Aardvark and set for I2C communication.
		/// </summary>
		public void Open()
		{
			int maxDev;
			ushort[] devices = new ushort[1];//device arrays

			//Find maximum amount of devices
			maxDev = AardvarkApi.aa_find_devices(1, devices);
			if (maxDev == 0)
			{
				throw new DeviceCommunicationException("Could not find Aardvark." + Environment.NewLine + "Is it plugged in?");
			}

			if ((devices[0] & ((ushort)0x8000)) == 0x8000)
			{
				throw new DeviceCommunicationException("Aardvark already in use.");
			}

			Aardvark = AardvarkApi.aa_open(devices[0]);
			if (Aardvark <= 0)
			{
				throw new DeviceCommunicationException("Could not open Aardvark.");
			}

			// Ensure that the I2C subsystem is enabled
			int status = AardvarkApi.aa_configure(Aardvark, AardvarkConfig.AA_CONFIG_SPI_I2C);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not configure Aardvark for I2C.");
			}

			// This command is only effective on v2.0 hardware or greater.
			// The power pins on the v1.02 hardware are not enabled by default.
			//AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);

			// Enable the I2C bus pullup resistors (2.2k resistors).
			// This command is only effective on v2.0 hardware or greater.
			// The pullup resistors on the v1.02 hardware are enabled by default.
			status = AardvarkApi.aa_i2c_pullup(Aardvark, AardvarkApi.AA_I2C_PULLUP_BOTH);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not configure Aardvark pull-up resistors.");
			}

			// Set the bitrate the number is amount in kHz
			status = AardvarkApi.aa_i2c_bitrate(Aardvark, 400);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not set Aardvark's bitrate.");
			}
		}

		/// <summary>
		/// Close the Aardvark.
		/// </summary>
		public void Close()
		{
			int status = AardvarkApi.aa_close(Aardvark);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not close Aardvark.");
			}
		}

		/// <summary>
		/// Write to the EEPROM on the electrochemical sensor.
		/// </summary>
		/// <param name="address">starting address of the location to pull bytes from</param>
		/// <param name="length">number of bytes to pull</param>
		/// <returns>list of requested bytes</returns>
		public void EepromWrite(ushort address, List<byte> data)
		{
			//Helps avoid errors when aardvark gets unplugged
			int status = AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not turn Aardvark power on.");
			}
			status = AardvarkApi.aa_i2c_free_bus(Aardvark);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not free I2C bus.");
			}

			//Attempt to Write to the EEPROM
			List<byte> page = new();

			foreach (byte b in data)
			{
				page.Add(b);
				if (page.Count == 64)
				{
					page.InsertRange(0, BitConverter.GetBytes(address));
					I2CWrite(EEPROM_I2C_ADDRESS, page);
					page.Clear();
					address += 64;
				}
			}
			if (page.Count != 0)
			{
				page.InsertRange(0, BitConverter.GetBytes(address));
				I2CWrite(EEPROM_I2C_ADDRESS, page);
			}

			//Helps avoid errors when aardvark gets unplugged
			status = AardvarkApi.aa_i2c_free_bus(Aardvark);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not free I2C bus.");
			}
			status = AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);
			if (status != 0)
			{
				throw new DeviceCommunicationException("Could not turn Aardvark power off.");
			}
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
			int status = AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_BOTH);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not turn Aardvark power on.");
			}
			status = AardvarkApi.aa_i2c_free_bus(Aardvark);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not free I2C bus.");
			}

			//List of bytes to return
			List<byte> eepromData = new();

			//Attempt to read from EEPROM
			List<byte> page = new() { Capacity = 64 };

			//Pretty sure this breaks up the length into page lengths
			for (ushort i = 0, add = address, len = length;
				(i <= ((ushort)(length / 64))); i++, add += 64, len -= 64)
			{
				List<byte> addr = new() { (byte)(add >> 8), ((byte)add) };
				if (len < 64)
				{
					page.AddRange(I2CWriteThenRead(EEPROM_I2C_ADDRESS, addr, len));
				}
				else if (len > 0)
				{
					page.AddRange(I2CWriteThenRead(EEPROM_I2C_ADDRESS, addr, 64));
				}

				//need the ms time in between or there will be an ack error (3)
				AardvarkApi.aa_sleep_ms(1);

				//Add page to bottom of the list of read data.
				eepromData.AddRange(page);

				//Remove all elements from the page
				page.Clear();
			}


			//Helps avoid errors when aardvark gets unplugged
			status = AardvarkApi.aa_i2c_free_bus(Aardvark);
			if (status == 0)
			{
				throw new DeviceCommunicationException("Could not free I2C bus.");
			}
			status = AardvarkApi.aa_target_power(Aardvark, AardvarkApi.AA_TARGET_POWER_NONE);
			if (status != 0)
			{
				throw new DeviceCommunicationException("Could not turn Aardvark power off.");
			}

			return eepromData;
		}

		/// <summary>
		/// Perform an I2C write then read.
		/// </summary>
		/// <param name="address">address to start reading bytes from</param>
		/// <param name="writeData">list of data to write</param>
		/// <param name="readLength">number of bytes to read</param>
		/// <returns>a list of requested data</returns>
		private List<byte> I2CWriteThenRead(ushort address, List<byte> writeData, ushort readLength)
		{
			ushort numWritten = 0;

			byte[] readData = new byte[readLength];
			ushort num_read = 0;

			//access address
			int status = AardvarkApi.aa_i2c_write_read(Aardvark, address,
				AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)writeData.Count, writeData.ToArray(), ref numWritten, readLength, readData, ref num_read);

			if (status != 0)
			{
				throw new DeviceCommandFailedException("Could not read from Aardvark.");
			}
			if (writeData.Count != numWritten)
			{
				throw new DeviceCommandFailedException("Number of data written to Aardvark is incorrect.");
			}
			if (readLength != num_read)
			{
				throw new DeviceCommandFailedException("Number of data read from Aardvark is incorrect.");
			}

			return readData.ToList();
		}

		/// <summary>
		/// Perform an I2C write.
		/// </summary>
		/// <param name="address">address to start writing on</param>
		/// <param name="data">data to write</param>
		private void I2CWrite(ushort address, List<byte> data)
		{
			ushort written = 0;

			int status = AardvarkApi.aa_i2c_write_ext(Aardvark, address, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)data.Count, data.ToArray(), ref written);

			if (status != 0)
			{
				throw new DeviceCommunicationException("Could not write to Aardvark." + $"Status number: {status}");
			}

			if (written != data.Count)
			{
				throw new DeviceCommunicationException("Could not write to EEPROM");
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