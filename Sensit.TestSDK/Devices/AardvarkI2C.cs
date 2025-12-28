using System;
using System.Collections.Generic;
using System.Linq;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Class for I2C communication using a Total Phase Aardvark
	/// https://www.totalphase.com/aardvark/
	/// </summary>
	public class AardvarkI2C
	{
		private int aardvarkHandle;

		/// <summary>
		/// Open Aardvark and set for I2C communication.
		/// </summary>
		public void Open()
		{
			// Find the number of connected Aardvark devices and their serial ports.
			ushort[] devicePorts = new ushort[1];
			int numDevicesFound = AardvarkApi.aa_find_devices(1, devicePorts);
			if (numDevicesFound == 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not find Aardvark." + Environment.NewLine + "Is it plugged in?");
			}

			// Pause
			AardvarkApi.aa_sleep_ms(1);

			// If the device is in use, throw an exception.
			if ((devicePorts[0] & (0x8000)) == 0x8000)
			{
				throw new DeviceCommunicationException("Aardvark already in use.");
			}

			// Open the first Aardvark port (assume we want to use device 0) and gete a device handle.
			aardvarkHandle = AardvarkApi.aa_open(devicePorts[0]);

			//if valid, will be greater than zero
			if (aardvarkHandle <= 0)
			{
				throw new DeviceCommunicationException("Could not open Aardvark. Try unplugging and replugging it in.");
			}

			// Pause
			AardvarkApi.aa_sleep_ms(1);

			// Enable I2C subsystem.
			// TODO:  Break out I2C enable into a separate method.
			int status = AardvarkApi.aa_configure(aardvarkHandle, AardvarkConfig.AA_CONFIG_SPI_I2C);
			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not configure Aardvark for I2C.");
			}

			// Pause
			AardvarkApi.aa_sleep_ms(1);

			// Enable 2.2k ohm I2C bus pullup resistors.
			// This command is only effective on v2.0 hardware or greater.
			// The pullup resistors on the v1.02 hardware are enabled by default.
			status = AardvarkApi.aa_i2c_pullup(aardvarkHandle, AardvarkApi.AA_I2C_PULLUP_BOTH);
			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not configure Aardvark pull-up resistors.");
			}

			//Pause
			AardvarkApi.aa_sleep_ms(1);

			// Set the bitrate the number is amount in kHz
			status = AardvarkApi.aa_i2c_bitrate(aardvarkHandle, 400);
			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not set Aardvark's bitrate.");
			}

			//Pause
			AardvarkApi.aa_sleep_ms(1);
		}

		/// <summary>
		/// Close the Aardvark.
		/// </summary>
		public void Close()
		{
			AardvarkApi.aa_close(aardvarkHandle);

			// Pause
			AardvarkApi.aa_sleep_ms(1);
		}

		/// <summary>
		/// Write a list of data to an EEPROM.
		/// </summary>
		/// <param name="i2cAddress">I2C address of the EEPROM</param>
		/// <param name="address">memory address to start writing to</param>
		/// <param name="data">bytes to write</param>
		public void EepromWrite(ushort i2cAddress, ushort address, List<byte> data)
		{
			// Turn target power on.
			int status = AardvarkApi.aa_target_power(aardvarkHandle, AardvarkApi.AA_TARGET_POWER_BOTH);
			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not turn Aardvark power on.");
			}

			// Pause for effect.
			AardvarkApi.aa_sleep_ms(1);

			// Attempt to write to the EEPROM.
			List<byte> page = [];

			foreach (byte b in data)
			{
				page.Add(b);
				if (page.Count == 64)
				{
					page.InsertRange(0, [(byte)(address >> 8), ((byte)address)]);
					I2CWrite(i2cAddress, page);
					page.Clear();
					address += 64;
				}
			}

			if (page.Count != 0)
			{
				page.InsertRange(0, [(byte)(address >> 8), ((byte)address)]);
				I2CWrite(i2cAddress, page);
			}

			// Turn target power off.
			status = AardvarkApi.aa_target_power(aardvarkHandle, AardvarkApi.AA_TARGET_POWER_NONE);
			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not turn Aardvark power off.");
			}

			// Pause for effect.
			AardvarkApi.aa_sleep_ms(1);
		}

		/// <summary>
		/// Reads a list of data from an EEPROM
		/// </summary>
		/// <param name="i2cAddress">I2C address of the EEPROM</param>
		/// <param name="address">memory address to start reading from</param>
		/// <param name="length">number of bytes to read</param>
		/// <returns>list of requested bytes</returns>
		public List<byte> EepromRead(ushort i2cAddress, ushort address, ushort length)
		{
			// Turn target power on.
			int status = AardvarkApi.aa_target_power(aardvarkHandle, AardvarkApi.AA_TARGET_POWER_BOTH);
			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not turn Aardvark power on.");
			}

			// Pause for effect.
			AardvarkApi.aa_sleep_ms(1);

			// List of bytes to return
			List<byte> eepromData = [];

			// Read from EEPROM in 64 byte chunks.
			while (length >= 64)
			{
				List<byte> addr = [(byte)(address >> 8), ((byte)address)];
				eepromData.AddRange(I2CWriteThenRead(i2cAddress, addr, 64));
				address += 64;
				length -= 64;
			}

			// Read last chunk of less than 64 bytes.
			if (length > 0)
			{
				List<byte> addr = new() { (byte)(address >> 8), ((byte)address) };
				eepromData.AddRange(I2CWriteThenRead(i2cAddress, addr, length));
			}

			// Turn target power off.
			status = AardvarkApi.aa_target_power(aardvarkHandle, AardvarkApi.AA_TARGET_POWER_NONE);
			if (status < 0)
			{
				Close();
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
		public List<byte> I2CWriteThenRead(ushort address, List<byte> writeData, ushort readLength)
		{
			ushort numWritten = 0;

			byte[] readData = new byte[readLength];
			ushort num_read = 0;

			//access address
			int status = AardvarkApi.aa_i2c_write_read(aardvarkHandle, address,
				AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)writeData.Count, writeData.ToArray(), ref numWritten, readLength, readData, ref num_read);

			//Status AA_OK == 0
			if (status < 0)
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

			//Pause
			AardvarkApi.aa_sleep_ms(100);

			return readData.ToList();
		}

		/// <summary>
		/// Perform an I2C write.
		/// </summary>
		/// <param name="address">address to start writing on</param>
		/// <param name="data">data to write</param>
		public void I2CWrite(ushort address, List<byte> data)
		{
			ushort written = 0;

			int status = AardvarkApi.aa_i2c_write_ext(aardvarkHandle, address, AardvarkI2cFlags.AA_I2C_NO_FLAGS, (ushort)data.Count, data.ToArray(), ref written);

			if (status < 0)
			{
				Close();
				throw new DeviceCommunicationException("Could not write to Aardvark." + $" Status number: {status}");
			}

			if (written != data.Count)
			{
				Close();
				throw new DeviceCommunicationException("Could not write to EEPROM");
			}

			//Waiting for write to complete.
			AardvarkApi.aa_sleep_ms(10);
		}

		/// <summary>
		/// Deconstructer for AardvarkI2C class
		/// </summary>
		~AardvarkI2C()
		{
			AardvarkApi.aa_close(aardvarkHandle);
		}
	}
}