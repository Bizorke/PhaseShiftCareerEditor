using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhaseShiftCareerEditor
{
	public partial class NewFolder : Form
	{
		string parentDir;
		public NewFolder(string parentDir)
		{
			this.parentDir = parentDir;
			InitializeComponent();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			var invalidChars = Path.GetInvalidPathChars();

			bool invalidchars = false;
			foreach (var c in invalidChars) {
				if (this.textBox1.Text.Contains(c)) {
					invalidchars = true;
					break;
				}
			}

			if (invalidchars || textBox1.Text.Contains(Path.DirectorySeparatorChar) || textBox1.Text.Contains(Path.AltDirectorySeparatorChar)) {
				var response = MessageBox.Show("Folder name contains invalid characters.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (response == DialogResult.Cancel) {
					Close();
				}
				return;
			}

			var path = Path.Combine(parentDir, textBox1.Text);
			if (Directory.Exists(path)) {
				var response = MessageBox.Show("A directory with that name already exists.", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
				if (response == DialogResult.Cancel)
				{
					Close();
				}
				return;
			}


			Directory.CreateDirectory(path);
			Close();
		}

		private void NewFolder_Load(object sender, EventArgs e)
		{
			if (!Directory.Exists(parentDir)) {
				this.Close();
			}
		}
	}
}
