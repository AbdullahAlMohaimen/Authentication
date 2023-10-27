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
		UserService userService = new UserService();
		public UserListController()
		{
			InitializeComponent();

			this.GetAllUsers();
		}

		#region Get ALL Users
		public void GetAllUsers()
		{
			List<BO.Users> users = new List<BO.Users>();	
			try
			{
				users = userService.GetUsers();
				allUserGrid.DataSource = users;
			}
			catch (Exception ex)
			{
				//MessageBox.Show("Please enter your login ID!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
	}
}
