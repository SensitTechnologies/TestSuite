using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;

namespace Sensit.App.Calibration
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// Create an object to represent calibration equipment and instrumentation.
			System system = new System();

			// Create an object to represent the tests being run.
			Test test = new Test();

			// Run the application.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new FormCalibration
			{
				// Link the test and support devices to form actions.
				Start = test.Start,
				Stop = test.Stop,
				Print = system.Print,
				Running = test.IsRunning
			});
		}
	}
}
