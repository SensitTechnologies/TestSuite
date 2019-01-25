using System;
using Sensit.TestSDK.Interfaces;
using Sensit.TestSDK.Exceptions;

namespace Sensit.TestSDK.Devices
{
	/// <summary>
	/// Use two Mass Flow Controllers to mix two gasses.
	/// </summary>
	public class GasConcentrationDevice : IGasConcentrationReference, IGasConcentrationController
	{
		private IMassFlowController _gasUnderTestController;
		private IMassFlowController _dilutentController;
		private IMassFlowReference _gasUnderTestReference;
		private IMassFlowReference _dilutentReference;

		public double Concentration => _gasUnderTestReference.MassFlow / MassFlowSetpoint * GasBottleConcentration * 100.0;

		public double GasBottleConcentration { get; set; }

		public double MassFlowSetpoint { get; set; }

		public double GasConcentrationSetpoint
		{
			// This equation results from solving the setter's equation "for gas under test" for value.
			get => _gasUnderTestController.MassFlowSetpoint / MassFlowSetpoint * GasBottleConcentration * 100.0;
			set
			{
				// Check for valid value.
				if ((value < 0.0) || (value > 100.0))
				{
					throw new DeviceOutOfRangeException("Gas Concentration Setpoint must be between 0.0 and 100.0 %."
						+ Environment.NewLine + "Value was:  " + value.ToString());
				}

				// For gas under test:  mass Flow = desired flow rate / original concentration.
				_gasUnderTestController.MassFlowSetpoint = MassFlowSetpoint * (value / 100 / GasBottleConcentration);

				// For dilutent:  mass flow = desired flow - gas under test flow.
				_dilutentController.MassFlowSetpoint = MassFlowSetpoint - _gasUnderTestController.MassFlowSetpoint;
			}
		}

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
			_gasUnderTestController = gasUnderTestController;
			_gasUnderTestReference = gasUnderTestReference;
		}

		public void Configure()
		{
			_dilutentReference.Configure();
			_gasUnderTestReference.Configure();
		}

		public void Read()
		{
			_dilutentReference.Read();
			_gasUnderTestReference.Read();
		}

		public double ReadGasConcentationSetpoint()
		{
			// Read the mass flows of each gas.
			_gasUnderTestController.ReadMassFlowSetpoint();
			_dilutentController.ReadMassFlowSetpoint();

			return GasConcentrationSetpoint;
		}

		public void SetControlMode(ControlMode mode)
		{
			_dilutentController.SetControlMode(mode);
			_gasUnderTestController.SetControlMode(mode);
		}

		public void WriteGasConcentrationSetpoint()
		{
			_dilutentController.WriteMassFlowSetpoint();
			_gasUnderTestController.WriteMassFlowSetpoint();
		}

		public void WriteGasConcentrationSetpoint(double setpoint)
		{
			GasConcentrationSetpoint = setpoint;

			WriteGasConcentrationSetpoint();
		}

		public void WriteMassFlowSetpoint()
		{
			_dilutentController.WriteMassFlowSetpoint();
			_gasUnderTestController.WriteMassFlowSetpoint();
		}

		public void WriteMassFlowSetpoint(double setpoint)
		{
			MassFlowSetpoint = setpoint;

			WriteMassFlowSetpoint();
		}

		public double ReadMassFlowSetpoint()
		{
			_dilutentController.ReadMassFlowSetpoint();
			_gasUnderTestController.ReadMassFlowSetpoint();

			// Return the setpoint in case the user wants it.
			return MassFlowSetpoint;
		}
	}
}
