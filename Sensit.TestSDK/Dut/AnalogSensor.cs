using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;

namespace Sensit.TestSDK.Dut
{
	class AnalogSensor : Dut
	{
		public override bool Selected { get; set; }
		public override DutStatus Status { get; set; }
		public override string Serial { get; set; }
		public override string Message { get; set; }
		public override List<DutCoefficient> Coefficients { get; set; }

		public override void TurnPowerOn()
		{
			// Nothing to do here.
		}

		public override void TurnPowerOff()
		{
			// Nothing to do here.
		}

		public override void ClosePort()
		{
			// Nothing to do here.
		}

		public override void ComputeCoefficients()
		{
			// Nothing to do here.
		}

		public override void FactoryDefault()
		{
			// Nothing to do here.
		}

		public override void Find()
		{
			throw new NotImplementedException();
		}

		public override string GetFirmwareVersion()
		{
			throw new NotImplementedException();
		}

		public override void OpenPort()
		{
			throw new NotImplementedException();
		}

		public override int ReadRawCounts()
		{
			throw new NotImplementedException();
		}

		public override void ReadSerialNumber()
		{
			// Prompt user to enter serial number.
			string serial = Serial;
			DialogResult result = InputDialog.Text("Enter firmware version", ref serial);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not read serial number.");

			// Update the property.
			Serial = serial;
		}

		public override void WriteCoefficients()
		{
			// Nothing to do here.
		}

		public override void WriteSerialNumber()
		{
			// Nothing to do here.
		}
	}
}
