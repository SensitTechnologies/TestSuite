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
		/// Fetch the device's current readings/settings.
		/// </summary>
		/// <returns>readings from device</returns>
		List<double> Read();
	}
}
