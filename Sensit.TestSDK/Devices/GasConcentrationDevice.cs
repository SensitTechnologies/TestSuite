using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Use two Mass Flow Controllers to mix two gasses.
	/// </summary>
	public class GasConcentrationDevice : IGasConcentrationReference, IGasMixController, IMassFlowReference
	{
		private IMassFlowController _analyteController;
		private IMassFlowController _dilutentController;
		private IMassFlowReference _analyteReference;
		private IMassFlowReference _dilutentReference;

		private double _analyteBottleConcentration;
		private double _massFlowSetpoint;
		private double _analyteConcentrationSetpoint;

		public UnitOfMeasure.Flow FlowUnit { get; set; } = UnitOfMeasure.Flow.CubicFeetPerMinute;

		public Gas GasSelection { get; set; } = Gas.Air;

		public double MassFlow { get; private set; }

		/// <summary>
		/// Desired total mass flow of mixed gas.
		/// </summary>
		public double MassFlowSetpoint
		{
			get => _massFlowSetpoint;
			set
			{
				// Check for valid value.
				if (value < 0.0)
				{
					throw new DeviceOutOfRangeException("Total Flow Setpoint must be greater than or equal to 0.0.");
				}

				_massFlowSetpoint = value;
			}
		}

		/// <summary>
		/// Concentration of analyte gas cylinder [%V].
		/// </summary>
		public double AnalyteBottleConcentration
		{
			get => _analyteBottleConcentration;
			set
			{
				// Check for valid value.
				if ((value < 0.0) || (value > 100.0))
				{
					throw new DeviceOutOfRangeException("Analyte Bottle Concentration must be between 0.0% and 100.%, inclusive.");
				}

				_analyteBottleConcentration = value;
			}
		}

		/// <summary>
		/// Desired analyte concentration in mixed gas [%V].
		/// </summary>
		public double AnalyteConcentrationSetpoint
		{
			get => _analyteConcentrationSetpoint;
			set
			{
				// Check for valid value.
				if ((value < 0.0) || (value > 100.0))
				{
					throw new DeviceOutOfRangeException("Gas Concentration Setpoint must be between 0.0% and 100.0%, inclusive.");
				}

				_analyteConcentrationSetpoint = value;
			}
		}

		/// <summary>
		/// Actual analyte concentration [%V] in mixed gas (calculated from mass flow controllers' measured flows).
		/// </summary>
		public double AnalyteConcentration { get; private set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// It's quite normal (but not necessary) for the controllers and references to actually be the same device.
		/// </remarks>
		/// <param name="gasUnderTestController">mass flow controller for the gas under test</param>
		/// <param name="dilutentController">mass flow controller for the dilutent gas</param>
		/// <param name="gasUnderTestReference">mass flow reference for the gas under test</param>
		/// <param name="dilutentReference">mass flow reference for the dilutent gas</param>
		public GasConcentrationDevice(
			IMassFlowReference dilutentReference,
			IMassFlowController dilutentController,
			IMassFlowController gasUnderTestController,
			IMassFlowReference gasUnderTestReference)
		{
			_dilutentController = dilutentController;
			_dilutentReference = dilutentReference;
			_analyteController = gasUnderTestController;
			_analyteReference = gasUnderTestReference;
		}

		public void Configure()
		{
			_dilutentReference.Configure();
			_analyteReference.Configure();
		}

		public void SetControlMode(ControlMode mode)
		{
			_dilutentController.SetControlMode(mode);
			_analyteController.SetControlMode(mode);
		}

		public void Read()
		{
			_dilutentReference.Read();
			_analyteReference.Read();

			// Calculate analyte concentration.
			if (_massFlowSetpoint.Equals(0.0))
			{
				AnalyteConcentration = 0.0;
			}
			else
			{
				AnalyteConcentration = _analyteReference.MassFlow / _massFlowSetpoint * _analyteBottleConcentration;
			}
		}

		public double ReadSetpoint()
		{
			double dilutentFlow = _dilutentController.ReadMassFlowSetpoint();
			double analyteFlow = _analyteController.ReadMassFlowSetpoint();

			_massFlowSetpoint = dilutentFlow + analyteFlow;

			// Return the setpoint in case the user wants it.
			return _analyteConcentrationSetpoint;
		}

		public void WriteSetpoint()
		{
			// For analyte:  mass Flow = desired flow rate / original concentration.
			_analyteController.MassFlowSetpoint = _massFlowSetpoint * (_analyteConcentrationSetpoint / _analyteBottleConcentration);

			// For diluent:  mass flow = desired flow - gas under test flow.
			_dilutentController.MassFlowSetpoint = MassFlowSetpoint - _analyteController.MassFlowSetpoint;

			_dilutentController.WriteMassFlowSetpoint();
			_analyteController.WriteMassFlowSetpoint();
		}

		public void WriteSetpoint(double concentration, double massFlow)
		{
			MassFlowSetpoint = massFlow;
			AnalyteConcentrationSetpoint = concentration;

			WriteSetpoint();
		}
	}
}
