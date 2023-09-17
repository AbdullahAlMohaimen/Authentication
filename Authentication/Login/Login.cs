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

		private void ForgetPass_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_UserLoginID.Text))
			{
				MessageBox.Show("Please enter your login ID!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				Forget_Password.ForgetPassword forgetPassword = new Forget_Password.ForgetPassword(this);
				forgetPassword._loginID = txt_UserLoginID.Text;
				forgetPassword.SetLoginID(txt_UserLoginID.Text);
				forgetPassword.Show();
			}
		}
	}
}
