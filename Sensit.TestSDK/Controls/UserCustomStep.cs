using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensit.TestSDK.Controls
{
    public partial class UserCustomStep : UserControl
    {
        public String radioButtonString = "";

        /// <summary>
        /// Used to create a Test Step in the Form
        /// </summary>
        /// <param name="stepInfo">Test Step</param>
        public UserCustomStep(String stepInfo)
        {
            InitializeComponent();
            label1.Text = stepInfo;
        }

        /// <summary>
        /// Shows or hides the textbox depending on the variable passed into this method
        /// </summary>
        /// <param name="visible">Set to whether or not you want the textbox to be visible</param>
        public void SetVisibility(bool visible)
        {
            failureExplanation.Visible = visible;
        }

        public String GetTestFailureResult()
        {
            return failureExplanation.Text;
        }

        /// <summary>
        /// Hides the textbox when the Pass radio button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonPass_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonString = "Pass";
            Console.WriteLine("Pass was clicked");
            SetVisibility(false);
        }

        /// <summary>
        /// Shows the textbox when the Fail radio button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonFail_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonString = "Fail";
            Console.WriteLine("Fail was clicked");
            SetVisibility(true);
        }

        public String ReturnText()
        {
            return label1.Text;
        }
    }
}
