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

namespace Authentication.Home
{
	public partial class UserListController : UserControl
	{
		List<BO.Role> roles = new List<BO.Role>();
		DataTable allUserDataTable = new DataTable();
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		public UserListController()
		{
			InitializeComponent();

			this.GetAllRole();
			this.GetAllUsers();

		}

		#region Get ALL Users
		public void GetAllUsers()
		{
			List<BO.Users> users = new List<BO.Users>();	
			try
			{
				users = userService.GetUsers();
				this.GetGridColumn();

				allUserGrid.AllowUserToAddRows = false;
				foreach (var user in users)
				{
					DataRow row = allUserDataTable.NewRow();
					row["Login ID"] = user.LoginID;
					row["User Name"] = user.UserName;
					var role = roles.Find(x=>x.ID == user.RoleID);
					if (role != null)
						row["Role"] = role.Name;
					row["Status"] = user.Status == EnumStatus.Active ? "Active" : "In-Active";
					row["Email"] = user.Email;
					allUserDataTable.Rows.Add(row);
				}
				allUserGrid.DataSource = allUserDataTable;

				this.SetGridColumn();

				DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
				editButton.HeaderText = "Edit";
				editButton.Text = "Edit";
				editButton.UseColumnTextForButtonValue = true;
				allUserGrid.Columns.Add(editButton);

				DataGridViewButtonColumn active = new DataGridViewButtonColumn();
				active.HeaderText = "Active";
				active.Text = "Active";
				active.UseColumnTextForButtonValue = true;
				allUserGrid.Columns.Add(active);

				DataGridViewButtonColumn action = new DataGridViewButtonColumn();
				action.HeaderText = "Action";
				action.Text = "Reset Password";
				action.UseColumnTextForButtonValue = true;
				allUserGrid.Columns.Add(action);


			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		#endregion

		#region Get ALL Users
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

		#region Get Grid Column
		public void GetGridColumn()
		{
			allUserDataTable.Columns.Add("Login ID");
			allUserDataTable.Columns.Add("User Name");
			allUserDataTable.Columns.Add("Role");
			allUserDataTable.Columns.Add("Status");
			allUserDataTable.Columns.Add("Email");
		}
		#endregion

		#region Set Grid Column
		public void SetGridColumn()
		{
			allUserGrid.Columns["Login ID"].Width = 80;
			allUserGrid.Columns["User Name"].Width = 130;
			allUserGrid.Columns["Role"].Width = 120;
			allUserGrid.Columns["Status"].Width = 80;
			allUserGrid.Columns["Email"].Width = 200;
		}
		#endregion

		// Event handler for cell click
		private void allUserGrid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			{
				// Check if the clicked cell is a button cell
				if (allUserGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex < allUserGrid.Rows.Count - 1)
				{
					// Check which button column was clicked
					if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Edit")
					{

					}
					else if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Active")
					{

					}
					else if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Action")
					{

					}
				}
			}
		}

	}
}
