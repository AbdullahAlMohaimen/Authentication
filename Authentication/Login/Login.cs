using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Login
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void ForgetPassword_Click(object sender, EventArgs e)
		{
			//DialogResult result = MessageBox.Show("Do you want to confirm this action?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			//if (result == DialogResult.Yes)
			//{
			//	MessageBox.Show("A tempory password has been send to your email!");
			//}
			//else
			//{
				
			//}
		}
	}
}
