using System;
using System.ComponentModel;

namespace Sensit.TestSDK.Devices
{
	[DisplayName("ADS111x 16-bit ADC"), Description("16-bit 860-SPS 4-channel delta-sigma ADC with I2C")]
	public static class ADS111x
	{
		// Address pointer register flags; determine which register we read from or write to.
		public enum AddressPointer : byte
		{
			// Conversion register is 16-bits, read only.
			ConversionRegister = 0x00,

			// Configuration register is 16-bits, read/write.
			ConfigRegister = 0x01,

			// These two registers are applicable only to the ADS1115 and ADS1114.
			// The upper and lower threshold values used by the comparator are stored in two 16-bit registers in 2's complement format. The comparator is implemented as a digital comparator; therefore, the values in these registers must be updated whenever the PGA settings are changed.
			LowThreshold = 0x02,
			HighThreshold = 0x03
		}

		// Configuration register flags
		// Names are prefixed to indicate which logical field they came from.
		[Flags]
		public enum ConfigFlags : byte
		{
			// Operational status (OS)
			OS_Converting = 0x00,
			OS_NotConverting = 0x80,

			// Multiplexer (MUX)
			// Input multiplexer configuration (ADS1115 only)
			// These bits configure the input multiplexer.
			// These bits serve no function on the ADS1113 and ADS1114.
			// ADS1113 and ADS1114 always use inputs AINP = AIN0 and AINN = AIN1.
			MUX_AIN0P_AIN1N = 0x00,
			MUX_AIN0P_AIN3N = 0x10,
			MUX_AIN1P_AIN3N = 0x20,
			MUX_AIN2P_AIN3N = 0x30,
			MUX_AIN0 = 0x40,
			MUX_AIN1 = 0x50,
			MUX_AIN2 = 0x60,
			MUX_AIN3 = 0x70,

			// Programmable gain amplifier (PGA)
			// These bits set the FSR of the programmable gain amplifier.
			// These bits serve no function on the ADS1113.
			// ADS1113 always uses FSR = ±2.048V.
			PGA_FSR_6_144V = 0x00,
			PGA_FSR_4_096V = 0x02,
			PGA_FSR_2_048V = 0x04,
			PGA_FSR_1_024V = 0x06,
			PGA_FSR_0_512V = 0x08,
			PGA_FSR_0_256V = 0x0A,

			// Operating mode
			MODE_Continuous = 0x00,
			MODE_SingleShot = 0x01,

			// Data rate (DR)
			DR_SPS_128 = 0x00,
			DR_SPS_250 = 0x20,
			DR_SPS_490 = 0x40,
			DR_SPS_920 = 0x60,
			DR_SPS_1600 = 0x80,
			DR_SPS_2400 = 0xA0,
			DR_SPS_3300 = 0xC0,

			// Comparator mode
			// This bit configures the comparator operating mode.
			// This bit serves no function on the ADS1113.
			COMP_MODE_Traditional = 0x00,
			COMP_MODE_Window = 0x10,

			// Comparator polarity
			// This bit controls the polarity of the ALERT/RDY pin.
			// This bit serves no function on the ADS1113.
			COMP_POL_Low = 0x00,
			COMP_POL_High = 0x08,

			// Comparator latching
			// This bit controls whether the ALERT/RDY pin latches after being
			// asserted or clears after conversions are within the margin of the
			// upper and lower threshold values.
			// This bit serves no function on the ADS1113.
			// Default is non-latching.
			// Latching means the asserted ALERT/RDY pin remains latched until conversion
			// data are read by the controller or an appropriate SMBus alert
			// response is sent by the controller. The device responds with an
			// address, and is the lowest address currently asserting the ALERT/RDY bus line.
			COMP_LATCH_NonLatching = 0x00,
			COMP_LATCH_Latching = 0x04,

			// Comparator queue
			// These bits perform two functions.
			// When set to 11, the comparator is disabled and the ALERT/RDY pin
			// is set to a high-impedance state.
			// When set to any other value, the ALERT/RDY pin and the comparator
			// function are enabled, and the set value determines the number of
			// successive conversions exceeding the upper or lower threshold
			// required before asserting the ALERT/RDY pin.
			// These bits serve no function on the ADS1113.
			COMP_QUE_One = 0x00,    // assert after one conversion
			COMP_QUE_Two = 0x01,    // assert after two conversions
			COMP_QUE_Four = 0x02,   // assert after four conversions
			COMP_QUE_Disabled = 0x03,   // disable comparator and set ALERT/RDY pin to high state (default)
		}

		[Flags]
		public enum Status
		{
			OK = 0x00,
			Error = 0x01,
			Busy = 0x02,
			Timeout = 0x03,
			NegativeValue = 0x04
		}

		public static byte AddressRegister(params AddressPointer[] pointers)
		{
			byte value = 0;
			foreach (var p in pointers)
			{
				value |= (byte)p;
			}
			return value;
		}

		// Convenience helper to build the register byte from multiple flags without repeated casts.
		public static byte ConfigRegister(params ConfigFlags[] flags)
		{
			byte value = 0;
			foreach (var f in flags)
			{
				value |= (byte)f;
			}
			return value;
		}
	}
}
