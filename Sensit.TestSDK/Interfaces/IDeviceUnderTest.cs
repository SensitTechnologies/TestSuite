using System.Collections.Generic;

namespace Sensit.TestSDK.Interfaces
{
	public struct DutCoefficient
	{
		/// <summary>
		/// name of the coefficient
		/// </summary>
		public string Label;

		/// <summary>
		/// the actual coefficient
		/// </summary>
		public double Value;
	}

	public enum DutStatus
	{
		Init,
		Found,
		NotFound,
		PortError,
		Fail,
		Pass
	}

	/// <summary>
	/// Device Under Test (DUT).
	/// </summary>
	/// /// <remarks>
	/// Don't implement this interface directly.
	/// Devices should implement one of the more specific interfaces below.
	/// </remarks>
	public interface IDeviceUnderTest
	{
		/// <summary>
		/// DUT's fixture position or channel
		/// </summary>
		int Index { get; set; }

		/// <summary>
		/// true if under test; false if idle
		/// </summary>
		bool Selected { get; set; }

		/// <summary>
		/// DUT status (pass, fail, etc.)
		/// </summary>
		DutStatus Status { get; set; }

		/// <summary>
		/// DUT's unique identification number
		/// </summary>
		string SerialNumber { get; set; }

		/// <summary>
		/// A message to be added to the log
		/// </summary>
		string Message { get; set; }

		/// <summary>
		/// DUT's Calibration coefficients
		/// </summary>
		List<DutCoefficient> Coefficients { get; set; }

		/// <summary>
		/// Compute sensor coefficient(s) to linearize device.
		/// </summary>
		void ComputeCoefficients();
	}

	/// <summary>
	/// DUT that has firmware and can communicate with test equipment on its own.
	/// </summary>
	public interface IFirmwareBasedDUT : IDeviceUnderTest
	{
		/// <summary>
		/// Firmware or Sensor Series/Model ID
		/// </summary>
		/// <remarks>
		/// Firmware devices do not likely support setting model ID.
		/// </remarks>
		string Model { get; }

		/// <summary>
		/// Firmware or Sensor Version
		/// </summary>
		/// <remarks>
		/// Firmware devices do not likely support setting version.
		/// </remarks>
		string Version { get; }

		/// <summary>
		/// Read firmware/sensor identification from device.
		/// </summary>
		void ReadModel();

		/// <summary>
		/// Read firmware version from device.
		/// </summary>
		/// <remarks>
		/// For convenience, this method updates the property and returns the value.
		/// </remarks>
		/// <returns>firmware version</returns>
		string ReadVersion();

		/// <summary>
		/// Write factory default settings to device.
		/// </summary>
		void FactoryDefault();

		/// <summary>
		/// Read serial number from device.
		/// </summary>
		/// <remarks>
		/// For convenience, this method updates the property and returns the value.
		/// </remarks>
		/// <returns>serial number</returns>
		string ReadSerialNumber();

		/// <summary>
		/// Write serial number to device.
		/// </summary>
		void WriteSerialNumber();

		/// <summary>
		/// Write serial number to device.
		/// </summary>
		/// <remarks>
		/// For convenience, this method sets the property and writes it to the device.
		/// So we can write one line of code instead of two.
		/// </remarks>
		/// <param name="serialNumber">serial number</param>
		void WriteSerialNumber(string serialNumber);

		/// <summary>
		/// Read sensor coefficient(s) from device.
		/// </summary>
		/// For convenience, this method updates the property and returns the list.
		/// <returns>list of coefficient structures</returns>
		List<DutCoefficient> ReadCoefficients();

		/// <summary>
		/// Write sensor coefficients to device.
		/// </summary>
		void WriteCoefficients();

		/// <summary>
		/// Write coefficients to device.
		/// </summary>
		/// <remarks>
		/// For convenience, this method sets the property and writes it to the device.
		/// So we can write one line of code instead of two.
		/// </remarks>
		/// <param name=""></param>
		void WriteCoefficients(List<DutCoefficient> coefficients);
	}

	/// <summary>
	///  DUT that relies on a support device to communicate.
	/// </summary>
	public interface IAnalogDUT : IDeviceUnderTest
	{
		/// <summary>
		/// Firmware or Sensor Series/Model ID
		/// </summary>
		string Model { get; set; }

		/// <summary>
		/// Firmware or Sensor Version
		/// </summary>
		string Version { get; set; }
	}
}
