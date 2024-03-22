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

namespace Authentication.Password
{
	public partial class PasswordController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new BO.CurrentUser();
		List<BO.Role> roleList = new List<BO.Role>();
		DataTable allRoleDataTable = new DataTable();
		RoleService roleService = new RoleService();
		LoginInfoService loginInfoService = new LoginInfoService();
		UserService userService = new UserService();
		List<BO.Users> userList = new List<BO.Users>();
		List<BO.LoginInfo> allLoginInfo = new List<BO.LoginInfo>();
		List<BO.Employee> employeeList = new List<BO.Employee>();
		BO.Users oSelectedUser = new BO.Users();
		EmployeeService employeeService = new EmployeeService();
		#endregion

		#region Load
		public PasswordController()
		{
			InitializeComponent();
			oSelectedUser = null;
			Clear_User_Button.Visible = false;

			employeeList = employeeService.GetEmployees();
			roleList = roleService.GetAllRole();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region User Search Click
		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchUser.SearchUser searchUser = new SearchUser.SearchUser(this);
			searchUser.Show();
		}
		#endregion

		#region Set Selected User
		public void SetSelectedUser(BO.Users oUser)
		{
			oSelectedUser = null;
			if (oUser != null)
			{
				txt_FindUser.Text = "(" + oUser.UserNo + ") - " + oUser.UserName;
				oSelectedUser = oUser;
				LoadUserData();
			}
			if (oSelectedUser != null)
			{
				Clear_User_Button.Visible = true;
			}
			else
			{
				Clear_User_Button.Visible = false;
			}
		}
		#endregion

		#region Load User Data
		public void LoadUserData()
		{
			if (oSelectedUser != null)
			{
				txt_UserNo.Text = oSelectedUser.UserNo;
				txt_UserName.Text = oSelectedUser.LoginID;
				txt_UserRole.Text = roleList.Where(x => x.ID == oSelectedUser.RoleID).FirstOrDefault() == null ? "" : roleList.Where(x => x.ID == oSelectedUser.RoleID).FirstOrDefault().Name;
				txt_UserEmail.Text = oSelectedUser.Email;
				txt_UserStatus.Text = oSelectedUser.Status.ToString();
				txt_UserIsApprover.Text = oSelectedUser.IsApprover == true ? "Yes" : "No";

				BO.Employee oMaster = employeeList.Where(x => x.ID == oSelectedUser.MasterID).FirstOrDefault();
				if (oMaster != null)
					txt_UserMaster.Text = oMaster.Name + " [" + oMaster.EmployeeNo + "] ";
				else
					txt_UserMaster.Text = "";
			}
		}
		#endregion

		#region User Clear Button
		private void Clear_User_Button_Click(object sender, EventArgs e)
		{
			txt_FindUser.Text = string.Empty;
			Clear_User_Button.Visible = false;

			txt_UserNo.Text = "";
			txt_UserName.Text = "";
			txt_UserRole.Text = "";
			txt_UserEmail.Text = "";
			txt_UserStatus.Text = "";
			txt_UserIsApprover.Text = "";
			txt_UserMaster.Text = "";
		}
		#endregion

		#region User Search Text
		private void txt_FindUser_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_FindUser.Text))
			{
				AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
				BO.Users oUser = new BO.Users();
				oUser = new UserService().SearchUser(txt_FindUser.Text, txt_FindUser.Text, txt_FindUser.Text);
				if (oUser != null)
				{
					SetSelectedUser(oUser);
				}
				else
				{
					return;
				}
			}
			else
			{
				SetSelectedUser(null);
			}
		}
		#endregion
	}
}
