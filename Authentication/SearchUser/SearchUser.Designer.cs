namespace Authentication.SearchUser
{
	partial class SearchUser
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchUser));
			this.panel1 = new System.Windows.Forms.Panel();
			this.label35 = new System.Windows.Forms.Label();
			this.Minimize = new System.Windows.Forms.Button();
			this.Exit = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SeaGreen;
			this.panel1.Controls.Add(this.label35);
			this.panel1.Controls.Add(this.Minimize);
			this.panel1.Controls.Add(this.Exit);
			this.panel1.Location = new System.Drawing.Point(-1, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(994, 29);
			this.panel1.TabIndex = 114;
			// 
			// label35
			// 
			this.label35.AutoSize = true;
			this.label35.Font = new System.Drawing.Font("Cascadia Code", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label35.ForeColor = System.Drawing.Color.Salmon;
			this.label35.Location = new System.Drawing.Point(7, -1);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(133, 25);
			this.label35.TabIndex = 106;
			this.label35.Text = "Search User";
			// 
			// Minimize
			// 
			this.Minimize.BackColor = System.Drawing.Color.SeaGreen;
			this.Minimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Minimize.BackgroundImage")));
			this.Minimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Minimize.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Minimize.FlatAppearance.BorderSize = 0;
			this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Minimize.Location = new System.Drawing.Point(923, 3);
			this.Minimize.Name = "Minimize";
			this.Minimize.Size = new System.Drawing.Size(24, 24);
			this.Minimize.TabIndex = 12;
			this.Minimize.UseVisualStyleBackColor = false;
			// 
			// Exit
			// 
			this.Exit.BackColor = System.Drawing.Color.SeaGreen;
			this.Exit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Exit.BackgroundImage")));
			this.Exit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.Exit.Cursor = System.Windows.Forms.Cursors.Hand;
			this.Exit.FlatAppearance.BorderSize = 0;
			this.Exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Exit.Location = new System.Drawing.Point(959, 3);
			this.Exit.Name = "Exit";
			this.Exit.Size = new System.Drawing.Size(24, 24);
			this.Exit.TabIndex = 11;
			this.Exit.UseVisualStyleBackColor = false;
			// 
			// SearchUser
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Wheat;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.ClientSize = new System.Drawing.Size(992, 437);
			this.ControlBox = false;
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SearchUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Button Minimize;
		private System.Windows.Forms.Button Exit;
	}
}