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
	public partial class NewEditTierDialog : Form
	{
		frmMain parent = null;
		string careerName;
		List<KeyValuePair<string, string>> tierFileData;
		int minrank = 0;
		int maxrank = 0;
		string instrument;
		int? tier;
		public NewEditTierDialog(frmMain parent, string selectedCareerName, string instrument, int? tier, List<KeyValuePair<string, string>> currentTierFileData, int minCareerRank, int maxCareerRank)
		{
			this.parent = parent;
			this.careerName = selectedCareerName;
			this.tierFileData = currentTierFileData;
			this.minrank = minCareerRank;
			this.maxrank = maxCareerRank;
			this.instrument = instrument;
			this.tier = tier;
			InitializeComponent();
		}

		private void NewEditTierDialog_Load(object sender, EventArgs e)
		{
			txtTierName.Text = (tierFileData != null ? tierFileData.Where(t => t.Key == "name").Select(t => t.Value).FirstOrDefault() ?? "" : "");
			string rankData = (tierFileData != null ? tierFileData.Where(t => t.Key == "unlock").Select(t => t.Value).FirstOrDefault() ?? "0" : "-1");
			int rankInt = -1;
			int.TryParse(rankData, out rankInt);

			if (rankInt < minrank) rankInt = (maxrank) / 2; //Sets it to 50%.
			if (rankInt < minrank) rankInt = (minrank); //Sets it to 50%.
			if (rankInt > maxrank) rankInt = maxrank;
			
			barRank.Minimum = minrank;
			barRank.Maximum = maxrank;
			barRank.Value = rankInt;

			txtRank.Text = "" + rankInt;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			//Change the name and unlock.
			bool changedName = false;
			bool changedUnlock = false;
			if (tierFileData != null)
			{
				for (var i = 0; i < tierFileData.Count; i++)
				{
					if (tierFileData[i].Key == "name")
					{
						tierFileData[i] = new KeyValuePair<string, string>("name", txtTierName.Text);
						changedName = true;
					}
					if (tierFileData[i].Key == "unlock")
					{
						tierFileData[i] = new KeyValuePair<string, string>("unlock", "" + barRank.Value);
						changedUnlock = true;
					}
				}
			}
			else {
				tierFileData = new List<KeyValuePair<string, string>>();
			}
			if (!changedName) tierFileData.Add(new KeyValuePair<string, string>("name", txtTierName.Text));
			if (!changedUnlock) tierFileData.Add(new KeyValuePair<string, string>("unlock", "" + barRank.Value));

			parent.UpdateTierFile(tierFileData, careerName, instrument, tier);

			Close();
		}

		private void barRank_Scroll(object sender, EventArgs e)
		{
			txtRank.Text = "" + barRank.Value;
		}
	}
}
