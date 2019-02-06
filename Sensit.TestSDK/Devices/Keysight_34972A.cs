using System;
using System.Collections.Generic;
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
		Ag3497x _v3497x;

		private List<double> _readings;

		public int NumberOfDuts { private get; set; }

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
			try
			{
				// Open the device.
				_v3497x = new Ag3497x(resourceName);

				// Confirm identity.
				_v3497x.SCPI.IDN.Query(out string identity);

				// The second word is the model number.
				string[] words = identity.Split(',');

				if (words[1].Equals("34970A") == false && words[1].Equals("34972A") == false)
				{
					throw new DeviceCommunicationException("Unexpected device model number.");
				}

				// Introduce yourself.
				_v3497x.SCPI.DISPlay.TEXT.Command("SENSIT");

				// Configure channels for DC voltage.
				// In order to use the following driver class, you need to reference this assembly : [C:\ProgramData\Keysight\Command Expert\ScpiNetDrivers\Ag3497x_1_13.dll]
				// TODO:  Configure the number of channels based on the NumberOfDuts.
				_v3497x.SCPI.CONFigure.VOLTage.DC.Command("AUTO", "DEF", "(@301,305,309,313,317)");

				// Enable inclusion of channel number on log.
				_v3497x.SCPI.FORMat.READing.CHANnel.Command(true);

				// Enable inclusion of timestamp on log.
				_v3497x.SCPI.FORMat.READing.TIME.Command(true);

				// Set format of timestamp.
				_v3497x.SCPI.FORMat.READing.TIME.TYPE.Command("ABSolute");

				// Set trigger source to software trigger over bus.
				_v3497x.SCPI.TRIGger.SOURce.Command("BUS");

				// Set trigger-to-trigger interval. Currently: 1 second.
				//_v3497x.SCPI.TRIGger.TIMer.Command(1D);

				// Number of sweeps through the scan list before stopping scan. MIN = 1, MAX = 50000, INFinity = infinite.
				_v3497x.SCPI.TRIGger.COUNt.Command("MIN");

				// Sets channels to be included in scan list.
				_v3497x.SCPI.ROUTe.SCAN.Command("@301,305,309,313,317");

			}
			catch (Exception ex)
			{
				throw new DeviceCommunicationException("Could not open datalogger."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void PowerOn(int dut)
		{
			// Nothing to do here.
		}

		public void PowerOff(int dut)
		{
			// Nothing to do here.
		}

		public void Find(int dut)
		{
			// Nothing to do here.
		}

		public void Read()
		{
			// Changes from idle to wait-for-trigger state. 
			// May want to move to "Open". Unsure if state is changed back to idle upon scan completion. 
			_v3497x.SCPI.INITiate.Command();

			// Sends trigger via bus source. 
			_v3497x.SCPI.TRG.Command();

			// Transfers NVM readings to output buffer. 
			_v3497x.SCPI.FETCh.QueryAllData(out string data);

			// TODO:  Parse data into list of readings.  Timestamps can be discarded for now.
			// double.Parse(readings[dut], System.Globalization.NumberStyles.AllowExponent);
		}

		public int ReadCounts(int dut)
		{
			throw new NotImplementedException("Cannot read counts from Keysight datalogger.");
		}

		public double ReadAnalog(int dut)
		{
			// Return the requested reading.
			return _readings[dut];
		}

		public void Close()
		{
			// Clear any text on the display.
			_v3497x?.SCPI.DISPlay.TEXT.CLEar.Command();

			// Disconnect.
			_v3497x?.Disconnect();

			// Prevent memory leaks.
			((IDisposable)_v3497x)?.Dispose();

			_v3497x = null;
		}
	}
}
