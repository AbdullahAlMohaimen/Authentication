using Authentication.Service;
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
		#region Load
		public Login()
		{
			InitializeComponent();
		}
		#endregion

		#region Exit Button
		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Forget Password Button Click
		private void ForgetPass_Click(object sender, EventArgs e)
		{
			try
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
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		#region Login Button
		private void LoginX_Click(object sender, EventArgs e)
		{
			BO.Users oUser = new BO.Users();
			HardPasswordSetupService oHP = new HardPasswordSetupService();
			UserService userService = new UserService();
			BO.Password password = new BO.Password();
			try
			{
				if (!string.IsNullOrEmpty(txt_UserLoginID.Text))
				{
					if (!string.IsNullOrEmpty(txt_Password.Text))
					{
						oUser = userService.GetUserByLoginID(txt_UserLoginID.Text);
						if(oUser != null)
						{
							if (password.AreEqual(txt_Password.Text,oUser.Password,oUser.Salt))
							{
								if(oUser.Status != BO.EnumStatus.Active)
								{
									MessageBox.Show("Your account is " + oUser.Status.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								}


							}
							else
							{
								MessageBox.Show("Wrong Password!\nPlease enter correct password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						else
						{
							MessageBox.Show("Wrong LoginID!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					else
					{
						MessageBox.Show("Please enter your password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else
				{
					MessageBox.Show("Please enter your login ID!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
	}
}
