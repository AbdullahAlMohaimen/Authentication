namespace Authentication.Home
{
	partial class EmployeeListController
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeListController));
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.total = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.changeStatus = new Guna.UI2.WinForms.Guna2Button();
			this.deleteButton_Click = new Guna.UI2.WinForms.Guna2Button();
			this.editButton_click = new Guna.UI2.WinForms.Guna2Button();
			this.allEmployeeListTable = new System.Windows.Forms.DataGridView();
			this.txt_EmployeeSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.AddNewUser = new Guna.UI2.WinForms.Guna2Button();
			this.PasswordReset = new Guna.UI2.WinForms.Guna2Button();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allEmployeeListTable)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.PasswordReset);
			this.guna2Panel1.Controls.Add(this.total);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
			this.guna2Panel1.Controls.Add(this.changeStatus);
			this.guna2Panel1.Controls.Add(this.deleteButton_Click);
			this.guna2Panel1.Controls.Add(this.editButton_click);
			this.guna2Panel1.Controls.Add(this.allEmployeeListTable);
			this.guna2Panel1.Controls.Add(this.txt_EmployeeSearch);
			this.guna2Panel1.Controls.Add(this.AddNewUser);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(1060, 585);
			this.guna2Panel1.TabIndex = 109;
			// 
			// total
			// 
			this.total.BackColor = System.Drawing.Color.Transparent;
			this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.total.ForeColor = System.Drawing.Color.DarkRed;
			this.total.Location = new System.Drawing.Point(78, 554);
			this.total.Name = "total";
			this.total.Size = new System.Drawing.Size(11, 18);
			this.total.TabIndex = 135;
			this.total.Text = "0";
			// 
			// guna2HtmlLabel2
			// 
			this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel2.Location = new System.Drawing.Point(63, 553);
			this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
			this.guna2HtmlLabel2.Size = new System.Drawing.Size(7, 18);
			this.guna2HtmlLabel2.TabIndex = 134;
			this.guna2HtmlLabel2.Text = ":";
			// 
			// guna2HtmlLabel1
			// 
			this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel1.Location = new System.Drawing.Point(14, 554);
			this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			this.guna2HtmlLabel1.Size = new System.Drawing.Size(39, 18);
			this.guna2HtmlLabel1.TabIndex = 133;
			this.guna2HtmlLabel1.Text = "Total";
			// 
			// changeStatus
			// 
			this.changeStatus.BorderRadius = 8;
			this.changeStatus.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.changeStatus.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.changeStatus.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.changeStatus.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.changeStatus.FillColor = System.Drawing.Color.SeaGreen;
			this.changeStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.changeStatus.ForeColor = System.Drawing.Color.Wheat;
			this.changeStatus.Image = ((System.Drawing.Image)(resources.GetObject("changeStatus.Image")));
			this.changeStatus.Location = new System.Drawing.Point(537, 549);
			this.changeStatus.Name = "changeStatus";
			this.changeStatus.Size = new System.Drawing.Size(160, 29);
			this.changeStatus.TabIndex = 132;
			this.changeStatus.Text = "Change Status";
			this.changeStatus.Click += new System.EventHandler(this.changeStatus_Click);
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
			this.deleteButton_Click.Location = new System.Drawing.Point(952, 549);
			this.deleteButton_Click.Name = "deleteButton_Click";
			this.deleteButton_Click.Size = new System.Drawing.Size(94, 29);
			this.deleteButton_Click.TabIndex = 131;
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
			this.editButton_click.Location = new System.Drawing.Point(868, 549);
			this.editButton_click.Name = "editButton_click";
			this.editButton_click.Size = new System.Drawing.Size(79, 29);
			this.editButton_click.TabIndex = 130;
			this.editButton_click.Text = "Edit";
			this.editButton_click.Click += new System.EventHandler(this.editButton_click_Click);
			// 
			// allEmployeeListTable
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Moccasin;
			this.allEmployeeListTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allEmployeeListTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.allEmployeeListTable.BackgroundColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allEmployeeListTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allEmployeeListTable.ColumnHeadersHeight = 30;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allEmployeeListTable.DefaultCellStyle = dataGridViewCellStyle3;
			this.allEmployeeListTable.EnableHeadersVisualStyles = false;
			this.allEmployeeListTable.Location = new System.Drawing.Point(7, 47);
			this.allEmployeeListTable.Name = "allEmployeeListTable";
			this.allEmployeeListTable.ReadOnly = true;
			this.allEmployeeListTable.Size = new System.Drawing.Size(1046, 496);
			this.allEmployeeListTable.TabIndex = 125;
			// 
			// txt_EmployeeSearch
			// 
			this.txt_EmployeeSearch.BorderColor = System.Drawing.Color.Maroon;
			this.txt_EmployeeSearch.BorderRadius = 6;
			this.txt_EmployeeSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txt_EmployeeSearch.DefaultText = "";
			this.txt_EmployeeSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txt_EmployeeSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txt_EmployeeSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_EmployeeSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_EmployeeSearch.FillColor = System.Drawing.Color.Wheat;
			this.txt_EmployeeSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_EmployeeSearch.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_EmployeeSearch.ForeColor = System.Drawing.Color.Black;
			this.txt_EmployeeSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_EmployeeSearch.Location = new System.Drawing.Point(207, 12);
			this.txt_EmployeeSearch.Name = "txt_EmployeeSearch";
			this.txt_EmployeeSearch.PasswordChar = '\0';
			this.txt_EmployeeSearch.PlaceholderForeColor = System.Drawing.Color.DarkRed;
			this.txt_EmployeeSearch.PlaceholderText = "Search in all columns.....";
			this.txt_EmployeeSearch.SelectedText = "";
			this.txt_EmployeeSearch.Size = new System.Drawing.Size(469, 29);
			this.txt_EmployeeSearch.TabIndex = 124;
			this.txt_EmployeeSearch.TextChanged += new System.EventHandler(this.txt_EmployeeSearch_TextChanged);
			// 
			// AddNewUser
			// 
			this.AddNewUser.BorderRadius = 8;
			this.AddNewUser.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.AddNewUser.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.AddNewUser.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.AddNewUser.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.AddNewUser.FillColor = System.Drawing.Color.Brown;
			this.AddNewUser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.AddNewUser.ForeColor = System.Drawing.Color.Wheat;
			this.AddNewUser.Image = ((System.Drawing.Image)(resources.GetObject("AddNewUser.Image")));
			this.AddNewUser.Location = new System.Drawing.Point(10, 12);
			this.AddNewUser.Name = "AddNewUser";
			this.AddNewUser.Size = new System.Drawing.Size(190, 29);
			this.AddNewUser.TabIndex = 107;
			this.AddNewUser.Text = "Add New Employee";
			this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
			// 
			// PasswordReset
			// 
			this.PasswordReset.BorderRadius = 8;
			this.PasswordReset.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.PasswordReset.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.PasswordReset.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.PasswordReset.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.PasswordReset.FillColor = System.Drawing.Color.Crimson;
			this.PasswordReset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.PasswordReset.ForeColor = System.Drawing.Color.Wheat;
			this.PasswordReset.Image = ((System.Drawing.Image)(resources.GetObject("PasswordReset.Image")));
			this.PasswordReset.Location = new System.Drawing.Point(703, 549);
			this.PasswordReset.Name = "PasswordReset";
			this.PasswordReset.Size = new System.Drawing.Size(159, 29);
			this.PasswordReset.TabIndex = 136;
			this.PasswordReset.Text = "Password Reset";
			this.PasswordReset.Click += new System.EventHandler(this.PasswordReset_Click);
			// 
			// EmployeeListController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.Controls.Add(this.guna2Panel1);
			this.Name = "EmployeeListController";
			this.Size = new System.Drawing.Size(1067, 590);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.allEmployeeListTable)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2Button AddNewUser;
		private Guna.UI2.WinForms.Guna2TextBox txt_EmployeeSearch;
		private System.Windows.Forms.DataGridView allEmployeeListTable;
		private Guna.UI2.WinForms.Guna2Button changeStatus;
		private Guna.UI2.WinForms.Guna2Button deleteButton_Click;
		private Guna.UI2.WinForms.Guna2Button editButton_click;
		private Guna.UI2.WinForms.Guna2HtmlLabel total;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private Guna.UI2.WinForms.Guna2Button PasswordReset;
	}
}
