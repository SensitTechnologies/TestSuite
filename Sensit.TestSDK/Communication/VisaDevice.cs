using System;
using System.Collections.Generic;
using System.Linq;
using Ivi.Visa;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Communication
{
	public static class VisaPattern
	{
		// common search patterns
		public const string ASRL = "ASRL?*";
		public const string GPIB = "GPIB?*";
		public const string GPIB_VXI = "GPIB-VXI?*";
		public const string TCPIP = "TCPIP?*";
		public const string VXI = "VXI?*";
		public const string USB = "USB?*";
	}

	/// <summary>
	/// Virtual Instrument Software Architecture (VISA)
	/// </summary>
	public abstract class VisaDevice
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Declaring an internal constructor means this class can only be extended
		/// within the SDK.
		/// https://stackoverflow.com/questions/61551474/why-are-internal-fields-preferable-to-protected-fields-in-an-abstract-class
		/// </remarks>
		internal VisaDevice() { }

		// IVI VISA object used to communicate with the device
		private IMessageBasedFormattedIO _instrument;

		/// <summary>
		/// Search for a device matching a specific pattern.
		/// </summary>
		/// <remarks>
		/// Several common patterns are included in this class.
		/// You can use this method to narrow your search, then use Open()
		/// with the same pattern to open an instrument.
		/// </remarks>
		/// <param name="pattern">string to match in resource names</param>
		/// <returns>list of resource names that include pattern</returns>
		public static IEnumerable<string> Find(string pattern = VisaPattern.USB)
		{
			IEnumerable<string> resourceNames;

			try
			{
				resourceNames = GlobalResourceManager.Find(pattern).ToList();
			}
			catch (EntryPointNotFoundException ex)
			{
				throw new DevicePortException("The IVI.VISA dll appears to be missing."
					+ Environment.NewLine +  "It must be installed as a separate package."
					+ Environment.NewLine + "Details:"
					+ Environment.NewLine + ex.Message);
			}

			return resourceNames;
		}

		/// <summary>
		/// Search for and then open a device.
		/// </summary>
		/// <remarks>
		/// By default, the first USB device found is opened.
		/// </remarks>
		/// <param name="pattern">string to match in resource names</param>
		/// <param name="index">which of the instruments matching the pattern to open</param>
		public void Open(string pattern = VisaPattern.USB, int index = 0)
		{
			try
			{
				// Find all available instruments.
				string[] resourceStrings = Find(pattern).ToArray();

				// Open a connection to the desired instrument.
				_instrument = GlobalResourceManager.Open(resourceStrings[index]) as IMessageBasedFormattedIO;
			}
			catch (EntryPointNotFoundException ex)
			{
				throw new DevicePortException("The IVI.VISA dll appears to be missing."
					+ Environment.NewLine +	"It must be installed as a separate package."
					+ Environment.NewLine +	"Details:"
					+ Environment.NewLine + ex.Message);
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new DeviceCommunicationException("Device was not found."
					+ Environment.NewLine + "Details:"
					+ Environment.NewLine + ex.Message);
			}
		}

		/// <summary>
		/// Write a message and return the response.
		/// </summary>
		/// <param name="message">message to send</param>
		/// <returns>message received</returns>
		public string Write(string message)
		{
			// Send the query to the instrument.
			_instrument?.WriteLine(message);

			// Read back the response.
			return _instrument?.ReadString();
		}

		/// <summary>
		/// Dispose of the device connection.
		/// </summary>
		public void Close()
		{
			// Dispose of the instrument connection if it is not null.
			((IDisposable)_instrument)?.Dispose();

			// Free the reference to the session.
			_instrument = null;
		}
	}
}
