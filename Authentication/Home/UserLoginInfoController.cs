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
			foreach (EnumWeek week in Enum.GetValues(typeof(EnumWeek)))
			{
				txt_week.Items.Add(week);
			}
			txt_week.SelectedItem = "Select Week...";
			userList = userService.GetUsers();
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
			txt_fromDate.Value = DateTime.Today.AddDays(-2);
			txt_toDate.Value = DateTime.Today.AddDays(1).AddTicks(-1);

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
			loginList.Columns.Add("User No", typeof(string));
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
				dr["User No"] = userList.Where(x => x.LoginID == oLoginInfo.LoginID).FirstOrDefault() == null ? "": userList.Where(x => x.LoginID == oLoginInfo.LoginID).FirstOrDefault().UserNo;
				dr["User Name"] = oLoginInfo.UserName;
				dr["PC Number"] = oLoginInfo.PCNumber;
				dr["Login Time"] = $"{oLoginInfo.LoginTime.ToString("dd MMM yyyy-hh:mm tt")} ({oLoginInfo.LoginTime.DayOfWeek.ToString()})";
				dr["Logout Time"] = oLoginInfo.LogoutTime == DateTime.MinValue? "" : (oLoginInfo.LogoutTime.Value.Year == 1900 ? "" : $"{oLoginInfo.LogoutTime.Value.ToString("dd MMM yyyy-hh:mm tt")} ({oLoginInfo.LogoutTime.Value.DayOfWeek.ToString()})");

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
			allUserLoginInfoListTable.Columns["Login ID"].Visible = false;
		}
		#endregion

		#region Checked Today
		private void IsSamePassword_CheckedChanged(object sender, EventArgs e)
		{
			if (IsToDay.Checked == true)
			{
				DateTime fromDate = DateTime.Today;
				DateTime toDate = DateTime.Today.AddDays(1).AddTicks(-1);

				allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate);

				this.ProcessData();
			}
			else
			{
				this.GetLoginInfo();
			}
		}
		#endregion

		#region Week Select
		private void txt_week_SelectedIndexChanged(object sender, EventArgs e)
		{
			EnumWeek week;
			IsToDay.Checked = false;
			DateTime fromDate = (DateTime)Convert.ToDateTime(txt_fromDate.Value);
			DateTime toDate = (DateTime)Convert.ToDateTime(txt_toDate.Value);
			if (txt_week.SelectedItem == "Select Week...")
			{
				this.GetLoginInfo();
				return;
			}
			else
			{
				week = (EnumWeek)txt_week.SelectedItem;
				allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate, week);
			}
			this.ProcessData();
		}
		#endregion

		#region Search LoginInfo
		private void txt_UserLoginInfoSearch_TextChanged(object sender, EventArgs e)
		{
			EnumWeek week;
			DateTime fromDate = (DateTime)Convert.ToDateTime(txt_fromDate.Value);
			DateTime toDate = (DateTime)Convert.ToDateTime(txt_toDate.Value);

			if (!string.IsNullOrEmpty(txt_UserLoginInfoSearch.Text))
			{
				if (IsToDay.Checked == true)
				{
					fromDate = DateTime.Today;
					toDate = DateTime.Today.AddDays(1).AddTicks(-1);
					allLoginInfo = loginInfoService.SearchLoginInfos(fromDate, toDate, txt_UserLoginInfoSearch.Text);
				}
				else
				{
					if (txt_week.SelectedItem == "Select Week...")
					{
						allLoginInfo = loginInfoService.SearchLoginInfos(fromDate, toDate, txt_UserLoginInfoSearch.Text);
					}
					else
					{
						week = (EnumWeek)txt_week.SelectedItem;
						allLoginInfo = loginInfoService.SearchLoginInfos(fromDate, toDate, txt_UserLoginInfoSearch.Text, week);
					}
				}
			}
			else
			{
				if (IsToDay.Checked == true)
				{
					fromDate = DateTime.Today;
					toDate = DateTime.Today.AddDays(1).AddTicks(-1);
					allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate);
				}
				else
				{
					if (txt_week.SelectedItem == "Select Week...")
					{
						allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate);
					}
					else
					{
						week = (EnumWeek)txt_week.SelectedItem;
						allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate, week);
					}
				}
			}
			this.ProcessData();
		}
		#endregion

		#region Search Click
		private void EmpSearch_Click(object sender, EventArgs e)
		{
			DateTime fromDate = (DateTime)Convert.ToDateTime(txt_fromDate.Value);
			DateTime toDate = (DateTime)Convert.ToDateTime(txt_toDate.Value);

			allLoginInfo = loginInfoService.GetLoginInfos(fromDate, toDate);

			this.ProcessData();
		}
		#endregion
	}
}
