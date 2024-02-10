namespace Authentication.Home
{
	partial class UserLoginInfoController
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginInfoController));
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.total = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.allUserLoginInfoListTable = new System.Windows.Forms.DataGridView();
			this.txt_UserLoginInfoSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Panel2 = new Guna.UI2.WinForms.Guna2Panel();
			this.EmpSearch = new Guna.UI2.WinForms.Guna2Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txt_fromDate = new MetroFramework.Controls.MetroDateTime();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txt_toDate = new MetroFramework.Controls.MetroDateTime();
			this.label4 = new System.Windows.Forms.Label();
			this.txt_week = new Guna.UI2.WinForms.Guna2ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allUserLoginInfoListTable)).BeginInit();
			this.guna2Panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.guna2Panel2);
			this.guna2Panel1.Controls.Add(this.total);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel2);
			this.guna2Panel1.Controls.Add(this.guna2HtmlLabel1);
			this.guna2Panel1.Controls.Add(this.allUserLoginInfoListTable);
			this.guna2Panel1.Controls.Add(this.txt_UserLoginInfoSearch);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(1060, 585);
			this.guna2Panel1.TabIndex = 110;
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
			// allUserLoginInfoListTable
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Moccasin;
			this.allUserLoginInfoListTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allUserLoginInfoListTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.allUserLoginInfoListTable.BackgroundColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allUserLoginInfoListTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allUserLoginInfoListTable.ColumnHeadersHeight = 30;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightCoral;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allUserLoginInfoListTable.DefaultCellStyle = dataGridViewCellStyle3;
			this.allUserLoginInfoListTable.EnableHeadersVisualStyles = false;
			this.allUserLoginInfoListTable.Location = new System.Drawing.Point(7, 104);
			this.allUserLoginInfoListTable.Name = "allUserLoginInfoListTable";
			this.allUserLoginInfoListTable.ReadOnly = true;
			this.allUserLoginInfoListTable.Size = new System.Drawing.Size(1046, 438);
			this.allUserLoginInfoListTable.TabIndex = 125;
			// 
			// txt_UserLoginInfoSearch
			// 
			this.txt_UserLoginInfoSearch.BorderColor = System.Drawing.Color.Maroon;
			this.txt_UserLoginInfoSearch.BorderRadius = 6;
			this.txt_UserLoginInfoSearch.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txt_UserLoginInfoSearch.DefaultText = "";
			this.txt_UserLoginInfoSearch.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
			this.txt_UserLoginInfoSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
			this.txt_UserLoginInfoSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_UserLoginInfoSearch.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
			this.txt_UserLoginInfoSearch.FillColor = System.Drawing.Color.Wheat;
			this.txt_UserLoginInfoSearch.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_UserLoginInfoSearch.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_UserLoginInfoSearch.ForeColor = System.Drawing.Color.Black;
			this.txt_UserLoginInfoSearch.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
			this.txt_UserLoginInfoSearch.Location = new System.Drawing.Point(9, 66);
			this.txt_UserLoginInfoSearch.Name = "txt_UserLoginInfoSearch";
			this.txt_UserLoginInfoSearch.PasswordChar = '\0';
			this.txt_UserLoginInfoSearch.PlaceholderForeColor = System.Drawing.Color.DarkRed;
			this.txt_UserLoginInfoSearch.PlaceholderText = "Search in all columns.....";
			this.txt_UserLoginInfoSearch.SelectedText = "";
			this.txt_UserLoginInfoSearch.Size = new System.Drawing.Size(469, 29);
			this.txt_UserLoginInfoSearch.TabIndex = 124;
			// 
			// guna2Panel2
			// 
			this.guna2Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel2.BorderRadius = 10;
			this.guna2Panel2.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel2.BorderThickness = 2;
			this.guna2Panel2.Controls.Add(this.label5);
			this.guna2Panel2.Controls.Add(this.label6);
			this.guna2Panel2.Controls.Add(this.txt_week);
			this.guna2Panel2.Controls.Add(this.label3);
			this.guna2Panel2.Controls.Add(this.txt_toDate);
			this.guna2Panel2.Controls.Add(this.label4);
			this.guna2Panel2.Controls.Add(this.label2);
			this.guna2Panel2.Controls.Add(this.txt_fromDate);
			this.guna2Panel2.Controls.Add(this.EmpSearch);
			this.guna2Panel2.Controls.Add(this.label1);
			this.guna2Panel2.Location = new System.Drawing.Point(6, 7);
			this.guna2Panel2.Name = "guna2Panel2";
			this.guna2Panel2.Size = new System.Drawing.Size(1047, 52);
			this.guna2Panel2.TabIndex = 136;
			// 
			// EmpSearch
			// 
			this.EmpSearch.BorderRadius = 8;
			this.EmpSearch.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
			this.EmpSearch.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
			this.EmpSearch.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
			this.EmpSearch.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
			this.EmpSearch.FillColor = System.Drawing.Color.SeaGreen;
			this.EmpSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.EmpSearch.ForeColor = System.Drawing.Color.Wheat;
			this.EmpSearch.Image = ((System.Drawing.Image)(resources.GetObject("EmpSearch.Image")));
			this.EmpSearch.Location = new System.Drawing.Point(930, 12);
			this.EmpSearch.Name = "EmpSearch";
			this.EmpSearch.Size = new System.Drawing.Size(101, 29);
			this.EmpSearch.TabIndex = 104;
			this.EmpSearch.Text = "Search";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label1.Location = new System.Drawing.Point(6, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(46, 21);
			this.label1.TabIndex = 54;
			this.label1.Text = "From";
			// 
			// txt_fromDate
			// 
			this.txt_fromDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_fromDate.CalendarForeColor = System.Drawing.Color.Wheat;
			this.txt_fromDate.CalendarMonthBackground = System.Drawing.Color.Wheat;
			this.txt_fromDate.CalendarTitleBackColor = System.Drawing.Color.Wheat;
			this.txt_fromDate.CalendarTitleForeColor = System.Drawing.Color.Wheat;
			this.txt_fromDate.CalendarTrailingForeColor = System.Drawing.Color.Wheat;
			this.txt_fromDate.Location = new System.Drawing.Point(72, 11);
			this.txt_fromDate.MinimumSize = new System.Drawing.Size(0, 29);
			this.txt_fromDate.Name = "txt_fromDate";
			this.txt_fromDate.Size = new System.Drawing.Size(204, 29);
			this.txt_fromDate.TabIndex = 137;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label2.Location = new System.Drawing.Point(49, 14);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(19, 21);
			this.label2.TabIndex = 138;
			this.label2.Text = ":";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label3.Location = new System.Drawing.Point(326, 14);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(19, 21);
			this.label3.TabIndex = 141;
			this.label3.Text = ":";
			// 
			// txt_toDate
			// 
			this.txt_toDate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_toDate.CalendarForeColor = System.Drawing.Color.Wheat;
			this.txt_toDate.CalendarMonthBackground = System.Drawing.Color.Wheat;
			this.txt_toDate.CalendarTitleBackColor = System.Drawing.Color.Wheat;
			this.txt_toDate.CalendarTitleForeColor = System.Drawing.Color.Wheat;
			this.txt_toDate.CalendarTrailingForeColor = System.Drawing.Color.Wheat;
			this.txt_toDate.Location = new System.Drawing.Point(349, 11);
			this.txt_toDate.MinimumSize = new System.Drawing.Size(0, 29);
			this.txt_toDate.Name = "txt_toDate";
			this.txt_toDate.Size = new System.Drawing.Size(204, 29);
			this.txt_toDate.TabIndex = 140;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label4.Location = new System.Drawing.Point(300, 14);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 21);
			this.label4.TabIndex = 139;
			this.label4.Text = "To";
			// 
			// txt_week
			// 
			this.txt_week.BackColor = System.Drawing.Color.Wheat;
			this.txt_week.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_week.BorderRadius = 8;
			this.txt_week.BorderThickness = 0;
			this.txt_week.Cursor = System.Windows.Forms.Cursors.Hand;
			this.txt_week.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.txt_week.DropDownHeight = 150;
			this.txt_week.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.txt_week.DropDownWidth = 120;
			this.txt_week.FillColor = System.Drawing.Color.Wheat;
			this.txt_week.FocusedColor = System.Drawing.Color.Empty;
			this.txt_week.FocusedState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_week.FocusedState.ForeColor = System.Drawing.Color.Black;
			this.txt_week.Font = new System.Drawing.Font("Segoe UI Emoji", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txt_week.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_week.HoverState.FillColor = System.Drawing.Color.Brown;
			this.txt_week.HoverState.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
			this.txt_week.HoverState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.txt_week.IntegralHeight = false;
			this.txt_week.ItemHeight = 28;
			this.txt_week.Location = new System.Drawing.Point(646, 6);
			this.txt_week.MaxDropDownItems = 5;
			this.txt_week.Name = "txt_week";
			this.txt_week.ShadowDecoration.Color = System.Drawing.Color.Gray;
			this.txt_week.Size = new System.Drawing.Size(238, 34);
			this.txt_week.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
			this.txt_week.TabIndex = 151;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label5.Location = new System.Drawing.Point(621, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(19, 21);
			this.label5.TabIndex = 153;
			this.label5.Text = ":";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Cascadia Code", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.label6.Location = new System.Drawing.Point(576, 16);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 21);
			this.label6.TabIndex = 152;
			this.label6.Text = "Week";
			// 
			// UserLoginInfoController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.Controls.Add(this.guna2Panel1);
			this.Name = "UserLoginInfoController";
			this.Size = new System.Drawing.Size(1067, 590);
			this.guna2Panel1.ResumeLayout(false);
			this.guna2Panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.allUserLoginInfoListTable)).EndInit();
			this.guna2Panel2.ResumeLayout(false);
			this.guna2Panel2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2HtmlLabel total;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private System.Windows.Forms.DataGridView allUserLoginInfoListTable;
		private Guna.UI2.WinForms.Guna2TextBox txt_UserLoginInfoSearch;
		private Guna.UI2.WinForms.Guna2Panel guna2Panel2;
		private Guna.UI2.WinForms.Guna2Button EmpSearch;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label3;
		private MetroFramework.Controls.MetroDateTime txt_toDate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private MetroFramework.Controls.MetroDateTime txt_fromDate;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private Guna.UI2.WinForms.Guna2ComboBox txt_week;
	}
}
