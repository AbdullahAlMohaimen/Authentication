using Authentication.BO;
using Authentication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.SearchUser
{
	public partial class SearchUser : Form
	{
		#region Shadow
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect = 0,
			int nTopRect = 0,
			int nRightRect = 0,
			int nBottomRect = 0,
			int nWidthEllipse = 0,
			int nHeightEllipse = 0
		 );
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
		private bool m_aeroEnabled;
		private const int CS_DROPSHADOW = 0x00020000;
		private const int WM_NCPAINT = 0x0085;
		private const int WM_ACTIVATEAPP = 0x001C;
		public struct MARGINS
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;
		protected override CreateParams CreateParams
		{
			get
			{
				m_aeroEnabled = CheckAeroEnabled();

				CreateParams cp = base.CreateParams;
				if (!m_aeroEnabled)
					cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}
		private bool CheckAeroEnabled()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int enabled = 0;
				DwmIsCompositionEnabled(ref enabled);
				return (enabled == 1) ? true : false;
			}
			return false;
		}
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCPAINT:
					if (m_aeroEnabled)
					{
						var v = 2;
						DwmSetWindowAttribute(this.Handle, 2, ref v, 10);
						MARGINS margins = new MARGINS()
						{
							bottomHeight = 0,
							leftWidth = 0,
							rightWidth = 0,
							topHeight = 0
						};
						DwmExtendFrameIntoClientArea(this.Handle, ref margins);
					}
					break;
				default:
					break;
			}
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
				m.Result = (IntPtr)HTCAPTION;
		}
		#endregion

		#region Property & Variable
		BO.Employee employee = new BO.Employee();
		EmployeeService employeeService = new EmployeeService();
		UserService userService = new UserService();
		List<BO.Employee> employees = new List<BO.Employee>();
		DataTable allEmployeeDataTable = new DataTable();
		private UserControl callingController;
		BO.Users oUser = new BO.Users();
		List<BO.Users> oUsers = new List<BO.Users>();
		List<BO.Role> allRoles = new List<BO.Role>();
		#endregion

		#region Load
		public SearchUser(UserControl userControl)
		{
			InitializeComponent();
			callingController = userControl;
			allRoles = new RoleService().GetAllRole();
		}
		#endregion

		#region Find All Button
		private void btn_findAllUsers_Click(object sender, EventArgs e)
		{
			try
			{
				oUsers = userService.Get(EnumStatus.Active);
				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Process Search Users
		public void ProcessData()
		{
			total.Text = oUsers.Count().ToString();
			DataRow dr = null;
			DataTable userList = new DataTable();
			userList.TableName = "User List";

			userList.Columns.Add("ID", typeof(int));
			userList.Columns.Add("User No", typeof(string));
			userList.Columns.Add("Name", typeof(string));
			userList.Columns.Add("Role", typeof(string));
			userList.Columns.Add("Status", typeof(string));

			allUserListDataTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allUserListDataTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (BO.Users oUser in oUsers)
			{
				dr = userList.NewRow();
				dr["ID"] = oUser.ID;
				dr["User No"] = oUser.UserNo;
				dr["Name"] = oUser.UserName;
				BO.Role oRole= allRoles.Find(x => x.ID == oUser.RoleID);
				dr["Role"] = oRole == null ? "" : oRole.Name;
				dr["Status"] = oUser.Status.ToString();

				userList.Rows.Add(dr);
			}
			allUserListDataTable.DataSource = userList;

			foreach (DataGridViewColumn column in allUserListDataTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allUserListDataTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allUserListDataTable.RowHeadersVisible = false;
			allUserListDataTable.Columns["ID"].Visible = false;
		}
		#endregion

		#region Search Button Click
		private void btn_UserSearch_Click(object sender, EventArgs e)
		{
			if(string.IsNullOrEmpty(txt_ID.Text) && string.IsNullOrEmpty(txt_Name.Text))
			{
				MessageBox.Show("PLease enter user NO or user NAME first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!string.IsNullOrEmpty(txt_ID.Text) || !string.IsNullOrEmpty(txt_Name.Text))
			{
				oUser = new BO.Users();
				oUser = userService.SearchUsers(txt_ID.Text,txt_Name.Text);
				if (oUser != null)
				{
					txt_UserNo.Text = oUser.UserNo;
					txt_UserName.Text = oUser.UserName;
					txt_UserRole.Text = allRoles.Where(x => x.ID == oUser.RoleID).FirstOrDefault().Name;
					txt_UserStatus.Text = oUser.Status.ToString();
					txt_UserEmail.Text = oUser.Email;
					txt_UserApprover.Text = oUser.IsApprover == true ? "Yes" : "No";
				}
				else
				{
					txt_UserNo.Text = "";
					txt_UserName.Text = "";
					txt_UserRole.Text = "";
					txt_UserStatus.Text = "";
					txt_UserEmail.Text = "";
					txt_UserApprover.Text = "";
					MessageBox.Show("User not found\nPLease try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

					txt_ID.Text = string.Empty;
					txt_Name.Text = string.Empty;
					return;
				}
			}
		}
		#endregion

		#region Exit Button
		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		#endregion

		#region Active Checked
		private void txt_Active_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_Active.Checked == true)
			{
				txt_All.Checked = false;
				oUsers = userService.Get(EnumStatus.Active);
				this.ProcessData();
			}
		}
		#endregion

		#region All Checked
		private void txt_All_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_All.Checked == true)
			{
				txt_Active.Checked = false;
				oUsers = userService.GetUsers();
				this.ProcessData();
			}
			else
			{
				btn_findAllUsers_Click(null,null);
			}
		}
		#endregion

		#region Search
		private void txt_UserSearch_TextChanged(object sender, EventArgs e)
		{
			if (oUsers.Count != 0)
			{
				if (!string.IsNullOrEmpty(txt_UserSearch.Text))
				{
					if (txt_Active.Checked == false && txt_All.Checked == false)
					{
						oUsers = userService.UserSearch(txt_UserSearch.Text, EnumStatus.Active);
					}
					else
					{
						if (txt_Active.Checked == true)
						{
							oUsers = userService.UserSearch(txt_UserSearch.Text, EnumStatus.Active);
						}
						if (txt_All.Checked == true)
						{
							oUsers = userService.UserSearch(txt_UserSearch.Text, EnumStatus.Regardless);
						}
					}
				}
				else
				{
					if (txt_Active.Checked == true)
					{
						oUsers = userService.Get(EnumStatus.Active);
					}
					else if (txt_All.Checked == true)
					{
						oUsers = userService.GetUsers();
					}
					else
					{
						oUsers = userService.Get(EnumStatus.Active);
					}
				}
			}
			else
			{
				return;
			}
			this.ProcessData();
		}
		#endregion

		#region Grid Click
		private void allUserListDataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = allUserListDataTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int userID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());

				oUser = new BO.Users();
				oUser = oUsers.Where(x => x.ID == userID).FirstOrDefault();
				if (oUser != null)
				{
					txt_UserNo.Text = oUser.UserNo;
					txt_UserName.Text = oUser.UserName;
					txt_UserRole.Text = allRoles.Where(x => x.ID == oUser.RoleID).FirstOrDefault().Name;
					txt_UserStatus.Text = oUser.Status.ToString();
					txt_UserEmail.Text = oUser.Email;
					txt_UserApprover.Text = oUser.IsApprover == true ? "Yes" : "No";
				}
			}
		}
		#endregion

		#region Select Button
		private void Select_Click(object sender, EventArgs e)
		{
			if (oUser != null)
			{
				if (oUser.ID > 0)
				{
					if (callingController is Home.UserWiseLoginInformation oUserLoginInfo)
					{
						oUserLoginInfo.SetSelectedUser(oUser);
						oUserLoginInfo.Show();
					}
					this.Close();
				}
				else
				{
					MessageBox.Show("Please find an employee first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			else
			{
				MessageBox.Show("Please find an employee first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		#endregion
	}
}
