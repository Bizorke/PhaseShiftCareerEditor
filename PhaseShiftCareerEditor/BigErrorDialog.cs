using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhaseShiftCareerEditor
{
	public partial class BigErrorDialog : Form
	{
		string message = "";
		string caption = "Errors";
		public BigErrorDialog(string message, string caption)
		{
			this.message = message;
			this.caption = caption;
			InitializeComponent();
		}

		private void txtErrors_TextChanged(object sender, EventArgs e)
		{

		}

		private void btnDone_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void BigErrorDialog_Load(object sender, EventArgs e)
		{
			this.Text = caption;
			txtErrors.Text = message;
		}
	}
}
