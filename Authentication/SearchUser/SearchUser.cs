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

namespace Authentication.SearchUser
{
	public partial class SearchUser : Form
	{
		#region Property & Variable
		BO.Employee employee = new BO.Employee();
		EmployeeService employeeService = new EmployeeService();
		UserService userService = new UserService();
		List<BO.Employee> employees = new List<BO.Employee>();
		DataTable allEmployeeDataTable = new DataTable();
		private UserControl callingController;
		BO.Users oUser = new BO.Users();
		List<BO.Users> oUsers = new List<BO.Users>();
		List<BO.Role> allRoles = new List<BO.Role>();
		#endregion

		#region Load
		public SearchUser(UserControl userControl)
		{
			InitializeComponent();
			callingController = userControl;
			allRoles = new RoleService().GetAllRole();
		}
		#endregion

		#region Find All Button
		private void btn_findAllUsers_Click(object sender, EventArgs e)
		{

		}
		#endregion

		#region Search Button Click
		private void btn_UserSearch_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(txt_ID.Text) && string.IsNullOrEmpty(txt_Name.Text))
			{
				MessageBox.Show("PLease enter user NO or user NAME first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!string.IsNullOrEmpty(txt_ID.Text) || !string.IsNullOrEmpty(txt_Name.Text))
			{
				oUser = userService.SearchUsers(txt_ID.Text,txt_Name.Text);
				if (oUser != null)
				{
					txt_UserNo.Text = oUser.UserNo;
					txt_UserName.Text = oUser.UserName;
					txt_UserRole.Text = allRoles.Where(x => x.ID == oUser.RoleID).FirstOrDefault().Name;
					txt_UserStatus.Text = oUser.Status.ToString();
					txt_UserEmail.Text = oUser.Email;
					txt_UserApprover.Text = oUser.IsApprover == true ? "Yes" : "No";
				}
				else
				{
					txt_UserNo.Text = "";
					txt_UserName.Text = "";
					txt_UserRole.Text = "";
					txt_UserStatus.Text = "";
					txt_UserEmail.Text = "";
					txt_UserApprover.Text = "";
				}
			}
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
	}
}
