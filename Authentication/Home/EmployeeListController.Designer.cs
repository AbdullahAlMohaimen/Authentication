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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmployeeListController));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.guna2Panel1 = new Guna.UI2.WinForms.Guna2Panel();
			this.AddNewUser = new Guna.UI2.WinForms.Guna2Button();
			this.allEmployeeGrid = new Guna.UI2.WinForms.Guna2DataGridView();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allEmployeeGrid)).BeginInit();
			this.SuspendLayout();
			// 
			// guna2Panel1
			// 
			this.guna2Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.guna2Panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
			this.guna2Panel1.BorderRadius = 10;
			this.guna2Panel1.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
			this.guna2Panel1.BorderThickness = 2;
			this.guna2Panel1.Controls.Add(this.AddNewUser);
			this.guna2Panel1.Controls.Add(this.allEmployeeGrid);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(1032, 585);
			this.guna2Panel1.TabIndex = 109;
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
			this.AddNewUser.Size = new System.Drawing.Size(198, 32);
			this.AddNewUser.TabIndex = 107;
			this.AddNewUser.Text = "Add New Employee";
			this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
			// 
			// allEmployeeGrid
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Maroon;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.SeaGreen;
			this.allEmployeeGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allEmployeeGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.allEmployeeGrid.BackgroundColor = System.Drawing.Color.Wheat;
			this.allEmployeeGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allEmployeeGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allEmployeeGrid.ColumnHeadersHeight = 22;
			this.allEmployeeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Wheat;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allEmployeeGrid.DefaultCellStyle = dataGridViewCellStyle3;
			this.allEmployeeGrid.GridColor = System.Drawing.Color.Black;
			this.allEmployeeGrid.Location = new System.Drawing.Point(6, 53);
			this.allEmployeeGrid.Name = "allEmployeeGrid";
			this.allEmployeeGrid.ReadOnly = true;
			this.allEmployeeGrid.RowHeadersVisible = false;
			this.allEmployeeGrid.Size = new System.Drawing.Size(1019, 526);
			this.allEmployeeGrid.TabIndex = 1;
			this.allEmployeeGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.allEmployeeGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.allEmployeeGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.allEmployeeGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.allEmployeeGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.allEmployeeGrid.ThemeStyle.BackColor = System.Drawing.Color.Wheat;
			this.allEmployeeGrid.ThemeStyle.GridColor = System.Drawing.Color.Black;
			this.allEmployeeGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			this.allEmployeeGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.allEmployeeGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allEmployeeGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.allEmployeeGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.allEmployeeGrid.ThemeStyle.HeaderStyle.Height = 22;
			this.allEmployeeGrid.ThemeStyle.ReadOnly = true;
			this.allEmployeeGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.allEmployeeGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.allEmployeeGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allEmployeeGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.allEmployeeGrid.ThemeStyle.RowsStyle.Height = 22;
			this.allEmployeeGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.allEmployeeGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			// 
			// EmployeeListController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.Controls.Add(this.guna2Panel1);
			this.Name = "EmployeeListController";
			this.Size = new System.Drawing.Size(1038, 590);
			this.guna2Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.allEmployeeGrid)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2DataGridView allEmployeeGrid;
		private Guna.UI2.WinForms.Guna2Button AddNewUser;
	}
}
