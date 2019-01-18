using System;
using System.Collections.Generic;
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
			Equipment equipment = new Equipment();

			// Create an object to represent the tests being run.
			Test test = new Test();

			// Create a GUI for user interaction.
			FormCalibration formCalibration = new FormCalibration
			{
				// TODO:  Tell the GUI what models are available.
				Models = new List<string> { "Simulator", "Analog Sensor" },
				// TODO:  Tell the GUI what ranges are available.
				Ranges = new List<string> { "0 - 5% V/V", "0 - 100% V/V" },
				// TODO:  Tell the GUI what tests are available.
				Tests = new List<string> { "Linearity" }
			};

			// TODO:  Every time a model, range, is updated, get new options.
			// TODO:  Tell the GUI and test objects what equipment is needed.
			// TODO:  Tell the GUI what variables to use. Maybe create test.Initialize that calls a form action and sends a list of references and controllers.
			// TODO:  Display tab for DUT.  Maybe show Excel in a web browser?

			// Set test actions.
			test.Update = formCalibration.TestUpdate;
			test.Finished = formCalibration.TestFinished;
			test.SystemOpen = equipment.Open;
			test.SystemClose = equipment.Close;
			test.SystemRead = equipment.Read;
			
			// Set GUI actions.
			formCalibration.TestStart = test.Start;
			formCalibration.TestStop = test.Stop;
			formCalibration.TestBusy = test.IsBusy;
			formCalibration.Print = equipment.Print;
			formCalibration.NumDutsChanged = test.SetNumDuts;
			formCalibration.ModelChanged = test.SetModel;
			formCalibration.RangeChanged = test.SetRange;
			formCalibration.TestChanged = test.SetTest;

			// Run the GUI.
			Application.Run(formCalibration);
		}
	}
}
