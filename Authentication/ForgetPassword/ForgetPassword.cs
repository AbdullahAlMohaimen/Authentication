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

namespace Authentication.Forget_Password
{
	public partial class ForgetPassword : Form
	{
		UserService userService = new UserService();
		#region property
		private Form callingForm;
		public string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region Load
		public ForgetPassword(Form caller)
		{
			InitializeComponent();
			callingForm = caller;
			txt_LoginID.Text = _loginID;
		}
		#endregion

		#region SetLoginID
		public void SetLoginID(string loginID)
		{
			txt_LoginID.Text = loginID;
		}
		#endregion

		#region Submit Button
		private void Submit_Click(object sender, EventArgs e)
		{
			BO.Users oUser = new BO.Users();
			HardPasswordSetupService oHP = new HardPasswordSetupService();
			UserService userService = new UserService();
			BO.Password password = new BO.Password();
			bool isHardPassword = false;
			string randomPassword = null;
			string result = null;

			try
			{
				if (!string.IsNullOrEmpty(txt_LoginID.Text))
				{
					oUser = userService.GetUserByLoginID(_loginID);
					if (oUser != null)
					{
						if (oUser.Email != null)
						{
							while (!isHardPassword)
							{
								if (oUser.RoleID == 1 || oUser.RoleID == 5 || oUser.RoleID == 20)
									randomPassword = password.GenerateRandomPassword(14, 16);
								else
									randomPassword = password.GenerateRandomPassword(10);
								if (randomPassword != null)
									if (oHP.IsHardPasswordSetup(randomPassword, oUser.UserName, oUser.RoleID))
										isHardPassword = true;
							}
							result = userService.ForgetPassword(oUser, randomPassword);
							if (result == "Ok")
								MessageBox.Show("A tempory password has been send to your email.\nPlease check your email", "Send Temporary Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
							else
								MessageBox.Show("Something Problem", "Failed to Send Temporary Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
							this.Close();
						}
						else
						{
							MessageBox.Show("Can't find your email!\nPlease contact with administrator", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							this.Close();
						}
					}
					else
					{
						MessageBox.Show("Wrong LoginID.\nPlease enter correct LoginID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						this.Close();
					}
				}
				else
				{
					MessageBox.Show("LoginID can't be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.Close();
				}
			}
			catch(Exception ex) 
			{
				MessageBox.Show(ex.ToString(), "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		#endregion

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Exit Button
		private void Exit_Click(object sender, EventArgs e)
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
	}
}
