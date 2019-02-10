using Sensit.TestSDK.Dut;
using Sensit.TestSDK.Interfaces;
using CsvHelper;
using System.IO;
using System.Collections.Generic;

namespace Sensit.App.Calibration
{
	public class TestResults
	{
		public double? Setpoint { get; set; }
		public double? Reference { get; set; }
		public double? SensorValue { get; set; }
		//public double Error { get; set; }
	}

	/// <summary>
	/// Manage devices under test.
	/// </summary>
	/// <remarks>
	/// Similarly to the Equipment class, we have the ability to create any type
	/// of DUT, and then we pass the selected type to the user for each needed
	/// interface.
	/// </remarks>
	public class Dut
	{
		// used when the user selects "Simulator" option for DUTs.
		private Simulator _simulator;

		// analog sensor device
		private AnalogSensor _analogSensor;

		#region Properties

		public List<TestResults> Results { get; set; } = new List<TestResults>();

		/// <summary>
		/// Device Under Test settings
		/// </summary>
		public ModelSetting Settings { private get; set; }

		public IDutInterfaceDevice InterfaceDevice { private get; set; }

		// TODO:  Select type of device based on settings passed into this class.
		public IDeviceUnderTest Device => _analogSensor;

		#endregion

		#region Constructor

		public Dut()
		{
			// Create DUT object.
			// Only the one chosen by the user will end up being used.
			// TODO:  (Medium priority) Choose type of DUT based on settings.
			//_simulator = new Simulator();
			_analogSensor = new AnalogSensor();
		}

		public void Open()
		{
			if (Device.Selected == true)
			{
				InterfaceDevice?.PowerOn(Device.Index);

				// TODO:  (Low priority) Open DUT ports (if applicable); throw exception is no DUT ports could be opened.
				// TODO:  (Low priority) Talk to each DUT to verify communication.
				// If communication succeeds, set status to "Found".
				Device.Status = DutStatus.Found;
			}
		}

		public void Close()
		{
			// Turn off DUTs that have been found, passed, failed.
			if ((Device.Status != DutStatus.PortError) &&
				(Device.Status != DutStatus.NotFound))
			{
				InterfaceDevice?.PowerOff(Device.Index);
			}

			if ((Device.Status == DutStatus.Found) ||
				(Device.Status == DutStatus.Fail) ||
				(Device.Status == DutStatus.NotFound))
			{
				// TODO:  (Low priority) Close DUT ports (if applicable).
			}

			// TODO:  Identify passing DUTs.

			// Save test results to csv file.
			using (var writer = new StreamWriter("results.csv"))
			using (var csv = new CsvWriter(writer))
			{
				csv.WriteRecords(Results);
			}
		}

		public double? Read()
		{
			return InterfaceDevice?.ReadAnalog(Device.Index);
		}

		public void ComputeCoefficients()
		{
			_analogSensor.ComputeCoefficients();
		}

		#endregion
	}
}
