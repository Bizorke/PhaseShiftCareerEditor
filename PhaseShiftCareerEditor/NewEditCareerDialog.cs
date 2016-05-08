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
	public partial class NewEditCareerDialog : Form
	{
		string defaultFsDirectory = @"C:\Program Files (x86)\Phase Shift";
		string defaultFsMusicDirectory = @"C:\Program Files (x86)\Phase Shift\music";
		string defaultFsCareerDirectory = @"C:\Program Files (x86)\Phase Shift\careers";
		string originalCareerName = null;
		frmMain parent = null;

		public NewEditCareerDialog(frmMain mainform, int? selectedCareerIndex = null)
		{
			InitializeComponent();

			if (selectedCareerIndex != null)
			{
				originalCareerName = (string)mainform.ListBoxCareers.Items[selectedCareerIndex.Value];
			}
			parent = mainform;
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			string name = txtCareer.Text;
			string finalName = "";

			foreach (var c in name) {
				bool addToResult = true;

				if (c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar || c == '.') {
					continue;
				}

				foreach (var ic in Path.InvalidPathChars) {
					if (ic == c) {
						addToResult = false;
						break;
					}
				}

				if (addToResult) {
					finalName += c;
				}
			}

			if (string.IsNullOrEmpty(finalName)) {
				MessageBox.Show("The name you specified cannot be saved because it does not contain any valid characters.", "Invalid Career Name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			string newDirectory = Path.Combine(defaultFsCareerDirectory, finalName);
			if ((originalCareerName == null || originalCareerName.ToLower() != finalName.ToLower()) && Directory.Exists(newDirectory)) {
				MessageBox.Show("The name you specified cannot be saved because a career already exists in a folder with the name \"" + finalName + "\".", "Invalid Career Name", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			try {
				if (originalCareerName == null)
				{
					//create
					Directory.CreateDirectory(newDirectory);
				}
				else if(originalCareerName.ToLower() != finalName.ToLower()) {
					//rename
					Directory.Move(Path.Combine(defaultFsCareerDirectory, originalCareerName), newDirectory);
				}

				var newcareerini = Path.Combine(defaultFsCareerDirectory, finalName, "career.ini");

				//create a new newcareerini or overwrite

				var toSave = new List<KeyValuePair<string, string>>();
				toSave.Add(new KeyValuePair<string, string>("name", txtCareer.Text));
				toSave.Add(new KeyValuePair<string, string>("comment", txtComment.Text));
				IniFileReader.WriteFile(newcareerini, toSave);
				
			}
			catch (Exception err){
				

				bool ableToCleanUp = true;
				if (originalCareerName == null)
				{
					try
					{
						if (Directory.Exists(newDirectory))
						{
							Directory.Delete(newDirectory, true);

						}
					}
					catch
					{
						ableToCleanUp = false;
					}
				}

				MessageBox.Show("An error occurred while saving the new career. It may pe permissions related. Try running as administrator." + (ableToCleanUp ? "" : " Unable to clean up attempt.") + "\r\n\r\nError message: " + err.Message, "File System Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}

			if (originalCareerName == null)
			{
				parent.ListBoxCareers.Items.Add(finalName);
				parent.ListBoxCareers.SelectedIndex = parent.ListBoxCareers.Items.Count - 1;
			}
			else 
			{
				for (var i = 0; i < parent.ListBoxCareers.Items.Count; i++) {
					if ((string)parent.ListBoxCareers.Items[i] == originalCareerName) {
						parent.ListBoxCareers.Items[i] = finalName;
						break;
					}
				}
			}

			this.Close();
			return;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void NewEditCareerDialog_Load(object sender, EventArgs e)
		{
			if (originalCareerName != null) {
				var careerini = Path.Combine(defaultFsCareerDirectory, originalCareerName, "career.ini");

				var careerData = IniFileReader.ReadFile(careerini);

				if (careerData != null)
				{
					txtCareer.Text = careerData.Where(k => k.Key == "name").Select(v => v.Value).FirstOrDefault() ?? "";

					txtComment.Text = careerData.Where(k => k.Key == "comment").Select(v => v.Value).FirstOrDefault() ?? "";
				}

			}
		}
	}
}
