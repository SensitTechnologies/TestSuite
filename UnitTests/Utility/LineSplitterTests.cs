using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sensit.TestSDK.Utilities.Tests
{
	[TestClass]
	public class LineSplitterTests
	{
		[TestMethod]
		public void DetectorTestTwoLinesArrivingTogether()
		{
			// Create a list to hold data packets.
			List<byte[]> result_lines = new();

			// Create a line splitter object.
			LineSplitter lineSplitter = new();

			// When a new data packet is received, add it to the list of data packets.
			lineSplitter.LineReceived += result_lines.Add;

			// Send an array of bytes into the splitter.
			lineSplitter.OnIncomingBinaryBlock(new byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x72, 0x65, 0x61, 0x64, 0x65, 0x72, 0x73, 0x21, 0x0D, 0x0A, 0x53, 0x70, 0x61, 0x72, 0x78, 0x20, 0x69, 0x73, 0x20, 0x74, 0x68, 0x65, 0x20, 0x62, 0x65, 0x73, 0x74, 0x2E, 0x0D, 0x0A });

			// Check that the line splitter correctly found two lines.
			Assert.AreEqual(2, result_lines.Count);
		}
	}
}
