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
			this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
			this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
			this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
			this.guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
			this.metroPanel1 = new MetroFramework.Controls.MetroPanel();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.panel1.SuspendLayout();
			this.panelContainer.SuspendLayout();
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
			this.panelContainer.Controls.Add(this.tableLayoutPanel1);
			this.panelContainer.Controls.Add(this.panel2);
			this.panelContainer.Controls.Add(this.flowLayoutPanel2);
			this.panelContainer.Controls.Add(this.flowLayoutPanel1);
			this.panelContainer.Controls.Add(this.metroPanel1);
			this.panelContainer.Controls.Add(this.guna2ShadowPanel1);
			this.panelContainer.Controls.Add(this.guna2Panel2);
			this.panelContainer.Controls.Add(this.guna2GradientPanel1);
			this.panelContainer.Controls.Add(this.guna2CustomGradientPanel1);
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
			// guna2CustomGradientPanel1
			// 
			this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(4, 5);
			this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
			this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(200, 200);
			this.guna2CustomGradientPanel1.TabIndex = 0;
			// 
			// guna2GradientPanel1
			// 
			this.guna2GradientPanel1.Location = new System.Drawing.Point(210, 5);
			this.guna2GradientPanel1.Name = "guna2GradientPanel1";
			this.guna2GradientPanel1.Size = new System.Drawing.Size(200, 100);
			this.guna2GradientPanel1.TabIndex = 1;
			// 
			// guna2Panel2
			// 
			this.guna2Panel2.Location = new System.Drawing.Point(416, 5);
			this.guna2Panel2.Name = "guna2Panel2";
			this.guna2Panel2.Size = new System.Drawing.Size(200, 100);
			this.guna2Panel2.TabIndex = 2;
			// 
			// guna2ShadowPanel1
			// 
			this.guna2ShadowPanel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2ShadowPanel1.FillColor = System.Drawing.Color.White;
			this.guna2ShadowPanel1.Location = new System.Drawing.Point(622, 5);
			this.guna2ShadowPanel1.Name = "guna2ShadowPanel1";
			this.guna2ShadowPanel1.ShadowColor = System.Drawing.Color.Black;
			this.guna2ShadowPanel1.Size = new System.Drawing.Size(200, 100);
			this.guna2ShadowPanel1.TabIndex = 3;
			// 
			// metroPanel1
			// 
			this.metroPanel1.HorizontalScrollbarBarColor = true;
			this.metroPanel1.HorizontalScrollbarHighlightOnWheel = false;
			this.metroPanel1.HorizontalScrollbarSize = 10;
			this.metroPanel1.Location = new System.Drawing.Point(210, 111);
			this.metroPanel1.Name = "metroPanel1";
			this.metroPanel1.Size = new System.Drawing.Size(200, 100);
			this.metroPanel1.TabIndex = 4;
			this.metroPanel1.VerticalScrollbarBarColor = true;
			this.metroPanel1.VerticalScrollbarHighlightOnWheel = false;
			this.metroPanel1.VerticalScrollbarSize = 10;
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Location = new System.Drawing.Point(828, 5);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 100);
			this.flowLayoutPanel1.TabIndex = 5;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Location = new System.Drawing.Point(416, 111);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(200, 100);
			this.flowLayoutPanel2.TabIndex = 6;
			// 
			// panel2
			// 
			this.panel2.Location = new System.Drawing.Point(622, 111);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(200, 100);
			this.panel2.TabIndex = 7;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Location = new System.Drawing.Point(827, 111);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(200, 100);
			this.tableLayoutPanel1.TabIndex = 8;
			// 
			// Home
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.ClientSize = new System.Drawing.Size(1307, 639);
			this.Controls.Add(this.guna2Panel1);
			this.Controls.Add(this.panelContainer);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "Home";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Home";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.panelContainer.ResumeLayout(false);
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
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private MetroFramework.Controls.MetroPanel metroPanel1;
		private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
		private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
		private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
		private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
	}
}