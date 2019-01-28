using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sensit.App.GasConcentration
{
	public partial class FormGasConcentration : Form
	{
		/// <summary>
		/// Runs when the application starts.
		/// </summary>
		public FormGasConcentration()
		{
			// Initialize the form.
			InitializeComponent();
		}

		/// <summary>
		/// When File --> Exit menu item is clicked, close the application.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
