using Authentication.BO;
using Authentication.Role;
using Authentication.Service;
using Authentication.Users;
using Guna.UI2.WinForms;
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

			txt_RoleStatus.Items.Add("Select Status...............");
			txt_RoleStatus.Items.Add("All");
			foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
			{
				if (status == EnumStatus.Regardless || status == EnumStatus.Active || status == EnumStatus.Inactive)
				{
					txt_RoleStatus.Items.Add(status);
				}
			}
			txt_RoleStatus.SelectedItem = "Select Status...............";
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
			roleEntry.EditingDone += RoleEntry_EditingDone;
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
				roles = roleService.GetAllRole(EnumStatus.Active);
				userList = new UserService().GetUsers();

				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Process Role Data
		public void ProcessData()
		{
			total.Text = roles.Count().ToString();
			DataRow dr = null;
			DataTable roleList = new DataTable();
			roleList.TableName = "Role List";
			roleList.Columns.Add("ID", typeof(int));
			roleList.Columns.Add("Code", typeof(string));
			roleList.Columns.Add("Name", typeof(string));
			roleList.Columns.Add("Status", typeof(string));
			roleList.Columns.Add("Description", typeof(string));
			roleList.Columns.Add("Created By", typeof(string));

			allRoleListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allRoleListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (BO.Role oRole in roles)
			{
				dr = roleList.NewRow();
				dr["ID"] = oRole.ID;
				dr["Code"] = oRole.Code;
				dr["Name"] = oRole.Name;
				dr["Status"] = oRole.Status.ToString();
				dr["Description"] = oRole.Description;
				BO.Users oUser = new BO.Users();
				oUser = userList.Where(x => x.ID == oRole.CreatedBy).FirstOrDefault();
				dr["Created By"] = oUser == null ? "" : oUser.UserName;

				roleList.Rows.Add(dr);
			}
			allRoleListTable.DataSource = roleList;



			foreach (DataGridViewColumn column in allRoleListTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allRoleListTable.Columns["Description"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			allRoleListTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			allRoleListTable.Columns["Created By"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allRoleListTable.RowHeadersVisible = false;
			allRoleListTable.Columns["ID"].Visible = false;
		}
		#endregion

		#region Edit Button
		private void editButton_click_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allRoleListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int roleID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());

				BO.Role selectedRole = roleService.GetRoleByID(roleID);
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
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int roleID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
				BO.Role selectedRole = roleService.GetRoleByID(roleID);

				DialogResult result = MessageBox.Show($"Are you sure to delete this Role?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
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
				MessageBox.Show("Please select a row for Delete", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}
		#endregion

		#region Search Role
		private void txt_RoleSearch_TextChanged(object sender, EventArgs e)
		{
			roles = new List<BO.Role>();
			userList = new UserService().GetUsers();
			EnumStatus Status;
			if (!string.IsNullOrEmpty(txt_RoleSearch.Text))
			{
				string searchText = txt_RoleSearch.Text;
				if (txt_RoleStatus.SelectedItem == "Select Status...............")
				{
					Status = EnumStatus.Active;
					roles = roleService.SearchRole(searchText, Status);
				}
				else if (txt_RoleStatus.SelectedItem == "All")
				{
					roles = roleService.SearchRole(searchText);
				}
				else
				{
					Status = (EnumStatus)txt_RoleStatus.SelectedItem;
					roles = roleService.SearchRole(searchText, Status);
				}
			}
			else
			{
				if (txt_RoleStatus.SelectedItem == "Select Status...............")
				{
					roles = roleService.GetAllRole(EnumStatus.Active);
				}
				else if (txt_RoleStatus.SelectedItem == "All")
				{
					roles = roleService.GetAllRole();
				}
				else
				{
					Status = (EnumStatus)txt_RoleStatus.SelectedItem;
					roles = roleService.GetAllRole(Status);
				}
			}
			this.ProcessData();

		}
		#endregion

		#region Dropdown
		private void txt_EmpDesignation_SelectedIndexChanged(object sender, EventArgs e)
		{
			EnumStatus Status;
			roles = new List<BO.Role>();
			userList = new UserService().GetUsers();
			if (txt_RoleStatus.SelectedItem == "Select Status...............")
			{
				this.loadGrid();
			}
			else if (txt_RoleStatus.SelectedItem == "All")
			{
				roles = roleService.GetAllRole();
			}
			else
			{
				Status = (EnumStatus)txt_RoleStatus.SelectedItem;
				roles = roleService.GetAllRole(Status);
			}
			this.ProcessData();
		}
		#endregion
	}
}
