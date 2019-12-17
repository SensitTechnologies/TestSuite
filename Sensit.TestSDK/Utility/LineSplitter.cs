using System;

namespace Sensit.TestSDK.Utilities
{
	/// <summary>
	/// Useful utility methods to help read messages from a serial port that are delimited by a character
	/// (such as a newline or carriage return).
	/// </summary>
	/// <remarks>
	/// https://www.sparxeng.com/blog/software/reading-lines-serial-port
	/// </remarks>
	public class LineSplitter
	{

		public event Action<byte[]> LineReceived;

		public byte Delimiter = (byte)'\n';

		private byte[] leftover;

		public void OnIncomingBinaryBlock(byte[] buffer)
		{
			int offset = 0;
			while (true)
			{
				int newlineIndex = Array.IndexOf(buffer, Delimiter, offset);
				if (newlineIndex < offset)
				{
					leftover = ConcatArray(leftover, buffer, offset, buffer.Length - offset);
					return;
				}

				++newlineIndex;
				byte[] full_line = ConcatArray(leftover, buffer, offset, newlineIndex - offset);
				leftover = null;
				offset = newlineIndex;

				// Raise an event for further processing.
				LineReceived?.Invoke(full_line);
			}
		}

		static byte[] ConcatArray(byte[] head, byte[] tail, int tailOffset, int tailCount)
		{
			byte[] result;
			if (head == null)
			{
				result = new byte[tailCount];
				Array.Copy(tail, tailOffset, result, 0, tailCount);
			}
			else
			{
				result = new byte[head.Length + tailCount];
				head.CopyTo(result, 0);
				Array.Copy(tail, tailOffset, result, head.Length, tailCount);
			}

			return result;
		}
	}
}
