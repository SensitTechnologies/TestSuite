using System.Collections.Generic;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Devices;

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
		// mass flow controller
		MFC _mfc = new MFC();

		// datalogger (for analog sensor DUTs)
		Keysight_34972A _datalogger = new Keysight_34972A();

		public void Open()
		{
			// TODO:  Read system settings.

			// Open all devices.
			//_mfc.Open();
			_datalogger.Open();
		}

		public void Close()
		{
			// Close all devices.
			_mfc.Close();
			_datalogger.Close();
		}

		/// <summary>
		/// Read all reference devices.
		/// </summary>
		/// <returns>collection of all readings, searchable by type</returns>
		public Dictionary<Reference, double> Read()
		{
			// Read all test equipment.
			_mfc.Read();
			//_datalogger.Read();

			// Fetch the readings and return them.
			Dictionary<Reference, double> readings = new Dictionary<Reference, double>
			{
				{ Reference.MassFlow, _mfc.MassFlow }
			};

			return readings;
		}

		public void Print()
		{

		}
	}
}
