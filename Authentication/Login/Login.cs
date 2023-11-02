using Authentication.BO;
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
					ForgetPassword forgetPassword = new ForgetPassword(this);
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
			LoginInfoService loginInfoService = new LoginInfoService();
			List<LoginInfo> loginInfos = new List<LoginInfo>();
			List<LoginInfo> lastLoginInfos = new List<LoginInfo>();
			UserService userService = new UserService();
			BO.Password password = new BO.Password();

			int nLoginCount = 0;
			int _nBadLoginAttempt = 10;
			try
			{
				if (!string.IsNullOrEmpty(txt_UserLoginID.Text))
				{
					if (!string.IsNullOrEmpty(txt_Password.Text))
					{
						oUser = userService.GetUserByLoginID(txt_UserLoginID.Text);
						if(oUser != null)
						{
							if(oUser.ForgetPasswordDate != DateTime.MinValue)
							{
								DateTime forgetPasswordDate = oUser.ForgetPasswordDate;
								DateTime nowTime = DateTime.Now;
								TimeSpan expireHour = (TimeSpan)(DateTime.Now - oUser.ForgetPasswordDate);
								if (expireHour.Days >= 1)
								{
									MessageBox.Show("Your temporary password has been expired! \nplease contact with Administrator.", "Password Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									return;
								}
							}
							if (password.AreEqual(txt_Password.Text,oUser.Password,oUser.Salt))
							{
								DateTime lastBadAttemptTime = oUser.TempStatusTime.AddMinutes(+45);
								DateTime currentTime = DateTime.Now;
								if (lastBadAttemptTime > currentTime)
								{
									if (lastBadAttemptTime > currentTime)
									{
										if (oUser.TempStatus == EnumStatus.Inactive)
										{
											MessageBox.Show("Your account has been inactive for 30 minutes because you entered the wrong password several times.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
											return;
										}
									}
								}

								if (oUser.PasswordResetByAdmin != true)
								{
									MessageBox.Show("Please change your password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									return;
								}

								if (oUser.Status != BO.EnumStatus.Active)
								{
									MessageBox.Show("Your account is " + oUser.Status.ToString() + ".\nplease contact with Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									return;
								}
								loginInfos = loginInfoService.GetLoginInfoByLoginID(oUser.LoginID);
								if (loginInfos.Count != 0)
								{
									foreach (LoginInfo li in loginInfos)
									{

									}
								}
								else
								{
									DialogResult result = MessageBox.Show("You are logged to system first time.\nPlease change your password.", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
									if (result == DialogResult.OK)
									{
										ChangePassword changePassword = new ChangePassword(this);
										changePassword._loginID = txt_UserLoginID.Text;
										changePassword.SetLoginID(txt_UserLoginID.Text);
										changePassword.SetType("Login");
										changePassword.Show();
									}
									return;
								}

								lastLoginInfos = loginInfoService.GetLastLoginInfo(oUser.LoginID);

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
