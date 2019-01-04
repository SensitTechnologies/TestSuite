using System.Collections.Generic;

namespace Sensit.TestSDK.Dut
{
	public class DutCoefficient
	{
		public string label;	// name of the coefficient (i.e. "A1" or "X0")
		public double value;	// the actual coefficient
	}

	public enum DutStatus
	{
		Unknown,
		Found,
		NotFound,
		PortError,
		Fail,
		Pass
	}

	/// <summary>
	/// An abstract class representing a generic Device Under Test (DUT).
	/// </summary>
	public abstract class Dut
	{
		#region Fields

		// true if selected; false otherwise
		protected bool selected;

		// serial number
		protected string serial = string.Empty;

		// firmware version
		protected string firmwareVersion = string.Empty;

		// status (pass, fail, etc.)
		protected DutStatus status = DutStatus.Unknown;

		// a message to be added to the log
		protected string message = string.Empty;

		protected List<DutCoefficient> coefficients;

		#endregion

		#region Properties

		public abstract bool Selected { get; set; }
		public abstract DutStatus Status { get; set; }
		public abstract string Serial { get; set; }
		public abstract string Message { get; set; }
		public abstract List<DutCoefficient> Coefficients { get; set; }

		#endregion

		#region Completed Methods

		#endregion

		#region Abstract Methods

		public abstract void TurnPowerOn();

		public abstract void TurnPowerOff();

		public abstract void OpenPort();

		public abstract void ClosePort();

		public abstract void Find();

		public abstract string GetFirmwareVersion();

		public abstract void FactoryDefault();

		public abstract void ReadSerialNumber();

		public abstract void WriteSerialNumber();

		public abstract int ReadRawCounts();

		public abstract void ComputeCoefficients();

		public abstract void WriteCoefficients();
		
		#endregion
	}
}
