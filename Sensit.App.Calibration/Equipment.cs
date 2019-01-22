using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Settings;

namespace Sensit.App.Calibration
{
	public class Equipment
	{
		private readonly EquipmentSettings _settings;	// system settings
		private MFC _mfc;								// mass flow controller
		private Keysight_34972A _datalogger;			// datalogger (for analog sensor DUTs)

		public Equipment()
		{
			// Read system settings.
			_settings = Settings.Load<EquipmentSettings>(Properties.Settings.Default.SystemSettingsFile);

			// Create test equipment objects.
			// TODO:  Do this according to settings, (i.e. use manual if selected).
			_mfc = new MFC();
			_datalogger = new Keysight_34972A();
		}

		public IDutInterfaceDevice DutInterface => _datalogger;

		public IMassFlowController MassFlowController => _mfc;

		public IMassFlowReference MassFlowReference => _mfc;

		public void Open()
		{
			// Open all devices.
			_mfc.Open(_settings?.MassFlowControllerPort);
			_datalogger.Open();
		}

		public void Close()
		{
			// Close all devices.
			_mfc?.Close();
			_datalogger?.Close();
		}
	}
}
