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
				allRoleGrid.Columns.Clear();
				allRoleGrid.DataSource = null;
				allRoleDataTable.Rows.Clear();
				this.GetGridColumn();

				allRoleGrid.AllowUserToAddRows = false;

				foreach (BO.Role oRole in roles)
				{
					DataRow row = allRoleDataTable.NewRow();
					row["Code"] = oRole.Code;
					row["Name"] = oRole.Name;
					row["Status"] = oRole.Status == EnumStatus.Active ? "Active" : "In-Active";
					var oUser = userService.GetUser(oRole.CreatedBy);
					if(oUser != null)
						row["Created By"] = oUser.UserName;
					else
						row["Created By"] = "";

					allRoleDataTable.Rows.Add(row);
				}
				allRoleGrid.DataSource = allRoleDataTable;
				this.SetGridColumn();

				DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
				editButton.HeaderText = "Edit";
				editButton.Text = "Edit";
				editButton.UseColumnTextForButtonValue = true;
				editButton.DefaultCellStyle.BackColor = SystemColors.Control;
				editButton.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
				editButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				editButton.CellTemplate.Style.ForeColor = Color.Maroon;
				editButton.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				allRoleGrid.Columns.Add(editButton);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Get Grid Column
		public void GetGridColumn()
		{
			allRoleDataTable.Columns.Clear();
			allRoleDataTable.Columns.Add("Code");
			allRoleDataTable.Columns.Add("Name");
			allRoleDataTable.Columns.Add("Status");
			allRoleDataTable.Columns.Add("Created By");
		}
		#endregion

		#region Set Grid Column
		public void SetGridColumn()
		{
			allRoleGrid.Columns["Code"].Width = 30;
			allRoleGrid.Columns["Name"].Width = 150;
			allRoleGrid.Columns["Status"].Width = 30;
			allRoleGrid.Columns["Created By"].Width = 400;
		}
		#endregion
	}
}
