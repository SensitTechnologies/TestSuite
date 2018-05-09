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

namespace Sensit.TestSDK.Forms
{
    public partial class FormTestCase : Form
    {
        public SqlServer Database;
        public Int16 Counter = 1;
        public Int16 TestCaseId;

        public FormTestCase(String server, String database, String username, String password, Int16 testCaseId)
        {
            InitializeComponent();
            Database = new SqlServer();
            Database.Server = server;
            Database.Database = database;
            Database.Username = username;
            Database.Password = password;
            Database.CheckConnection();
            TestCaseId = 5;
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs anotherEvent)
        {

            String result = Database.ModularQueryWithResult("select * from TestSteps where TestCaseID = " + TestCaseId + " order by Sequence", "TestSteps", "");
            var jo = JArray.Parse(result);
            Counter = 1;
            foreach (var item in jo)
            {
                UserCustomStep step = new UserCustomStep(Counter, "Step: " + Counter + " " + (String) item["Step"] );  // Creates new user custom step control instance

                tableLayoutTest.Controls.Add(step, 0, Counter);  // Adds CustomStep to first column (creates the entire first row)

                Counter++;  // Increment couter to add subsequent steps underneath the previous ones.

            }

        }

        private void FormManualTest_Load(object sender, EventArgs e)
        {

        }

        private void saveAndCloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Saved Button was pressed.");
        }
    }

}
