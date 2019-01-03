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
			// Auto-generated code.
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			
			// Create an object to represent test equipment.
			System system = new System();

			// Create an object to represent the tests being run.
			Test test = new Test();

			// Create a GUI for user interaction.
			FormCalibration formCalibration = new FormCalibration();

			// Link test actions that update the GUI.
			test.UpdateStatus = formCalibration.UpdateStatus;
			
			// Link the test and support devices to form actions.
			formCalibration.Start = test.Start;
			formCalibration.Stop = test.Stop;
			formCalibration.Print = system.Print;
			formCalibration.Running = test.IsRunning;

			// Run the GUI.
			Application.Run(formCalibration);
		}
	}
}
