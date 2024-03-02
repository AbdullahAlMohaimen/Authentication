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
			try
			{
				oUsers = userService.Get(EnumStatus.Active);
				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Process Search Users
		public void ProcessData()
		{
			total.Text = oUsers.Count().ToString();
			DataRow dr = null;
			DataTable userList = new DataTable();
			userList.TableName = "User List";

			userList.Columns.Add("ID", typeof(int));
			userList.Columns.Add("User No", typeof(string));
			userList.Columns.Add("Name", typeof(string));
			userList.Columns.Add("Role", typeof(string));
			userList.Columns.Add("Status", typeof(string));

			allUserListDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allUserListDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (BO.Users oUser in oUsers)
			{
				dr = userList.NewRow();
				dr["ID"] = oUser.ID;
				dr["User No"] = oUser.UserNo;
				dr["Name"] = oUser.UserName;
				BO.Role oRole= allRoles.Find(x => x.ID == oUser.RoleID);
				dr["Role"] = oRole == null ? "" : oRole.Name;
				dr["Status"] = oUser.Status.ToString();

				userList.Rows.Add(dr);
			}
			allUserListDataTable.DataSource = userList;

			foreach (DataGridViewColumn column in allUserListDataTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allUserListDataTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allUserListDataTable.RowHeadersVisible = false;
			allUserListDataTable.Columns["ID"].Visible = false;
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
					MessageBox.Show("User not found\nPLease try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
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

		#region Active Checked
		private void txt_Active_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_Active.Checked == true)
			{
				txt_All.Checked = false;
				oUsers = userService.Get(EnumStatus.Active);
				this.ProcessData();
			}
		}
		#endregion

		#region All Checked
		private void txt_All_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_All.Checked == true)
			{
				txt_Active.Checked = false;
				oUsers = userService.GetUsers();
				this.ProcessData();
			}
			else
			{
				btn_findAllUsers_Click(null,null);
			}
		}
		#endregion

		#region Search
		private void txt_UserSearch_TextChanged(object sender, EventArgs e)
		{
			if (txt_UserSearch.Text == string.Empty)
			{
				return;
			}
			if (oUsers.Count == 0)
			{
				MessageBox.Show("No data in grid.\nFind grid data first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				txt_UserSearch.Text = string.Empty;
				return;
			}
			if (txt_Active.Checked == false && txt_All.Checked == false)
			{
				oUsers = userService.SearchUsers(txt_UserSearch.Text, EnumStatus.Active);
			}
			else
			{
				if (txt_Active.Checked == true)
				{
					oUsers = userService.SearchUsers(txt_UserSearch.Text, EnumStatus.Active);
				}
				if (txt_All.Checked == true)
				{
					oUsers = userService.SearchUsers(txt_UserSearch.Text, EnumStatus.Regardless);
				}
			}

			this.ProcessData();
		}
		#endregion
	}
}
