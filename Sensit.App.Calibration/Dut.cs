using System.Collections.Generic;
using Sensit.TestSDK.Dut;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Manage devices under test.
	/// </summary>
	/// <remarks>
	/// Similarly to the Equipment class, we have the ability to create any type
	/// of DUT, and then we pass the selected type to the user for each needed
	/// interface.
	/// </remarks>
	public class Dut : IDeviceUnderTest
	{
		// used when the user selects "Simulator" option for DUTs.
		private Simulator _simulator;

		// analog sensor device
		private AnalogSensor _analogSensor;

		#region Properties

		/// <summary>
		/// Device Under Test settings
		/// </summary>
		public ModelSetting Settings { private get; set; }

		public IDeviceUnderTest Device => _analogSensor;

		public int Index
		{
			get => _analogSensor.Index;
			set => _analogSensor.Index = value;
		}

		public bool Selected
		{
			get => _analogSensor.Selected;
			set => _analogSensor.Selected = value;
		}

		public DutStatus Status
		{
			get => _analogSensor.Status;
			set => _analogSensor.Status = value;
		}

		public string SerialNumber
		{
			get => _analogSensor.SerialNumber;
			set => _analogSensor.SerialNumber = value;
		}

		public string Message
		{
			get => _analogSensor.Message;
			set => _analogSensor.Message = value;
		}

		public List<DutCoefficient> Coefficients
		{
			get => _analogSensor.Coefficients;
			set => _analogSensor.Coefficients = value;
		}

		#endregion

		#region Constructor

		public Dut()
		{
			// Create lists of DUTs.
			// Only the one chosen by the user will end up being used.
			// TODO:  (Medium priority) Choose type of DUT based on settings.
			//_simulator = new Simulator();
			_analogSensor = new AnalogSensor();
		}

		public void ComputeCoefficients()
		{
			_analogSensor.ComputeCoefficients();
		}

		#endregion
	}
}
