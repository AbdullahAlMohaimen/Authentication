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
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.total = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
			this.allUserLoginInfoListTable = new System.Windows.Forms.DataGridView();
			this.txt_UserLoginInfoSearch = new Guna.UI2.WinForms.Guna2TextBox();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allUserLoginInfoListTable)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
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
			this.allUserLoginInfoListTable.Location = new System.Drawing.Point(7, 47);
			this.allUserLoginInfoListTable.Name = "allUserLoginInfoListTable";
			this.allUserLoginInfoListTable.ReadOnly = true;
			this.allUserLoginInfoListTable.Size = new System.Drawing.Size(1046, 496);
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
			this.txt_UserLoginInfoSearch.Location = new System.Drawing.Point(9, 12);
			this.txt_UserLoginInfoSearch.Name = "txt_UserLoginInfoSearch";
			this.txt_UserLoginInfoSearch.PasswordChar = '\0';
			this.txt_UserLoginInfoSearch.PlaceholderForeColor = System.Drawing.Color.DarkRed;
			this.txt_UserLoginInfoSearch.PlaceholderText = "Search in all columns.....";
			this.txt_UserLoginInfoSearch.SelectedText = "";
			this.txt_UserLoginInfoSearch.Size = new System.Drawing.Size(469, 29);
			this.txt_UserLoginInfoSearch.TabIndex = 124;
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
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2HtmlLabel total;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
		private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
		private System.Windows.Forms.DataGridView allUserLoginInfoListTable;
		private Guna.UI2.WinForms.Guna2TextBox txt_UserLoginInfoSearch;
	}
}
