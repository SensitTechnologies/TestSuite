using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sensit.App.Calibration
{
	[Serializable]
	public class SystemSettings
	{
		[Category("Hardware"), Description("Serial Port")]
		public string MassFlowControllerPort { get; set; } = "COM18";
	}
}
