using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sensit.TestSDK.Forms
{
	public static class InputDialog
	{
		public static DialogResult Numeric(string caption, ref int input, int min = 0, int max = 100)
		{
			// Create a new form.
			Size size = new Size(200, 70);
			Form inputBox = new Form
			{
				// Set the form's properties.
				FormBorderStyle = FormBorderStyle.FixedDialog,
				ClientSize = size,
				Text = caption
			};

			// Create a numeric up/down control.
			NumericUpDown numericInput = new NumericUpDown();
			numericInput.Size = new Size(size.Width - 10, 23);
			numericInput.Location = new Point(5, 5);
			numericInput.Value = input;
			numericInput.Increment = 1;
			numericInput.Minimum = min;
			numericInput.Maximum = max;
			inputBox.Controls.Add(numericInput);

			// Create an OK button.
			Button okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "buttonOK";
			okButton.Size = new Size(75, 23);
			okButton.Text = "&OK";
			okButton.Location = new Point(size.Width - 80 - 80, 39);
			inputBox.Controls.Add(okButton);

			// Create a Cancel button.
			Button cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "buttonCancel";
			cancelButton.Size = new Size(75, 23);
			cancelButton.Text = "&Cancel";
			cancelButton.Location = new Point(size.Width - 80, 39);
			inputBox.Controls.Add(cancelButton);

			// Set the DialogResult to be based on the buttons.
			inputBox.AcceptButton = okButton;
			inputBox.CancelButton = cancelButton;

			// Show the form; read and return user input.
			DialogResult result = inputBox.ShowDialog();
			input = Convert.ToInt32(numericInput.Value);
			return result;
		}

		public static DialogResult Text(string caption, ref string input)
		{
			// Create a new form.
			Size size = new Size(200, 70);
			Form inputBox = new Form
			{
				// Set the form's properties.
				FormBorderStyle = FormBorderStyle.FixedDialog,
				ClientSize = size,
				Text = caption
			};

			// Create a numeric up/down control.
			TextBox textBox = new TextBox();
			textBox.Size = new Size(size.Width - 10, 23);
			textBox.Location = new Point(5, 5);
			textBox.Text = input;
			inputBox.Controls.Add(textBox);

			// Create an OK button.
			Button okButton = new Button();
			okButton.DialogResult = DialogResult.OK;
			okButton.Name = "buttonOK";
			okButton.Size = new Size(75, 23);
			okButton.Text = "&OK";
			okButton.Location = new Point(size.Width - 80 - 80, 39);
			inputBox.Controls.Add(okButton);

			// Create a Cancel button.
			Button cancelButton = new Button();
			cancelButton.DialogResult = DialogResult.Cancel;
			cancelButton.Name = "buttonCancel";
			cancelButton.Size = new Size(75, 23);
			cancelButton.Text = "&Cancel";
			cancelButton.Location = new Point(size.Width - 80, 39);
			inputBox.Controls.Add(cancelButton);

			// Set the DialogResult to be based on the buttons.
			inputBox.AcceptButton = okButton;
			inputBox.CancelButton = cancelButton;

			// Show the form; read and return user input.
			DialogResult result = inputBox.ShowDialog();
			input = textBox.Text;
			return result;
		}
	}
}
