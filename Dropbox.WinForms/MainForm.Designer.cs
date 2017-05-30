namespace Dropbox.WinForms
{
	partial class MainForm
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
			this.lbFiles = new System.Windows.Forms.ListBox();
			this.btAddFile = new System.Windows.Forms.Button();
			this.btDeleteFile = new System.Windows.Forms.Button();
			this.btDownload = new System.Windows.Forms.Button();
			this.lbUserNameLabel = new System.Windows.Forms.Label();
			this.lbUserName = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lbFiles
			// 
			this.lbFiles.DisplayMember = "Name";
			this.lbFiles.FormattingEnabled = true;
			this.lbFiles.Location = new System.Drawing.Point(12, 38);
			this.lbFiles.Name = "lbFiles";
			this.lbFiles.Size = new System.Drawing.Size(240, 199);
			this.lbFiles.TabIndex = 0;
			// 
			// btAddFile
			// 
			this.btAddFile.Location = new System.Drawing.Point(12, 255);
			this.btAddFile.Name = "btAddFile";
			this.btAddFile.Size = new System.Drawing.Size(75, 23);
			this.btAddFile.TabIndex = 1;
			this.btAddFile.Text = "Добавить";
			this.btAddFile.UseVisualStyleBackColor = true;
			this.btAddFile.Click += new System.EventHandler(this.btAddFile_Click);
			// 
			// btDeleteFile
			// 
			this.btDeleteFile.Location = new System.Drawing.Point(95, 255);
			this.btDeleteFile.Name = "btDeleteFile";
			this.btDeleteFile.Size = new System.Drawing.Size(75, 23);
			this.btDeleteFile.TabIndex = 2;
			this.btDeleteFile.Text = "Удалить";
			this.btDeleteFile.UseVisualStyleBackColor = true;
			this.btDeleteFile.Click += new System.EventHandler(this.btDeleteFile_Click);
			// 
			// btDownload
			// 
			this.btDownload.Location = new System.Drawing.Point(177, 255);
			this.btDownload.Name = "btDownload";
			this.btDownload.Size = new System.Drawing.Size(75, 23);
			this.btDownload.TabIndex = 3;
			this.btDownload.Text = "Скачать";
			this.btDownload.UseVisualStyleBackColor = true;
			this.btDownload.Click += new System.EventHandler(this.btDownload_Click);
			// 
			// lbUserNameLabel
			// 
			this.lbUserNameLabel.AutoSize = true;
			this.lbUserNameLabel.Location = new System.Drawing.Point(13, 13);
			this.lbUserNameLabel.Name = "lbUserNameLabel";
			this.lbUserNameLabel.Size = new System.Drawing.Size(129, 13);
			this.lbUserNameLabel.TabIndex = 4;
			this.lbUserNameLabel.Text = "Текущий пользователь:";
			// 
			// lbUserName
			// 
			this.lbUserName.AutoSize = true;
			this.lbUserName.Location = new System.Drawing.Point(145, 13);
			this.lbUserName.Name = "lbUserName";
			this.lbUserName.Size = new System.Drawing.Size(0, 13);
			this.lbUserName.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(266, 295);
			this.Controls.Add(this.lbUserName);
			this.Controls.Add(this.lbUserNameLabel);
			this.Controls.Add(this.btDownload);
			this.Controls.Add(this.btDeleteFile);
			this.Controls.Add(this.btAddFile);
			this.Controls.Add(this.lbFiles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Dropbox";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbFiles;
		private System.Windows.Forms.Button btAddFile;
		private System.Windows.Forms.Button btDeleteFile;
		private System.Windows.Forms.Button btDownload;
		private System.Windows.Forms.Label lbUserNameLabel;
		private System.Windows.Forms.Label lbUserName;
	}
}

