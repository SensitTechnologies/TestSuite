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
        public int Counter;

        public UserCustomStep(Int16 counter, String stepInfo)
        {
            InitializeComponent();
            label1.Text = stepInfo;
            Counter = counter;
        }

        public void SetVisibility(bool visible)
        {
            textBox1.Visible = visible;
        }

        private void radioButtonPass_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Pass: " + Counter + " was clicked");
            SetVisibility(false);
        }

        private void radioButtonFail_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Fail: " + Counter + " was clicked");
            SetVisibility(true);
        }
    }
}
