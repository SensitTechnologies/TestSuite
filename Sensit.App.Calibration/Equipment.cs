using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Manage devices used to collect data during tests.
	/// </summary>
	/// <remarks>
	/// We have one of each possible type of device.  Depending on the user's
	/// selections, we choose which device(s) to use and pass to the user for
	/// each needed interface.
	/// 
	/// DUT interface devices are a different sort of beast that may make more
	/// sense to manage elsewhere, but they're here for now.
	/// </remarks>
	public class Equipment
	{
		// generic manual device, used whenever the user selects "Manual" option for equipment.
		private Manual _manual;

		// mass flow controller for analyte gas
		private ColeParmerMFC _mfcAnalyte;

		// mass flow controller for diluent gas (needed for gas mixing)
		private ColeParmerMFC _mfcDiluent;

		// both mass flow controllers combined for mixing gas
		private GasConcentrationDevice _gasMixer;

		// datalogger (for analog sensor DUTs)
		private Keysight_34972A _datalogger;

		#region Properties

		/// <summary>
		/// Equipment settings
		/// </summary>
		public EquipmentSettings Settings { private get; set; }

		/// <summary>
		///  DUT interface device used to take readings from sensors/products/etc.
		/// </summary>
		public IDutInterfaceDevice DutInterface => _datalogger;

		/// <summary>
		/// Gas Concentration Controller used to mix gasses.
		/// </summary>
		public IGasConcentrationController GasController => _manual;

		/// <summary>
		/// Gas Concentration Reference used to determine gas composition.
		/// </summary>
		public IGasConcentrationReference GasReference => _manual;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor; creates equipment objects.
		/// </summary>
		public Equipment()
		{
			// Create test equipment objects.
			// Only the ones chosen by the user will end up being used.
			_mfcAnalyte = new ColeParmerMFC();
			_mfcDiluent = new ColeParmerMFC();
			_gasMixer = new GasConcentrationDevice(_mfcDiluent, _mfcDiluent, _mfcAnalyte, _mfcAnalyte);
			_datalogger = new Keysight_34972A();
			_manual = new Manual();
		}

		#endregion

		/// <summary>
		/// Initializes all equipment.
		/// </summary>
		public void Open()
		{
			// Configure the mass flow controllers.
			_mfcAnalyte.Open(Settings?.AnalyteControllerPort);
			_mfcDiluent.Open(Settings?.DiluentControllerPort);

			// Configure the datalogger.
			_datalogger.Open();
		}

		/// <summary>
		/// Close all equipment.
		/// </summary>
		public void Close()
		{
			// Close all devices.
			_mfcAnalyte?.Close();
			_mfcDiluent?.Close();
			_datalogger?.Close();
		}
	}
}
