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
			this.AddNewUser = new Guna.UI2.WinForms.Guna2Button();
			this.allUserGrid = new Guna.UI2.WinForms.Guna2DataGridView();
			this.guna2Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.allUserGrid)).BeginInit();
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
			this.guna2Panel1.Controls.Add(this.allUserGrid);
			this.guna2Panel1.Location = new System.Drawing.Point(3, 3);
			this.guna2Panel1.Name = "guna2Panel1";
			this.guna2Panel1.Size = new System.Drawing.Size(858, 494);
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
			this.AddNewUser.Location = new System.Drawing.Point(10, 15);
			this.AddNewUser.Name = "AddNewUser";
			this.AddNewUser.Size = new System.Drawing.Size(163, 32);
			this.AddNewUser.TabIndex = 106;
			this.AddNewUser.Text = "Add New User";
			this.AddNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
			// 
			// allUserGrid
			// 
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
			this.allUserGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
			this.allUserGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
			this.allUserGrid.BackgroundColor = System.Drawing.Color.Wheat;
			this.allUserGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.SeaGreen;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.allUserGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
			this.allUserGrid.ColumnHeadersHeight = 22;
			this.allUserGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightGray;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.allUserGrid.DefaultCellStyle = dataGridViewCellStyle3;
			this.allUserGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.allUserGrid.Location = new System.Drawing.Point(9, 53);
			this.allUserGrid.Name = "allUserGrid";
			this.allUserGrid.RowHeadersVisible = false;
			this.allUserGrid.Size = new System.Drawing.Size(840, 431);
			this.allUserGrid.TabIndex = 0;
			this.allUserGrid.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
			this.allUserGrid.ThemeStyle.AlternatingRowsStyle.Font = null;
			this.allUserGrid.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
			this.allUserGrid.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
			this.allUserGrid.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
			this.allUserGrid.ThemeStyle.BackColor = System.Drawing.Color.Wheat;
			this.allUserGrid.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.allUserGrid.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
			this.allUserGrid.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			this.allUserGrid.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allUserGrid.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
			this.allUserGrid.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
			this.allUserGrid.ThemeStyle.HeaderStyle.Height = 22;
			this.allUserGrid.ThemeStyle.ReadOnly = false;
			this.allUserGrid.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.White;
			this.allUserGrid.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.allUserGrid.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.allUserGrid.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.allUserGrid.ThemeStyle.RowsStyle.Height = 22;
			this.allUserGrid.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(229)))), ((int)(((byte)(255)))));
			this.allUserGrid.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(69)))), ((int)(((byte)(94)))));
			this.allUserGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.allUserGrid_CellClick);
			// 
			// UserListController
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.Controls.Add(this.guna2Panel1);
			this.Name = "UserListController";
			this.Size = new System.Drawing.Size(864, 500);
			this.guna2Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.allUserGrid)).EndInit();
			this.ResumeLayout(false);

        }

		#endregion

		private Guna.UI2.WinForms.Guna2Panel guna2Panel1;
		private Guna.UI2.WinForms.Guna2DataGridView allUserGrid;
		private Guna.UI2.WinForms.Guna2Button AddNewUser;
	}
}
