using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Dut
{
	/// <summary>
	/// A virtual device under test.  Useful for testing software and test equipment.
	/// </summary>
	class Simulator : IFirmwareBasedDUT, IAnalogDUT
	{
		public int Index { get; set; }

		public string Model { get; set; }

		public string Version { get; set; }

		public bool Selected { get; set; } = false;

		public DutStatus Status { get; set; } = DutStatus.Init;

		public string SerialNumber { get; set; } = "Simulator";

		public string Message { get; set; } = String.Empty;

		public List<DutCoefficient> Coefficients { get; set; }

		public void ReadModel()
		{
			// Pause for effect.
			Thread.Sleep(1000);

			// Dut has been found!
			Status = DutStatus.Found;
		}

		public string ReadVersion()
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			string version = "1.0.0";
			DialogResult result = InputDialog.Text("Enter firmware version", ref version);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not get firmware version.");

			return version;
		}

		public void FactoryDefault()
		{
			// Pause for effect.
			Thread.Sleep(250);
		}

		public string ReadSerialNumber()
		{
			// Prompt user to enter desired number of DUTs (current value as default).
			string serial = SerialNumber;
			DialogResult result = InputDialog.Text("Enter firmware version", ref serial);

			// If user cancels, throw an error.
			if (result != DialogResult.OK)
				throw new Exception("Could not read serial number.");

			// Update the property.
			SerialNumber = serial;

			// Return the value.
			return SerialNumber;
		}

		public void WriteSerialNumber()
		{
			// Pause for effect.
			Thread.Sleep(250);
		}

		public void WriteSerialNumber(string serialNumber)
		{
			SerialNumber = serialNumber;

			WriteSerialNumber();
		}

		public int ReadRawCounts()
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

		public void ComputeCoefficients()
		{
			throw new NotImplementedException();
		}

		public List<DutCoefficient> ReadCoefficients()
		{
			// Pause for effect.
			Thread.Sleep(250);

			return Coefficients;
		}

		public void WriteCoefficients()
		{
			// Pause for effect.
			Thread.Sleep(250);
		}

		public void WriteCoefficients(List<DutCoefficient> coefficients)
		{
			Coefficients = coefficients;

			WriteCoefficients();
		}
	}
}
