using System;
using System.Windows.Forms;

namespace Sensit.TestSDK.Controls
{
	public partial class UserCustomStep : UserControl
    {
		private int _index;

		public enum StepResult
		{
			Pass,
			Fail,
			Unknown,
		}

        /// <summary>
        /// Constructor
        /// </summary>
        public UserCustomStep()
        {
            InitializeComponent();
        }

		/// <summary>
		/// Number to associate with the step.
		/// </summary>
		public int Index
		{
			get => _index;
			set
			{
				_index = value;
				groupBoxStep.Text = "Step " + value;
			}
		}

		/// <summary>
		/// Instructional text displayed to the user.
		/// </summary>
		public string Instructions
		{
			get => labelInstructions.Text;
			set => labelInstructions.Text = value;
		}

		/// <summary>
		/// The desired effect of the instructions.
		/// </summary>
		public string ExpectedResult
		{
			get => labelExpectedResult.Text;
			set => labelExpectedResult.Text = value;
		}

		/// <summary>
		/// Whether the instructions produced the expected result.
		/// </summary>
		public StepResult Result
		{
			get
			{
				if (radioButtonFail.Checked)
					return StepResult.Fail;
				else if (radioButtonPass.Checked)
					return StepResult.Pass;
				else
					return StepResult.Unknown;
			}
			set
			{
				switch (value)
				{
					case StepResult.Fail:
						radioButtonFail.Checked = true;
						radioButtonPass.Checked = false;
						break;
					case StepResult.Pass:
						radioButtonFail.Checked = false;
						radioButtonPass.Checked = true;
						break;
					default:
						radioButtonFail.Checked = false;
						radioButtonPass.Checked = false;
						break;
				}
			}
		}

		/// <summary>
		/// The observed effect of the instructions.
		/// </summary>
		public string ActualResult
		{
			get => textBoxActualResult.Text;
			set => textBoxActualResult.Text = value;
		}

        /// <summary>
        /// Hides the textbox when the Pass radio button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonPass_CheckedChanged(object sender, EventArgs e)
        {
			// Do stuff only if the radio button is checked.
			// (Otherwise the actions will run twice.)
			if (((RadioButton)sender).Checked)
			{
				textBoxActualResult.Visible = false;
			}
        }

        /// <summary>
        /// Shows the textbox when the Fail radio button has been clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonFail_CheckedChanged(object sender, EventArgs e)
        {
			// Do stuff only if the radio button is checked.
			// (Otherwise the actions will run twice.)
			if (((RadioButton)sender).Checked)
			{
				textBoxActualResult.Visible = true;
			}
        }
    }
}
