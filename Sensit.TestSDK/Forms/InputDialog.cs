using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	public static class InputDialog
	{
		#region Private Methods

		private static Form CreateBox(string caption)
		{
			// Create a new form.
			Size size = new Size(160, 70);
			// TODO:  Make the form autosize to the controls.
			Form inputBox = new Form
			{
				// Set the form's properties.
				MinimizeBox = false,
				MaximizeBox = false,
				FormBorderStyle = FormBorderStyle.FixedDialog,
				ClientSize = size,
				Text = caption
			};

			// Create an OK button.
			Button okButton = new Button()
			{
				DialogResult = DialogResult.OK,
				Name = "buttonOK",
				Size = new Size(75, 23),
				Text = "&OK",
				Location = new Point(size.Width - 80 - 80, 39)
			};

			inputBox.Controls.Add(okButton);

			// Create a Cancel button.
			Button cancelButton = new Button()
			{
				DialogResult = DialogResult.Cancel,
				Name = "buttonCancel",
				Size = new Size(75, 23),
				Text = "&Cancel",
				Location = new Point(size.Width - 80, 39)
			};

			inputBox.Controls.Add(cancelButton);

			// Set the DialogResult to be based on the buttons.
			inputBox.AcceptButton = okButton;
			inputBox.CancelButton = cancelButton;

			return inputBox;
		}

		#endregion

		public static DialogResult Numeric(string caption, ref int input, int min = 0, int max = 100, int increment = 1)
		{
			// Create a new form.
			Form inputBox = CreateBox(caption);

			// Create a numeric up/down control.
			NumericUpDown numericInput = new NumericUpDown
			{
				Location = new Point(5, 5),
				Value = input,
				Increment = increment,
				Minimum = min,
				Maximum = max
			};
			
			inputBox.Controls.Add(numericInput);

			// Show the form; read and return user input.
			DialogResult result = inputBox.ShowDialog();
			input = Convert.ToInt32(numericInput.Value);
			return result;
		}

		public static DialogResult Numeric(string caption, ref double input, double min = 0, double max = 100, double increment = 1.0)
		{
			// Create a new form.
			Form inputBox = CreateBox(caption);

			// Create a numeric up/down control.
			NumericUpDown numericInput = new NumericUpDown
			{
				Location = new Point(5, 5),
				Value = (decimal)input,
				Increment = (decimal)increment,
				Minimum = (decimal)min,
				Maximum = (decimal)max
			};

			inputBox.Controls.Add(numericInput);

			// Show the form; read and return user input.
			DialogResult result = inputBox.ShowDialog();
			input = Convert.ToInt32(numericInput.Value);
			return result;
		}

		public static DialogResult Text(string caption, ref string input)
		{
			// Create a new form.
			Form inputBox = CreateBox(caption);

			// Create a numeric up/down control.
			TextBox textBox = new TextBox
			{
				Location = new Point(5, 5),
				Text = input
			};

			inputBox.Controls.Add(textBox);

			// Show the form; read and return user input.
			DialogResult result = inputBox.ShowDialog();
			input = textBox.Text;
			return result;
		}
	}
}
