using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Calculations;

namespace UnitTests.Calculations
{
	[TestClass]
	public class ChecksumTests
	{
		[TestMethod]
		public void ChecksumTest()
		{
			// Arrange.
			// Data of a mock MODBUS packet (missing the checksum).
			byte[] data = new byte[] { 0x11, 0x03, 0x06, 0xAE, 0x41, 0x56, 0x52, 0x43, 0x40 };

			// Act.
			ushort crc = Checksum.Crc16(data);

			// Assert.
			Assert.AreEqual(0xAD49, crc);
		}
	}
}
