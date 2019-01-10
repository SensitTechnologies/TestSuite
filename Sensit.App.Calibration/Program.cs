using System;
using System.Collections;
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

			formCalibration.ModelList = new ArrayList(new string[] { "Simulator", "Analog Sensor" });

			// TODO:  Tell formCalibration class and Test class what variables to use.
			// TODO:  Tell formCalibration and test objects what equipment is needed.
			// TODO:  Display tab for DUT.  Maybe show Excel in a web browser?
			// TODO:  Code DAQ library.

			// Set test actions.
			test.Update = formCalibration.TestUpdate;
			test.Finished = formCalibration.TestFinished;
			
			// Set form actions.
			formCalibration.TestStart = test.Start;
			formCalibration.TestStop = test.Stop;
			formCalibration.TestBusy = test.IsBusy;
			formCalibration.Print = system.Print;
			formCalibration.NumDutsChanged = test.SetNumDuts;
			formCalibration.ModelChanged = test.SetModel;
			formCalibration.RangeChanged = test.SetRange;
			formCalibration.TestChanged = test.SetTest;

			// Run the GUI.
			Application.Run(formCalibration);
		}
	}
}
