using System.Collections.Generic;
using Sensit.TestSDK.Devices;
using Sensit.TestSDK.Settings;

namespace Sensit.App.Calibration
{
	/// <summary>
	/// Possible reference devices in our test system.
	/// </summary>
	public enum Reference
	{
		MassFlow,
		VolumeFlow,
		Velocity,
		Pressure,
		Temperature
	}

	/// <summary>
	/// Possible control devices in our test system.
	/// </summary>
	public enum Controller
	{
		MassFlow,
		VolumeFlow,
		Velocity,
		Pressure,
		Temperature
	}

	public class System
	{
		// file where system settings are stored
		private const string SYSTEM_SETTINGS_FILE = "System Settings";

		// system settings
		SystemSettings settings = default(SystemSettings);

		// mass flow controller
		MFC _mfc = new MFC();

		// datalogger (for analog sensor DUTs)
		//Keysight_34972A _datalogger = new Keysight_34972A();

		public void ReadSettings()
		{
			// Read system settings.
			settings = SettingsMethods.LoadSettings<SystemSettings>(SYSTEM_SETTINGS_FILE);
		}

		public void Open()
		{
			// Open all devices.
			_mfc.Open(settings?.MassFlowControllerPort);
			//_datalogger.Open();
		}

		public void Close()
		{
			// Close all devices.
			_mfc.Close();
			//_datalogger.Close();
		}

		/// <summary>
		/// Read all reference devices.
		/// </summary>
		/// <returns>collection of all readings, searchable by type</returns>
		public Dictionary<Reference, double> Read()
		{
			// Read all test equipment.
			//_mfc.Read();

			// TODO:  Read datalogger if selected.
			
			//_datalogger.Read();

			// Fetch the readings and return them.
			Dictionary<Reference, double> readings = new Dictionary<Reference, double>
			{
				//{ Reference.MassFlow, _mfc.MassFlow }
			};

			return readings;
		}

		public void Print()
		{

		}
	}
}
