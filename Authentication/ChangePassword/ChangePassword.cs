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

		#region Exit Button
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
			string result = null;
			long nCount = 0;
			string newPassword;
			string salt;
			string newHashPassword;
			DateTime lastChangeDate = DateTime.MinValue;
			DateTime nowDate = DateTime.Now;

			List<UserPasswordHistory> userPasswordHistories = new List<UserPasswordHistory>();

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
													newPassword = txt_newPassword.Text;
													salt = password.CreateSalt(40);
													newHashPassword = password.GenerateHash(newPassword, salt);

													if(oUser.LastChangeDate != null)
													{
														lastChangeDate = oUser.LastChangeDate.AddHours(+24);
													}
													nCount = loginInfoService.NoOfLoginInfo(oUser.LoginID);
													if( nCount == 0)
													{
														newHistory.UserID = oUser.ID;

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
																userPasswordHistories = userPasswordHistoryService.GetUserPasswordHistories(oUser.ID);
																if (userPasswordHistories.Count == 0)
																{
																	newHistory.UserID = oUser.ID;
																}
																else
																{
																	foreach (UserPasswordHistory ph in userPasswordHistories)
																	{
																		if (password.AreEqual(txt_newPassword.Text, ph.UserPassword, ph.Salt))
																		{
																			newHistory.UserID = 0;
																			MessageBox.Show("Please choose a new password.\nThe password you entered matches the last 10 passwords that have been changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
																		}
																		else
																		{
																			newHistory.UserID = oUser.ID;
																		}
																	}
																}
															}
															else
															{
																MessageBox.Show("You cannot change password within 24 hours!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
															}
														}
														else
														{
															userPasswordHistories = userPasswordHistoryService.GetUserPasswordHistories(oUser.ID);
															if (userPasswordHistories.Count == 0)
															{
																newHistory.UserID = oUser.ID;
															}
															else
															{
																foreach (UserPasswordHistory ph in userPasswordHistories)
																{
																	if (password.AreEqual(txt_newPassword.Text, ph.UserPassword, ph.Salt))
																	{
																		newHistory.UserID = 0;
																		MessageBox.Show("Please choose a new password.\nThe password you entered matches the last 10 passwords that have been changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
																		return;
																	}
																	else
																	{
																		newHistory.UserID = oUser.ID;
																	}
																}
															}
														}
													}
													if(newHistory.UserID != 0)
													{
														oUser.Password = newHashPassword;
														oUser.Salt = salt;
														oUser.ChangePasswordNextLogon = 0;
														oUser.LastChangeDate = DateTime.Now;
														userService.UpdatePassword(oUser);

														newHistory.UserPassword = newHashPassword;
														newHistory.Salt = salt;
														newHistory.EntryDate = DateTime.Now;
														result = userPasswordHistoryService.Save(newHistory);

														if(result == "Ok")
														{
															MessageBox.Show("Password changed successfully", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
															this.clearData();
															this.Close();
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
							else
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

		public void clearData()
		{
			this.txt_LoginID.Text = null;
			this.txt_CurrentPassword.Text = null;
			this.txt_ConfirmPassword.Text = null;
			this.txt_newPassword.Text = null;
		}
		private void SaveLoginHistory(LoginInfo item)
		{
			LoginInfoService srv = new LoginInfoService();

			item.PCNumber = System.Environment.MachineName;
			item.LoginTime = DateTime.Now;
			item.LogoutTime = null;
			item.Type = "Not Initiate";
			item.IsLogout = true;
			srv.Save(item);
		}
	}
}
