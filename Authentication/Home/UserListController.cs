using Authentication.BO;
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

namespace Authentication.Home
{
	public partial class UserListController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		List<BO.Role> roles = new List<BO.Role>();
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
				editButton.DefaultCellStyle.BackColor = SystemColors.Control;
				editButton.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
				editButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				editButton.CellTemplate.Style.BackColor = Color.SeaGreen;
				editButton.CellTemplate.Style.ForeColor = Color.Maroon;
				editButton.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				allUserGrid.Columns.Add(editButton);

				if (users.Count > 0)
				{
					var lastUser = users[users.Count - 1];
					DataGridViewButtonColumn active = new DataGridViewButtonColumn();
					active.HeaderText = "Active";
					active.UseColumnTextForButtonValue = true;
					active.DefaultCellStyle.BackColor = SystemColors.Control;
					active.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
					active.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
					active.CellTemplate.Style.BackColor = Color.SeaGreen;
					active.CellTemplate.Style.ForeColor = Color.Maroon;
					active.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

					// Set the button text based on the last user's status
					active.Text = (lastUser.Status == EnumStatus.Active) ? "In-Active" : "Active";
					allUserGrid.Columns.Add(active);
				}

				DataGridViewButtonColumn action = new DataGridViewButtonColumn();
				action.HeaderText = "Action";
				action.Text = "Reset Password";
				action.UseColumnTextForButtonValue = true;
				action.DefaultCellStyle.BackColor = SystemColors.Control;
				action.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
				action.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				action.CellTemplate.Style.BackColor = Color.SeaGreen;
				action.CellTemplate.Style.ForeColor = Color.Maroon;
				action.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
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
			allUserGrid.Columns["Login ID"].Width = 70;
			allUserGrid.Columns["User Name"].Width = 150;
			allUserGrid.Columns["Role"].Width = 120;
			allUserGrid.Columns["Status"].Width = 70;
			allUserGrid.Columns["Email"].Width = 200;
		}
		#endregion

		#region Grid Button Click
		private void allUserGrid_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridViewRow selectedRow = allUserGrid.Rows[e.RowIndex];
			BO.Users oUser = new BO.Users();

			string loginID = selectedRow.Cells["Login ID"].Value.ToString();
			oUser = userService.GetUserByLoginID(loginID);

			if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Edit")
			{
				UserEntry userEntry = new UserEntry(this);
				userEntry.SetCurrentUser(this.oCurrentUser);
				userEntry.EditUser(oUser);
				userEntry._loginID = oCurrentUser.LoginID;
				userEntry.Show();
			}
			else if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Active")
			{
				string statusString = oUser.Status == EnumStatus.Active ? "In-Active" : "Active";
				DialogResult result = MessageBox.Show($"Are you sure to {statusString} this User?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (result == DialogResult.OK)
				{

				}
				return;
			}
			else if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Action")
			{

			}
			//if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
			//{
			//	if (allUserGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex < allUserGrid.Rows.Count - 1)
			//	{
			//		if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Edit")
			//		{

			//		}
			//		else if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Active")
			//		{

			//		}
			//		else if (allUserGrid.Columns[e.ColumnIndex].HeaderText == "Action")
			//		{

			//		}
			//	}
			//}
		}
		#endregion

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
	}
}
