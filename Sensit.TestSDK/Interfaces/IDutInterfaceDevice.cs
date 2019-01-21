namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that controls several devices under test.
	/// </summary>
	public interface IDutInterfaceDevice
	{
		/// <summary>
		/// Apply power to the specified DUT.
		/// </summary>
		/// <param name="dut">device to act upon</param>
		void PowerOn(int dut);

		/// <summary>
		/// Remove power from the specified DUT.
		/// </summary>
		/// <param name="dut">device to act upon</param>
		void PowerOff(int dut);

		/// <summary>
		/// Confirm that a DUT is present.
		/// </summary>
		/// <remarks>
		/// May also do some other useful function, such as clearing a
		/// previously stored calibration or setting a memory write enable.
		/// </remarks>
		/// <param name="dut">the device to act upon</param>
		void Find(int dut);

		/// <summary>
		/// Collect digital output data.
		/// </summary>
		/// <param name="dut">the device to act upon</param>
		/// <returns>the device's reported output value</returns>
		int ReadCounts(int dut);

		/// <summary>
		/// Collect analog output data.
		/// </summary>
		/// <param name="dut"></param>
		/// <returns></returns>
		double ReadAnalog(int dut);
	}
}
