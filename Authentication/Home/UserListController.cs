using Authentication.BO;
using Authentication.Role;
using Authentication.Service;
using Authentication.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Authentication.Home
{
	public partial class UserListController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		List<BO.Role> roles = new List<BO.Role>();
		List<BO.Users> users = new List<BO.Users>();
		DataTable allUserDataTable = new DataTable();
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		List<BO.Users> allUsers = new List<BO.Users>();
		#endregion

		#region Load
		public UserListController()
		{
			InitializeComponent();
			this.loadGrid();
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
			this.GetAllRole();
			this.GetAllUsers();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region Get ALL Users
		public void GetAllUsers()
		{
			try
			{
				users = userService.GetUsers();
				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Process User Data
		public void ProcessData()
		{
			allUsers = userService.GetUsers();
			total.Text = users.Count().ToString();
			DataRow dr = null;
			DataTable UserList = new DataTable();
			UserList.TableName = "User List";
			UserList.Columns.Add("ID", typeof(int));
			UserList.Columns.Add("Login ID", typeof(string));
			UserList.Columns.Add("User Name", typeof(string));
			UserList.Columns.Add("Role", typeof(string));
			UserList.Columns.Add("Status", typeof(string));
			UserList.Columns.Add("Email", typeof(string));
			UserList.Columns.Add("Created By", typeof(string));

			allUserListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allUserListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (var user in users)
			{
				dr = UserList.NewRow();
				dr["ID"] = user.ID;
				dr["Login ID"] = user.LoginID;
				dr["User Name"] = user.UserName;

				BO.Role oRole = new BO.Role();
				oRole = roles.Where(x => x.ID == user.RoleID).FirstOrDefault();
				dr["Role"] = oRole == null ? "" : oRole.Name;
				dr["Status"] = user.Status == EnumStatus.Active ? "Active" : "In-Active";
				dr["Email"] = user.Email;

				BO.Users oUser = new BO.Users();
				oUser = allUsers.Where(x => x.ID == user.CreatedBy).FirstOrDefault();
				dr["Created By"] = oUser == null ? "" : oUser.UserName;
				UserList.Rows.Add(dr);
			}

			allUserListTable.DataSource = UserList;
			//allUserListTable.RowHeadersVisible = false;
			//allUserListTable.Columns["ID"].Visible = false;

			foreach (DataGridViewColumn column in allUserListTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allUserListTable.Columns["Created By"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allUserListTable.RowHeadersVisible = false;
			allUserListTable.Columns["ID"].Visible = false;
		}
		#endregion

		#region Get ALL Role
		public void GetAllRole()
		{
			try
			{
				roles = roleService.GetAllRole();
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Please enter your login ID!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		private void UserEntry_EditingDone(object sender, EventArgs e)
		{
			this.loadGrid();
		}

		#region Search User
		private void txt_RoleSearch_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_UserSearch.Text))
			{
				string searchText = txt_UserSearch.Text;
				this.GetAllRole();
				users = new UserService().SearchUsers(searchText);
				this.ProcessData();
			}
			else
			{
				this.loadGrid();
			}
		}
		#endregion

		private void deleteButton_Click_Click(object sender, EventArgs e)
		{

		}

		private void editButton_click_Click(object sender, EventArgs e)
		{

		}

		private void passwordReset_btnClick_Click(object sender, EventArgs e)
		{

		}

		private void changeStatus_Click(object sender, EventArgs e)
		{

		}

		private void AddNewUser_Click(object sender, EventArgs e)
		{

		}
	}
}
