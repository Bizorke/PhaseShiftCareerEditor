using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhaseShiftCareerEditor
{
	public partial class frmMain : Form
	{
		string psInstallDirectory = @"C:\Program Files (x86)\Phase Shift";
		string psMusicDirectory = @"C:\Program Files (x86)\Phase Shift\music";
		string psCareerDirectory = @"C:\Program Files (x86)\Phase Shift\careers";

		string currentMusicFolder = "";

		public ListBox ListBoxCareers { get { return lstCareers; } }
		public string SelectedCareerName { get { return (string)lstCareers.SelectedItem; } }
		//public ListBox ListBoxFiles { get { return lstFiles; } }

		private List<KeyValuePair<string, string>> currentTierFileData = null;
		private List<int> currentMinRankForEachTier = null;
		private List<int> currentSongsForEachTier = null;
		private List<int> currentUnlockValuesForEachTier = null;
		private int instrumentIconIndex = 1;


		public frmMain()
		{
			currentMusicFolder = psMusicDirectory;

			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			lstFiles.Columns[0].Width = -2;
			lstTiers.Columns[0].Width = -2;
			lstSongs.Columns[0].Width = -2;
			cboInstrument.SelectedIndex = 0;

			/*this.lstFiles.UseCustomSelectionColors = true;
			this.lstFiles.HighlightBackgroundColor = Color.Lime;
			this.lstFiles.UnfocusedHighlightBackgroundColor = Color.Lime;*/

			//TODO: more robust programming.
			var ev = Environment.GetEnvironmentVariables();
			List<string> placesToCheck = new List<string>();

			if (File.Exists("psce.ini"))
			{
				var configdat = IniFileReader.ReadFile("psce.ini");
				var installdir = configdat.Where(d => d.Key == "psinstalldir").Select(d => d.Value).FirstOrDefault();
				if (installdir != null)
				{
					try { placesToCheck.Add(installdir); } catch { }
				}
			}

			try { placesToCheck.Add(Path.Combine((string)ev["ProgramFiles(x86)"], "Phase Shift")); } catch { }
			try { placesToCheck.Add(Path.Combine((string)ev["ProgramFiles"], "Phase Shift")); } catch { }
			try { placesToCheck.Add(Path.Combine((string)ev["ProgramW6432"], "Phase Shift")); } catch { }
			try { placesToCheck.Add(Path.Combine((string)ev["SystemDrive"], "Program Files (x86)", "Phase Shift")); } catch { }
			try { placesToCheck.Add(Path.Combine((string)ev["SystemDrive"], "Program Files", "Phase Shift")); } catch { }
			try { placesToCheck.Add(Path.Combine(Path.GetPathRoot(Environment.CurrentDirectory), "Program Files (x86)", "Phase Shift")); } catch { }
			try { placesToCheck.Add(Path.Combine(Path.GetPathRoot(Environment.CurrentDirectory), "Program Files", "Phase Shift")); } catch { }


			psInstallDirectory = null;
			for (var i = 0; i < placesToCheck.Count(); i++)
			{
				if (Directory.Exists(placesToCheck[i]))
				{
					psInstallDirectory = placesToCheck[i];
					break;
				}
			}

			bool nonDefaultPathRequired = false;
			if (psInstallDirectory == null)
			{
				var answer = MessageBox.Show("Phase Shift was not found in the default install location. Would you like to brows for it?", "Phase Shift not Found", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

				if (answer == DialogResult.Yes)
				{
					installDirFinder.ShowDialog(this);

					psInstallDirectory = installDirFinder.SelectedPath;

					nonDefaultPathRequired = true;

				}
			}

			if (psInstallDirectory != null)
			{
				psCareerDirectory = Path.Combine(psInstallDirectory, "careers");
				psMusicDirectory = Path.Combine(psInstallDirectory, "music");
			}

			if (psInstallDirectory == null || !Directory.Exists(psInstallDirectory))
			{

				Application.Exit();
			}
			else if (!Directory.Exists(psCareerDirectory))
			{
				MessageBox.Show("The career directory was not found in the default location.", "Career Directory not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				Application.Exit();
			}
			else if (!Directory.Exists(psMusicDirectory))
			{
				MessageBox.Show("The music directory was not found in the default location.", "Music Directory not Found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				Application.Exit();
			}
			else {
				//Save config if necessary
				if (nonDefaultPathRequired)
				{
					try
					{
						List<KeyValuePair<string, string>> configData = new List<KeyValuePair<string, string>>();
						configData.Add(new KeyValuePair<string, string>("psinstalldir", psInstallDirectory));
						IniFileReader.WriteFile("psce.ini", configData);
					}
					catch { }
				}

				//Populate lstCareers.
				var careerfolders = Directory.GetDirectories(psCareerDirectory);
				foreach (var c in careerfolders)
				{
					lstCareers.Items.Add(Path.GetFileName(c));

					LoadFolderIntoListControl(psMusicDirectory);
				}
			}
		}

		private void btnNewCareer_Click(object sender, EventArgs e)
		{
			var editor = new NewEditCareerDialog(this);
			editor.ShowDialog();
		}

		private void lstCareers_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReorganizeTiers();
		}

		private void lstCareers_DoubleClick(object sender, EventArgs e)
		{
			var editor = new NewEditCareerDialog(this, lstCareers.SelectedIndex);
			editor.ShowDialog();
		}

		private void lstFiles_SelectedIndexChanged(object sender, EventArgs e)
		{

		}


		private void lstSongs_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (Char)Keys.Delete)
			{
				removeSelectedSongs();
			}
		}
		private void lstFiles_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == (Char)Keys.Enter)
			{
				addSongFromFileList();
			}
		}

		private void lstFiles_DoubleClick(object sender, EventArgs e)
		{
			addSongFromFileList();
		}

		private void addSongFromFileList()
		{
			var folderName = lstFiles.SelectedItems[0].Text;

			var newfolder = NormalizePath(Path.Combine(currentMusicFolder, folderName));

			if (Directory.Exists(newfolder))
			{
				if (!File.Exists(Path.Combine(newfolder, "song.ini")))
				{
					LoadFolderIntoListControl(newfolder);
					currentMusicFolder = newfolder;
				}
				else {
					var songName = Path.GetFileName(newfolder);
					AddSongsToSelectedTier(new string[] { songName });
				}
			}
		}

		private void frmMain_Resize(object sender, EventArgs e)
		{
			lstFiles.Columns[0].Width = -2;
			lstTiers.Columns[0].Width = -2;
			lstSongs.Columns[0].Width = -2;
		}

		private void btnAddTier_Click(object sender, EventArgs e)
		{
			if (SelectedCareerName != null)
			{
				int min = 0;
				int max = 0;
				if (currentSongsForEachTier != null)
				{
					for (var i = 0; i < currentSongsForEachTier.Count; i++)
					{
						max += currentSongsForEachTier[i] * 6;
						if (currentMinRankForEachTier != null && currentMinRankForEachTier[i] > min)
						{
							min = currentMinRankForEachTier[i];
						}
					}
				}
				var editor = new NewEditTierDialog(this, SelectedCareerName, (string)cboInstrument.SelectedItem, null, null, min, max);
				editor.ShowDialog();
			}
		}

		/*private void addTier(string careerName, string promptValue, int requiredPoints) {
			if (!string.IsNullOrEmpty(promptValue))
			{
				//Create the tier.
				var thisCareerDir = Path.Combine(defaultFsCareerDirectory, SelectedCareerName);
				if (!Directory.Exists(thisCareerDir))
				{
					Directory.CreateDirectory(thisCareerDir);
				}
				var thisInstrumentDir = Path.Combine(thisCareerDir, "guitar");
				if (!Directory.Exists(thisInstrumentDir))
				{
					Directory.CreateDirectory(thisInstrumentDir);
				}

				int tierNumb = 0;

				while (File.Exists(getTierFilePath(tierNumb)))
				{
					tierNumb++;
				}

				var tierFilePath = getTierFilePath(tierNumb);

				var data = new List<KeyValuePair<string, string>>();
				data.Add(new KeyValuePair<string, string>("name", promptValue));
				data.Add(new KeyValuePair<string, string>("unlock", 0));

				File.WriteAllText("tier_" + tierNumb + ".ini", "name = \"" + promptValue + "\"", Encoding.Unicode);
			}
		}*/

		private void cboInstrument_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch ((string)cboInstrument.SelectedItem)
			{
				case "guitar":
				case "guitar_real":
					instrumentIconIndex = 3;
					break;

				case "bass":
				case "bass_adv":
				case "bass_real":
					instrumentIconIndex = 4;
					break;
				case "drums":
				case "drums_adv":
				case "drums_real":
					instrumentIconIndex = 5;
					break;
				case "keys":
				case "keys_adv":
				case "keys_real":
					instrumentIconIndex = 6;
					break;
			}

			LoadFolderIntoListControl(currentMusicFolder);

			ReorganizeTiers();
		}


		private void lstTiers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstTiers.SelectedIndices.Count > 0)
			{
				int selectedIndex = lstTiers.SelectedIndices[0];
				currentTierFileData = IniFileReader.ReadFile(getTierFilePath(selectedIndex));

			}
			RefreshSongList();
		}

		private void lstTiers_DoubleClick(object sender, EventArgs e)
		{
			//Open the editor
			if (lstTiers.SelectedIndices.Count > 0)
			{
				int min = 0;
				int max = 0;
				int tiernumber = lstTiers.SelectedIndices[0];
				if (currentSongsForEachTier != null)
				{
					for (var i = 0; i < tiernumber; i++)
					{
						max += currentSongsForEachTier[i] * 6;
						if (currentMinRankForEachTier != null && currentMinRankForEachTier[i] > min)
						{
							min = currentMinRankForEachTier[i];
						}
					}
				}
				var editor = new NewEditTierDialog(this, SelectedCareerName, (string)cboInstrument.SelectedItem, tiernumber, currentTierFileData, min, max);
				editor.ShowDialog();
			}
		}


		private void btnDeleteTier_Click(object sender, EventArgs e)
		{
			if (lstTiers.SelectedIndices.Count > 0)
			{
				int tiernumber = lstTiers.SelectedIndices[0];
				var currentNumberOfSongs = currentSongsForEachTier[tiernumber];
				var unlockStr = currentUnlockValuesForEachTier[tiernumber];

				File.Delete(getTierFilePath(tiernumber));

				int unlockDiff = 0;
				if (tiernumber + 1 < currentUnlockValuesForEachTier.Count)
				{
					unlockDiff = currentUnlockValuesForEachTier[tiernumber + 1] - currentUnlockValuesForEachTier[tiernumber];
				}

				tiernumber++;
				while (File.Exists(getTierFilePath(tiernumber)))
				{
					//First rename the file.
					File.Move(getTierFilePath(tiernumber), getTierFilePath(tiernumber - 1));

					//Now change the contents of the file.
					var nextTierData = IniFileReader.ReadFile(getTierFilePath(tiernumber - 1));

					ChangeUnlockValue(nextTierData, currentUnlockValuesForEachTier[tiernumber] - unlockDiff);

					IniFileReader.WriteFile(getTierFilePath(tiernumber - 1), nextTierData);

					tiernumber++;
				}
			}

			ReorganizeTiers();
		}



		private void btnAddSongs_Click(object sender, EventArgs e)
		{
			if (SelectedCareerName != null && lstTiers.SelectedItems.Count > 0)
			{
				List<string> newSongs = new List<string>();

				foreach (int s in lstFiles.SelectedIndices)
				{
					if (File.Exists(Path.Combine(currentMusicFolder, lstFiles.Items[s].Text, "song.ini")))
					{
						newSongs.Add(lstFiles.Items[s].Text);
					}
				}
				AddSongsToSelectedTier(newSongs.ToArray());

			}
		}

		private void btnRemoveSong_Click(object sender, EventArgs e)
		{
			removeSelectedSongs();
		}

		private void removeSelectedSongs()
		{
			if (SelectedCareerName != null && lstTiers.SelectedItems.Count > 0 && lstSongs.SelectedItems.Count > 0)
			{
				List<string> songsToRemove = new List<string>();

				foreach (int s in lstSongs.SelectedIndices)
				{
					songsToRemove.Add(lstSongs.Items[s].Text);
				}
				RemoveSongsFromSelectedTier(lstSongs.SelectedIndices);

				for (var i = lstSongs.SelectedIndices.Count - 1; i >= 0; i--)
				{
					lstSongs.Items.RemoveAt(lstSongs.SelectedIndices[i]);
				}

			}
		}


		private void btnMoveSongUp_Click(object sender, EventArgs e)
		{
			if (lstSongs.Items.Count > 0 && lstSongs.SelectedIndices.Count == 1 && lstSongs.SelectedIndices[0] > 0)
			{
				var indexToMove = lstSongs.SelectedIndices[0];
				var destinationIndex = indexToMove - 1;
				var lstTxt1 = lstSongs.Items[indexToMove].Text;
				var lstTxt2 = lstSongs.Items[destinationIndex].Text;
				lstSongs.Items[indexToMove].Text = lstTxt2;
				lstSongs.Items[destinationIndex].Text = lstTxt1;

				lstSongs.Items[indexToMove].Selected = false;
				lstSongs.Items[destinationIndex].Selected = true;

				var newData = new List<KeyValuePair<string, string>>();

				int loopSongNumb = -1;
				for (var d = 0; d < currentTierFileData.Count; d++)
				{
					if (currentTierFileData[d].Key == "song")
					{
						loopSongNumb++;
						if (loopSongNumb == destinationIndex)
						{
							newData.Add(currentTierFileData[d + 1]);
						}
						else if (loopSongNumb == indexToMove)
						{
							newData.Add(currentTierFileData[d - 1]);
						}
						else
						{
							newData.Add(currentTierFileData[d]);
						}
					}
					else
					{
						newData.Add(currentTierFileData[d]);
					}
				}

				currentTierFileData = newData;

				int tiernumber = lstTiers.SelectedIndices[0];
				IniFileReader.WriteFile(getTierFilePath(tiernumber), newData);
			}
		}

		private void btnMoveSongDown_Click(object sender, EventArgs e)
		{
			if (lstSongs.Items.Count > 0 && lstSongs.SelectedIndices.Count == 1 && lstSongs.SelectedIndices[0] < lstSongs.Items.Count - 1)
			{
				var indexToMove = lstSongs.SelectedIndices[0];
				var destinationIndex = indexToMove + 1;
				var lstTxt1 = lstSongs.Items[indexToMove].Text;
				var lstTxt2 = lstSongs.Items[destinationIndex].Text;
				lstSongs.Items[indexToMove].Text = lstTxt2;
				lstSongs.Items[destinationIndex].Text = lstTxt1;

				lstSongs.Items[indexToMove].Selected = false;
				lstSongs.Items[destinationIndex].Selected = true;

				var newData = new List<KeyValuePair<string, string>>();

				int loopSongNumb = -1;
				for (var d = 0; d < currentTierFileData.Count; d++)
				{
					if (currentTierFileData[d].Key == "song")
					{
						loopSongNumb++;
						if (loopSongNumb == destinationIndex)
						{
							newData.Add(currentTierFileData[d - 1]);
						}
						else if (loopSongNumb == indexToMove)
						{
							newData.Add(currentTierFileData[d + 1]);
						}
						else
						{
							newData.Add(currentTierFileData[d]);
						}
					}
					else
					{
						newData.Add(currentTierFileData[d]);
					}
				}

				currentTierFileData = newData;

				int tiernumber = lstTiers.SelectedIndices[0];
				IniFileReader.WriteFile(getTierFilePath(tiernumber), newData);
			}
		}


		private void swapLstTierOptions(int tiernumber, int swapTier)
		{

			var swapData = IniFileReader.ReadFile(getTierFilePath(swapTier));
			var swapUnlockValue = GetUnlockValue(swapData);
			var currentUnlockValue = GetUnlockValue(currentTierFileData);

			currentUnlockValuesForEachTier[tiernumber] = swapUnlockValue;
			currentUnlockValuesForEachTier[swapTier] = currentUnlockValue;

			var currentMin = currentMinRankForEachTier[tiernumber];
			currentMinRankForEachTier[tiernumber] = currentMinRankForEachTier[swapTier];
			currentMinRankForEachTier[swapTier] = currentMin;

			var currentSongNum = currentSongsForEachTier[tiernumber];
			currentSongsForEachTier[tiernumber] = currentSongsForEachTier[swapTier];
			currentSongsForEachTier[swapTier] = currentMin;

			ChangeUnlockValue(swapData, currentUnlockValue);
			ChangeUnlockValue(currentTierFileData, swapUnlockValue);

			IniFileReader.WriteFile(getTierFilePath(tiernumber), swapData);
			IniFileReader.WriteFile(getTierFilePath(swapTier), currentTierFileData);

			var lstTxt1 = lstTiers.Items[tiernumber].Text;
			var lstTxt2 = lstTiers.Items[swapTier].Text;

			lstTiers.Items[tiernumber].Text = GetTierDisplayName(swapData);
			lstTiers.Items[swapTier].Text = GetTierDisplayName(currentTierFileData);

			lstTiers.Items[tiernumber].Selected = false;
			lstTiers.Items[swapTier].Selected = true;
		}
		private void btnMoveTierUp_Click(object sender, EventArgs e)
		{
			if (lstTiers.Items.Count > 0 && lstTiers.SelectedIndices.Count == 1 && lstTiers.SelectedIndices[0] > 0)
			{
				var tiernumber = lstTiers.SelectedIndices[0];
				var swapTier = tiernumber - 1;
				swapLstTierOptions(tiernumber, swapTier);
			}

		}

		private void btnMoveTierDown_Click(object sender, EventArgs e)
		{
			if (lstTiers.Items.Count > 0 && lstTiers.SelectedIndices.Count == 1 && lstTiers.SelectedIndices[0] < lstTiers.Items.Count - 1)
			{
				var tiernumber = lstTiers.SelectedIndices[0];
				var swapTier = tiernumber + 1;
				swapLstTierOptions(tiernumber, swapTier);
			}
		}


		private void btnDisableCareer_Click(object sender, EventArgs e)
		{
			if (SelectedCareerName != null)
			{
				var disabledCareersDir = Path.Combine(psInstallDirectory, "disabledcareers");
				if (!Directory.Exists(disabledCareersDir))
				{
					Directory.CreateDirectory(disabledCareersDir);
				}

				Directory.Move(Path.Combine(psCareerDirectory, SelectedCareerName), Path.Combine(disabledCareersDir, SelectedCareerName));

				lstCareers.Items.RemoveAt(lstCareers.SelectedIndex);
			}

			MessageBox.Show("The campaign was moved to the \"disabledcareers\" folder within the Phase Shift install directory.", "Campaign Removed", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		public static string NormalizePath(string path)
		{
			return Path.GetFullPath(new Uri(path).LocalPath)
					   .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
					   .ToLowerInvariant();
		}

		public static string GetSongPathFromIniFile(string data)
		{
			var fileName = data;
			if (data.Contains("|"))
			{
				fileName = data.Substring(0, data.LastIndexOf("|"));
			}
			if (fileName.EndsWith("\\"))
			{
				fileName = fileName.Substring(0, fileName.Length - 1);
			}

			return NormalizePath(fileName);
		}

		public void LoadFolderIntoListControl(string folder)
		{
			try
			{
				if (Directory.Exists(folder))
				{
					var allFolders = Directory.EnumerateDirectories(folder);
					//var allFiles = Directory.EnumerateFiles(folder); -> don't really need this, do you...

					lstFiles.Items.Clear();

					if (NormalizePath(folder) != NormalizePath(psMusicDirectory))
					{
						lstFiles.Items.Add("..", 0);

					}
					var listOfSongs = new List<string>();


					foreach (var f in allFolders)
					{
						if (File.Exists(Path.Combine(f, "song.ini")))
						{
							string[] instrumentFileNames = { };
							switch ((string)cboInstrument.SelectedItem)
							{
								case "guitar":
								case "guitar_real":
									instrumentFileNames = new string[] { "guitar" };
									break;
								case "bass":
								case "bass_adv":
								case "bass_real":
									instrumentFileNames = new string[] { "rhythm" };
									break;
								case "drums":
								case "drums_adv":
								case "drums_real":
									instrumentFileNames = new string[] { "drums", "drums_1", "drums_2", "drums_3", "drums_4" };
									break;
								case "keys":
								case "keys_adv":
								case "keys_real":
									instrumentFileNames = new string[] { "keys" };
									break;
							}

							bool songcontainsinstrument = false;
							foreach (var i in instrumentFileNames)
							{
								if (File.Exists(Path.Combine(f, i + ".ogg")))
								{
									songcontainsinstrument = true;
									break;
								}
							}
							if (songcontainsinstrument && Path.GetFileName(f).ToLower().Contains(txtSongSearch.Text.ToLower()))
							{
								listOfSongs.Add(Path.GetFileName(f));
							}

						}
						else {
							lstFiles.Items.Add(Path.GetFileName(f), 0);
						}
					}

					foreach (var s in listOfSongs)
					{
						lstFiles.Items.Add(s, instrumentIconIndex);
					}
				}
			}
			catch { }
		}

		public void ReorganizeTiers()
		{
			lstTiers.Items.Clear();
			lstSongs.Items.Clear();
			currentMinRankForEachTier = null;
			currentSongsForEachTier = null;
			currentUnlockValuesForEachTier = null;
			int currentMin = 0;
			if (SelectedCareerName != null)
			{
				string instrument = (string)cboInstrument.SelectedItem;
				currentMinRankForEachTier = new List<int>();
				currentSongsForEachTier = new List<int>();
				currentUnlockValuesForEachTier = new List<int>();

				if (Directory.Exists(Path.Combine(psCareerDirectory, SelectedCareerName, instrument)))
				{
					for (var i = 0; File.Exists(getTierFilePath(i)); i++)
					{
						var tierData = IniFileReader.ReadFile(getTierFilePath(i));
						var tierName = tierData.Where(k => k.Key == "name").Select(v => v.Value).FirstOrDefault() ?? "";
						int numbSongs = tierData.Where(k => k.Key == "song").Count();

						int unlockRank = GetUnlockValue(tierData);

						lstTiers.Items.Add(tierName + " (" + unlockRank + ")");

						currentUnlockValuesForEachTier.Add(unlockRank);

						currentMin = Math.Max(currentMin, unlockRank);
						currentMinRankForEachTier.Add(currentMin);

						currentSongsForEachTier.Add(numbSongs);


					}
				}
			}
		}

		public void RefreshSongList()
		{
			lstSongs.Items.Clear();

			if (lstTiers.SelectedIndices.Count > 0)
			{
				int selectedIndex = lstTiers.SelectedIndices[0];
				foreach (var l in currentTierFileData)
				{
					if (l.Key == "song")
					{
						var fileName = GetSongPathFromIniFile(l.Value);
						lstSongs.Items.Add(Path.GetFileName(fileName), instrumentIconIndex);
					}
				}
			}
		}

		public void UpdateTierFile(List<KeyValuePair<string, string>> tierFileData, string careerName, string instrument, int? tier)
		{
			if (tier == null)
			{
				tier = lstTiers.Items.Count;
			}

			var iPath = Path.Combine(psCareerDirectory, SelectedCareerName, (string)cboInstrument.SelectedItem);
			if (!Directory.Exists(iPath))
			{
				Directory.CreateDirectory(iPath);
			}

			IniFileReader.WriteFile(getTierFilePath(tier.Value), tierFileData);

			ReorganizeTiers();

			lstTiers.Items[lstTiers.Items.Count - 1].Selected = true;
		}

		private string getTierFilePath(int tiernumber)
		{
			return Path.Combine(psCareerDirectory, SelectedCareerName, (string)cboInstrument.SelectedItem, "tier_" + tiernumber + ".ini");
		}

		public string GetTierDisplayName(List<KeyValuePair<string, string>> data)
		{
			return GetTierName(data) + " (" + GetUnlockValue(data) + ")";
		}
		public string GetTierName(List<KeyValuePair<string, string>> data)
		{
			return data.Where(k => k.Key == "name").Select(v => v.Value).FirstOrDefault();
		}
		public int GetUnlockValue(List<KeyValuePair<string, string>> data)
		{
			var tierUnlockValue = data.Where(k => k.Key == "unlock").Select(v => v.Value).FirstOrDefault() ?? "0";
			int tierUnlockInt = 0;
			int.TryParse(tierUnlockValue, out tierUnlockInt);

			return tierUnlockInt;
		}

		public void ChangeUnlockValue(List<KeyValuePair<string, string>> data, int value)
		{
			bool updatedUnlockVal = false;
			for (var i = 0; i < data.Count; i++)
			{
				if (data[i].Key == "unlock")
				{
					data[i] = new KeyValuePair<string, string>("unlock", "" + value);
					updatedUnlockVal = true;
					break;
				}
			}

			if (!updatedUnlockVal)
			{
				data.Add(new KeyValuePair<string, string>("unlock", "" + value));
			}
		}

		private void AddSongsToSelectedTier(string[] fileNames)
		{
			int numbSongsAdded = fileNames.Length;
			if (SelectedCareerName != null && lstTiers.SelectedItems.Count > 0 && numbSongsAdded > 0)
			{
				foreach (var f in fileNames)
				{
					currentTierFileData.Add(new KeyValuePair<string, string>("song", Path.Combine(currentMusicFolder, f)));

					lstSongs.Items.Add(f, instrumentIconIndex);
				}

				var cTier = lstTiers.SelectedIndices[0];

				currentSongsForEachTier[cTier] += numbSongsAdded;

				IniFileReader.WriteFile(getTierFilePath(cTier), currentTierFileData);

				cTier++;

				while (File.Exists(getTierFilePath(cTier)))
				{
					//We want to change the unlock value of it to reflect 
					var cData = IniFileReader.ReadFile(getTierFilePath(cTier));
					ChangeUnlockValue(cData, GetUnlockValue(cData) + numbSongsAdded * 3);
					IniFileReader.WriteFile(getTierFilePath(cTier), cData);

					//Change model data and view.

					if (cTier + 1 < currentMinRankForEachTier.Count)
					{
						currentMinRankForEachTier[cTier + 1] += numbSongsAdded * 3;
					}
					currentUnlockValuesForEachTier[cTier] += numbSongsAdded * 3;

					lstTiers.Items[cTier].Text = GetTierDisplayName(cData);

					cTier++;
				}
			}
		}
		private void RemoveSongsFromSelectedTier(ListView.SelectedIndexCollection songIndecies)
		{
			int numbSongsRemoved = songIndecies.Count;
			if (SelectedCareerName != null && lstTiers.SelectedItems.Count > 0 && numbSongsRemoved > 0)
			{
				int loopSongIndex = lstSongs.Items.Count - 1;
				int songIndeciesIndex = songIndecies.Count - 1;
				for (var i = currentTierFileData.Count - 1; i >= 0; i--)
				{
					if (currentTierFileData[i].Key == "song")
					{
						if (loopSongIndex == songIndecies[songIndeciesIndex])
						{
							currentTierFileData.RemoveAt(i);
							songIndeciesIndex--;
							if (songIndeciesIndex < 0) break;
						}

						loopSongIndex--;
					}
				}

				var cTier = lstTiers.SelectedIndices[0];

				currentSongsForEachTier[cTier] -= numbSongsRemoved;

				IniFileReader.WriteFile(getTierFilePath(cTier), currentTierFileData);

				cTier++;

				while (File.Exists(getTierFilePath(cTier)))
				{
					//We want to change the unlock value of it to reflect 
					var cData = IniFileReader.ReadFile(getTierFilePath(cTier));
					ChangeUnlockValue(cData, GetUnlockValue(cData) - numbSongsRemoved * 3);
					IniFileReader.WriteFile(getTierFilePath(cTier), cData);

					//Change model data and view.

					var reduceUnlockBy = numbSongsRemoved * 3;
					if (currentUnlockValuesForEachTier[cTier] - reduceUnlockBy < currentMinRankForEachTier[cTier])
					{
						reduceUnlockBy = currentUnlockValuesForEachTier[cTier] - currentMinRankForEachTier[cTier];
						currentUnlockValuesForEachTier[cTier] = currentMinRankForEachTier[cTier];
					}
					else {
						currentUnlockValuesForEachTier[cTier] -= numbSongsRemoved * 3;
					}


					if (cTier + 1 < currentMinRankForEachTier.Count)
					{
						currentMinRankForEachTier[cTier + 1] -= reduceUnlockBy;
					}

					lstTiers.Items[cTier].Text = GetTierDisplayName(cData);

					cTier++;
				}
			}
		}

		private void btnClear_Click(object sender, EventArgs e)
		{
			txtSongSearch.Text = "";
		}

		private void txtSongSearch_TextChanged(object sender, EventArgs e)
		{
			LoadFolderIntoListControl(currentMusicFolder);
		}

		private void lstSongs_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void btnNewFolder_Click(object sender, EventArgs e)
		{
			var newFolderDialog = new NewFolder(currentMusicFolder);

			LoadFolderIntoListControl(currentMusicFolder);
		}

		private void btnBrows_Click(object sender, EventArgs e)
		{
			Process.Start(currentMusicFolder);
		}

		private void btnRefresh_Click(object sender, EventArgs e)
		{
			LoadFolderIntoListControl(currentMusicFolder);
		}

		private void btnImportDirs_Click(object sender, EventArgs e)
		{
			var result = directoryImporter.ShowDialog();

			if (result == DialogResult.OK) {
				attemptImport(new string[] { directoryImporter.SelectedPath });
			}
		}

		private void btnImportZips_Click(object sender, EventArgs e)
		{
			var result = compressedFileImporter.ShowDialog();

			if (result == DialogResult.OK)
			{
				attemptImport(compressedFileImporter.FileNames);
			}
		}

		private void tryUnzip(string file) {
			var extension = Path.GetExtension(file).ToLower();
			switch (extension)
			{
				case ".zip":
					ZipFile.ExtractToDirectory(file, currentMusicFolder);
					break;
				//case ".7z":
				//case ".rar":
				default:
					throw new Exception("The following file type is not yet supported: " + extension);
					//DecompressFileLZMA(files[i], Path.Combine(currentMusicFolder, "out"));
					break;
			}
		}

		private void lstFiles_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		}

		private void lstFiles_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			attemptImport(files);

		}


		private void attemptImport(string[] paths) {
			string errorList = "";

			importProgress.Value = 0;

			for (var i = 0; i < paths.Length; i++)
			{
				var path = paths[i];
				try
				{
					if (Directory.Exists(path))
					{
						var folder = path;
						if (folder.EndsWith("\\") || path.EndsWith("/"))
						{
							folder = folder.Substring(0, folder.Length - 1);
						}

						if (!File.Exists(Path.Combine(folder, "song.ini"))) {
							throw new Exception("Not a valid Phase Shift song (to copy directories and subdirectories full of songs, use the file explorer).");
						}
						DirectoryCopy(folder, Path.Combine(currentMusicFolder, Path.GetFileName(folder)), false);
					}
					else if (File.Exists(path))
					{
						var file = path;
						tryUnzip(file);
					}
					else {
						throw new Exception("Could not read file.");
					}
				}
				catch (Exception e) {
					errorList += Path.GetFileName(path) + ":\t";
					errorList += e.Message + Environment.NewLine + Environment.NewLine;
				}

				importProgress.Value = Math.Min(100, (100 * i) / paths.Length);
			}

			LoadFolderIntoListControl(currentMusicFolder);

			if (errorList != "")
			{
				var errMW = new BigErrorDialog(errorList, "Some errors occurred while importing the selected files.");
				errMW.ShowDialog();
			}

			importProgress.Value = 0;
		}

		private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
		{
			// Get the subdirectories for the specified directory.
			DirectoryInfo dir = new DirectoryInfo(sourceDirName);

			if (!dir.Exists)
			{
				throw new DirectoryNotFoundException(
					"Source directory does not exist or could not be found: "
					+ sourceDirName);
			}

			DirectoryInfo[] dirs = dir.GetDirectories();
			// If the destination directory doesn't exist, create it.
			if (!Directory.Exists(destDirName))
			{
				Directory.CreateDirectory(destDirName);
			}

			// Get the files in the directory and copy them to the new location.
			FileInfo[] files = dir.GetFiles();
			foreach (FileInfo file in files)
			{
				string temppath = Path.Combine(destDirName, file.Name);
				file.CopyTo(temppath, false);
			}

			// If copying subdirectories, copy them and their contents to new location.
			if (copySubDirs)
			{
				foreach (DirectoryInfo subdir in dirs)
				{
					string temppath = Path.Combine(destDirName, subdir.Name);
					DirectoryCopy(subdir.FullName, temppath, copySubDirs);
				}
			}
		}
	}
}
