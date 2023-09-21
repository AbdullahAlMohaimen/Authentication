using Authentication.BO.Password;
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
			BO.Users.Users oUser = new BO.Users.Users();
			HardPasswordSetupService oHP = new HardPasswordSetupService();
			Password password = new Password();
			string randomPassword = null; ;
			//string result = null;

			if (!string.IsNullOrEmpty(txt_LoginID.Text))
			{
				oUser = userService.GetUserByLoginID(_loginID);
				if (oUser != null)
				{
					if (oUser.RoleID == 1 || oUser.RoleID == 5 || oUser.RoleID == 20)
						randomPassword = password.GenerateRandomPassword(14, 16);
					else
						randomPassword = password.GenerateRandomPassword(10);

					if(randomPassword != null)
					{
						if (oHP.IsHardPasswordSetup(randomPassword, oUser.UserName, oUser.RoleID))
						{
							oUser.Salt = password.CreateSalt(128);
							oUser.Password = password.GenerateHash(randomPassword, oUser.Salt);
						}
					}
				}
				else
				{
					MessageBox.Show("Wrong LoginID.\nPlease enter correct LoginID", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
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
