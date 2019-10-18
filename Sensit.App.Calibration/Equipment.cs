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
	public class Equipment
	{
		// holds settings for the equipment
		private readonly EquipmentSettings _settings;

		// generic manual device, used whenever the user selects "Manual" option for equipment.
		private Manual _manual;

		// mass flow controller for analyte gas
		private ColeParmerMFC _mfcAnalyte;

		// mass flow controller for diluent gas (needed for gas mixing)
		private ColeParmerMFC _mfcDiluent;

		// both mass flow controllers combined for mixing gas
		private GasMixingDevice _gasMixer;

		// datalogger (for analog sensor DUTs)
		private Keysight_34972A _datalogger;

		// whether or not to configure a datalogger to interface with one or more DUTs.
		private bool _useDatalogger;

		#region Properties

		public Dictionary<VariableType, IControlDevice> Controllers;

		public Dictionary<VariableType, IReferenceDevice> References;

		public IDutInterfaceDevice DutInterface => _datalogger;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor; creates equipment objects.
		/// </summary>
		public Equipment(EquipmentSettings settings)
		{
			_settings = settings;

			// Create test equipment objects.
			// Only the ones chosen by the user will end up being used.
			_mfcAnalyte = new ColeParmerMFC();
			_mfcDiluent = new ColeParmerMFC();
			_gasMixer = new GasMixingDevice(_mfcDiluent, _mfcDiluent, _mfcAnalyte, _mfcAnalyte);
			_datalogger = new Keysight_34972A();
			_manual = new Manual();

			Controllers = new Dictionary<VariableType, IControlDevice>
			{
				{ VariableType.GasConcentration, _gasMixer },
				{ VariableType.MassFlow, _gasMixer }
			};

			References = new Dictionary<VariableType, IReferenceDevice>
			{
				{ VariableType.GasConcentration, _gasMixer },
				{ VariableType.MassFlow, _gasMixer }
			};
		}

		#endregion

		/// <summary>
		/// Initializes all equipment.
		/// </summary>
		public void Open(bool useDatalogger)
		{
			// Remember whether we're using the datalogger or not.
			_useDatalogger = useDatalogger;

			// Configure the mass flow controllers.
			_mfcAnalyte?.Open(_settings.GasMixer.AnalyteMFC.SerialPort);
			_mfcDiluent?.Open(_settings.GasMixer.DiluentMFC.SerialPort);

			// Configure the gas mixer.
			if (_gasMixer != null)
			{
				_gasMixer.AnalyteBottleConcentration = _settings.GasMixer.AnalyteBottleConcentration;
			}

			// Configure the datalogger.
			if ((_useDatalogger == true) && (_datalogger != null))
			{
				_datalogger.Bank = _settings.Datalogger.Bank;
				_datalogger.Open();
			}
		}

		/// <summary>
		/// Update readings from all devices.
		/// </summary>
		public void Read()
		{
			_gasMixer?.Read();

			if (_useDatalogger == true)
			{
				_datalogger?.Read();
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
			_datalogger?.Close();
		}
	}
}
