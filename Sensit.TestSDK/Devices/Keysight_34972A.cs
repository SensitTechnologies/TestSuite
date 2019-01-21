using System;
using System.Linq;
using Agilent.CommandExpert.ScpiNet.Ag3497x_1_13;
using Sensit.TestSDK.Communication;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Communication driver for a Keysight 34970A/34972A.
	/// </summary>
	/// <remarks>
	/// Product Website:
	/// https://www.keysight.com/en/pd-1756491-pn-34972A/lxi-data-acquisition-data-logger-switch-unit
	/// This is a three-slot mainframe with a built-in 6.5 digit multimeter.  Choose from eight
	/// optional plug-in modules to create a compact data logger, full-featured data acquisition
	/// system or low-cost switching unit.
	/// </remarks>
	public class Keysight_34972A : IDutInterfaceDevice
	{
		Ag3497x _v34972A;

		public void Open()
		{
			// The device uses a USB VISA interface, so look for devices with that pattern.
			string[] resourceStrings = VisaDevice.Find(VisaPattern.USB).ToArray();

			try
			{
				// Open a connection to the desired instrument.
				Open(resourceStrings[0]);
			}
			catch (IndexOutOfRangeException ex)
			{
				throw new DeviceCommunicationException("Device was not found."
					+ Environment.NewLine + "Details:"
					+ Environment.NewLine + ex.Message);
			}
		}

		public void Open(string resourceName)
		{
			// Open the device.
			_v34972A = new Ag3497x(resourceName);

			// Confirm identity.
			_v34972A.SCPI.IDN.Query(out string identity);

			// The second word is the model number.
			string[] words = identity.Split(',');

			if (words[1].Equals("34972A") == false)
			{
				throw new DeviceCommunicationException("Unexpected device model number.");
			}

			// Introduce yourself.
			_v34972A.SCPI.DISPlay.TEXT.Command("SENSIT");
		}

		public void PowerOn(int dut)
		{
			throw new NotImplementedException();
		}

		public void PowerOff(int dut)
		{
			throw new NotImplementedException();
		}

		public void Find(int dut)
		{
			throw new NotImplementedException();
		}

		public int ReadCounts(int dut)
		{
			throw new NotImplementedException();
		}

		public double ReadAnalog(int dut)
		{
			throw new NotImplementedException();
		}

		public void Close()
		{
			// Clear any text on the display.
			_v34972A.SCPI.DISPlay.TEXT.CLEar.Command();

			// Disconnect.
			_v34972A?.Disconnect();

			// Prevent memory leaks.
			((IDisposable)_v34972A)?.Dispose();

			_v34972A = null;
		}
	}
}
