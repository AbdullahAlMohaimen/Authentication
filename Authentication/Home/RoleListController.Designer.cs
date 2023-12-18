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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoleListController));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.deleteButton_Click = new Guna.UI2.WinForms.Guna2Button();
			this.editButton_click = new Guna.UI2.WinForms.Guna2Button();
			this.AddNewRole = new Guna.UI2.WinForms.Guna2Button();
			this.allRoleGrid = new Guna.UI2.WinForms.Guna2DataGridView();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allRoleGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.deleteButton_Click);
			this.guna2Panel1.Controls.Add(this.editButton_click);
			this.guna2Panel1.Controls.Add(this.AddNewRole);
			this.guna2Panel1.Controls.Add(this.allRoleGrid);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(1060, 585);
			this.guna2Panel1.TabIndex = 110;
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
			this.deleteButton_Click.Location = new System.Drawing.Point(935, 539);
			this.deleteButton_Click.Name = "deleteButton_Click";
			this.deleteButton_Click.Size = new System.Drawing.Size(109, 32);
			this.deleteButton_Click.TabIndex = 109;
			this.deleteButton_Click.Text = "Delete";
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
			this.editButton_click.Location = new System.Drawing.Point(815, 539);
			this.editButton_click.Name = "editButton_click";
			this.editButton_click.Size = new System.Drawing.Size(109, 32);
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
			this.AddNewRole.Size = new System.Drawing.Size(163, 32);
			this.AddNewRole.TabIndex = 106;
			this.AddNewRole.Text = "Add New Role";
			this.AddNewRole.Click += new System.EventHandler(this.AddNewRole_Click);
			// 
			// allRoleGrid
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
			this.allRoleGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allRoleGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.allRoleGrid.BackgroundColor = System.Drawing.Color.Wheat;
			this.allRoleGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allRoleGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allRoleGrid.ColumnHeadersHeight = 22;
			this.allRoleGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allRoleGrid.DefaultCellStyle = dataGridViewCellStyle3;
			this.allRoleGrid.GridColor = System.Drawing.Color.Black;
			this.allRoleGrid.Location = new System.Drawing.Point(6, 53);
			this.allRoleGrid.Name = "allRoleGrid";
			this.allRoleGrid.ReadOnly = true;
			this.allRoleGrid.RowHeadersVisible = false;
			this.allRoleGrid.Size = new System.Drawing.Size(1048, 471);
			this.allRoleGrid.TabIndex = 0;
			this.allRoleGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.allRoleGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.allRoleGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.allRoleGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.allRoleGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.allRoleGrid.ThemeStyle.BackColor = System.Drawing.Color.Wheat;
			this.allRoleGrid.ThemeStyle.GridColor = System.Drawing.Color.Black;
			this.allRoleGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			this.allRoleGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.allRoleGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allRoleGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.allRoleGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.allRoleGrid.ThemeStyle.HeaderStyle.Height = 22;
			this.allRoleGrid.ThemeStyle.ReadOnly = true;
			this.allRoleGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.allRoleGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.allRoleGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allRoleGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.allRoleGrid.ThemeStyle.RowsStyle.Height = 22;
			this.allRoleGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.allRoleGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
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
			((System.ComponentModel.ISupportInitialize)(this.allRoleGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2Button AddNewRole;
		private Guna.UI2.WinForms.Guna2DataGridView allRoleGrid;
		private Guna.UI2.WinForms.Guna2Button deleteButton_Click;
		private Guna.UI2.WinForms.Guna2Button editButton_click;
	}
}
