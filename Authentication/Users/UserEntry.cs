﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authentication.BO;
using Authentication.SearchEmployee;
using Authentication.Service;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using Newtonsoft.Json.Linq;
using Authentication.Home;
using System.IO;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;
using System.Runtime.InteropServices;

namespace Authentication.Users
{
	public partial class UserEntry : Form
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
		private SearchEmployee.SearchEmployee searchForm;
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
		public UserEntry(UserControl caller)
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
			BO.Role role = new BO.Role();
			this.LoadRoalData();
			if (_user != null)
			{
				txtHeader.Text = "Edit User";
				SaveUser.Text = "Edit";

				txt_UserNo.ReadOnly = true;
				txt_UserLoginID.ReadOnly = true;

				txt_UserLoginID.Text = _user.LoginID.ToString();
				txt_UserName.Text = _user.UserName.ToString();
				txt_UserEmail.Text = _user.Email.ToString();

				role = this._roles.Find(x => x.ID == _user.RoleID);
				txt_UserRoleID.SelectedItem = role.Name;

				BO.Employee _employee = employeeService.GetEmployee(_user.MasterID);
				txt_UserMaster.Text = "(" + _employee.EmployeeNo + ")" + _employee.Name;
				if (_user.IsApprover == true)
				{
					txt_IsApprover.Checked = true;
				}
				if (_user.IsApprover == false)
				{
					txt_IsApprover.Checked = false;
				}
				SearchEmp = _employee;
			}
			else
			{
				txtHeader.Text = "New User Entry";
				SaveUser.Text = "Save";

				txt_UserNo.ReadOnly = false;
				txt_UserLoginID.ReadOnly = false;

				_user = new BO.Users();
			}
		}
		#endregion

		#region GET Role
		public void LoadRoalData()
		{
			try
			{
				_roles = roleService.GetAllRole();
				if (_roles.Count != 0)
				{
					txt_UserRoleID.Items.Add("Select User Type");
					foreach (var role in _roles)
					{
						txt_UserRoleID.Items.Add(role.Name);
					}
				}
			}
			catch (Exception ex)
			{

			}
			this.txt_UserRoleID.SelectedIndex = 0;
		}
		#endregion

		#region Property (for Search Employee)
		public BO.Employee _searchEmployee;
		public BO.Employee SearchEmp
		{
			get { return _searchEmployee; }
			set { _searchEmployee = value; }
		}
		#endregion

		#region LoginId Auto Generate
		private void txt_UserLoginIDAuto_CheckedChanged(object sender, EventArgs e)
		{
			string loginID = null;
			bool isLoginIDUnique = false;
			if (txt_UserLoginIDAuto.Checked)
			{
				_users = userService.GetUsers();
				while (!isLoginIDUnique)
				{
					loginID = _password.GenerateRandomLoginID();
					isLoginIDUnique = !_users.Any(user => user.LoginID == loginID);
					if (isLoginIDUnique)
					{
						txt_UserLoginID.Text = loginID;
					}
				}
			}
			else
			{
				txt_UserLoginID.Text = string.Empty;
			}
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

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Save Button
		private void SaveUser_Click(object sender, EventArgs e)
		{

			string roleName = txt_UserRoleID.Text;
			string invalidMessage;
			string result;
			try
			{
				_users = userService.GetUsers();
				_role = _roles.Find(item => item.Name == roleName);
				invalidMessage = this.isValidate();
				if (string.IsNullOrEmpty(invalidMessage) || invalidMessage == "")
				{
					if (_user.IsNew == true)
					{
						if(_users.Any(user => user.UserNo == txt_UserNo.Text))
						{
							MessageBox.Show($"{txt_UserNo.Text}, you can't use this USER NO.\nPlease choose new USER NO.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}

						if (_users.Any(user => user.LoginID == txt_UserLoginID.Text))
						{
							MessageBox.Show($"{txt_UserLoginID.Text}, you can't use this LOGIN ID.\nPlease choose new LOGIN ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}

						_user.UserNo = txt_UserNo.Text;
						_user.LoginID = txt_UserLoginID.Text;
						_user.UserName = txt_UserName.Text;
						_user.RoleID = _role.ID;
						_user.Email = txt_UserEmail.Text;
						_user.MasterID = SearchEmp.ID;
						_user.CreatedBy = this.oCurrentUser.ID;
						_user.CreatedDate = DateTime.Now;
					}
					else
					{
						_user.UserName = txt_UserName.Text;
						_user.Email = txt_UserEmail.Text;
						_user.RoleID = _role.ID;
						_user.ModifiedBy = this.oCurrentUser.ID;
						_user.ModifiedDate = DateTime.Now;
					}

					if(txt_IsApprover.Checked == true)
					{
						_user.IsApprover = true;
					}
					if (txt_IsApprover.Checked == false)
					{
						_user.IsApprover = false;
					}
					result = userService.Save(_user);

					if (result == "Ok")
					{
						MessageBox.Show("User information save successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("User information save filed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
					this.Clear();

					EditingDone?.Invoke(this, EventArgs.Empty);
					this.Close();
				}
				else
				{
					MessageBox.Show(invalidMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		#endregion

		#region Validation
		public string isValidate()
		{
			string invalidMessage = "";
			if(string.IsNullOrEmpty(txt_UserLoginID.Text) || txt_UserLoginID.Text == "")
			{
				invalidMessage = "Login ID can't be empty!\nPlease enter a Login ID";
				return invalidMessage;
			}
			if (string.IsNullOrEmpty(txt_UserName.Text) || txt_UserName.Text == "")
			{
				invalidMessage = "User name can't be empty!\nPlease enter a User name";
				return invalidMessage;
			}
			if (txt_UserRoleID.SelectedIndex == 0)
			{
				invalidMessage = "Please select user role type";
				return invalidMessage;
			}
			if (string.IsNullOrEmpty(txt_UserEmail.Text) || txt_UserEmail.Text == "")
			{
				invalidMessage = "User email can't be empty!\nPlease enter User email";
				return invalidMessage;
			}
			if (string.IsNullOrEmpty(txt_UserMaster.Text) || txt_UserMaster.Text == "")
			{
				invalidMessage = "Please select an employee";
				return invalidMessage;
			}
			return invalidMessage;
		}
		#endregion

		#region Clear Method
		public void Clear()
		{
			SearchEmp = null;
			txt_UserLoginID.Text = string.Empty;
			txt_UserRoleID.SelectedIndex = 0;
			txt_UserName.Text = string.Empty;
			txt_UserEmail.Text = string.Empty;
			txt_UserMaster.Text = string.Empty;
		}
		#endregion

		#region Search Employee Button
		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchEmployee.SearchEmployee search = new SearchEmployee.SearchEmployee(this);
			search.SearchBy = "User";
			search.Show();
		}
		#endregion

		#region Set Selected Employee
		public void SetSelectedEmployee(BO.Employee SEemployee)
		{
			if (SEemployee != null)
			{
				txt_UserMaster.Text = "(" + SEemployee.EmployeeNo+")"+SEemployee.Name;
				SearchEmp = SEemployee;
			}
		}
		#endregion

		private void txt_UserMaster_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_UserMaster.Text))
			{
				BO.Employee oEmployee = new BO.Employee();
				oEmployee = employeeService.SearchEmp(txt_UserMaster.Text, txt_UserMaster.Text, txt_UserMaster.Text);
				if (oEmployee != null)
				{
					txt_UserMaster.Text = "(" + oEmployee.EmployeeNo + ")" + oEmployee.Name;
					SearchEmp = oEmployee;
				}
			}
			else
			{
				SearchEmp = null;
			}
		}

		#region UserNo Auto Generate
		private void txt_UserNoAuto_CheckedChanged(object sender, EventArgs e)
		{
			string userNo = null;
			bool isUserNoUnique = false;
			if (txt_UserNoAuto.Checked)
			{
				_users = userService.GetUsers();
				while (!isUserNoUnique)
				{
					userNo = _password.GenerateRandomUserNo();
					isUserNoUnique = !_users.Any(user => user.UserNo == userNo);
					if (isUserNoUnique)
					{
						txt_UserNo.Text = userNo;
					}
				}
			}
			else
			{
				txt_UserNo.Text = string.Empty;
			}
		}
		#endregion

		private void txt_UserNo_TextChanged(object sender, EventArgs e)
		{
			//if(!string.IsNullOrEmpty(txt_UserNo.Text))
			//{
			//	txt_UserNoAuto.Checked = false;
			//}
		}

		private void txt_UserLoginID_TextChanged(object sender, EventArgs e)
		{
			//if (!string.IsNullOrEmpty(txt_UserLoginID.Text))
			//{
			//	txt_UserLoginIDAuto.Checked = false;
			//}
		}
	}
}
