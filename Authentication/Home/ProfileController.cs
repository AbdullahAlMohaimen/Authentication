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
	public partial class ProfileController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		List<BO.Role> roleList = new List<BO.Role>();
		DataTable allRoleDataTable = new DataTable();
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		EmployeeService employeeService = new EmployeeService();
		List<BO.Users> userList = new List<BO.Users>();
		List<BO.Employee> employeeList = new List<BO.Employee>();

		BO.Users oUser = new BO.Users();
		List<BO.LoginInfo> useLoginInfos = new List<BO.LoginInfo>();
		#endregion

		public ProfileController()
		{
			InitializeComponent();

			userList = userService.GetUsers();
			employeeList = employeeService.GetEmployees();
			roleList = roleService.GetAllRole();
		}

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;

			if(oCurrentUser != null)
			{
				LoadUserData();
				LoadDashboardData();
			}
		}
		#endregion

		#region Load User Data
		public void LoadUserData()
		{
			oUser = userService.GetUser(oCurrentUser.ID);

			if (oUser != null)
			{
				txt_UserName.Text = oUser.UserName;
				txt_UserNo.Text = oUser.UserNo;
				txt_LoginID.Text = oUser.LoginID;
				txt_UserRole.Text = roleList.Where(x => x.ID == oUser.RoleID).FirstOrDefault() == null ? "" : roleList.Where(x => x.ID == oUser.RoleID).FirstOrDefault().Name;
				txt_UserEmail.Text = oUser.Email;
				txt_UserStatus.Text = oUser.Status.ToString();
				txt_UserIsApprover.Text = oUser.IsApprover == true ? "Yes" : "No";

				BO.Employee oMaster = employeeList.Where(x => x.ID == oUser.MasterID).FirstOrDefault();
				if (oMaster != null)
					txt_UserMaster.Text = oMaster.Name + " [" + oMaster.EmployeeNo + "] ";
				else
					txt_UserMaster.Text = "";
			}
		}
		#endregion

		#region Load User Dashboard Data
		public void LoadDashboardData()
		{
			useLoginInfos = new LoginInfoService().GetLoginInfoByLoginID(oUser.LoginID);


		}
		#endregion
	}
}
