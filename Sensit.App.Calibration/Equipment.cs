using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;

namespace Sensit.App.Calibration
{
	public class Equipment
	{
		// system settings
		private readonly EquipmentSettings _settings;

		Manual _manual;

		// mass flow controller for analyte gas
		private ColeParmerMFC _mfcAnalyte;

		// mass flow controller for diluent gas
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

			// TODO:  (Low priority) Create test equipment objects (as specified in settings).
			_mfcAnalyte = new ColeParmerMFC();
			_mfcDiluent = new ColeParmerMFC();
			_gasMixer = new GasConcentrationDevice(_mfcDiluent, _mfcDiluent, _mfcAnalyte, _mfcAnalyte);
			_datalogger = new Keysight_34972A();

			_manual = new Manual();
		}

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
			//_datalogger.Open();
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
