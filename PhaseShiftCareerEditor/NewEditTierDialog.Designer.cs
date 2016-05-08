namespace PhaseShiftCareerEditor
{
	partial class NewEditTierDialog
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
			this.label2 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.txtTierName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.barRank = new System.Windows.Forms.TrackBar();
			this.txtRank = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.barRank)).BeginInit();
			this.SuspendLayout();
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 38);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Rank:";
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(197, 96);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 4;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnOk.Location = new System.Drawing.Point(12, 96);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 3;
			this.btnOk.Text = "Done";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// txtTierName
			// 
			this.txtTierName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtTierName.Location = new System.Drawing.Point(72, 6);
			this.txtTierName.Name = "txtTierName";
			this.txtTierName.Size = new System.Drawing.Size(197, 20);
			this.txtTierName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(38, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Name:";
			// 
			// barRank
			// 
			this.barRank.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.barRank.LargeChange = 1;
			this.barRank.Location = new System.Drawing.Point(54, 38);
			this.barRank.Maximum = 100;
			this.barRank.Name = "barRank";
			this.barRank.Size = new System.Drawing.Size(175, 45);
			this.barRank.TabIndex = 2;
			this.barRank.TickFrequency = 3;
			this.barRank.TickStyle = System.Windows.Forms.TickStyle.Both;
			this.toolTip1.SetToolTip(this.barRank, "Specifies the career rank required to unlock this tier. Default is 50% (an averag" +
        "e of 3/6 rank points per song).");
			this.barRank.Value = 50;
			this.barRank.Scroll += new System.EventHandler(this.barRank_Scroll);
			// 
			// txtRank
			// 
			this.txtRank.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.txtRank.Location = new System.Drawing.Point(235, 49);
			this.txtRank.Name = "txtRank";
			this.txtRank.Size = new System.Drawing.Size(38, 20);
			this.txtRank.TabIndex = 12;
			this.txtRank.TabStop = false;
			// 
			// NewEditTierDialog
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(284, 131);
			this.Controls.Add(this.txtRank);
			this.Controls.Add(this.barRank);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.txtTierName);
			this.Controls.Add(this.label1);
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(300, 170);
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(300, 170);
			this.Name = "NewEditTierDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "NewEditTierDialog";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.NewEditTierDialog_Load);
			((System.ComponentModel.ISupportInitialize)(this.barRank)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TextBox txtTierName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.TrackBar barRank;
		private System.Windows.Forms.TextBox txtRank;
	}
}