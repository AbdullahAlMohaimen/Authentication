﻿using Authentication.BO;
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
			total.Text = users.Count().ToString();
			DataRow dr = null;
			DataTable UserList = new DataTable();
			UserList.TableName = "Role List";
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
				oUser = users.Where(x => x.ID == user.CreatedBy).FirstOrDefault();
				dr["Created By"] = oUser == null ? "" : oUser.UserName;
				UserList.Rows.Add(dr);
			}

			allUserListTable.DataSource = UserList;
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

		#region AddNewUser Button
		private void AddNewUser_Click(object sender, EventArgs e)
		{
			UserEntry userEntry = new UserEntry(this);
			userEntry.SetCurrentUser(this.oCurrentUser);
			userEntry.EditUser(null);
			userEntry._loginID = oCurrentUser.LoginID;
			userEntry.Show();
		}
		#endregion

		#region Edit Button
		private void editButton_click_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allUserListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				BO.Users oUser = new BO.Users();
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
				oUser = userService.GetUser(userID);

				UserEntry userEntry = new UserEntry(this);
				userEntry.SetCurrentUser(this.oCurrentUser);
				userEntry.EditUser(oUser);
				userEntry._loginID = oCurrentUser.LoginID;
				userEntry.EditingDone += UserEntry_EditingDone;
				userEntry.Show();
			}
			else
			{
				MessageBox.Show("Please select a row for edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		#endregion

		#region Change Status Button
		private void changeStatus_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allUserListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				BO.Users oUser = new BO.Users();
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
				oUser = userService.GetUser(userID);

				EnumStatus status;
				string statusString = oUser.Status == EnumStatus.Active ? "In-Active" : "Active";
				DialogResult result = MessageBox.Show($"Are you sure to {statusString} this User?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result == DialogResult.OK)
				{
					if (oUser.Status == EnumStatus.Active)
						status = EnumStatus.Inactive;
					else
						status = EnumStatus.Active;

					string updateStatusResult = userService.UpdateUserStatus(oUser.ID, status, oCurrentUser.ID, DateTime.Now, DateTime.Now);
					if (updateStatusResult == "Ok")
					{
						MessageBox.Show($"{oUser.UserName} is now {statusString}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
						this.loadGrid();
					}
					else
					{
						MessageBox.Show($"Something Problem.\nPlease try again.", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
				return;
			}
			else
			{
				MessageBox.Show("Please select a row for change user status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		#endregion

		#region Delete Button
		private void deleteButton_Click_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allUserListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				BO.Users oUser = new BO.Users();
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
				oUser = userService.GetUser(userID);

				if (oUser.ID == oCurrentUser.ID)
				{
					MessageBox.Show("Current user and edited user can't be the same.\nThe current user can't reset his own password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				DialogResult result = MessageBox.Show($"Are you sure to reset the password to this User?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result == DialogResult.OK)
				{
					oUser.PasswordResetByAdmin = true;
					oUser.PasswordResetBy = oCurrentUser.ID;
					oUser.PasswordResetDate = DateTime.Now;
					string passwordResetStatus = userService.PasswordResetByAdmin(oUser);

					if (passwordResetStatus == "Ok")
					{
						MessageBox.Show("You have successfully reset a new password to this user email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				return;
			}
			else
			{
				MessageBox.Show("Please select a row for edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		#endregion

		private void txt_RoleSearch_TextChanged(object sender, EventArgs e)
		{

		}
	}
}
