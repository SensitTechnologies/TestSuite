using System.Collections.Generic;

namespace Sensit.TestSDK.Interfaces
{
	/// <summary>
	/// Device that controls several devices under test.
	/// </summary>
	public interface IDatalogger
	{
		///  <summary>
		/// Readings from device.
		/// </summary>
		/// <remarks>
		/// Key is channel number, value is the reading.
		/// </remarks>
		Dictionary<uint, double> Readings { get; }

		/// <summary>
		/// Bank to read the channels from.
		/// </summary>
		int Bank { get; set; }

		/// <summary>
		/// Configured channels of the bank.
		/// </summary>
		List<bool> Channels { get; }

		/// <summary>
		/// Set active bank and channels.
		/// </summary>
		/// <remarks>
		/// Set via properties.
		/// </remarks>
		void Configure();

		/// <summary>
		/// Set active bank and channels.
		/// </summary>
		/// <remarks>
		/// Bank is set via properties.
		/// </remarks>
		/// <param name="channels"></param>
		void Configure(bool[] channels);

		/// <summary>
		/// Set active bank and channels.
		/// </summary>
		/// <remarks>
		/// Updates properties too.
		/// </remarks>
		/// <param name="bank">bank to read the channels from</param>
		/// <param name="channels">channels to configure</param>
		void Configure(int bank, bool[] channels);

		/// <summary>
		/// Fetch the device's current readings/settings.
		/// </summary>
		void Read();
	}
}
