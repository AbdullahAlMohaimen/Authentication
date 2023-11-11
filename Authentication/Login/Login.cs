using Authentication.BO;
using Authentication.HardPasswordSetup;
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
			txt_Password.Text = "";
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
			UserService userService = new UserService();
			HardPasswordSetupService oHP = new HardPasswordSetupService();
			LoginInfoService loginInfoService = new LoginInfoService();
			BadLoginAttemptInfoService badLoginAttemptInfoService = new BadLoginAttemptInfoService();

			BO.Users oUser = new BO.Users();
			BO.HardPasswordSetup oHardPasswordSetup = new BO.HardPasswordSetup();
			List<LoginInfo> loginInfos = new List<LoginInfo>();
			List<LoginInfo> lastLoginInfos = new List<LoginInfo>();
			List<BadLoginAttemptInfo> badLoginAttemptInfos = new List<BadLoginAttemptInfo>();
			BO.Password password = new BO.Password();

			int nBadLoginCount = 0;
			int nBadLoginTotalAttempt = 10;

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
								DateTime? forgetPasswordDate = oUser.ForgetPasswordDate;
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

								if (oUser.PasswordResetByAdmin != false)
								{
									DialogResult result = MessageBox.Show("An admin can reset your password.\nPlease change your password now.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
									DialogResult result = MessageBox.Show("You are logged to system first time.\nPlease change your password.", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
								if (lastLoginInfos.Count > 0)
								{
									DateTime lastLoginTime = lastLoginInfos[0].LoginTime;
									TimeSpan ts = DateTime.Now - lastLoginTime;
									TimeSpan tsAuthorizedDate = (TimeSpan)(DateTime.Now - oUser.AuthorizedDate);
									if (ts.Days > 90 && tsAuthorizedDate.Days > 90)
									{
										oUser.Status = EnumStatus.Locked;
										oUser.StatusChangedDate = DateTime.Now;
										userService.Update(oUser);

										MessageBox.Show("You didn't access last 90 days.Your account deactivated by system.\nplease contact with Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
										return;
									}
								}

								if(oUser.LoginID != string.Empty)
								{
									if (!oHP.IsPasswordExpired(oUser.LoginID))
									{
										MessageBox.Show("Password expired.\nplease contact with Administrator.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
										return;
									}
									else
									{
										oHardPasswordSetup = oHP.GetHardPasswordSetup(1);
										if (oHardPasswordSetup.PasswordExpNotificationDays > 0)
										{
											TimeSpan ts = DateTime.Today - oUser.LastChangeDate;
											if(ts.Days > oHardPasswordSetup.PasswordExpNotificationDays)
											{
												if(oHardPasswordSetup.PasswordExpDays - ts.Days == 0)
												{
													DialogResult result = MessageBox.Show("Your password will expire today. Do you want to change password now ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
												else if(oHardPasswordSetup.PasswordExpDays - ts.Days <= oHardPasswordSetup.PasswordExpNotificationDays)
												{
													DialogResult result = MessageBox.Show("Your password will expire in" + (oHardPasswordSetup.PasswordExpDays - ts.Days).ToString() +" days. Do you want to change password now ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
											}
										}
									}
								}

								if (oUser.ChangePasswordNextLogon == 1)
								{
									MessageBox.Show("", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

									DialogResult result = MessageBox.Show("This a temporary password, and this password is valid with in 24 hours.\nPlease change your password now", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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

								LoginInfo oLoginInfo = new LoginInfo();
								oLoginInfo.UserName = oUser.UserName;
								oLoginInfo.LoginID = oUser.LoginID;
								this.SaveLoginHistory(oLoginInfo);

								Home.Home home = new Home.Home(this);
								home._loginID = txt_UserLoginID.Text;
								home.SetCurrentUser(oUser);
								home.SetType("Login");
								this.Close();
								home.Show();

							}
							else
							{
								BadLoginAttemptInfo badLoginAttemptInfo = new BadLoginAttemptInfo();
								badLoginAttemptInfo.UserID = oUser.ID;
								badLoginAttemptInfo.LoginID = oUser.LoginID;
								this.SaveBadLoginHistory(badLoginAttemptInfo);

								badLoginAttemptInfos = badLoginAttemptInfoService.GetBadLoginAttempt(oUser.LoginID, oUser.ID);
								nBadLoginCount = badLoginAttemptInfos.Count;

								if (nBadLoginCount >= nBadLoginTotalAttempt)
								{
									userService.UpdateUserTempStatus(oUser.ID);
									MessageBox.Show("You have typed wrong password in several times.\nyour account is inactive for 45 min.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								}
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

		#region SaveLoginHistory
		private void SaveLoginHistory(LoginInfo item)
		{
			LoginInfoService srv = new LoginInfoService();

			item.PCNumber = System.Environment.MachineName;
			item.LoginTime = DateTime.Now;
			item.LogoutTime = null;
			item.Type = "Not Initiate";
			item.IsLogout = false;
			srv.Save(item);
		}
		#endregion

		#region SaveBadLoginHistory
		private void SaveBadLoginHistory(BadLoginAttemptInfo item)
		{
			BadLoginAttemptInfoService badLoginAttemptInfoService = new BadLoginAttemptInfoService();
			item.Type = "Not Initiate";
			item.AttemptTime = DateTime.Now;
			item.PCNumber = System.Environment.MachineName;
			badLoginAttemptInfoService.Save(item);
		}
		#endregion
	}
}
