using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sensit.TestSDK.Forms;
using Sensit.TestSDK.Controls;
using Sensit.TestSDK.Database;
using Newtonsoft.Json.Linq;
/// <summary>
/// Form Popup that will render when a test case has been pressed
/// </summary>
/// <remarks>This code has undergone many revisions in order to iterate properly with each row.  Here's my SO question that prompted the code shown below: https://stackoverflow.com/questions/50221721/creating-dynamic-controller-names-in-c-sharp-with-winforms-for-tablelayoutpanel </remarks>

namespace Sensit.TestSDK.Forms
{
    public partial class FormTestCase : Form
    {
        public Int16 Counter = 1;  // Counter used for incrementing the step count (Should use Sequence attribute, but for testing purposes a simple Counter was being used)
        public JArray TestSteps;   // JArray that will become the JArray that is passed to this Form
        public SqlServer Database = new SqlServer();  // Creates a new SqlServer instance

        public FormTestCase(JArray testSteps, String server, String database, String username, String password)
        {
            InitializeComponent();
            TestSteps = testSteps;

            // Set database properties using application properties
            Database.Server = server;
            Database.Database = database;
            Database.Username = username;
            Database.Password = password;

            // Iterate through each element in the JArray and create a new row for each step
            foreach (var item in TestSteps)
            {
                // Creates new user custom step control instance
                UserCustomStep step = new UserCustomStep("Step: " + Counter + " " + (String)item["Step"]);

                // Adds CustomStep to first column (creates the entire first row)
                tableLayoutTest.Controls.Add(step, 0, Counter);

                // Increment couter to add subsequent steps underneath the previous ones.
                Counter++;
            }
        }

        // Used for testing purposes, please get rid of this element entirely
        private void addRowToolStripMenuItem_Click(object sender, EventArgs anotherEvent)
        {

        }

        // Needs to be deleted
        private void FormManualTest_Load(object sender, EventArgs e)
        {

        }

        // Will have to send data back to the database and store the results and updates made from creating the test run
        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Grab list of UserCustomSteps that are preloaded into the FormTestCase
            List<UserCustomStep> c = tableLayoutTest.Controls.OfType<UserCustomStep>().Cast<UserCustomStep>().ToList();

            // Used to indicate whether all of the test cases have been marked with a pass or fail
            Boolean radioEmptyString = false;

            // Loop through each test step
            foreach (var item in c)
            {
                // If either radio button hasn't been clicked, this will set the radioEmptyString to true and stops iterating over the steps
                if(item.radioButtonString == "")
                {
                    radioEmptyString = true;
                    break;
                }
                
                
            }

            // If one of the radio buttons hasn't been pressed, show a message box indicating that there is an issue trying to save the test run
            if(radioEmptyString==true)
            {
                if (MessageBox.Show("Are you sure you want to do this?", "Question", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    MessageBox.Show("You pressed OK!");
                }
                else
                {
                    MessageBox.Show("You pressed Cancel!");
                }
            }

            else
            {
                // Insert a new row into the test run
                Database.InsertIntoTestRuns(DateTime.Now.ToString("M/d/yyyy"), "Tester", "Notes", "Issue", "Status");

                // Loop through each test step
                foreach (var item in c)
                {
                    // Grab Status (Pass or Fail) from value of radio button
                    var radioButtonStatus = item.radioButtonString;

                    // String that's used if anything fails and user puts something in the textbox that appears
                    var failureResult = "";

                    // Grabs the test step
                    var step = item.ReturnText().Substring(8);

                    // If the test case has failed, takes the string that the user has entered in the textbox and places it in failureResult
                    if (radioButtonStatus=="Fail")
                    {
                        failureResult = item.GetTestFailureResult();
                    }

                    // Grabs test steps from the TestSteps table
                    String finalResult = Database.ModularQueryWithResult("select * from TestSteps where Step = '" + step + "'", "TestSteps", "");

                    // Parse result into a JSON Array for easy manipulation
                    var joFinal = JArray.Parse(finalResult);

                    // Grabs just the TestStepID from the Array and stores it in testStepID
                    var testStepID = joFinal[0]["TestStepID"];
                    
                    // Insert new row into the TestStepResults table with the failure status, the radio button status, and the test step ID
                    Database.InsertIntoTestStepResults(failureResult, radioButtonStatus, testStepID.ToString());
                }
                
            }
            
        }
    }

}
