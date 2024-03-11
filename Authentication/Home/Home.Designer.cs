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
			this.panel1 = new System.Windows.Forms.Panel();
			this.homeDropDown = new Guna.UI2.WinForms.Guna2ComboBox();
			this.headerTitle = new System.Windows.Forms.Label();
			this.Minimize = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.panelContainer = new Guna.UI2.WinForms.Guna2Panel();
			this.menuTreeView = new System.Windows.Forms.TreeView();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.panel7 = new System.Windows.Forms.Panel();
			this.panel8 = new System.Windows.Forms.Panel();
			this.panel9 = new System.Windows.Forms.Panel();
			this.panel10 = new System.Windows.Forms.Panel();
			this.panel11 = new System.Windows.Forms.Panel();
			this.panel1.SuspendLayout();
			this.guna2Panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SeaGreen;
			this.panel1.Controls.Add(this.homeDropDown);
			this.panel1.Controls.Add(this.headerTitle);
			this.panel1.Controls.Add(this.Minimize);
			this.panel1.Controls.Add(this.Exit);
			this.panel1.Location = new System.Drawing.Point(-2, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(1312, 36);
			this.panel1.TabIndex = 12;
			// 
			// homeDropDown
			// 
			this.homeDropDown.BackColor = System.Drawing.Color.Wheat;
			this.homeDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.homeDropDown.BorderRadius = 8;
			this.homeDropDown.BorderStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
			this.homeDropDown.BorderThickness = 2;
			this.homeDropDown.Cursor = System.Windows.Forms.Cursors.Hand;
			this.homeDropDown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.homeDropDown.DropDownHeight = 150;
			this.homeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.homeDropDown.DropDownWidth = 120;
			this.homeDropDown.FillColor = System.Drawing.Color.SeaGreen;
			this.homeDropDown.FocusedColor = System.Drawing.Color.Empty;
			this.homeDropDown.FocusedState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.homeDropDown.FocusedState.ForeColor = System.Drawing.Color.Black;
			this.homeDropDown.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold);
			this.homeDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.homeDropDown.HoverState.FillColor = System.Drawing.Color.Brown;
			this.homeDropDown.HoverState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.homeDropDown.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.homeDropDown.IntegralHeight = false;
			this.homeDropDown.ItemHeight = 20;
			this.homeDropDown.Location = new System.Drawing.Point(949, 6);
			this.homeDropDown.MaxDropDownItems = 5;
			this.homeDropDown.Name = "homeDropDown";
			this.homeDropDown.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.homeDropDown.ShadowDecoration.Color = System.Drawing.Color.Gray;
			this.homeDropDown.Size = new System.Drawing.Size(264, 26);
			this.homeDropDown.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.homeDropDown.TabIndex = 107;
			this.homeDropDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.homeDropDown.SelectedIndexChanged += new System.EventHandler(this.homeDropDown_SelectedIndexChanged);
			// 
			// headerTitle
			// 
			this.headerTitle.AutoSize = true;
			this.headerTitle.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.headerTitle.ForeColor = System.Drawing.Color.Salmon;
			this.headerTitle.Location = new System.Drawing.Point(8, 2);
			this.headerTitle.Name = "headerTitle";
			this.headerTitle.Size = new System.Drawing.Size(0, 25);
			this.headerTitle.TabIndex = 106;
			// 
			// Minimize
			// 
			this.Minimize.BackColor = System.Drawing.Color.SeaGreen;
			this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
			this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Minimize.FlatAppearance.BorderSize = 0;
			this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Minimize.Location = new System.Drawing.Point(1232, 6);
			this.Minimize.Name = "Minimize";
			this.Minimize.Size = new System.Drawing.Size(28, 24);
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
			this.Exit.Location = new System.Drawing.Point(1272, 6);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(27, 24);
			this.Exit.TabIndex = 11;
			this.Exit.UseVisualStyleBackColor = false;
			this.Exit.Click += new System.EventHandler(this.Exit_Click);
			// 
			// panelContainer
			// 
			this.panelContainer.Location = new System.Drawing.Point(240, 49);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(1065, 588);
			this.panelContainer.TabIndex = 13;
			// 
			// menuTreeView
			// 
			this.menuTreeView.BackColor = System.Drawing.Color.Wheat;
			this.menuTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.menuTreeView.Cursor = System.Windows.Forms.Cursors.Hand;
			this.menuTreeView.Font = new System.Drawing.Font("MS Reference Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.menuTreeView.ForeColor = System.Drawing.Color.Maroon;
			this.menuTreeView.Location = new System.Drawing.Point(5, 3);
			this.menuTreeView.Name = "menuTreeView";
			this.menuTreeView.Size = new System.Drawing.Size(227, 577);
			this.menuTreeView.TabIndex = 14;
			this.menuTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTreeView_AfterSelect);
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.menuTreeView);
			this.guna2Panel1.Location = new System.Drawing.Point(2, 51);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(236, 586);
			this.guna2Panel1.TabIndex = 108;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(18)))), ((int)(((byte)(25)))));
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(130, 13);
			this.panel2.TabIndex = 0;
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(115)))));
			this.panel3.Location = new System.Drawing.Point(130, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(130, 13);
			this.panel3.TabIndex = 1;
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(210)))), ((int)(((byte)(189)))));
			this.panel4.Location = new System.Drawing.Point(390, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(130, 13);
			this.panel4.TabIndex = 3;
			// 
			// panel5
			// 
			this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(147)))), ((int)(((byte)(150)))));
			this.panel5.Location = new System.Drawing.Point(260, 0);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(130, 13);
			this.panel5.TabIndex = 2;
			// 
			// panel6
			// 
			this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(62)))), ((int)(((byte)(3)))));
			this.panel6.Location = new System.Drawing.Point(911, 0);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(131, 13);
			this.panel6.TabIndex = 7;
			// 
			// panel7
			// 
			this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(155)))), ((int)(((byte)(0)))));
			this.panel7.Location = new System.Drawing.Point(650, 0);
			this.panel7.Name = "panel7";
			this.panel7.Size = new System.Drawing.Size(130, 13);
			this.panel7.TabIndex = 5;
			// 
			// panel8
			// 
			this.panel8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(103)))), ((int)(((byte)(2)))));
			this.panel8.Location = new System.Drawing.Point(780, 0);
			this.panel8.Name = "panel8";
			this.panel8.Size = new System.Drawing.Size(131, 13);
			this.panel8.TabIndex = 6;
			// 
			// panel9
			// 
			this.panel9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(216)))), ((int)(((byte)(166)))));
			this.panel9.Location = new System.Drawing.Point(520, 0);
			this.panel9.Name = "panel9";
			this.panel9.Size = new System.Drawing.Size(130, 13);
			this.panel9.TabIndex = 4;
			// 
			// panel10
			// 
			this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
			this.panel10.Location = new System.Drawing.Point(1174, 0);
			this.panel10.Name = "panel10";
			this.panel10.Size = new System.Drawing.Size(133, 13);
			this.panel10.TabIndex = 9;
			// 
			// panel11
			// 
			this.panel11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(174)))), ((int)(((byte)(32)))), ((int)(((byte)(18)))));
			this.panel11.Location = new System.Drawing.Point(1042, 0);
			this.panel11.Name = "panel11";
			this.panel11.Size = new System.Drawing.Size(132, 13);
			this.panel11.TabIndex = 8;
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.ClientSize = new System.Drawing.Size(1307, 639);
			this.Controls.Add(this.panel10);
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.panel11);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel7);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel8);
			this.Controls.Add(this.panel5);
			this.Controls.Add(this.panel9);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.guna2Panel1);
			this.Controls.Add(this.panelContainer);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Home";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Home";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.guna2Panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label headerTitle;
		private System.Windows.Forms.Button Minimize;
		private System.Windows.Forms.Button Exit;
		private Guna.UI2.WinForms.Guna2Panel panelContainer;
		private System.Windows.Forms.TreeView menuTreeView;
		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2ComboBox homeDropDown;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Panel panel7;
		private System.Windows.Forms.Panel panel8;
		private System.Windows.Forms.Panel panel9;
		private System.Windows.Forms.Panel panel10;
		private System.Windows.Forms.Panel panel11;
	}
}