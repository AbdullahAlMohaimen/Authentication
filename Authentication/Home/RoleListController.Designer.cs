namespace Authentication.Home
{
	partial class RoleListController
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleListController));
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.txt_RoleStatus = new Guna.UI2.WinForms.Guna2ComboBox();
			this.txt_RoleSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.allRoleListTable = new System.Windows.Forms.DataGridView();
			this.total = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.deleteButton_Click = new Guna.UI2.WinForms.Guna2Button();
			this.editButton_click = new Guna.UI2.WinForms.Guna2Button();
			this.AddNewRole = new Guna.UI2.WinForms.Guna2Button();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allRoleListTable)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.txt_RoleStatus);
			this.guna2Panel1.Controls.Add(this.txt_RoleSearch);
			this.guna2Panel1.Controls.Add(this.allRoleListTable);
			this.guna2Panel1.Controls.Add(this.total);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
			this.guna2Panel1.Controls.Add(this.deleteButton_Click);
			this.guna2Panel1.Controls.Add(this.editButton_click);
			this.guna2Panel1.Controls.Add(this.AddNewRole);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(1060, 585);
			this.guna2Panel1.TabIndex = 110;
			// 
			// txt_RoleStatus
			// 
			this.txt_RoleStatus.BackColor = System.Drawing.Color.Wheat;
			this.txt_RoleStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_RoleStatus.BorderRadius = 8;
			this.txt_RoleStatus.BorderThickness = 0;
			this.txt_RoleStatus.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txt_RoleStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.txt_RoleStatus.DropDownHeight = 150;
			this.txt_RoleStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.txt_RoleStatus.DropDownWidth = 120;
			this.txt_RoleStatus.FillColor = System.Drawing.Color.Wheat;
			this.txt_RoleStatus.FocusedColor = System.Drawing.Color.Empty;
			this.txt_RoleStatus.FocusedState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_RoleStatus.FocusedState.ForeColor = System.Drawing.Color.Black;
			this.txt_RoleStatus.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_RoleStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_RoleStatus.HoverState.FillColor = System.Drawing.Color.Brown;
			this.txt_RoleStatus.HoverState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.txt_RoleStatus.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_RoleStatus.IntegralHeight = false;
			this.txt_RoleStatus.ItemHeight = 28;
			this.txt_RoleStatus.Location = new System.Drawing.Point(645, 6);
			this.txt_RoleStatus.MaxDropDownItems = 5;
			this.txt_RoleStatus.Name = "txt_RoleStatus";
			this.txt_RoleStatus.ShadowDecoration.Color = System.Drawing.Color.Gray;
			this.txt_RoleStatus.Size = new System.Drawing.Size(241, 34);
			this.txt_RoleStatus.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txt_RoleStatus.TabIndex = 148;
			this.txt_RoleStatus.SelectedIndexChanged += new System.EventHandler(this.txt_EmpDesignation_SelectedIndexChanged);
			// 
			// txt_RoleSearch
			// 
			this.txt_RoleSearch.BorderColor = System.Drawing.Color.Maroon;
			this.txt_RoleSearch.BorderRadius = 6;
			this.txt_RoleSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txt_RoleSearch.DefaultText = "";
			this.txt_RoleSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txt_RoleSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txt_RoleSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_RoleSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_RoleSearch.FillColor = System.Drawing.Color.Wheat;
			this.txt_RoleSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_RoleSearch.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_RoleSearch.ForeColor = System.Drawing.Color.Black;
			this.txt_RoleSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_RoleSearch.Location = new System.Drawing.Point(166, 12);
			this.txt_RoleSearch.Name = "txt_RoleSearch";
			this.txt_RoleSearch.PasswordChar = '\0';
			this.txt_RoleSearch.PlaceholderForeColor = System.Drawing.Color.DarkRed;
			this.txt_RoleSearch.PlaceholderText = "Search in all columns.....";
			this.txt_RoleSearch.SelectedText = "";
			this.txt_RoleSearch.Size = new System.Drawing.Size(469, 29);
			this.txt_RoleSearch.TabIndex = 122;
			this.txt_RoleSearch.TextChanged += new System.EventHandler(this.txt_RoleSearch_TextChanged);
			// 
			// allRoleListTable
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Moccasin;
			this.allRoleListTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allRoleListTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.allRoleListTable.BackgroundColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allRoleListTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allRoleListTable.ColumnHeadersHeight = 30;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allRoleListTable.DefaultCellStyle = dataGridViewCellStyle3;
			this.allRoleListTable.EnableHeadersVisualStyles = false;
			this.allRoleListTable.Location = new System.Drawing.Point(14, 47);
			this.allRoleListTable.Name = "allRoleListTable";
			this.allRoleListTable.ReadOnly = true;
			this.allRoleListTable.Size = new System.Drawing.Size(1032, 496);
			this.allRoleListTable.TabIndex = 114;
			// 
			// total
			// 
			this.total.BackColor = System.Drawing.Color.Transparent;
			this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.total.ForeColor = System.Drawing.Color.DarkRed;
			this.total.Location = new System.Drawing.Point(78, 554);
			this.total.Name = "total";
			this.total.Size = new System.Drawing.Size(11, 18);
			this.total.TabIndex = 113;
			this.total.Text = "0";
			// 
			// guna2HtmlLabel2
			// 
			this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel2.Location = new System.Drawing.Point(63, 553);
			this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
			this.guna2HtmlLabel2.Size = new System.Drawing.Size(7, 18);
			this.guna2HtmlLabel2.TabIndex = 112;
			this.guna2HtmlLabel2.Text = ":";
			// 
			// guna2HtmlLabel1
			// 
			this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel1.Location = new System.Drawing.Point(14, 554);
			this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			this.guna2HtmlLabel1.Size = new System.Drawing.Size(39, 18);
			this.guna2HtmlLabel1.TabIndex = 111;
			this.guna2HtmlLabel1.Text = "Total";
			// 
			// deleteButton_Click
			// 
			this.deleteButton_Click.BorderRadius = 8;
			this.deleteButton_Click.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.deleteButton_Click.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.deleteButton_Click.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.deleteButton_Click.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.deleteButton_Click.FillColor = System.Drawing.Color.OrangeRed;
			this.deleteButton_Click.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.deleteButton_Click.ForeColor = System.Drawing.Color.Wheat;
			this.deleteButton_Click.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton_Click.Image")));
			this.deleteButton_Click.Location = new System.Drawing.Point(953, 549);
			this.deleteButton_Click.Name = "deleteButton_Click";
			this.deleteButton_Click.Size = new System.Drawing.Size(93, 29);
			this.deleteButton_Click.TabIndex = 109;
			this.deleteButton_Click.Text = "Delete";
			this.deleteButton_Click.Click += new System.EventHandler(this.deleteButton_Click_Click);
			// 
			// editButton_click
			// 
			this.editButton_click.BorderRadius = 8;
			this.editButton_click.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.editButton_click.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.editButton_click.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.editButton_click.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.editButton_click.FillColor = System.Drawing.Color.Teal;
			this.editButton_click.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.editButton_click.ForeColor = System.Drawing.Color.Wheat;
			this.editButton_click.Image = ((System.Drawing.Image)(resources.GetObject("editButton_click.Image")));
			this.editButton_click.Location = new System.Drawing.Point(869, 549);
			this.editButton_click.Name = "editButton_click";
			this.editButton_click.Size = new System.Drawing.Size(75, 29);
			this.editButton_click.TabIndex = 108;
			this.editButton_click.Text = "Edit";
			this.editButton_click.Click += new System.EventHandler(this.editButton_click_Click);
			// 
			// AddNewRole
			// 
			this.AddNewRole.BorderRadius = 8;
			this.AddNewRole.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.AddNewRole.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.AddNewRole.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.AddNewRole.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.AddNewRole.FillColor = System.Drawing.Color.Brown;
			this.AddNewRole.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddNewRole.ForeColor = System.Drawing.Color.Wheat;
			this.AddNewRole.Image = ((System.Drawing.Image)(resources.GetObject("AddNewRole.Image")));
			this.AddNewRole.Location = new System.Drawing.Point(10, 12);
			this.AddNewRole.Name = "AddNewRole";
			this.AddNewRole.Size = new System.Drawing.Size(150, 29);
			this.AddNewRole.TabIndex = 106;
			this.AddNewRole.Text = "Add New Role";
			this.AddNewRole.Click += new System.EventHandler(this.AddNewRole_Click);
			// 
			// RoleListController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.Controls.Add(this.guna2Panel1);
			this.Name = "RoleListController";
			this.Size = new System.Drawing.Size(1067, 590);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.allRoleListTable)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2Button AddNewRole;
		private Guna.UI2.WinForms.Guna2Button deleteButton_Click;
		private Guna.UI2.WinForms.Guna2Button editButton_click;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
		private Guna.UI2.WinForms.Guna2HtmlLabel total;
		private System.Windows.Forms.DataGridView allRoleListTable;
		private Guna.UI2.WinForms.Guna2TextBox txt_RoleSearch;
		private Guna.UI2.WinForms.Guna2ComboBox txt_RoleStatus;
	}
}
