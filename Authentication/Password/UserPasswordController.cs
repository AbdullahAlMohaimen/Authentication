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

namespace Authentication.Password
{
	public partial class UserPasswordController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new BO.CurrentUser();
		List<BO.Role> roleList = new List<BO.Role>();
		DataTable allRoleDataTable = new DataTable();
		RoleService roleService = new RoleService();
		LoginInfoService loginInfoService = new LoginInfoService();
		UserService userService = new UserService();
		List<BO.Users> userList = new List<BO.Users>();
		List<BO.LoginInfo> allLoginInfo = new List<BO.LoginInfo>();
		List<BO.Employee> employeeList = new List<BO.Employee>();
		BO.Users oSelectedUser = new BO.Users();
		EmployeeService employeeService = new EmployeeService();
		List<PasswordResetHistory> _passwordResetHistories = new List<PasswordResetHistory>();
		#endregion

		#region Load
		public UserPasswordController()
		{
			InitializeComponent();
			oSelectedUser = null;
			Clear_User_Button.Visible = false;

			userList = userService.GetUsers();
			employeeList = employeeService.GetEmployees();
			roleList = roleService.GetAllRole();

			LoadUserPasswordResetHistoryData();
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
				LoadUserData();
				LoadUserPasswordResetHistoryData();
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

		#region Load User Data
		public void LoadUserData()
		{
			if (oSelectedUser != null)
			{
				txt_UserNo.Text = oSelectedUser.UserNo;
				txt_UserName.Text = oSelectedUser.UserName;
				txt_UserRole.Text = roleList.Where(x => x.ID == oSelectedUser.RoleID).FirstOrDefault() == null ? "" : roleList.Where(x => x.ID == oSelectedUser.RoleID).FirstOrDefault().Name;
				txt_UserEmail.Text = oSelectedUser.Email;
				txt_UserStatus.Text = oSelectedUser.Status.ToString();
				txt_UserIsApprover.Text = oSelectedUser.IsApprover == true ? "Yes" : "No";
				txt_LastPasswordChangeDate.Text = oSelectedUser.LastChangeDate == DateTime.MinValue ? "" : oSelectedUser.LastChangeDate.ToString("dd MMM yyyy | hh:mm tt");

				BO.Employee oMaster = employeeList.Where(x => x.ID == oSelectedUser.MasterID).FirstOrDefault();
				if (oMaster != null)
					txt_UserMaster.Text = oMaster.Name + " [" + oMaster.EmployeeNo + "] ";
				else
					txt_UserMaster.Text = "";
			}
		}
		#endregion

		#region Load User Password Reset History Data
		public void LoadUserPasswordResetHistoryData()
		{
			if (oSelectedUser != null)
			{
				_passwordResetHistories = new PasswordResetHistoryService().GetByUserID(oSelectedUser.ID);
				this.ProcessData();
			}
		}
		#endregion

		#region ProcessData
		public void ProcessData()
		{
			total.Text = _passwordResetHistories.Count().ToString();
			DataRow dr = null;
			DataTable passwordResetHistoryList = new DataTable();
			passwordResetHistoryList.TableName = "User Password Reset History List";
			passwordResetHistoryList.Columns.Add("ID", typeof(int));
			passwordResetHistoryList.Columns.Add("User No", typeof(string));
			passwordResetHistoryList.Columns.Add("Password Reset By", typeof(string));
			passwordResetHistoryList.Columns.Add("Password Reset Date", typeof(string));
			passwordResetHistoryList.Columns.Add("Reason", typeof(string));

			userPasswordResetTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			userPasswordResetTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (BO.PasswordResetHistory oPasswordResetHistory in _passwordResetHistories)
			{
				dr = passwordResetHistoryList.NewRow();
				dr["ID"] = oPasswordResetHistory.ID;
				dr["User No"] = oSelectedUser.UserNo;
				BO.Users oUser = userList.Where(x => x.ID == oPasswordResetHistory.PasswordResetBy).FirstOrDefault();
				dr["Password Reset By"] = oUser == null ? "" : "["+ oUser.UserNo + "] " + oUser.UserName;
				dr["Password Reset Date"] = oPasswordResetHistory.PasswordResetDate.ToString("dd MMM yyyy");
				dr["Reason"] = oPasswordResetHistory.Reason;
				passwordResetHistoryList.Rows.Add(dr);
			}
			userPasswordResetTable.DataSource = passwordResetHistoryList;

			foreach (DataGridViewColumn column in userPasswordResetTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			userPasswordResetTable.Columns["Password Reset By"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
			userPasswordResetTable.Columns["Reason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			userPasswordResetTable.RowHeadersVisible = false;
			userPasswordResetTable.Columns["ID"].Visible = false;
		}
		#endregion

		#region User Clear Button
		private void Clear_User_Button_Click(object sender, EventArgs e)
		{
			oSelectedUser = null;
			txt_FindUser.Text = string.Empty;
			Clear_User_Button.Visible = false;

			txt_UserNo.Text = "";
			txt_UserName.Text = "";
			txt_UserRole.Text = "";
			txt_UserEmail.Text = "";
			txt_UserStatus.Text = "";
			txt_UserIsApprover.Text = "";
			txt_UserMaster.Text = "";
			txt_LastPasswordChangeDate.Text = "";
			this.LoadUserPasswordResetHistoryData();
		}
		#endregion

		#region User Search Text
		private void txt_FindUser_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_FindUser.Text))
			{
				AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
				BO.Users oUser = new BO.Users();
				oUser = new UserService().SearchUser(txt_FindUser.Text, txt_FindUser.Text, txt_FindUser.Text);
				if (oUser != null)
				{
					SetSelectedUser(oUser);
				}
				else
				{
					return;
				}
			}
			else
			{
				SetSelectedUser(null);
			}
		}
		#endregion

		#region Password Reset Button
		private void passwordReset_btnClick_Click(object sender, EventArgs e)
		{
			string passwordResetReason = "";
			try
			{
				if (oSelectedUser != null)
				{
					if (oSelectedUser.ID == oCurrentUser.ID)
					{
						MessageBox.Show("Current user and selected user can't be the same.\nThe current user can't reset his own password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (oSelectedUser.Status != EnumStatus.Active)
					{
						MessageBox.Show("This user is now " + oSelectedUser.Status.ToString() + "\nYou can't reset a new password to this user.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					if (oSelectedUser.PasswordResetByAdmin == true)
					{
						MessageBox.Show("Already a new password reset to this User's email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					if (string.IsNullOrEmpty(txt_PasswordResetReason.Text))
					{
						MessageBox.Show("Please write a reason for Password Reset", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return;
					}

					passwordResetReason = txt_PasswordResetReason.Text;
					DialogResult result = MessageBox.Show($"Are you sure to reset the password to this User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (result == DialogResult.Yes)
					{
						oSelectedUser.PasswordResetByAdmin = true;
						oSelectedUser.PasswordResetBy = oCurrentUser.ID;
						oSelectedUser.PasswordResetDate = DateTime.Now;

						string passwordResetStatus = userService.PasswordResetByAdminNew(oSelectedUser, passwordResetReason);

						if (passwordResetStatus == "Ok")
						{
							MessageBox.Show("You have successfully reset a new password to this user email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						}
						LoadUserPasswordResetHistoryData();
					}
				}
				else
				{
					MessageBox.Show("Please select an User.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
	}
}
