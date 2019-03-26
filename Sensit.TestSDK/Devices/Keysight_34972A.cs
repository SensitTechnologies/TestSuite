using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		public List<double> Readings { get; private set; } = new List<double>();

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

			}
			catch (Exception ex)
			{
				throw new DeviceCommunicationException("Could not open datalogger."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void Configure(int bank, List<bool> channels)
		{
			try
			{
				// Build the channel configuration string.
				// Remember that the channels are 1-indexed.
				StringBuilder sb = new StringBuilder("@");
				for(int i = 0; i < channels.Count; i++)
				{
					if (channels[i])
					{
						if (i != 0)
							sb.Append(',');
						sb.Append(bank.ToString());
						sb.Append((i + 1).ToString("D2"));
					}
				}
				string config = sb.ToString();

				// Configure channels for DC voltage.
				_v3497x.SCPI.CONFigure.VOLTage.DC.Command("AUTO", "DEF", "(" + config + ")");

				// Enable inclusion of channel number on log.
				_v3497x.SCPI.FORMat.READing.CHANnel.Command(true);

				// Set trigger source to software trigger over bus.
				_v3497x.SCPI.TRIGger.SOURce.Command("BUS");

				// Number of sweeps through the scan list before stopping scan.
				// MIN = 1, MAX = 50000, INFinity = infinite.
				_v3497x.SCPI.TRIGger.COUNt.Command("MIN");

				// Sets channels to be included in scan list.
				_v3497x.SCPI.ROUTe.SCAN.Command(config);
			}
			catch (Exception ex)
			{
				throw new DeviceCommunicationException("Could not configure datalogger."
					+ Environment.NewLine + ex.Message);
			}
		}

		public void PowerOn(uint dut)
		{
			// Nothing to do here.
		}

		public void PowerOff(uint dut)
		{
			// Nothing to do here.
		}

		public void Find(uint dut)
		{
			// Nothing to do here.
		}

		public void Read()
		{
			try
			{
				// Changes from idle to wait-for-trigger state.
				// May want to move to "Open". Unsure if state is changed back to idle upon scan completion.
				_v3497x.SCPI.INITiate.Command();

				// Sends trigger via bus source. 
				_v3497x.SCPI.TRG.Command();

				// Transfers NVM readings to output buffer. 
				_v3497x.SCPI.FETCh.QueryAllData(out string data);

				string[] dataSeparated = data.Split(',');

				for (int i = 0; i < dataSeparated.Length; i += 2)
				{
					// Parse sensor output from string into double and add to list of readings.
					//uint key = uint.Parse(dataSeparated[(i + 1)]) % 100;
					double value = double.Parse(dataSeparated[i], System.Globalization.NumberStyles.Any);
					Readings.Add(value);
				}
			}
			catch (Exception ex)
			{
				throw new DeviceCommandFailedException("Could not read from Keysight datalogger."
					+ Environment.NewLine + ex.Message);
			}
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
