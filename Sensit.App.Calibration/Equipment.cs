using System;
using System.Collections.Generic;
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
	/// </remarks>
	public class Equipment : IDisposable
	{
		// holds settings for the equipment
		private readonly EquipmentSettings _settings;

		// generic manual device, used whenever the user selects "Manual" option for equipment.
		private Manual _manual;

		// mass flow controller for analyte gas
		private ColeParmerMFC _mfcAnalyte;

		// mass flow controller for diluent gas (needed for gas mixing)
		private ColeParmerMFC _mfcDiluent;

		// power supply
		private GPDX303S _powerSupply;

		#region Properties

		/// <summary>
		/// Whether or not to control a power supply.
		/// </summary>
		public bool UsePowerSupply { get; set; } = false;

		public bool UseMassFlow { get; set; } = false;

		public bool UseGasMixer { get; set; } = false;

		public Dictionary<VariableType, IControlDevice> Controllers { get; }

		public Dictionary<VariableType, IReferenceDevice> References { get; }

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
			_manual = new Manual();
			_powerSupply = new GPDX303S();
		}

		#endregion

		/// <summary>
		/// Initializes all equipment.
		/// </summary>
		public void Open()
		{
			// Configure the mass flow controllers.
			if ((UseGasMixer) && (_mfcAnalyte != null) && (_mfcDiluent != null))
			{
				_mfcAnalyte?.Open(_settings.GasMixer.AnalyteMFC.SerialPort);
				_mfcDiluent?.Open(_settings.GasMixer.DiluentMFC.SerialPort);
			}

			// Configure the power supply.
			if (UsePowerSupply && (_powerSupply != null))
			{
				_powerSupply.Channel = 1;
				_powerSupply.Open(_settings.PowerSupply.SerialPort, _settings.PowerSupply.BaudRate);
			}
		}

		/// <summary>
		/// Update readings from all devices.
		/// </summary>
		public void Read()
		{
			if (UseGasMixer)
			{
				_mfcAnalyte?.Read();
				_mfcDiluent?.Read();
			}

			// TODO:  Update GUI with new values.
		}

		/// <summary>
		/// Close all equipment.
		/// </summary>
		public void Close()
		{
			_mfcAnalyte?.Close();
			_mfcDiluent?.Close();
			_powerSupply?.Close();
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose
		/// </remarks>
		/// <param name="disposing"></param>
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				// Dispose managed resources.
				_mfcAnalyte?.Dispose();
				_mfcDiluent?.Dispose();
				_powerSupply?.Dispose();
			}
		}

		/// <summary>
		/// Dispose of managed resources.
		/// </summary>
		/// <remarks>
		/// See https://docs.microsoft.com/en-us/visualstudio/code-quality/ca1001
		/// </remarks>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}
