using Authentication.BO;
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

namespace Authentication.Users
{
	public partial class ChangeUserStatus : Form
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

		#region property / Variable
		public event EventHandler EditingDone;
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		EmployeeService employeeService = new EmployeeService();
		List<BO.Role> _roles = new List<BO.Role>();
		List<BO.Users> _users = new List<BO.Users>();
		BO.Role _role = new BO.Role();
		BO.Users _user = new BO.Users();
		BO.Password _password = new BO.Password();
		BO.CurrentUser oCurrentUser = new CurrentUser();
		private UserControl callingForm;
		public string _loginID;
		public string LoginID { get { return _loginID; } set { _loginID = value; } }
		#endregion

		#region Constructor(Load)
		public ChangeUserStatus(UserControl caller)
		{
			InitializeComponent();
			callingForm = caller;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oCUser)
		{
			oCurrentUser = oCUser;
		}
		#endregion

		#region SetEditedUser & Type
		public void EditUser(BO.Users oUser)
		{
			_user = oUser;
			string status;
			if (_user != null)
			{
				status = _user.Status.ToString();
				txt_User.Text = "(" + _user.LoginID + ") " + _user.UserName;
				statusString.Text = status.ToUpper();

				switch (_user.Status)
				{
					case EnumStatus.Active:
						isActive.Checked = true;
						isInActive.Checked = false;
						isLocked.Checked = false;
						isPasswordExpired.Checked = false;
						break;
					case EnumStatus.Inactive:
						isActive.Checked = false;
						isInActive.Checked = true;
						isLocked.Checked = false;
						isPasswordExpired.Checked = false;
						break;
					case EnumStatus.Locked:
						isActive.Checked = false;
						isInActive.Checked = false;
						isLocked.Checked = true;
						isPasswordExpired.Checked = false;
						break;
					case EnumStatus.PasswordExpired:
						isActive.Checked = false;
						isInActive.Checked = false;
						isLocked.Checked = false;
						isPasswordExpired.Checked = true;
						break;
					default :
						break;
				}
			}
		}
		#endregion

		#region GET Role
		public void LoadRoalData()
		{
			try
			{
				_roles = roleService.GetAllRole();
			}
			catch (Exception ex)
			{

			}
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
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

		#region ChangeStatus
		private void ChangeStatus_Click(object sender, EventArgs e)
		{
			EnumStatus newStatus;

			if (isActive.Checked == true)
				newStatus = EnumStatus.Active;
			else if (isInActive.Checked == true)
				newStatus = EnumStatus.Inactive;
			else if (isLocked.Checked == true)
				newStatus = EnumStatus.Locked;
			else if (isPasswordExpired.Checked == true)
				newStatus = EnumStatus.PasswordExpired;
			else
				newStatus = EnumStatus.None;

			if (newStatus == EnumStatus.None)
			{
				MessageBox.Show("Please select any status, otherwize you can't change user's status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (_user.Status == newStatus)
			{
				MessageBox.Show("This is user's previous status.\nPlease choose another status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			_user.Status = newStatus;
			_user.StatusChangedDate = DateTime.Now;
			_user.ModifiedBy = oCurrentUser.ID;
			_user.ModifiedDate = DateTime.Now;

			try
			{
				string result = userService.UpdateUserStatus(_user.ID, newStatus, oCurrentUser.ID, DateTime.Now, DateTime.Now);

				if (result == "Ok")
				{
					MessageBox.Show($"User status changed successfully.\n{_user.UserName} is now {newStatus.ToString()}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Failed.\nPlease try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				EditingDone?.Invoke(this, EventArgs.Empty);
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region Is Active Change
		private void isActive_CheckedChanged(object sender, EventArgs e)
		{
			if (isActive.Checked == true)
			{
				isActive.Checked = true;
				isInActive.Checked = false;
				isLocked.Checked = false;
				isPasswordExpired.Checked = false;
			}
		}
		#endregion

		#region Is InActive Change
		private void isInActive_CheckedChanged(object sender, EventArgs e)
		{
			if (isInActive.Checked == true)
			{
				isActive.Checked = false;
				isInActive.Checked = true;
				isLocked.Checked = false;
				isPasswordExpired.Checked = false;
			}
		}
		#endregion

		#region Is Locked Change
		private void isLocked_CheckedChanged(object sender, EventArgs e)
		{
			if (isLocked.Checked == true)
			{
				isActive.Checked = false;
				isInActive.Checked = false;
				isLocked.Checked = true;
				isPasswordExpired.Checked = false;
			}
		}
		#endregion

		#region Is Password Expired Change
		private void isPasswordExpired_CheckedChanged(object sender, EventArgs e)
		{
			if (isPasswordExpired.Checked == true)
			{
				isActive.Checked = false;
				isInActive.Checked = false;
				isLocked.Checked = false;
				isPasswordExpired.Checked = true;
			}
		}
		#endregion
	}
}
