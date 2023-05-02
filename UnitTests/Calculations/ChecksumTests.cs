using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensit.TestSDK.Calculations;

namespace UnitTests.Calculations
{
	[TestClass]
	public class ChecksumTests
	{
		[TestMethod]
		public void Crc16Test()
		{
			// Arrange.
			// Data of a mock MODBUS packet (missing the checksum).
			byte[] data = new byte[] { 0x11, 0x03, 0x06, 0xAE, 0x41, 0x56, 0x52, 0x43, 0x40 };

			// Act.
			ushort crc = Checksum.Crc16(data);

			// Assert.
			Assert.AreEqual(0xAD49, crc);
		}

		[TestMethod]
		public void LrcTest()
		{
			// Arrange.
			// Data of a mock MODBUS ASCII packet (missing the checksum).
			byte[] data = new byte[] { 0x11, 0x03, 0x00, 0x6B, 0x00, 0x03 };

			// Act.
			byte lrc = Checksum.LRC(data);

			// Assert.
			Assert.AreEqual(0x7E, lrc);
		}
	}
}
