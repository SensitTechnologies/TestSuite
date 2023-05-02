using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Exceptions;

namespace UnitTests.Exceptions
{
	[TestClass]
	public class ModbusExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusException' was thrown.";

			// Act.
			var exception = new ModbusException();

			// Assert.
			Assert.IsNull(exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}

		[TestMethod]
		public void MessageTest()
		{
			// Arrange.
			const string expectedMessage = "message";

			// Act.
			var exception = new ModbusException(expectedMessage);
			
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
			var exception = new ModbusException(expectedMessage , innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusTimeoutExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusTimeoutException' was thrown.";

			// Act
			var exception = new ModbusTimeoutException();

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
			var exception = new ModbusTimeoutException(expectedMessage);

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
			var exception = new ModbusTimeoutException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusRequestExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusRequestException' was thrown.";

			// Act
			var exception = new ModbusRequestException();

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
			var exception = new ModbusRequestException(expectedMessage);

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
			var exception = new ModbusRequestException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusResponseExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusResponseException' was thrown.";

			// Act
			var exception = new ModbusResponseException();

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
			var exception = new ModbusResponseException(expectedMessage);

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
			var exception = new ModbusResponseException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusIllegalFunctionExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusIllegalFunctionException' was thrown.";

			// Act
			var exception = new ModbusIllegalFunctionException();

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
			var exception = new ModbusIllegalFunctionException(expectedMessage);

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
			var exception = new ModbusIllegalFunctionException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusIllegalDataAddressExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusIllegalDataAddressException' was thrown.";

			// Act
			var exception = new ModbusIllegalDataAddressException();

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
			var exception = new ModbusIllegalDataAddressException(expectedMessage);

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
			var exception = new ModbusIllegalDataAddressException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusIllegalDataValueExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusIllegalDataValueException' was thrown.";

			// Act
			var exception = new ModbusIllegalDataValueException();

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
			var exception = new ModbusIllegalDataValueException(expectedMessage);

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
			var exception = new ModbusIllegalDataValueException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}

	[TestClass]
	public class ModbusSlaveDeviceFailureExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.ModbusSlaveDeviceFailureException' was thrown.";

			// Act
			var exception = new ModbusSlaveDeviceFailureException();

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
			var exception = new ModbusSlaveDeviceFailureException(expectedMessage);

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
			var exception = new ModbusSlaveDeviceFailureException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}
}
