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

using System.Net.Http;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.IO;
using Authentication.BO;

namespace Authentication
{
	public partial class ChangePassword : Form
	{
		UserService userService = new UserService();
		string Type;
		#region property
		private Form callingForm;
		public string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region SetLoginID & Type
		public void SetLoginID(string loginID)
		{
			txt_LoginID.Text = loginID;
			BO.Users oUser = new BO.Users();
			oUser = userService.GetUserByLoginID(_loginID);
			if(oUser.RoleID == 1 || oUser.RoleID == 5 || oUser.RoleID == 20)
			{
				label13.Text = "Minimum 16 character";
			}
			else
			{
				label13.Text = "Minimum 12 character";
			}
		}

		public void SetType(string type)
		{
			this.Type = type;
		}
		#endregion

		#region Load
		public ChangePassword(Form caller)
		{
			InitializeComponent();
			callingForm = caller;
			txt_LoginID.Text = _loginID;
		}
		#endregion

		#region Cancel Button
		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		#region Submit Button
		private void Submit_Click(object sender, EventArgs e)
		{
			BO.Users oUser = new BO.Users();
			HardPasswordSetupService oHP = new HardPasswordSetupService();
			UserPasswordHistory newHistory = new UserPasswordHistory();
			LoginInfo loginInfo = new LoginInfo();
			UserPasswordHistoryService userPasswordHistoryService = new UserPasswordHistoryService();
			LoginInfoService loginInfoService = new LoginInfoService();
			UserService userService = new UserService();
			BO.Password password = new BO.Password();
			bool isHardPassword = false;
			string randomPassword = null;
			string result = null;

			try
			{
				if (!string.IsNullOrEmpty(txt_LoginID.Text))
				{
					if (!string.IsNullOrEmpty(txt_CurrentPassword.Text))
					{
						if(!string.IsNullOrEmpty(txt_newPassword.Text))
						{
							if (!string.IsNullOrEmpty(txt_ConfirmPassword.Text))
							{
								if(txt_CurrentPassword.Text != txt_newPassword.Text)
								{
									if (txt_newPassword.Text == txt_ConfirmPassword.Text)
									{
										oUser = userService.GetUserByLoginID(_loginID);
										if(oUser != null)
										{
											if (password.AreEqual(txt_CurrentPassword.Text, oUser.Password, oUser.Salt))
											{
												if (oHP.IsHardPasswordSetup(txt_newPassword.Text, oUser.UserName, oUser.RoleID))
												{
													string newPassword = txt_newPassword.Text;
													string salt = password.CreateSalt(40);
													string newHashPassword = password.GenerateHash(newPassword, salt);

													DateTime lastChangeDate = oUser.LastChangeDate.AddHours(+24);
													DateTime nowDate = DateTime.Now;

													long nCount = loginInfoService.NoOfLoginInfo(oUser.LoginID);
													if( nCount == 0)
													{
														loginInfo.LoginID = oUser.LoginID;
														loginInfo.UserName = oUser.UserName;
														this.SaveLoginHistory(loginInfo);
													}
													else
													{
														if(oUser.PasswordResetByAdmin != true)
														{
															if (lastChangeDate < nowDate)
															{

															}
															else
															{
																MessageBox.Show("You cannot change password within 24 hours!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
															}
														}
														else
														{

														}
													}

												}
												else
												{
													MessageBox.Show("Please follow the STANDARD password policy mentioned below.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
												}
											}
											else
											{
												MessageBox.Show("Your CURRENT password is incorrect !\nPlease enter correct password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
											}
										}
										else
										{
											MessageBox.Show("User not found!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
										}
									}
									else
									{
										MessageBox.Show("Your New password and CONFIRM password must be same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
									}
								}
								else
								{
									MessageBox.Show("Your CURRENT password and NEW password can't be same!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
								}
							}
							{
								MessageBox.Show("Please enter CONFIRM password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						else
						{
							MessageBox.Show("Please enter NEW password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
					}
					else
					{
						MessageBox.Show("Please enter CURRENT password!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else
				{
					MessageBox.Show("LoginID can't be null!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion


		private void SaveLoginHistory(LoginInfo item)
		{
			LoginInfoService srv = new LoginInfoService();

			item.PCNumber = System.Environment.MachineName;
			item.LoginTime = DateTime.Now;
			item.LogoutTime = null;
			item.Type = "Not Initiate";
			srv.Save(item);
		}
	}
}
