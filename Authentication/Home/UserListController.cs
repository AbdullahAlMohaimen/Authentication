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
				this.setGridColumn();

				foreach (var user in users)
				{
					DataRow row = allUserDataTable.NewRow();
					row["Login ID"] = user.LoginID;
					row["User Name"] = user.UserName;
					var role = roles.Find(x=>x.ID == user.RoleID);
					if (role != null)
					{
						row["Role"] = role.Name;
					}
					row["Status"] = user.Status == EnumStatus.Active ? "Active" : "In-Active";
					row["Email"] = user.Email;
					allUserDataTable.Rows.Add(row);
				}
				allUserGrid.DataSource = allUserDataTable;
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

		#region Set Grid Column
		public void setGridColumn()
		{
			allUserDataTable.Columns.Add("Login ID");
			allUserDataTable.Columns.Add("User Name");
			allUserDataTable.Columns.Add("Role");
			allUserDataTable.Columns.Add("Status");
			allUserDataTable.Columns.Add("Email");
		}
		#endregion
	}
}
