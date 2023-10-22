using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Home
{
	public partial class Home : Form
	{
		public Home()
		{
			InitializeComponent();
		}

		public void AddUserControl(UserControl userControl)
		{
			userControl.Dock = DockStyle.Fill;
			panelContainer.Controls.Clear();
			panelContainer.Controls.Add(userControl);
			userControl.BringToFront();
		}

		private void Administration_Click(object sender, EventArgs e)
		{
			AdministratorController administratorController = new AdministratorController();
			AddUserControl(administratorController);
		}
	}
}
