using System.Collections.Generic;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that controls several devices under test.
	/// </summary>
	public interface IDutInterfaceDevice
	{
		/// <summary>
		/// Set active bank and channels.
		/// </summary>
		/// <param name="bank">bank to read the channels from</param>
		/// <param name="channels">channels to configure</param>
		void Configure(int bank, List<bool> channels);

		/// <summary>
		/// Apply power to the specified DUT.
		/// </summary>
		/// <param name="dut">device to act upon</param>
		void PowerOn(uint dut);

		/// <summary>
		/// Remove power from the specified DUT.
		/// </summary>
		/// <param name="dut">device to act upon</param>
		void PowerOff(uint dut);

		/// <summary>
		/// Fetch the device's current readings/settings.
		/// </summary>
		/// <returns>readings from device</returns>
		List<double> Read();

		/// <summary>
		/// Confirm that a DUT is present.
		/// </summary>
		/// <remarks>
		/// May also do some other useful function, such as clearing a
		/// previously stored calibration or setting a memory write enable.
		/// </remarks>
		/// <param name="dut">the device to act upon</param>
		void Find(uint dut);
	}
}
