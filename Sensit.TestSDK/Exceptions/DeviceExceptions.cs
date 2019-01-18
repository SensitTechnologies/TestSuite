using System;

/// <summary>
/// Custom exceptions for the SDK.
/// </summary>
/// <remarks>
/// See this document for information on how to define user-defined exceptions:
/// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
/// </remarks>
namespace Sensit.TestSDK.Exceptions
{
	/// <summary>
	/// Device dependency is not present or not working.
	/// </summary>
	/// <remarks>
	/// This exception indicates problems such as COM port failure or DLL missing.
	/// </remarks>
	public class DevicePortException : Exception
	{
		public DevicePortException() { }
		public DevicePortException(string message) : base(message) { }
		public DevicePortException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device is not present or not working.
	/// </summary>
	public class DeviceCommunicationException : Exception
	{
		public DeviceCommunicationException() { }
		public DeviceCommunicationException(string message) : base(message) { }
		public DeviceCommunicationException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device does not support a requested setting.
	/// </summary>
	public class DeviceSettingNotSupportedException : Exception
	{
		public DeviceSettingNotSupportedException() { }
		public DeviceSettingNotSupportedException(string message) : base(message) { }
		public DeviceSettingNotSupportedException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device failed to execute the command.
	/// </summary>
	public class DeviceCommandFailedException : Exception
	{
		public DeviceCommandFailedException() { }
		public DeviceCommandFailedException(string message) : base(message) { }
		public DeviceCommandFailedException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device is out of measurement range.
	/// </summary>
	public class DeviceOutOfRangeException : Exception
	{
		public DeviceOutOfRangeException() { }
		public DeviceOutOfRangeException(string message) : base(message) { }
		public DeviceOutOfRangeException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device data could not be linearized.
	/// </summary>
	public class DeviceCalibrationFailedException : Exception
	{
		public DeviceCalibrationFailedException() { }
		public DeviceCalibrationFailedException(string message) : base(message) { }
		public DeviceCalibrationFailedException(string message, Exception inner) : base(message, inner) { }
	}
}
