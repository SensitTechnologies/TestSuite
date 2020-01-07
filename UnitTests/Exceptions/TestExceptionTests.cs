using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Exceptions;

namespace UnitTests.Exceptions
{
	[TestClass]
	public class TestExceptionTests
	{
		[TestMethod]
		public void ExceptionTest()
		{
			// Arrange.
			const string expectedMessage = "Exception of type 'Sensit.TestSDK.Exceptions.TestException' was thrown.";

			// Act
			var exception = new TestException();

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
			var exception = new TestException(expectedMessage);

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
			var exception = new TestException(expectedMessage, innerException);

			// Assert.
			Assert.AreEqual(innerException, exception.InnerException);
			Assert.AreEqual(expectedMessage, exception.Message);
		}
	}
}
