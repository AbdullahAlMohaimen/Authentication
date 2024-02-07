using Authentication.BO;
using Authentication.HardPasswordSetup;
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
	public partial class HardPasswordController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		DataTable allRoleDataTable = new DataTable();
		UserService userService = new UserService();
		HardPasswordSetupService hpService = new HardPasswordSetupService();
		List<BO.Users> userList = new List<BO.Users>();
		#endregion

		#region Load
		public HardPasswordController()
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
		private void AddNewHardPassword_Click(object sender, EventArgs e)
		{
			HardPasswordSetup.HardPasswordSetup hardPasswordSetup = new HardPasswordSetup.HardPasswordSetup(this);
			hardPasswordSetup.SetCurrentUser(this.oCurrentUser);
			hardPasswordSetup.EditHardPassword(null);
			hardPasswordSetup._loginID = oCurrentUser.LoginID;
			//hardPasswordSetup.EditingDone += RoleEntry_EditingDone;
			hardPasswordSetup.Show();
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
			//this.GetAllHardPassword();
		}
		#endregion
		private void txt_HardPasswordSearch_TextChanged(object sender, EventArgs e)
		{

		}

		private void editButton_click_Click(object sender, EventArgs e)
		{

		}

		private void deleteButton_Click_Click(object sender, EventArgs e)
		{

		}
	}
}
