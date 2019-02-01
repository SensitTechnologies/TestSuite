using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using Sensit.TestSDK.Controls;
using Sensit.TestSDK.Database;
/// <summary>
/// Form Popup that will render when a test case has been pressed
/// </summary>
/// <remarks>
/// This code has undergone many revisions in order to iterate properly with each row.
/// Here's my SO question that prompted the code shown below:
/// https://stackoverflow.com/questions/50221721/creating-dynamic-controller-names-in-c-sharp-with-winforms-for-tablelayoutpanel
/// </remarks>

namespace Sensit.TestSDK.Forms
{
	public partial class FormTestCase : Form
	{
		public short _counter = 1;  // Counter used for incrementing the step count (Should use Sequence attribute, but for testing purposes a simple Counter was being used)
		public JArray _testSteps;   // JArray that will become the JArray that is passed to this Form
		public SqlServer _database = new SqlServer();  // Creates a new SqlServer instance

		public FormTestCase(JArray testSteps, string server, string database, string username, string password)
		{
			InitializeComponent();
			_testSteps = testSteps;

			// Set database properties using application properties
			_database.Server = server;
			_database.Database = database;
			_database.Username = username;
			_database.Password = password;

			// Iterate through each element in the JArray and create a new row for each step
			foreach (var item in _testSteps)
			{
				// Creates new user custom step control instance
				UserCustomStep step = new UserCustomStep
				{
					Index = _counter,
					Instructions = (string)item["Step"]
				};

				// Adds CustomStep to first column (creates the entire first row)
				tableLayoutTest.Controls.Add(step, 0, _counter);

				// Increment couter to add subsequent steps underneath the previous ones.
				_counter++;
			}
		}

		/// <summary>
		/// Save the user's test results in the database.
		/// </summary>
		private void SaveResults()
		{
			// Grab list of UserCustomSteps that are preloaded into the FormTestCase
			List<UserCustomStep> stepList = tableLayoutTest.Controls.OfType<UserCustomStep>().Cast<UserCustomStep>().ToList();

			// Insert a new row into the test run
			_database.InsertIntoTestRuns(DateTime.Now.ToString("M/d/yyyy"), "Tester", "Notes", "Issue", "Status");

			// Loop through each test step
			foreach (var item in stepList)
			{
				// Grab Status (Pass or Fail) from value of radio button
				UserCustomStep.StepResult status = item.Result;

				// String that's used if anything fails and user puts something in the textbox that appears
				string actualResult = "";

				// Grabs the test step
				string instructions = item.Instructions;

				// If the test case has failed, fetch the string that the user has entered in the textbox.
				if (status == UserCustomStep.StepResult.Fail)
				{
					actualResult = item.ActualResult;
				}

				// Grabs test steps from the TestSteps table
				String finalResult = _database.ModularQueryWithResult("select * from TestSteps where Step = '" + instructions + "'", "TestSteps", "");

				// Parse result into a JSON Array for easy manipulation
				JArray joFinal = JArray.Parse(finalResult);

				// Grabs just the TestStepID from the Array and stores it in testStepID
				JToken testStepID = joFinal[0]["TestStepID"];

				// Insert new row into the TestStepResults table with the failure status, the radio button status, and the test step ID
				_database.InsertIntoTestStepResults(actualResult, status.ToString(), testStepID.ToString());
			}
		}

		// Will have to send data back to the database and store the results and updates made from creating the test run
		private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
		{
			// Grab list of UserCustomSteps that are preloaded into the FormTestCase
			List<UserCustomStep> stepList = tableLayoutTest.Controls.OfType<UserCustomStep>().Cast<UserCustomStep>().ToList();

			// Used to indicate whether all of the test cases have been marked with a pass or fail
			bool missingResult = false;

			// If any test step has not been marked "Pass" or "Fail", prompt the user.
			foreach (UserCustomStep s in stepList)
			{
				if (s.Result == UserCustomStep.StepResult.Unknown)
				{
					missingResult = true;
					break;
				}
			}

			// If one of the radio buttons hasn't been pressed, show a message box indicating that there is an issue trying to save the test run
			if (missingResult == true)
			{
				DialogResult result = MessageBox.Show("Are you sure you want to do this?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result == DialogResult.OK)
				{
					SaveResults();
				}
			}
			else
			{
				SaveResults();
			}
		}
	}

}
