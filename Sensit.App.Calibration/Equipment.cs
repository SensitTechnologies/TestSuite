using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;

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
		// system settings
		private readonly EquipmentSettings _settings;

		// generic manual device, used whenever the user selects "Manual" option for equipment.
		Manual _manual;

		// mass flow controller for analyte gas
		private ColeParmerMFC _mfcAnalyte;

		// mass flow controller for diluent gas (needed for gas mixing)
		private ColeParmerMFC _mfcDiluent;

		// both mass flow controllers combined for mixing gas
		private GasConcentrationDevice _gasMixer;

		// datalogger (for analog sensor DUTs)
		private Keysight_34972A _datalogger;

		/// <summary>
		/// Constructor; reads settings and creates equipment objects.
		/// </summary>
		public Equipment()
		{
			// Read system settings.
			_settings = Settings.Load<EquipmentSettings>(Properties.Settings.Default.SystemSettingsFile);

			// Create test equipment objects.
			// Only the ones chosen by the user will end up being used.
			_mfcAnalyte = new ColeParmerMFC();
			_mfcDiluent = new ColeParmerMFC();
			_gasMixer = new GasConcentrationDevice(_mfcDiluent, _mfcDiluent, _mfcAnalyte, _mfcAnalyte);
			_datalogger = new Keysight_34972A();
			_manual = new Manual();
		}

		/// <summary>
		///  DUT interface device used to take readings from sensors/products/etc.
		/// </summary>
		public IDutInterfaceDevice DutInterface => _datalogger;

		public IGasConcentrationController GasController => _manual;

		public IGasConcentrationReference GasReference => _manual;

		/// <summary>
		/// Initializes all equipment.
		/// </summary>
		public void Open()
		{
			// Configure the mass flow controllers.
			_mfcAnalyte.Open(_settings?.AnalyteControllerPort);
			_mfcDiluent.Open(_settings?.DiluentControllerPort);

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
