namespace PhaseShiftCareerEditor
{
	partial class BigErrorDialog
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
			this.txtErrors = new System.Windows.Forms.TextBox();
			this.btnDone = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtErrors
			// 
			this.txtErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtErrors.BackColor = System.Drawing.SystemColors.Window;
			this.txtErrors.ForeColor = System.Drawing.Color.Maroon;
			this.txtErrors.Location = new System.Drawing.Point(12, 12);
			this.txtErrors.Multiline = true;
			this.txtErrors.Name = "txtErrors";
			this.txtErrors.ReadOnly = true;
			this.txtErrors.Size = new System.Drawing.Size(647, 297);
			this.txtErrors.TabIndex = 0;
			// 
			// btnDone
			// 
			this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDone.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnDone.Location = new System.Drawing.Point(12, 315);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(75, 23);
			this.btnDone.TabIndex = 1;
			this.btnDone.Text = "Close";
			this.btnDone.UseVisualStyleBackColor = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// BigErrorDialog
			// 
			this.AcceptButton = this.btnDone;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnDone;
			this.ClientSize = new System.Drawing.Size(671, 350);
			this.Controls.Add(this.btnDone);
			this.Controls.Add(this.txtErrors);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BigErrorDialog";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "Errors";
			this.Load += new System.EventHandler(this.BigErrorDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtErrors;
		private System.Windows.Forms.Button btnDone;
	}
}