using System;
using System.Collections.Generic;
using Sensit.TestSDK.Calculations;
using Sensit.TestSDK.Exceptions;
using Sensit.TestSDK.Interfaces;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Use two Mass Flow Controllers to mix two gasses.
	/// </summary>
	public class GasMixingDevice : IGasMixReference, IGasMixController, IMassFlowReference
	{
		#region Fields

		// mass flow controllers
		private IMassFlowController _analyteController;
		private IMassFlowController _dilutentController;
		private IMassFlowReference _analyteReference;
		private IMassFlowReference _dilutentReference;

		// total mass flow (of both mass flow controllers combined)
		private double _massFlowSetpoint = 0;

		// desired analyte concentration in mixed gas [%V]; must never exceed analyte bottle concentration
		private double _gasMixSetpoint = 0;

		#endregion

		#region Properties

		public Dictionary<VariableType, double> Readings { get; private set; } = new Dictionary<VariableType, double>
		{
			// percent of analyte in mixed gas (calculated from mass flow controllers' measured flows)
			{ VariableType.GasConcentration, 0.0 },

			// actual total mass flow (summed from both mass flow controllers)
			{ VariableType.MassFlow, 0.0 }
		};

		/// <summary>
		/// Unit of measure for mass flow.
		/// </summary>
		public UnitOfMeasure.Flow FlowUnit { get; set; } = UnitOfMeasure.Flow.CubicFeetPerMinute;

		/// <summary>
		/// Unit of measure for gas concentration.
		/// </summary>
		/// TODO: Use this property to change the unit of the readings.
		public UnitOfMeasure.Concentration ConcentrationUnit { get; set; } = UnitOfMeasure.Concentration.PercentVolume;

		/// <summary>
		/// Analyte gas.
		/// </summary>
		public Gas GasSelection { get; set; } = Gas.Air;
		public bool Enabled { get; set; }

		#endregion

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
		public GasMixingDevice(
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

		public void SetControlMode(ControlMode mode)
		{
			_dilutentController.SetControlMode(mode);
			_analyteController.SetControlMode(mode);
		}

		public void Read()
		{
			// Update references.
			_dilutentReference.Read();
			_analyteReference.Read();

			// Calculate total mass flow.
			Readings[VariableType.MassFlow] = _dilutentReference.Readings[VariableType.MassFlow] + _analyteReference.Readings[VariableType.MassFlow];

			// Calculate analyte concentration.
			if (Readings[VariableType.MassFlow].Equals(0.0))
			{
				Readings[VariableType.GasConcentration] = 0.0;
			}
			else
			{
				Readings[VariableType.GasConcentration] = _analyteReference.Readings[VariableType.MassFlow] / Readings[VariableType.MassFlow];
			}
		}

		public void WriteSetpoint(VariableType type, double setpoint)
		{
			if (type == VariableType.MassFlow)
			{
				// Check for valid value.
				if (setpoint < 0.0)
				{
					throw new DeviceOutOfRangeException("Total Flow Setpoint must be greater than or equal to 0.0.");
				}

				_massFlowSetpoint = setpoint;
			}
			else if (type == VariableType.GasConcentration)
			{
				// Check for valid value.
				if ((setpoint < 0.0) || (setpoint > 100.0))
				{
					throw new DeviceOutOfRangeException("Gas Mix Setpoint must be between 0.0% and 100.0%, inclusive."
						+ Environment.NewLine + "Attempted Gas Mix Setpoint was:  " + setpoint);
				}

				_gasMixSetpoint = setpoint;
			}
			else
			{
				throw new DeviceSettingNotSupportedException("Gas Mixing Device does not support the requested setpoint.");
			}

			// For analyte:  mass Flow = desired flow rate / original concentration.
			_analyteController.WriteSetpoint(VariableType.MassFlow, _massFlowSetpoint * (_gasMixSetpoint / 100));

			// For diluent:  mass flow = desired flow - gas under test flow.
			_dilutentController.WriteSetpoint(VariableType.MassFlow, _massFlowSetpoint - _analyteController.ReadSetpoint(VariableType.MassFlow));
		}

		public double ReadSetpoint(VariableType type)
		{
			// Update setpoints.
			double diluentFlowSetpoint = _dilutentController.ReadSetpoint(VariableType.MassFlow);
			double analyteFlowSetpoint = _analyteController.ReadSetpoint(VariableType.MassFlow);

			_massFlowSetpoint = diluentFlowSetpoint + analyteFlowSetpoint;

			// Avoid divide-by-zero error.
			if (_massFlowSetpoint.Equals(0.0))
			{
				_gasMixSetpoint = 0.0;
			}
			else
			{
				_gasMixSetpoint = _analyteController.ReadSetpoint(VariableType.MassFlow) / _massFlowSetpoint * 100;
			}

			// Return the requested value.
			if (type == VariableType.GasConcentration)
			{
				return _gasMixSetpoint;
			}
			else if (type == VariableType.MassFlow)
			{
				return _massFlowSetpoint;
			}
			else
			{
				throw new DeviceSettingNotSupportedException("Gas Mixing Device does not support requested setpoint.");
			}
		}
	}
}
