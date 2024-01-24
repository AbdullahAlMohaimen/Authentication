using Authentication.BO;
using Authentication.Role;
using Authentication.Service;
using Authentication.Users;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Home
{
	public partial class RoleListController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		List<BO.Role> roles = new List<BO.Role>();
		DataTable allRoleDataTable = new DataTable();
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		List<BO.Users> userList = new List<BO.Users>();
		#endregion

		#region Load
		public RoleListController()
		{
			InitializeComponent();
			this.loadGrid();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region AddNewRolwButton
		private void AddNewRole_Click(object sender, EventArgs e)
		{
			RoleEntry roleEntry = new RoleEntry(this);
			roleEntry.SetCurrentUser(this.oCurrentUser);
			roleEntry.EditRole(null);
			roleEntry._loginID = oCurrentUser.LoginID;
			roleEntry.Show();
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
			this.GetAllRole();
		}
		#endregion

		#region Get ALL Role
		public void GetAllRole()
		{
			try
			{
				roles = new List<BO.Role>();
				roles = roleService.GetAllRole();
				userList = new UserService().GetUsers();
				total.Text = roles.Count().ToString();

				DataRow dr = null;
				DataTable roleList = new DataTable();
				roleList.TableName = "Role List";
				roleList.Columns.Add("ID", typeof(int));
				roleList.Columns.Add("Code", typeof(string));
				roleList.Columns.Add("Name", typeof(string));
				roleList.Columns.Add("Status", typeof(string));
				roleList.Columns.Add("Created By", typeof (string));

				allRoleListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
				allRoleListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

				foreach (BO.Role oRole in roles)
				{
					dr = roleList.NewRow();
					dr["ID"] = oRole.ID;
					dr["Code"] = oRole.Code;
					dr["Name"] = oRole.Name;
					dr["Status"] = oRole.Status.ToString();

					BO.Users oUser = new BO.Users();
					oUser = userList.Where(x => x.ID == oRole.CreatedBy).FirstOrDefault();
					dr["Created By"] = oUser == null ? "" : oUser.UserName;

					roleList.Rows.Add(dr);
				}
				allRoleListTable.DataSource = roleList;
				allRoleListTable.RowHeadersVisible = false;
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
			DataGridView dataGridView = allRoleListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				string code = selectedRow.Cells["Code"].Value.ToString();

				BO.Role selectedRole = roleService.GetRoleByCode(code);
				RoleEntry roleEntry = new RoleEntry(this);
				roleEntry.SetCurrentUser(this.oCurrentUser);
				roleEntry.EditRole(selectedRole);
				roleEntry._loginID = oCurrentUser.LoginID;
				roleEntry.EditingDone += RoleEntry_EditingDone;
				roleEntry.Show();
			}
			else
			{
				MessageBox.Show("Please select a row for edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void RoleEntry_EditingDone(object sender, EventArgs e)
		{
			this.loadGrid();
		}
		#endregion

		#region Delete Button
		private void deleteButton_Click_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allRoleListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				DialogResult result = MessageBox.Show($"Are you sure to delete this Role?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					string code = selectedRow.Cells["Code"].Value.ToString();
					BO.Role selectedRole = roleService.GetRoleByCode(code);

					string rslt = new RoleService().Delete(selectedRole.ID);
					if (rslt == "Ok")
					{
						MessageBox.Show("Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("Deleted Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				return;
			}
			else
			{
				MessageBox.Show("Please select a row for edit", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		#endregion
	}
}
