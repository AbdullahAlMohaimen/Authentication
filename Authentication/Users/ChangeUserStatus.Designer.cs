namespace Authentication.Users
{
	partial class ChangeUserStatus
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeUserStatus));
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtHeader = new System.Windows.Forms.Label();
			this.Minimize = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.label4 = new System.Windows.Forms.Label();
			this.isPasswordExpired = new Guna.UI2.WinForms.Guna2CheckBox();
			this.label3 = new System.Windows.Forms.Label();
			this.isLocked = new Guna.UI2.WinForms.Guna2CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.isInActive = new Guna.UI2.WinForms.Guna2CheckBox();
			this.label21 = new System.Windows.Forms.Label();
			this.isActive = new Guna.UI2.WinForms.Guna2CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.statusString = new System.Windows.Forms.Label();
			this.ChangeStatus = new Guna.UI2.WinForms.Guna2Button();
			this.Cancel = new Guna.UI2.WinForms.Guna2Button();
			this.label5 = new System.Windows.Forms.Label();
			this.txt_User = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SeaGreen;
			this.panel1.Controls.Add(this.txtHeader);
			this.panel1.Controls.Add(this.Minimize);
			this.panel1.Controls.Add(this.Exit);
			this.panel1.Location = new System.Drawing.Point(-2, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(566, 30);
			this.panel1.TabIndex = 13;
			// 
			// txtHeader
			// 
			this.txtHeader.AutoSize = true;
			this.txtHeader.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtHeader.ForeColor = System.Drawing.Color.Salmon;
			this.txtHeader.Location = new System.Drawing.Point(8, 0);
			this.txtHeader.Name = "txtHeader";
			this.txtHeader.Size = new System.Drawing.Size(210, 25);
			this.txtHeader.TabIndex = 106;
			this.txtHeader.Text = "Change User Status";
			// 
			// Minimize
			// 
			this.Minimize.BackColor = System.Drawing.Color.SeaGreen;
			this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
			this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Minimize.FlatAppearance.BorderSize = 0;
			this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Minimize.Location = new System.Drawing.Point(494, 3);
			this.Minimize.Name = "Minimize";
			this.Minimize.Size = new System.Drawing.Size(24, 24);
			this.Minimize.TabIndex = 12;
			this.Minimize.UseVisualStyleBackColor = false;
			this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.Color.SeaGreen;
			this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
			this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Exit.FlatAppearance.BorderSize = 0;
			this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Exit.Location = new System.Drawing.Point(533, 3);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(24, 24);
			this.Exit.TabIndex = 11;
			this.Exit.UseVisualStyleBackColor = false;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.label4);
			this.guna2Panel1.Controls.Add(this.isPasswordExpired);
			this.guna2Panel1.Controls.Add(this.label3);
			this.guna2Panel1.Controls.Add(this.isLocked);
			this.guna2Panel1.Controls.Add(this.label2);
			this.guna2Panel1.Controls.Add(this.isInActive);
			this.guna2Panel1.Controls.Add(this.label21);
			this.guna2Panel1.Controls.Add(this.isActive);
			this.guna2Panel1.Location = new System.Drawing.Point(6, 87);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(552, 47);
			this.guna2Panel1.TabIndex = 108;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label4.Location = new System.Drawing.Point(378, 12);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(154, 21);
			this.label4.TabIndex = 184;
			this.label4.Text = "Password Expired";
			// 
			// isPasswordExpired
			// 
			this.isPasswordExpired.AutoSize = true;
			this.isPasswordExpired.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isPasswordExpired.CheckedState.BorderRadius = 0;
			this.isPasswordExpired.CheckedState.BorderThickness = 0;
			this.isPasswordExpired.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isPasswordExpired.Location = new System.Drawing.Point(355, 16);
			this.isPasswordExpired.Name = "isPasswordExpired";
			this.isPasswordExpired.Size = new System.Drawing.Size(15, 14);
			this.isPasswordExpired.TabIndex = 185;
			this.isPasswordExpired.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isPasswordExpired.UncheckedState.BorderRadius = 0;
			this.isPasswordExpired.UncheckedState.BorderThickness = 0;
			this.isPasswordExpired.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isPasswordExpired.CheckedChanged += new System.EventHandler(this.isPasswordExpired_CheckedChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label3.Location = new System.Drawing.Point(290, 12);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(46, 21);
			this.label3.TabIndex = 182;
			this.label3.Text = "Lock";
			// 
			// isLocked
			// 
			this.isLocked.AutoSize = true;
			this.isLocked.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isLocked.CheckedState.BorderRadius = 0;
			this.isLocked.CheckedState.BorderThickness = 0;
			this.isLocked.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isLocked.Location = new System.Drawing.Point(267, 16);
			this.isLocked.Name = "isLocked";
			this.isLocked.Size = new System.Drawing.Size(15, 14);
			this.isLocked.TabIndex = 183;
			this.isLocked.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isLocked.UncheckedState.BorderRadius = 0;
			this.isLocked.UncheckedState.BorderThickness = 0;
			this.isLocked.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isLocked.CheckedChanged += new System.EventHandler(this.isLocked_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label2.Location = new System.Drawing.Point(157, 12);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(91, 21);
			this.label2.TabIndex = 180;
			this.label2.Text = "In-Active";
			// 
			// isInActive
			// 
			this.isInActive.AutoSize = true;
			this.isInActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isInActive.CheckedState.BorderRadius = 0;
			this.isInActive.CheckedState.BorderThickness = 0;
			this.isInActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isInActive.Location = new System.Drawing.Point(134, 16);
			this.isInActive.Name = "isInActive";
			this.isInActive.Size = new System.Drawing.Size(15, 14);
			this.isInActive.TabIndex = 181;
			this.isInActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isInActive.UncheckedState.BorderRadius = 0;
			this.isInActive.UncheckedState.BorderThickness = 0;
			this.isInActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isInActive.CheckedChanged += new System.EventHandler(this.isInActive_CheckedChanged);
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label21.Location = new System.Drawing.Point(45, 12);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(64, 21);
			this.label21.TabIndex = 178;
			this.label21.Text = "Active";
			// 
			// isActive
			// 
			this.isActive.AutoSize = true;
			this.isActive.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isActive.CheckedState.BorderRadius = 0;
			this.isActive.CheckedState.BorderThickness = 0;
			this.isActive.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.isActive.Location = new System.Drawing.Point(22, 16);
			this.isActive.Name = "isActive";
			this.isActive.Size = new System.Drawing.Size(15, 14);
			this.isActive.TabIndex = 179;
			this.isActive.UncheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isActive.UncheckedState.BorderRadius = 0;
			this.isActive.UncheckedState.BorderThickness = 0;
			this.isActive.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(137)))), ((int)(((byte)(149)))));
			this.isActive.CheckedChanged += new System.EventHandler(this.isActive_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Maroon;
			this.label1.Location = new System.Drawing.Point(8, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 16);
			this.label1.TabIndex = 109;
			this.label1.Text = "This User is now  :  ";
			// 
			// statusString
			// 
			this.statusString.AutoSize = true;
			this.statusString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.statusString.ForeColor = System.Drawing.Color.SeaGreen;
			this.statusString.Location = new System.Drawing.Point(141, 64);
			this.statusString.Name = "statusString";
			this.statusString.Size = new System.Drawing.Size(0, 16);
			this.statusString.TabIndex = 110;
			// 
			// ChangeStatus
			// 
			this.ChangeStatus.BorderRadius = 8;
			this.ChangeStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.ChangeStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.ChangeStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.ChangeStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.ChangeStatus.FillColor = System.Drawing.Color.SeaGreen;
			this.ChangeStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.ChangeStatus.ForeColor = System.Drawing.Color.Wheat;
			this.ChangeStatus.Image = ((System.Drawing.Image)(resources.GetObject("ChangeStatus.Image")));
			this.ChangeStatus.Location = new System.Drawing.Point(452, 139);
			this.ChangeStatus.Name = "ChangeStatus";
			this.ChangeStatus.Size = new System.Drawing.Size(100, 29);
			this.ChangeStatus.TabIndex = 111;
			this.ChangeStatus.Text = "  Save";
			this.ChangeStatus.Click += new System.EventHandler(this.ChangeStatus_Click);
			// 
			// Cancel
			// 
			this.Cancel.BorderRadius = 8;
			this.Cancel.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.Cancel.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.Cancel.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.Cancel.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.Cancel.FillColor = System.Drawing.Color.Brown;
			this.Cancel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Cancel.ForeColor = System.Drawing.Color.Wheat;
			this.Cancel.Image = ((System.Drawing.Image)(resources.GetObject("Cancel.Image")));
			this.Cancel.Location = new System.Drawing.Point(346, 139);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(100, 29);
			this.Cancel.TabIndex = 112;
			this.Cancel.Text = " Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Maroon;
			this.label5.Location = new System.Drawing.Point(8, 46);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 16);
			this.label5.TabIndex = 113;
			this.label5.Text = "User  :";
			// 
			// txt_User
			// 
			this.txt_User.AutoSize = true;
			this.txt_User.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_User.ForeColor = System.Drawing.Color.Maroon;
			this.txt_User.Location = new System.Drawing.Point(66, 46);
			this.txt_User.Name = "txt_User";
			this.txt_User.Size = new System.Drawing.Size(0, 16);
			this.txt_User.TabIndex = 114;
			// 
			// ChangeUserStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(564, 173);
			this.ControlBox = false;
			this.Controls.Add(this.txt_User);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.ChangeStatus);
			this.Controls.Add(this.Cancel);
			this.Controls.Add(this.statusString);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.guna2Panel1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ChangeUserStatus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label txtHeader;
		private System.Windows.Forms.Button Minimize;
		private System.Windows.Forms.Button Exit;
		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private System.Windows.Forms.Label label21;
		private Guna.UI2.WinForms.Guna2CheckBox isActive;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label statusString;
		private System.Windows.Forms.Label label2;
		private Guna.UI2.WinForms.Guna2CheckBox isInActive;
		private System.Windows.Forms.Label label4;
		private Guna.UI2.WinForms.Guna2CheckBox isPasswordExpired;
		private System.Windows.Forms.Label label3;
		private Guna.UI2.WinForms.Guna2CheckBox isLocked;
		private Guna.UI2.WinForms.Guna2Button ChangeStatus;
		private Guna.UI2.WinForms.Guna2Button Cancel;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label txt_User;
	}
}