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

namespace Authentication
{
	public partial class ForgetPassword : Form
	{
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

		#region property
		UserService userService = new UserService();
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
			DateTime forgetPassword;

			try
			{
				if (!string.IsNullOrEmpty(txt_LoginID.Text))
				{
					oUser = userService.GetUserByLoginID(_loginID);
					if (oUser != null)
					{
						forgetPassword = oUser.ForgetPasswordDate == null ? DateTime.MinValue : oUser.ForgetPasswordDate.Value;
						if (forgetPassword.Date != DateTime.Now.Date)
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
							MessageBox.Show("Please check your Email.\nAlready a temporary password has already been sent to your Email on Today.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
