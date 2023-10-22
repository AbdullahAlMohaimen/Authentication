namespace Authentication.Home
{
	partial class Home
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
			this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
			this.Administration = new Guna.UI2.WinForms.Guna2GradientButton();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label35 = new System.Windows.Forms.Label();
			this.Minimize = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
			this.adminCombobox = new Guna.UI2.WinForms.Guna2ComboBox();
			this.guna2ShadowPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// guna2ShadowPanel1
			// 
			this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Moccasin;
			this.guna2ShadowPanel1.Controls.Add(this.adminCombobox);
			this.guna2ShadowPanel1.Controls.Add(this.Administration);
			this.guna2ShadowPanel1.FillColor = System.Drawing.Color.Moccasin;
			this.guna2ShadowPanel1.Location = new System.Drawing.Point(-2, 48);
			this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
			this.guna2ShadowPanel1.Size = new System.Drawing.Size(188, 501);
			this.guna2ShadowPanel1.TabIndex = 4;
			// 
			// Administration
			// 
			this.Administration.BorderColor = System.Drawing.Color.DarkGreen;
			this.Administration.BorderRadius = 2;
			this.Administration.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.Administration.BorderThickness = 1;
			this.Administration.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Administration.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.Administration.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.Administration.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.Administration.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.Administration.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.Administration.FillColor = System.Drawing.Color.NavajoWhite;
			this.Administration.FillColor2 = System.Drawing.Color.IndianRed;
			this.Administration.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Administration.ForeColor = System.Drawing.Color.Maroon;
			this.Administration.ImageAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.Administration.ImageSize = new System.Drawing.Size(24, 24);
			this.Administration.IndicateFocus = true;
			this.Administration.Location = new System.Drawing.Point(6, 117);
			this.Administration.Name = "Administration";
			this.Administration.Size = new System.Drawing.Size(174, 28);
			this.Administration.TabIndex = 9;
			this.Administration.Text = "Administration";
			this.Administration.Click += new System.EventHandler(this.Administration_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SeaGreen;
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.Minimize);
			this.panel1.Controls.Add(this.Exit);
			this.panel1.Location = new System.Drawing.Point(-2, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1075, 36);
			this.panel1.TabIndex = 12;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.Color.Salmon;
			this.label35.Location = new System.Drawing.Point(8, 2);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(210, 25);
			this.label35.TabIndex = 106;
			this.label35.Text = "New Employee Entry";
			// 
			// Minimize
			// 
			this.Minimize.BackColor = System.Drawing.Color.SeaGreen;
			this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
			this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Minimize.FlatAppearance.BorderSize = 0;
			this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Minimize.Location = new System.Drawing.Point(998, 6);
			this.Minimize.Name = "Minimize";
			this.Minimize.Size = new System.Drawing.Size(28, 24);
			this.Minimize.TabIndex = 12;
			this.Minimize.UseVisualStyleBackColor = false;
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.Color.SeaGreen;
			this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
			this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Exit.FlatAppearance.BorderSize = 0;
			this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Exit.Location = new System.Drawing.Point(1037, 6);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(28, 24);
			this.Exit.TabIndex = 11;
			this.Exit.UseVisualStyleBackColor = false;
			// 
			// panelContainer
			// 
			this.panelContainer.Location = new System.Drawing.Point(184, 48);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(889, 501);
			this.panelContainer.TabIndex = 13;
			// 
			// adminCombobox
			// 
			this.adminCombobox.BackColor = System.Drawing.Color.Moccasin;
			this.adminCombobox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.adminCombobox.BorderRadius = 8;
			this.adminCombobox.BorderThickness = 0;
			this.adminCombobox.Cursor = System.Windows.Forms.Cursors.Hand;
			this.adminCombobox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.adminCombobox.DropDownHeight = 150;
			this.adminCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.adminCombobox.DropDownWidth = 120;
			this.adminCombobox.FillColor = System.Drawing.Color.Moccasin;
			this.adminCombobox.FocusedColor = System.Drawing.Color.Empty;
			this.adminCombobox.FocusedState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.adminCombobox.FocusedState.ForeColor = System.Drawing.Color.Black;
			this.adminCombobox.Font = new System.Drawing.Font("Segoe UI Emoji", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.adminCombobox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.adminCombobox.HoverState.FillColor = System.Drawing.Color.Brown;
			this.adminCombobox.HoverState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.adminCombobox.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.adminCombobox.IntegralHeight = false;
			this.adminCombobox.ItemHeight = 28;
			this.adminCombobox.Location = new System.Drawing.Point(3, 6);
			this.adminCombobox.MaxDropDownItems = 5;
			this.adminCombobox.Name = "adminCombobox";
			this.adminCombobox.ShadowDecoration.Color = System.Drawing.Color.Gray;
			this.adminCombobox.Size = new System.Drawing.Size(182, 34);
			this.adminCombobox.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.adminCombobox.TabIndex = 6;
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.ClientSize = new System.Drawing.Size(1071, 548);
			this.Controls.Add(this.panelContainer);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.guna2ShadowPanel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Home";
			this.Text = "Home";
			this.guna2ShadowPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
		private Guna.UI2.WinForms.Guna2GradientButton Administration;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Button Minimize;
		private System.Windows.Forms.Button Exit;
		private Guna.UI2.WinForms.Guna2Panel panelContainer;
		private Guna.UI2.WinForms.Guna2ComboBox adminCombobox;
	}
}