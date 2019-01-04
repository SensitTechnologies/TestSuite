using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
	/// Device is not present or not working.
	/// </summary>
	public class DeviceNotFoundException : Exception
	{
		public DeviceNotFoundException() { }
		public DeviceNotFoundException(string message) : base(message) { }
		public DeviceNotFoundException(string message, Exception inner) : base(message, inner) { }
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
	/// Device communication failed.
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
}
