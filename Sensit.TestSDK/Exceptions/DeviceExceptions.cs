using System;

/// <summary>
/// Custom exceptions for device communication.
/// </summary>
/// <remarks>
/// See this document for information on how to define user-defined exceptions:
/// https://docs.microsoft.com/en-us/dotnet/standard/exceptions/how-to-create-user-defined-exceptions
/// Used as an example of how to code unit tests for custom exceptions:
/// Perhaps someday the recommendations on serialization will also be applicable.
/// https://docs.microsoft.com/en-us/archive/blogs/agileer/the-correct-way-to-code-a-custom-exception-class
/// </remarks>
namespace Sensit.TestSDK.Exceptions
{
	/// <summary>
	/// Custom class of exceptions for devices
	/// </summary>
	/// <remarks>
	/// Don't throw this exception; best practice is to throw one of the derived classes below.
	/// Catch this exception in application-level code so your application handles all device errors.
	/// </remarks>
	public class DeviceException : Exception
	{
		public DeviceException() { }
		public DeviceException(string message) : base(message) { }
		public DeviceException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device dependency is not present or not working.
	/// </summary>
	/// <remarks>
	/// This exception indicates problems such as COM port failure or DLL missing.
	/// </remarks>
	public class DevicePortException : DeviceException
	{
		public DevicePortException() { }
		public DevicePortException(string message) : base(message) { }
		public DevicePortException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device is not present or not working.
	/// </summary>
	public class DeviceCommunicationException : DeviceException
	{
		public DeviceCommunicationException() { }
		public DeviceCommunicationException(string message) : base(message) { }
		public DeviceCommunicationException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device does not support a requested setting.
	/// </summary>
	public class DeviceSettingNotSupportedException : DeviceException
	{
		public DeviceSettingNotSupportedException() { }
		public DeviceSettingNotSupportedException(string message) : base(message) { }
		public DeviceSettingNotSupportedException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device failed to execute the command.
	/// </summary>
	public class DeviceCommandFailedException : DeviceException
	{
		public DeviceCommandFailedException() { }
		public DeviceCommandFailedException(string message) : base(message) { }
		public DeviceCommandFailedException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device is out of measurement range.
	/// </summary>
	public class DeviceOutOfRangeException : DeviceException
	{
		public DeviceOutOfRangeException() { }
		public DeviceOutOfRangeException(string message) : base(message) { }
		public DeviceOutOfRangeException(string message, Exception inner) : base(message, inner) { }
	}

	/// <summary>
	/// Device data could not be linearized.
	/// </summary>
	public class DeviceCalibrationFailedException : DeviceException
	{
		public DeviceCalibrationFailedException() { }
		public DeviceCalibrationFailedException(string message) : base(message) { }
		public DeviceCalibrationFailedException(string message, Exception inner) : base(message, inner) { }
	}
}
