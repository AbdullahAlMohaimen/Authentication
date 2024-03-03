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
	public partial class UserWiseLoginInformation : UserControl
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
		BO.Users oSelectedUser = new BO.Users();
		#endregion

		#region Load
		public UserWiseLoginInformation()
		{
			InitializeComponent();
			oSelectedUser = null;
			Clear_User_Button.Visible = false;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region User Search Click
		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchUser.SearchUser searchUser = new SearchUser.SearchUser(this);
			searchUser.Show();
		}
		#endregion

		#region Set Selected User
		public void SetSelectedUser(BO.Users oUser)
		{
			oSelectedUser = null;
			if (oUser != null)
			{
				txt_FindUser.Text = "(" + oUser.UserNo + ") - " + oUser.UserName;
				oSelectedUser = oUser;
			}
			if (oSelectedUser != null)
			{
				Clear_User_Button.Visible = true;
			}
			else
			{
				Clear_User_Button.Visible = false;
			}
		}
		#endregion

		#region User Clear Button
		private void Clear_User_Button_Click(object sender, EventArgs e)
		{
			txt_FindUser.Text = string.Empty;
			Clear_User_Button.Visible = false;
		}

		#endregion

		#region User Search Button
		private void UserSearch_Click(object sender, EventArgs e)
		{
			if (oSelectedUser == null)
			{
				MessageBox.Show("PLease select a USER first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			DateTime fromDate = (DateTime)Convert.ToDateTime(txt_fromDate.Value);
			DateTime toDate = (DateTime)Convert.ToDateTime(txt_toDate.Value);

			allLoginInfo = loginInfoService.GetLoginInfosByUserID(oSelectedUser.ID, fromDate, toDate);

			this.ProcessData();
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
				dr["User No"] = userList.Where(x => x.LoginID == oLoginInfo.LoginID).FirstOrDefault() == null ? "" : userList.Where(x => x.LoginID == oLoginInfo.LoginID).FirstOrDefault().UserNo;
				dr["User Name"] = oLoginInfo.UserName;
				dr["PC Number"] = oLoginInfo.PCNumber;
				dr["Login Time"] = $"{oLoginInfo.LoginTime.ToString("dd MMM yyyy-hh:mm tt")} ({oLoginInfo.LoginTime.DayOfWeek.ToString()})";
				dr["Logout Time"] = oLoginInfo.LogoutTime == DateTime.MinValue ? "" : (oLoginInfo.LogoutTime.Value.Year == 1900 ? "" : $"{oLoginInfo.LogoutTime.Value.ToString("dd MMM yyyy-hh:mm tt")} ({oLoginInfo.LogoutTime.Value.DayOfWeek.ToString()})");

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
	}
}
