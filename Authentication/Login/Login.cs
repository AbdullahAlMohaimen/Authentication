using Authentication.BO;
using Authentication.HardPasswordSetup;
using Authentication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Login
{
	public partial class Login : Form
	{
		#region Global Variable
		CurrentUser oCurrentUser = new CurrentUser();
		#endregion

		#region Shadow
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect = 0,
			int nTopRect = 0,
			int nRightRect = 0,
			int nBottomRect = 0,
			int nWidthEllipse = 0,
			int nHeightEllipse = 0
		 );
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
		private bool m_aeroEnabled;
		private const int CS_DROPSHADOW = 0x00020000;
		private const int WM_NCPAINT = 0x0085;
		private const int WM_ACTIVATEAPP = 0x001C;
		public struct MARGINS
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;
		protected override CreateParams CreateParams
		{
			get
			{
				m_aeroEnabled = CheckAeroEnabled();

				CreateParams cp = base.CreateParams;
				if (!m_aeroEnabled)
					cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}
		private bool CheckAeroEnabled()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int enabled = 0;
				DwmIsCompositionEnabled(ref enabled);
				return (enabled == 1) ? true : false;
			}
			return false;
		}
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCPAINT:
					if (m_aeroEnabled)
					{
						var v = 2;
						DwmSetWindowAttribute(this.Handle, 2, ref v, 10);
						MARGINS margins = new MARGINS()
						{
							bottomHeight = 0,
							leftWidth = 0,
							rightWidth = 0,
							topHeight = 0
						};
						DwmExtendFrameIntoClientArea(this.Handle, ref margins);
					}
					break;
				default:
					break;
			}
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
				m.Result = (IntPtr)HTCAPTION;
		}
		#endregion

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
										userService.UpdateUserDeactivate(oUser);

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

														return;
													}
												}
												else if(oHardPasswordSetup.PasswordExpDays - ts.Days <= oHardPasswordSetup.PasswordExpNotificationDays)
												{
													DialogResult result = MessageBox.Show("Your password will expire in " + (oHardPasswordSetup.PasswordExpDays - ts.Days).ToString() +" days. Do you want to change password now ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
													if (result == DialogResult.Yes)
													{
														ChangePassword changePassword = new ChangePassword(this);
														changePassword._loginID = txt_UserLoginID.Text;
														changePassword.SetLoginID(txt_UserLoginID.Text);
														changePassword.SetType("Login");
														changePassword.Show();

														return;
													}
												}
											}
										}
									}
								}

								if (oUser.ChangePasswordNextLogon == 1)
								{
									DialogResult result = MessageBox.Show("This is a temporary password, and this password is valid with in 24 hours.\nPlease change your password now", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
								oLoginInfo.UserID = oUser.ID;
								oLoginInfo.UserName = oUser.UserName;
								oLoginInfo.LoginID = oUser.LoginID;
								oLoginInfo.Type = new RoleService().GetRoleByID(oUser.RoleID).Name;
								this.SaveLoginHistory(oLoginInfo);

								#region Set CurrentUser
								oCurrentUser.ID = oUser.ID;
								oCurrentUser.UserID = oUser.ID;
								oCurrentUser.UserType = EnumUserType.User;
								oCurrentUser.EmployeeID = 0;
								oCurrentUser.LoginID = oUser.LoginID;
								oCurrentUser.UserName = oUser.UserName;
								oCurrentUser.UserNo = oUser.UserNo;
								oCurrentUser.Status = (EnumStatus)oUser.Status;
								oCurrentUser.Email = oUser.Email;
								oCurrentUser.RoleID = oUser.RoleID;
								oCurrentUser.IsLogout = false;
								oCurrentUser.MasterID = oUser.MasterID;
								#endregion

								Home.Home home = new Home.Home(this);
								home._loginID = txt_UserLoginID.Text;
								home.SetCurrentUser(oCurrentUser);
								home.SetType("Login");
								home.Show();
								this.Hide();
								

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
