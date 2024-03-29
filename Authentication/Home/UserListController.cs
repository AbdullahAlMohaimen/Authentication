﻿using Authentication.BO;
using Authentication.Role;
using Authentication.Service;
using Authentication.Users;
using MailKit.Search;
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
		List<BO.Users> userList = new List<BO.Users>();
		#endregion

		#region Load
		public UserListController()
		{
			InitializeComponent();

			txt_UserStatus.Items.Add("Select Status...............");
			txt_UserStatus.Items.Add("All");
			foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
			{
				if (status != EnumStatus.None)
				{
					txt_UserStatus.Items.Add(status);
				}
			}
			txt_UserStatus.SelectedItem = "Select Status...............";
			userList = userService.GetUsers();
			this.loadGrid();
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
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
				users = userService.Get(EnumStatus.Active);
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
			roles = roleService.GetAllRole();
			total.Text = users.Count().ToString();
			DataRow dr = null;
			DataTable UserList = new DataTable();
			UserList.TableName = "User List";
			UserList.Columns.Add("ID", typeof(int));
			UserList.Columns.Add("Login ID", typeof(string));
			UserList.Columns.Add("User No", typeof(string));
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
				dr["User No"] = user.UserNo;
				dr["User Name"] = user.UserName;

				BO.Role oRole = new BO.Role();
				oRole = roles.Where(x => x.ID == user.RoleID).FirstOrDefault();
				dr["Role"] = oRole == null ? "" : oRole.Name;
				dr["Status"] = user.Status.ToString();
				dr["Email"] = user.Email;

				BO.Users oUser = new BO.Users();
				oUser = userList.Where(x => x.ID == user.CreatedBy).FirstOrDefault();
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
			allUserListTable.Columns["Login ID"].Visible = false;
		}
		#endregion

		private void UserEntry_EditingDone(object sender, EventArgs e)
		{
			this.loadGrid();
		}

		#region Search User
		private void txt_RoleSearch_TextChanged(object sender, EventArgs e)
		{
			EnumStatus status;

			try
			{
				if (!string.IsNullOrEmpty(txt_UserSearch.Text))
				{
					string searchText = txt_UserSearch.Text;
					if (txt_UserStatus.SelectedItem == "Select Status...............")
					{
						users = new UserService().SearchUsers(searchText, EnumStatus.Active);
					}
					else if (txt_UserStatus.SelectedItem == "All")
					{
						users = new UserService().SearchUsers(searchText);
					}
					else
					{
						status = (EnumStatus)txt_UserStatus.SelectedItem;
						users = new UserService().SearchUsers(searchText, status);
					}

				}
				else
				{
					if (txt_UserStatus.SelectedItem == "Select Status...............")
					{
						users = userService.Get(EnumStatus.Active);
					}
					else if (txt_UserStatus.SelectedItem == "All")
					{
						users = userService.GetUsers();
					}
					else
					{
						status = (EnumStatus)txt_UserStatus.SelectedItem;
						users = userService.Get(status);
					}
				}
				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Delete Button
		private void deleteButton_Click_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridView dataGridView = allUserListTable;
				BO.Users oUser = new BO.Users();

				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oUser = userService.GetUser(userID);

					if (oUser != null)
					{
						DialogResult result = MessageBox.Show($"Are you sure to delete {oUser.UserName} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							string status = userService.Delete(oUser.ID);
							if (status != null && status == "Ok")
							{
								MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Edit Button
		private void editButton_click_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allUserListTable;
			BO.Users oUser = new BO.Users();

			try
			{
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oUser = userService.GetUser(userID);

					if (oUser != null)
					{
						UserEntry userEntry = new UserEntry(this);
						userEntry.SetCurrentUser(this.oCurrentUser);
						userEntry.EditUser(oUser);
						userEntry._loginID = oCurrentUser.LoginID;
						userEntry.EditingDone += UserEntry_EditingDone;
						userEntry.Show();
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Password Reset Button
		private void passwordReset_btnClick_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allUserListTable;
			BO.Users oUser = new BO.Users();
			try
			{
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oUser = userService.GetUser(userID);

					if (oUser.ID == oCurrentUser.ID)
					{
						MessageBox.Show("Current user and selected user can't be the same.\nThe current user can't reset his own password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}
					DialogResult result = MessageBox.Show($"Are you sure to reset the password to this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
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
					MessageBox.Show("Please select a row for reset password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Change status button
		private void changeStatus_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allUserListTable;
			BO.Users oUser = new BO.Users();

			try
			{
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oUser = userService.GetUser(userID);

					if (oUser != null)
					{
						if (oUser.ID == oCurrentUser.ID)
						{
							MessageBox.Show("Current user and selected user can't be the same.\nThe current user can't change his own status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							return;
						}

						ChangeUserStatus changeStatus = new ChangeUserStatus(this);
						changeStatus.SetCurrentUser(this.oCurrentUser);
						changeStatus.EditUser(oUser);
						changeStatus._loginID = oCurrentUser.LoginID;
						changeStatus.EditingDone += UserEntry_EditingDone;
						changeStatus.Show();
					}
				}
				else
				{
					MessageBox.Show("Please select a row for reset password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Add New User Button
		private void AddNewUser_Click(object sender, EventArgs e)
		{
			UserEntry userEntry = new UserEntry(this);
			userEntry.SetCurrentUser(this.oCurrentUser);
			userEntry.EditUser(null);
			userEntry._loginID = oCurrentUser.LoginID;
			userEntry.EditingDone += UserEntry_EditingDone;
			userEntry.Show();
		}
		#endregion

		#region user status Dropdown
		private void txt_RoleStatus_SelectedIndexChanged(object sender, EventArgs e)
		{
			EnumStatus Status;
			if (txt_UserStatus.SelectedItem == "Select Status...............")
			{
				this.loadGrid();
				return;
			}
			else if (txt_UserStatus.SelectedItem == "All")
			{
				users = userService.Get(EnumStatus.Regardless);
			}
			else
			{
				Status = (EnumStatus)txt_UserStatus.SelectedItem;
				users = userService.Get(Status);
			}
			this.ProcessData();
		}
		#endregion
	}
}
