using System.Windows.Forms;

namespace Authentication.Home
{
    partial class UserListController
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserListController));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.txt_UserStatus = new Guna.UI2.WinForms.Guna2ComboBox();
			this.deleteButton_Click = new Guna.UI2.WinForms.Guna2Button();
			this.changeStatus = new Guna.UI2.WinForms.Guna2Button();
			this.total = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.passwordReset_btnClick = new Guna.UI2.WinForms.Guna2Button();
			this.editButton_click = new Guna.UI2.WinForms.Guna2Button();
			this.txt_UserSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.allUserListTable = new System.Windows.Forms.DataGridView();
			this.AddNewUser = new Guna.UI2.WinForms.Guna2Button();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allUserListTable)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.txt_UserStatus);
			this.guna2Panel1.Controls.Add(this.deleteButton_Click);
			this.guna2Panel1.Controls.Add(this.changeStatus);
			this.guna2Panel1.Controls.Add(this.total);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
			this.guna2Panel1.Controls.Add(this.passwordReset_btnClick);
			this.guna2Panel1.Controls.Add(this.editButton_click);
			this.guna2Panel1.Controls.Add(this.txt_UserSearch);
			this.guna2Panel1.Controls.Add(this.allUserListTable);
			this.guna2Panel1.Controls.Add(this.AddNewUser);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(1060, 585);
			this.guna2Panel1.TabIndex = 109;
			// 
			// txt_UserStatus
			// 
			this.txt_UserStatus.BackColor = System.Drawing.Color.Wheat;
			this.txt_UserStatus.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_UserStatus.BorderRadius = 8;
			this.txt_UserStatus.BorderThickness = 0;
			this.txt_UserStatus.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txt_UserStatus.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.txt_UserStatus.DropDownHeight = 150;
			this.txt_UserStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.txt_UserStatus.DropDownWidth = 120;
			this.txt_UserStatus.FillColor = System.Drawing.Color.Wheat;
			this.txt_UserStatus.FocusedColor = System.Drawing.Color.Empty;
			this.txt_UserStatus.FocusedState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_UserStatus.FocusedState.ForeColor = System.Drawing.Color.Black;
			this.txt_UserStatus.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_UserStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_UserStatus.HoverState.FillColor = System.Drawing.Color.Brown;
			this.txt_UserStatus.HoverState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.txt_UserStatus.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_UserStatus.IntegralHeight = false;
			this.txt_UserStatus.ItemHeight = 28;
			this.txt_UserStatus.Location = new System.Drawing.Point(645, 6);
			this.txt_UserStatus.MaxDropDownItems = 5;
			this.txt_UserStatus.Name = "txt_UserStatus";
			this.txt_UserStatus.ShadowDecoration.Color = System.Drawing.Color.Gray;
			this.txt_UserStatus.Size = new System.Drawing.Size(241, 34);
			this.txt_UserStatus.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txt_UserStatus.TabIndex = 149;
			this.txt_UserStatus.SelectedIndexChanged += new System.EventHandler(this.txt_RoleStatus_SelectedIndexChanged);
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
			this.deleteButton_Click.TabIndex = 132;
			this.deleteButton_Click.Text = "Delete";
			this.deleteButton_Click.Click += new System.EventHandler(this.deleteButton_Click_Click);
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
			this.changeStatus.TabIndex = 129;
			this.changeStatus.Text = "Change Status";
			this.changeStatus.Visible = false;
			this.changeStatus.Click += new System.EventHandler(this.changeStatus_Click);
			// 
			// total
			// 
			this.total.BackColor = System.Drawing.Color.Transparent;
			this.total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.total.ForeColor = System.Drawing.Color.DarkRed;
			this.total.Location = new System.Drawing.Point(78, 554);
			this.total.Name = "total";
			this.total.Size = new System.Drawing.Size(11, 18);
			this.total.TabIndex = 128;
			this.total.Text = "0";
			// 
			// guna2HtmlLabel2
			// 
			this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel2.Location = new System.Drawing.Point(63, 553);
			this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
			this.guna2HtmlLabel2.Size = new System.Drawing.Size(7, 18);
			this.guna2HtmlLabel2.TabIndex = 127;
			this.guna2HtmlLabel2.Text = ":";
			// 
			// guna2HtmlLabel1
			// 
			this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
			this.guna2HtmlLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.guna2HtmlLabel1.Location = new System.Drawing.Point(14, 554);
			this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
			this.guna2HtmlLabel1.Size = new System.Drawing.Size(39, 18);
			this.guna2HtmlLabel1.TabIndex = 126;
			this.guna2HtmlLabel1.Text = "Total";
			// 
			// passwordReset_btnClick
			// 
			this.passwordReset_btnClick.BorderRadius = 8;
			this.passwordReset_btnClick.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.passwordReset_btnClick.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.passwordReset_btnClick.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.passwordReset_btnClick.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.passwordReset_btnClick.FillColor = System.Drawing.Color.Crimson;
			this.passwordReset_btnClick.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.passwordReset_btnClick.ForeColor = System.Drawing.Color.Wheat;
			this.passwordReset_btnClick.Image = ((System.Drawing.Image)(resources.GetObject("passwordReset_btnClick.Image")));
			this.passwordReset_btnClick.Location = new System.Drawing.Point(703, 549);
			this.passwordReset_btnClick.Name = "passwordReset_btnClick";
			this.passwordReset_btnClick.Size = new System.Drawing.Size(159, 29);
			this.passwordReset_btnClick.TabIndex = 125;
			this.passwordReset_btnClick.Text = "Password Reset";
			this.passwordReset_btnClick.Visible = false;
			this.passwordReset_btnClick.Click += new System.EventHandler(this.passwordReset_btnClick_Click);
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
			this.editButton_click.TabIndex = 124;
			this.editButton_click.Text = "Edit";
			this.editButton_click.Click += new System.EventHandler(this.editButton_click_Click);
			// 
			// txt_UserSearch
			// 
			this.txt_UserSearch.BorderColor = System.Drawing.Color.Maroon;
			this.txt_UserSearch.BorderRadius = 6;
			this.txt_UserSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txt_UserSearch.DefaultText = "";
			this.txt_UserSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txt_UserSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txt_UserSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_UserSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_UserSearch.FillColor = System.Drawing.Color.Wheat;
			this.txt_UserSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_UserSearch.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_UserSearch.ForeColor = System.Drawing.Color.Black;
			this.txt_UserSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_UserSearch.Location = new System.Drawing.Point(166, 12);
			this.txt_UserSearch.Name = "txt_UserSearch";
			this.txt_UserSearch.PasswordChar = '\0';
			this.txt_UserSearch.PlaceholderForeColor = System.Drawing.Color.DarkRed;
			this.txt_UserSearch.PlaceholderText = "Search in all columns.....";
			this.txt_UserSearch.SelectedText = "";
			this.txt_UserSearch.Size = new System.Drawing.Size(469, 29);
			this.txt_UserSearch.TabIndex = 123;
			this.txt_UserSearch.TextChanged += new System.EventHandler(this.txt_RoleSearch_TextChanged);
			// 
			// allUserListTable
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Moccasin;
			this.allUserListTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allUserListTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.allUserListTable.BackgroundColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allUserListTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allUserListTable.ColumnHeadersHeight = 30;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allUserListTable.DefaultCellStyle = dataGridViewCellStyle3;
			this.allUserListTable.EnableHeadersVisualStyles = false;
			this.allUserListTable.Location = new System.Drawing.Point(7, 47);
			this.allUserListTable.Name = "allUserListTable";
			this.allUserListTable.ReadOnly = true;
			this.allUserListTable.Size = new System.Drawing.Size(1046, 496);
			this.allUserListTable.TabIndex = 115;
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
			this.AddNewUser.Size = new System.Drawing.Size(150, 29);
			this.AddNewUser.TabIndex = 106;
			this.AddNewUser.Text = "Add New User";
			this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
			// 
			// UserListController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.Controls.Add(this.guna2Panel1);
			this.Name = "UserListController";
			this.Size = new System.Drawing.Size(1067, 590);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.allUserListTable)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2Button AddNewUser;
		private DataGridView allUserListTable;
		private Guna.UI2.WinForms.Guna2TextBox txt_UserSearch;
		private Guna.UI2.WinForms.Guna2HtmlLabel total;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private Guna.UI2.WinForms.Guna2Button passwordReset_btnClick;
		private Guna.UI2.WinForms.Guna2Button editButton_click;
		private Guna.UI2.WinForms.Guna2Button changeStatus;
		private Guna.UI2.WinForms.Guna2Button deleteButton_Click;
		private Guna.UI2.WinForms.Guna2ComboBox txt_UserStatus;
	}
}
