using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;

namespace Sensit.TestSDK.Dut
{
	class Simulator : Dut
	{
		public override bool Selected { get; set; } = false;
		public override DutStatus Status { get; set; } = DutStatus.Unknown;
		public override string Serial { get; set; } = "Simulator";
		public override string Message { get; set; }
		public override List<DutCoefficient> Coefficients { get; set; }

		public override void ClosePort()
		{
			// Nothing to do here.
		}

		public override void ComputeCoefficients()
		{
			throw new NotImplementedException();
		}

		public override void FactoryDefault()
		{
			// Nothing to do here.
		}

		public override void Find()
		{
			// Pause for effect.
			Thread.Sleep(1000);

			// Dut has been found!
			Status = DutStatus.Found;
		}

		public override string GetFirmwareVersion()
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			string version = "1.0.0";
			DialogResult result = InputDialog.Text("Enter firmware version", ref version);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not get firmware version.");

			return version;
		}

		public override void OpenPort()
		{
			// Nothing to do here.
		}

		public override int ReadRawCounts()
		{
			// Return a random 16-bit number.
			//Random random = new Random();
			//return random.Next(65535);

			// Prompt user to enter a value.
			int counts = 0;
			DialogResult result = InputDialog.Numeric("Enter count value", ref counts, 0, 65535);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not read counts.");

			return counts;
		}

		public override void ReadSerialNumber()
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			string serial = Serial;
			DialogResult result = InputDialog.Text("Enter firmware version", ref serial);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not read serial number.");

			// Update the property.
			Serial = serial;
		}

		public override void TurnPowerOff()
		{
			// Nothing to do here.
		}

		public override void TurnPowerOn()
		{
			// Nothing to do here.
		}

		public override void WriteCoefficients()
		{
			// Pause for effect.
			Thread.Sleep(250);
		}

		public override void WriteSerialNumber()
		{
			// Nothing to do here.
		}
	}
}
