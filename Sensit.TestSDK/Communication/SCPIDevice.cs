namespace Sensit.TestSDK.Communication
{
	public interface ISCPICommand
	{
		/// <summary>
		/// Returns the command string.
		/// </summary>
		/// <returns></returns>
		string Command();
	}

	public interface ISCPIQuery
	{
		/// <summary>
		/// Returns the query string.
		/// </summary>
		/// <returns></returns>
		string Query();
	}

	public abstract class SCPIDevice : ISCPIQuery, ISCPICommand
	{
		/// <summary>
		/// Constructor
		/// </summary>
		/// <remarks>
		/// Declaring an internal constructor keeps this class from being
		/// inherited outside the SDK.
		/// </remarks>
		internal SCPIDevice() { }

		// String that will be the output of the class.
		// Start with an empty string.
		private protected string _command = string.Empty;

		public string Command()
		{
			return _command;
		}

		public string Query()
		{
			return _command += "?";
		}
	}
}
