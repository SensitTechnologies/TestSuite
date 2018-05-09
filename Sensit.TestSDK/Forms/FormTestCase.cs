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

        public FormTestCase(JArray testSteps)
        {
            InitializeComponent();
            TestSteps = testSteps;

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
            Console.WriteLine("Saved Button was pressed.");
        }
    }

}
