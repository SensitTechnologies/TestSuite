using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Exceptions;

namespace UnitTests.Exceptions
{
	[TestClass]
	public class DeviceExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DeviceException' was thrown.";

			// Act
			var exception = new DeviceException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DeviceException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DeviceException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class DevicePortExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DevicePortException' was thrown.";

			// Act
			var exception = new DevicePortException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DevicePortException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DevicePortException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class DeviceCommunicationExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DeviceCommunicationException' was thrown.";

			// Act
			var exception = new DeviceCommunicationException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DevicePortException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DevicePortException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class DeviceSettingNotSupportedExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DeviceSettingNotSupportedException' was thrown.";

			// Act
			var exception = new DeviceSettingNotSupportedException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DeviceSettingNotSupportedException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DeviceSettingNotSupportedException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class DeviceCommandFailedExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DeviceCommandFailedException' was thrown.";

			// Act
			var exception = new DeviceCommandFailedException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DeviceCommandFailedException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DeviceCommandFailedException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class DeviceOutOfRangeExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DeviceOutOfRangeException' was thrown.";

			// Act
			var exception = new DeviceOutOfRangeException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DeviceOutOfRangeException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DeviceOutOfRangeException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class DeviceCalibrationFailedExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.DeviceCalibrationFailedException' was thrown.";

			// Act
			var exception = new DeviceCalibrationFailedException();

			// Assert
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new DeviceCalibrationFailedException(expectedMessage);

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void InnerExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "message";
			var innerException = new Exception("foo");

			// Act.
			var exception = new DeviceCalibrationFailedException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}
}
