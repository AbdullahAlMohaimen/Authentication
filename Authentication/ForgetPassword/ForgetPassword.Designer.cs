namespace Authentication
{
	partial class ForgetPassword
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPassword));
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label35 = new System.Windows.Forms.Label();
			this.Minimize = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.Cancel = new Guna.UI2.WinForms.Guna2Button();
			this.Submit = new Guna.UI2.WinForms.Guna2Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_LoginID = new Guna.UI2.WinForms.Guna2TextBox();
			this.label27 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SeaGreen;
			this.panel1.Controls.Add(this.panel3);
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.Minimize);
			this.panel1.Controls.Add(this.Exit);
			this.panel1.Location = new System.Drawing.Point(-2, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(519, 36);
			this.panel1.TabIndex = 14;
			// 
			// panel3
			// 
			this.panel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel3.BackgroundImage")));
			this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.panel3.Location = new System.Drawing.Point(185, 6);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(28, 25);
			this.panel3.TabIndex = 15;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.Color.Salmon;
			this.label35.Location = new System.Drawing.Point(8, 2);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(177, 25);
			this.label35.TabIndex = 106;
			this.label35.Text = "Forget Password";
			// 
			// Minimize
			// 
			this.Minimize.BackColor = System.Drawing.Color.SeaGreen;
			this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
			this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Minimize.FlatAppearance.BorderSize = 0;
			this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Minimize.Location = new System.Drawing.Point(450, 6);
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
			this.Exit.Location = new System.Drawing.Point(485, 6);
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
			this.guna2Panel1.Controls.Add(this.label3);
			this.guna2Panel1.Controls.Add(this.Cancel);
			this.guna2Panel1.Controls.Add(this.Submit);
			this.guna2Panel1.Controls.Add(this.label1);
			this.guna2Panel1.Controls.Add(this.txt_LoginID);
			this.guna2Panel1.Controls.Add(this.label27);
			this.guna2Panel1.Location = new System.Drawing.Point(12, 54);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(494, 160);
			this.guna2Panel1.TabIndex = 108;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.Maroon;
			this.label3.Location = new System.Drawing.Point(45, 65);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(404, 32);
			this.label3.TabIndex = 106;
			this.label3.Text = "                     If you click on submit button \r\na temporary password will be" +
	" send in your email address.";
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
			this.Cancel.Location = new System.Drawing.Point(203, 114);
			this.Cancel.Name = "Cancel";
			this.Cancel.Size = new System.Drawing.Size(121, 31);
			this.Cancel.TabIndex = 105;
			this.Cancel.Text = " Cancel";
			this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
			// 
			// Submit
			// 
			this.Submit.BorderRadius = 8;
			this.Submit.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.Submit.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.Submit.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.Submit.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.Submit.FillColor = System.Drawing.Color.SeaGreen;
			this.Submit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Submit.ForeColor = System.Drawing.Color.Wheat;
			this.Submit.Image = ((System.Drawing.Image)(resources.GetObject("Submit.Image")));
			this.Submit.Location = new System.Drawing.Point(350, 114);
			this.Submit.Name = "Submit";
			this.Submit.Size = new System.Drawing.Size(115, 31);
			this.Submit.TabIndex = 104;
			this.Submit.Text = " Submit";
			this.Submit.Click += new System.EventHandler(this.Submit_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(27, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(82, 21);
			this.label1.TabIndex = 54;
			this.label1.Text = "Login ID";
			// 
			// txt_LoginID
			// 
			this.txt_LoginID.BorderColor = System.Drawing.Color.Maroon;
			this.txt_LoginID.BorderRadius = 6;
			this.txt_LoginID.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txt_LoginID.DefaultText = "";
			this.txt_LoginID.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txt_LoginID.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txt_LoginID.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_LoginID.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_LoginID.FillColor = System.Drawing.Color.Wheat;
			this.txt_LoginID.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_LoginID.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_LoginID.ForeColor = System.Drawing.Color.Black;
			this.txt_LoginID.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_LoginID.Location = new System.Drawing.Point(137, 17);
			this.txt_LoginID.Name = "txt_LoginID";
			this.txt_LoginID.PasswordChar = '\0';
			this.txt_LoginID.PlaceholderText = "";
			this.txt_LoginID.SelectedText = "";
			this.txt_LoginID.Size = new System.Drawing.Size(328, 34);
			this.txt_LoginID.TabIndex = 61;
			// 
			// label27
			// 
			this.label27.AutoSize = true;
			this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label27.Location = new System.Drawing.Point(115, 21);
			this.label27.Name = "label27";
			this.label27.Size = new System.Drawing.Size(16, 24);
			this.label27.TabIndex = 96;
			this.label27.Text = ":";
			// 
			// ForgetPassword
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.ClientSize = new System.Drawing.Size(517, 225);
			this.ControlBox = false;
			this.Controls.Add(this.guna2Panel1);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ForgetPassword";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Button Minimize;
		private System.Windows.Forms.Button Exit;
		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2Button Cancel;
		private Guna.UI2.WinForms.Guna2Button Submit;
		private System.Windows.Forms.Label label1;
		private Guna.UI2.WinForms.Guna2TextBox txt_LoginID;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label3;
	}
}