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

			// TODO:  Tell the GUI what models are available.
			formCalibration.Models = new ArrayList(new string[] { "Simulator", "Analog Sensor" });
			// TODO:  Tell the GUI what ranges are available.
			// TODO:  Tell the GUI what tests are available.

			// TODO:  Tell the GUI variables to use.
			//        Maybe create test.Initialize that calls a form action and sends
			//        a list of references and controllers.
			// TODO:  Tell formCalibration and test objects what equipment is needed.
			// TODO:  Display tab for DUT.  Maybe show Excel in a web browser?
			// TODO:  Code DAQ library.

			// Set test actions.
			test.Update = formCalibration.TestUpdate;
			test.Finished = formCalibration.TestFinished;
			test.SystemOpen = system.Open;
			test.SystemClose = system.Close;
			test.SystemRead = system.Read;
			
			// Set GUI actions.
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
