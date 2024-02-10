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
using System.Windows.Shell;

namespace Authentication.Home
{
	public partial class UserLoginInfoController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		List<BO.Role> roles = new List<BO.Role>();
		DataTable allRoleDataTable = new DataTable();
		RoleService roleService = new RoleService();
		LoginInfoService loginInfoService = new LoginInfoService();
		UserService userService = new UserService();
		List<BO.Users> userList = new List<BO.Users>();
		List<BO.LoginInfo> allLoginInfo = new List<BO.LoginInfo>();
		
		#endregion

		#region Load
		public UserLoginInfoController()
		{
			InitializeComponent();

			txt_week.Items.Add("Select Week...");
			txt_week.Items.Add("All");
			foreach (EnumWeek week in Enum.GetValues(typeof(EnumWeek)))
			{
				txt_week.Items.Add(week);
			}
			txt_week.SelectedItem = "Select Week...";

			this.loadGrid();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
			txt_fromDate.Value = DateTime.Now.AddDays(-2);
			txt_toDate.Value = DateTime.Now;

			this.GetLoginInfo();
		}
		#endregion

		#region GetLoginInfo
		public void GetLoginInfo()
		{
			try
			{
				DateTime fromDate = (DateTime)Convert.ToDateTime(txt_fromDate.Value);
				DateTime toDate = (DateTime)Convert.ToDateTime(txt_toDate.Value);
				allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate);
				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region ProcessData
		public void ProcessData()
		{
			total.Text = allLoginInfo.Count().ToString();
			DataRow dr = null;
			DataTable loginList = new DataTable();
			loginList.TableName = "Login List";
			loginList.Columns.Add("ID", typeof(int));
			loginList.Columns.Add("Login ID", typeof(string));
			loginList.Columns.Add("User Name", typeof(string));
			loginList.Columns.Add("PC Number", typeof(string));
			loginList.Columns.Add("Login Time", typeof(string));
			loginList.Columns.Add("Logout Time", typeof(string));

			allUserLoginInfoListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allUserLoginInfoListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (BO.LoginInfo oLoginInfo in allLoginInfo)
			{
				dr = loginList.NewRow();
				dr["ID"] = oLoginInfo.ID;
				dr["Login ID"] = oLoginInfo.LoginID;
				dr["User Name"] = oLoginInfo.UserName;
				dr["PC Number"] = oLoginInfo.PCNumber;
				dr["Login Time"] = oLoginInfo.LoginTime.ToString("dd MM yyy-hh:mm tt");
				dr["Logout Time"] = oLoginInfo.LogoutTime == DateTime.MinValue ? "" : oLoginInfo.LogoutTime.Value.ToString("dd MMM yyy-hh:mm tt");
				loginList.Rows.Add(dr);
			}
			allUserLoginInfoListTable.DataSource = loginList;
			//allEmployeeListTable.RowHeadersVisible = false;
			//allEmployeeListTable.Columns["ID"].Visible = false;

			foreach (DataGridViewColumn column in allUserLoginInfoListTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allUserLoginInfoListTable.Columns["User Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			allUserLoginInfoListTable.Columns["PC Number"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			allUserLoginInfoListTable.Columns["Login Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			allUserLoginInfoListTable.Columns["Logout Time"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allUserLoginInfoListTable.RowHeadersVisible = false;
			allUserLoginInfoListTable.Columns["ID"].Visible = false;
		}
		#endregion
	}
}
