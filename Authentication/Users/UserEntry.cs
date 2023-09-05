using System;
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
using Authentication.BO.Role;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Web.UI.WebControls;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace Authentication.Users
{
	public partial class UserEntry : Form
	{
		private SearchEmployee.SearchEmployee searchForm;
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		List<BO.Role.Role> _roles = new List<BO.Role.Role>();
		List<BO.Users.Users> _users = new List<BO.Users.Users>();
		BO.Role.Role _role = new BO.Role.Role();
		BO.Users.Users _user = new BO.Users.Users();

		#region Load
		public UserEntry(BO.Employee.Employee SEmployee)
		{
			InitializeComponent();
			this.LoadRoalData();

			if (SEmployee != null)
			{
				txt_UserMaster.Text = SEmployee.Name;
			}
			SearchEmp = SEmployee;
		}
		#endregion

		#region GET Role
		public void LoadRoalData()
		{
			try
			{
				_roles = roleService.GetRole();
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
		public BO.Employee.Employee _searchEmployee;
		public BO.Employee.Employee SearchEmp
		{
			get { return _searchEmployee; }
			set { _searchEmployee = value; }
		}
		#endregion

		#region LoginId Auto Generate
		private void txt_UserLoginIDAuto_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_UserLoginIDAuto.Checked)
			{
				txt_UserLoginID.Text = "1111";
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
				_role = _roles.Find(item => item.Name == roleName);
				invalidMessage = this.isValidate();
				if (string.IsNullOrEmpty(invalidMessage) || invalidMessage == "")
				{
					_user.LoginID = txt_UserLoginID.Text;
					_user.UserName = txt_UserName.Text;
					_user.RoleID = _role.ID;
					_user.Email = txt_UserEmail.Text;
					_user.MasterID = SearchEmp.ID;

					result = userService.Save(_user);

					if (result == "Ok")
					{
						MessageBox.Show("User information save successfullt", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("User information save filed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				else
				{
					MessageBox.Show(invalidMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
				invalidMessage = "Please select user role type";
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

		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchEmployee.SearchEmployee search = new SearchEmployee.SearchEmployee();
			search.Show(this);
		}
	}
}
