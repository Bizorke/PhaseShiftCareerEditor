namespace PhaseShiftCareerEditor
{
	partial class frmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
			this.imgIcons = new System.Windows.Forms.ImageList(this.components);
			this.lstFiles = new System.Windows.Forms.ListView();
			this.colFiles = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.lstTiers = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnDeleteTier = new System.Windows.Forms.Button();
			this.lstSongs = new System.Windows.Forms.ListView();
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnRemoveSong = new System.Windows.Forms.Button();
			this.cboInstrument = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnAddSongs = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.txtSongSearch = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.btnAddTier = new System.Windows.Forms.Button();
			this.lstCareers = new System.Windows.Forms.ListBox();
			this.btnNewCareer = new System.Windows.Forms.Button();
			this.btnDisableCareer = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.installDirFinder = new System.Windows.Forms.FolderBrowserDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.btnImportDirs = new System.Windows.Forms.Button();
			this.btnImportZips = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			this.btnBrows = new System.Windows.Forms.Button();
			this.btnNewFolder = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnMoveSongDown = new System.Windows.Forms.Button();
			this.btnMoveSongUp = new System.Windows.Forms.Button();
			this.btnMoveTierDown = new System.Windows.Forms.Button();
			this.btnMoveTierUp = new System.Windows.Forms.Button();
			this.directoryImporter = new System.Windows.Forms.FolderBrowserDialog();
			this.compressedFileImporter = new System.Windows.Forms.OpenFileDialog();
			this.importProgress = new System.Windows.Forms.ProgressBar();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// imgIcons
			// 
			this.imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcons.ImageStream")));
			this.imgIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imgIcons.Images.SetKeyName(0, "folder.png");
			this.imgIcons.Images.SetKeyName(1, "music.png");
			this.imgIcons.Images.SetKeyName(2, "warning.png");
			this.imgIcons.Images.SetKeyName(3, "electric_guitar.png");
			this.imgIcons.Images.SetKeyName(4, "acoustic_guitar.png");
			this.imgIcons.Images.SetKeyName(5, "drum.png");
			this.imgIcons.Images.SetKeyName(6, "piano.png");
			// 
			// lstFiles
			// 
			this.lstFiles.AllowDrop = true;
			this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstFiles.BackColor = System.Drawing.SystemColors.Window;
			this.lstFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colFiles});
			this.lstFiles.HideSelection = false;
			this.lstFiles.LargeImageList = this.imgIcons;
			this.lstFiles.Location = new System.Drawing.Point(6, 69);
			this.lstFiles.Name = "lstFiles";
			this.lstFiles.Size = new System.Drawing.Size(435, 369);
			this.lstFiles.SmallImageList = this.imgIcons;
			this.lstFiles.StateImageList = this.imgIcons;
			this.lstFiles.TabIndex = 6;
			this.lstFiles.UseCompatibleStateImageBehavior = false;
			this.lstFiles.View = System.Windows.Forms.View.Details;
			this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
			this.lstFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragDrop);
			this.lstFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lstFiles_DragEnter);
			this.lstFiles.DoubleClick += new System.EventHandler(this.lstFiles_DoubleClick);
			this.lstFiles.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstFiles_KeyPress);
			// 
			// colFiles
			// 
			this.colFiles.Text = "Music (drag + drop folders/zip/etc to import)";
			this.colFiles.Width = 389;
			// 
			// lstTiers
			// 
			this.lstTiers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lstTiers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
			this.lstTiers.HideSelection = false;
			this.lstTiers.Location = new System.Drawing.Point(447, 19);
			this.lstTiers.MultiSelect = false;
			this.lstTiers.Name = "lstTiers";
			this.lstTiers.Size = new System.Drawing.Size(300, 176);
			this.lstTiers.TabIndex = 7;
			this.lstTiers.UseCompatibleStateImageBehavior = false;
			this.lstTiers.View = System.Windows.Forms.View.Details;
			this.lstTiers.SelectedIndexChanged += new System.EventHandler(this.lstTiers_SelectedIndexChanged);
			this.lstTiers.DoubleClick += new System.EventHandler(this.lstTiers_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Tiers";
			this.columnHeader1.Width = 187;
			// 
			// btnDeleteTier
			// 
			this.btnDeleteTier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteTier.Location = new System.Drawing.Point(539, 201);
			this.btnDeleteTier.Name = "btnDeleteTier";
			this.btnDeleteTier.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteTier.TabIndex = 9;
			this.btnDeleteTier.Text = "Delete";
			this.btnDeleteTier.UseVisualStyleBackColor = true;
			this.btnDeleteTier.Click += new System.EventHandler(this.btnDeleteTier_Click);
			// 
			// lstSongs
			// 
			this.lstSongs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstSongs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
			this.lstSongs.HideSelection = false;
			this.lstSongs.LargeImageList = this.imgIcons;
			this.lstSongs.Location = new System.Drawing.Point(447, 230);
			this.lstSongs.Name = "lstSongs";
			this.lstSongs.Size = new System.Drawing.Size(300, 209);
			this.lstSongs.SmallImageList = this.imgIcons;
			this.lstSongs.StateImageList = this.imgIcons;
			this.lstSongs.TabIndex = 12;
			this.lstSongs.UseCompatibleStateImageBehavior = false;
			this.lstSongs.View = System.Windows.Forms.View.Details;
			this.lstSongs.SelectedIndexChanged += new System.EventHandler(this.lstSongs_SelectedIndexChanged);
			this.lstSongs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lstSongs_KeyPress);
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Songs in Tier";
			this.columnHeader2.Width = 0;
			// 
			// btnRemoveSong
			// 
			this.btnRemoveSong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRemoveSong.Location = new System.Drawing.Point(539, 445);
			this.btnRemoveSong.Name = "btnRemoveSong";
			this.btnRemoveSong.Size = new System.Drawing.Size(75, 23);
			this.btnRemoveSong.TabIndex = 14;
			this.btnRemoveSong.Text = "Remove";
			this.btnRemoveSong.UseVisualStyleBackColor = true;
			this.btnRemoveSong.Click += new System.EventHandler(this.btnRemoveSong_Click);
			// 
			// cboInstrument
			// 
			this.cboInstrument.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cboInstrument.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cboInstrument.FormattingEnabled = true;
			this.cboInstrument.Items.AddRange(new object[] {
            "guitar",
            "guitar_real",
            "bass",
            "bass_real",
            "drums",
            "drums_adv",
            "drums_real",
            "keys",
            "keys_adv",
            "keys_real"});
			this.cboInstrument.Location = new System.Drawing.Point(44, 16);
			this.cboInstrument.Name = "cboInstrument";
			this.cboInstrument.Size = new System.Drawing.Size(397, 21);
			this.cboInstrument.TabIndex = 3;
			this.cboInstrument.SelectedIndexChanged += new System.EventHandler(this.cboInstrument_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Filter:";
			// 
			// btnAddSongs
			// 
			this.btnAddSongs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddSongs.Location = new System.Drawing.Point(447, 445);
			this.btnAddSongs.Name = "btnAddSongs";
			this.btnAddSongs.Size = new System.Drawing.Size(86, 23);
			this.btnAddSongs.TabIndex = 13;
			this.btnAddSongs.Text = "Add Selected";
			this.btnAddSongs.UseVisualStyleBackColor = true;
			this.btnAddSongs.Click += new System.EventHandler(this.btnAddSongs_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.importProgress);
			this.groupBox2.Controls.Add(this.btnImportDirs);
			this.groupBox2.Controls.Add(this.btnImportZips);
			this.groupBox2.Controls.Add(this.btnRefresh);
			this.groupBox2.Controls.Add(this.btnBrows);
			this.groupBox2.Controls.Add(this.btnNewFolder);
			this.groupBox2.Controls.Add(this.btnClear);
			this.groupBox2.Controls.Add(this.txtSongSearch);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.btnMoveSongDown);
			this.groupBox2.Controls.Add(this.btnMoveSongUp);
			this.groupBox2.Controls.Add(this.btnMoveTierDown);
			this.groupBox2.Controls.Add(this.btnMoveTierUp);
			this.groupBox2.Controls.Add(this.btnAddSongs);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Controls.Add(this.cboInstrument);
			this.groupBox2.Controls.Add(this.btnRemoveSong);
			this.groupBox2.Controls.Add(this.lstSongs);
			this.groupBox2.Controls.Add(this.btnDeleteTier);
			this.groupBox2.Controls.Add(this.btnAddTier);
			this.groupBox2.Controls.Add(this.lstTiers);
			this.groupBox2.Controls.Add(this.lstFiles);
			this.groupBox2.Location = new System.Drawing.Point(218, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(753, 474);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Songs";
			// 
			// txtSongSearch
			// 
			this.txtSongSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSongSearch.Location = new System.Drawing.Point(81, 43);
			this.txtSongSearch.Name = "txtSongSearch";
			this.txtSongSearch.Size = new System.Drawing.Size(330, 20);
			this.txtSongSearch.TabIndex = 4;
			this.txtSongSearch.TextChanged += new System.EventHandler(this.txtSongSearch_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Search Filter:";
			// 
			// btnAddTier
			// 
			this.btnAddTier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddTier.Location = new System.Drawing.Point(447, 201);
			this.btnAddTier.Name = "btnAddTier";
			this.btnAddTier.Size = new System.Drawing.Size(86, 23);
			this.btnAddTier.TabIndex = 8;
			this.btnAddTier.Text = "New";
			this.btnAddTier.UseVisualStyleBackColor = true;
			this.btnAddTier.Click += new System.EventHandler(this.btnAddTier_Click);
			// 
			// lstCareers
			// 
			this.lstCareers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.lstCareers.FormattingEnabled = true;
			this.lstCareers.Location = new System.Drawing.Point(6, 19);
			this.lstCareers.Name = "lstCareers";
			this.lstCareers.Size = new System.Drawing.Size(188, 407);
			this.lstCareers.TabIndex = 0;
			this.lstCareers.SelectedIndexChanged += new System.EventHandler(this.lstCareers_SelectedIndexChanged);
			this.lstCareers.DoubleClick += new System.EventHandler(this.lstCareers_DoubleClick);
			// 
			// btnNewCareer
			// 
			this.btnNewCareer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNewCareer.Location = new System.Drawing.Point(6, 445);
			this.btnNewCareer.Name = "btnNewCareer";
			this.btnNewCareer.Size = new System.Drawing.Size(75, 23);
			this.btnNewCareer.TabIndex = 1;
			this.btnNewCareer.Text = "New";
			this.btnNewCareer.UseVisualStyleBackColor = true;
			this.btnNewCareer.Click += new System.EventHandler(this.btnNewCareer_Click);
			// 
			// btnDisableCareer
			// 
			this.btnDisableCareer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDisableCareer.Location = new System.Drawing.Point(87, 445);
			this.btnDisableCareer.Name = "btnDisableCareer";
			this.btnDisableCareer.Size = new System.Drawing.Size(75, 23);
			this.btnDisableCareer.TabIndex = 2;
			this.btnDisableCareer.Text = "Disable";
			this.btnDisableCareer.UseVisualStyleBackColor = true;
			this.btnDisableCareer.Click += new System.EventHandler(this.btnDisableCareer_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.groupBox1.Controls.Add(this.btnDisableCareer);
			this.groupBox1.Controls.Add(this.btnNewCareer);
			this.groupBox1.Controls.Add(this.lstCareers);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 474);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Careers";
			// 
			// installDirFinder
			// 
			this.installDirFinder.ShowNewFolderButton = false;
			// 
			// btnImportDirs
			// 
			this.btnImportDirs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImportDirs.Image = global::PhaseShiftCareerEditor.Properties.Resources.saved_imports;
			this.btnImportDirs.Location = new System.Drawing.Point(146, 444);
			this.btnImportDirs.Name = "btnImportDirs";
			this.btnImportDirs.Size = new System.Drawing.Size(24, 24);
			this.btnImportDirs.TabIndex = 21;
			this.toolTip1.SetToolTip(this.btnImportDirs, "Import songs by selecting compressed files. Tip: it may be faster to drag and dro" +
        "p them into the above view.");
			this.btnImportDirs.UseVisualStyleBackColor = true;
			this.btnImportDirs.Click += new System.EventHandler(this.btnImportDirs_Click);
			// 
			// btnImportZips
			// 
			this.btnImportZips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnImportZips.Image = global::PhaseShiftCareerEditor.Properties.Resources.folder_vertical_zipper;
			this.btnImportZips.Location = new System.Drawing.Point(116, 444);
			this.btnImportZips.Name = "btnImportZips";
			this.btnImportZips.Size = new System.Drawing.Size(24, 24);
			this.btnImportZips.TabIndex = 20;
			this.toolTip1.SetToolTip(this.btnImportZips, "Import songs by selecting compressed files.");
			this.btnImportZips.UseVisualStyleBackColor = true;
			this.btnImportZips.Click += new System.EventHandler(this.btnImportZips_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnRefresh.Image = global::PhaseShiftCareerEditor.Properties.Resources.arrow_refresh;
			this.btnRefresh.Location = new System.Drawing.Point(66, 444);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(24, 24);
			this.btnRefresh.TabIndex = 19;
			this.toolTip1.SetToolTip(this.btnRefresh, "Refresh view.");
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// btnBrows
			// 
			this.btnBrows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnBrows.Image = global::PhaseShiftCareerEditor.Properties.Resources.folder_explorer;
			this.btnBrows.Location = new System.Drawing.Point(36, 444);
			this.btnBrows.Name = "btnBrows";
			this.btnBrows.Size = new System.Drawing.Size(24, 24);
			this.btnBrows.TabIndex = 18;
			this.toolTip1.SetToolTip(this.btnBrows, "Open in file explorer.");
			this.btnBrows.UseVisualStyleBackColor = true;
			this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
			// 
			// btnNewFolder
			// 
			this.btnNewFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnNewFolder.Image = global::PhaseShiftCareerEditor.Properties.Resources.folder_add;
			this.btnNewFolder.Location = new System.Drawing.Point(6, 444);
			this.btnNewFolder.Name = "btnNewFolder";
			this.btnNewFolder.Size = new System.Drawing.Size(24, 24);
			this.btnNewFolder.TabIndex = 17;
			this.toolTip1.SetToolTip(this.btnNewFolder, "Add new directory.");
			this.btnNewFolder.UseVisualStyleBackColor = true;
			this.btnNewFolder.Click += new System.EventHandler(this.btnNewFolder_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Image = global::PhaseShiftCareerEditor.Properties.Resources.filter_clear;
			this.btnClear.Location = new System.Drawing.Point(417, 40);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(24, 24);
			this.btnClear.TabIndex = 5;
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// btnMoveSongDown
			// 
			this.btnMoveSongDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveSongDown.Image = global::PhaseShiftCareerEditor.Properties.Resources.arrow_down;
			this.btnMoveSongDown.Location = new System.Drawing.Point(721, 445);
			this.btnMoveSongDown.Name = "btnMoveSongDown";
			this.btnMoveSongDown.Size = new System.Drawing.Size(23, 23);
			this.btnMoveSongDown.TabIndex = 16;
			this.btnMoveSongDown.UseVisualStyleBackColor = true;
			this.btnMoveSongDown.Click += new System.EventHandler(this.btnMoveSongDown_Click);
			// 
			// btnMoveSongUp
			// 
			this.btnMoveSongUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveSongUp.Image = global::PhaseShiftCareerEditor.Properties.Resources.arrow_up;
			this.btnMoveSongUp.Location = new System.Drawing.Point(692, 445);
			this.btnMoveSongUp.Name = "btnMoveSongUp";
			this.btnMoveSongUp.Size = new System.Drawing.Size(23, 23);
			this.btnMoveSongUp.TabIndex = 15;
			this.btnMoveSongUp.UseVisualStyleBackColor = true;
			this.btnMoveSongUp.Click += new System.EventHandler(this.btnMoveSongUp_Click);
			// 
			// btnMoveTierDown
			// 
			this.btnMoveTierDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveTierDown.Image = global::PhaseShiftCareerEditor.Properties.Resources.arrow_down;
			this.btnMoveTierDown.Location = new System.Drawing.Point(721, 201);
			this.btnMoveTierDown.Name = "btnMoveTierDown";
			this.btnMoveTierDown.Size = new System.Drawing.Size(23, 23);
			this.btnMoveTierDown.TabIndex = 11;
			this.btnMoveTierDown.UseVisualStyleBackColor = true;
			this.btnMoveTierDown.Click += new System.EventHandler(this.btnMoveTierDown_Click);
			// 
			// btnMoveTierUp
			// 
			this.btnMoveTierUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnMoveTierUp.Image = global::PhaseShiftCareerEditor.Properties.Resources.arrow_up;
			this.btnMoveTierUp.Location = new System.Drawing.Point(692, 201);
			this.btnMoveTierUp.Name = "btnMoveTierUp";
			this.btnMoveTierUp.Size = new System.Drawing.Size(23, 23);
			this.btnMoveTierUp.TabIndex = 10;
			this.btnMoveTierUp.UseVisualStyleBackColor = true;
			this.btnMoveTierUp.Click += new System.EventHandler(this.btnMoveTierUp_Click);
			// 
			// directoryImporter
			// 
			this.directoryImporter.Description = "Select folders containing music to import.";
			this.directoryImporter.ShowNewFolderButton = false;
			// 
			// compressedFileImporter
			// 
			this.compressedFileImporter.Multiselect = true;
			// 
			// importProgress
			// 
			this.importProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.importProgress.Location = new System.Drawing.Point(176, 444);
			this.importProgress.Name = "importProgress";
			this.importProgress.Size = new System.Drawing.Size(265, 23);
			this.importProgress.TabIndex = 22;
			// 
			// frmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(985, 498);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(767, 392);
			this.Name = "frmMain";
			this.Text = "JSideris\' Phase Shift Career Editor V0.1";
			this.Load += new System.EventHandler(this.frmMain_Load);
			this.Resize += new System.EventHandler(this.frmMain_Resize);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ImageList imgIcons;
		private System.Windows.Forms.ListView lstFiles;
		private System.Windows.Forms.ColumnHeader colFiles;
		private System.Windows.Forms.ListView lstTiers;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button btnDeleteTier;
		private System.Windows.Forms.ListView lstSongs;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Button btnRemoveSong;
		private System.Windows.Forms.ComboBox cboInstrument;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnAddSongs;
		private System.Windows.Forms.Button btnMoveTierUp;
		private System.Windows.Forms.Button btnMoveTierDown;
		private System.Windows.Forms.Button btnMoveSongUp;
		private System.Windows.Forms.Button btnMoveSongDown;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button btnAddTier;
		private System.Windows.Forms.ListBox lstCareers;
		private System.Windows.Forms.Button btnNewCareer;
		private System.Windows.Forms.Button btnDisableCareer;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.FolderBrowserDialog installDirFinder;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox txtSongSearch;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnNewFolder;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Button btnBrows;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.Button btnImportZips;
		private System.Windows.Forms.Button btnImportDirs;
		private System.Windows.Forms.FolderBrowserDialog directoryImporter;
		private System.Windows.Forms.OpenFileDialog compressedFileImporter;
		private System.Windows.Forms.ProgressBar importProgress;
	}
}

