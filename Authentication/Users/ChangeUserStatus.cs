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

namespace Authentication.Users
{
	public partial class ChangeUserStatus : Form
	{
		#region property / Variable
		public event EventHandler EditingDone;
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		EmployeeService employeeService = new EmployeeService();
		List<BO.Role> _roles = new List<BO.Role>();
		List<BO.Users> _users = new List<BO.Users>();
		BO.Role _role = new BO.Role();
		BO.Users _user = new BO.Users();
		BO.Password _password = new BO.Password();
		BO.CurrentUser oCurrentUser = new CurrentUser();
		private UserControl callingForm;
		public string _loginID;
		public string LoginID { get { return _loginID; } set { _loginID = value; } }
		#endregion

		#region Constructor(Load)
		public ChangeUserStatus(UserControl caller)
		{
			InitializeComponent();
			callingForm = caller;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oCUser)
		{
			oCurrentUser = oCUser;
		}
		#endregion

		#region SetEditedUser & Type
		public void EditUser(BO.Users oUser)
		{
			_user = oUser;
			string status;
			if (_user != null)
			{
				status = _user.Status.ToString();
				txt_User.Text = "(" + _user.LoginID + ") " + _user.UserName;
				statusString.Text = status.ToUpper();

				switch (_user.Status)
				{
					case EnumStatus.Active:
						isActive.Checked = true;
						isInActive.Checked = false;
						isLocked.Checked = false;
						isPasswordExpired.Checked = false;
						break;
					case EnumStatus.Inactive:
						isActive.Checked = false;
						isInActive.Checked = true;
						isLocked.Checked = false;
						isPasswordExpired.Checked = false;
						break;
					case EnumStatus.Locked:
						isActive.Checked = false;
						isInActive.Checked = false;
						isLocked.Checked = true;
						isPasswordExpired.Checked = false;
						break;
					case EnumStatus.PasswordExpired:
						isActive.Checked = false;
						isInActive.Checked = false;
						isLocked.Checked = false;
						isPasswordExpired.Checked = true;
						break;
					default :
						break;
				}
			}
		}
		#endregion

		#region GET Role
		public void LoadRoalData()
		{
			try
			{
				_roles = roleService.GetAllRole();
			}
			catch (Exception ex)
			{

			}
		}
		#endregion

		#region Minimize Button
		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
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

		#region ChangeStatus
		private void ChangeStatus_Click(object sender, EventArgs e)
		{
			EnumStatus newStatus;

			if (isActive.Checked == true)
				newStatus = EnumStatus.Active;
			else if (isInActive.Checked == true)
				newStatus = EnumStatus.Inactive;
			else if (isLocked.Checked == true)
				newStatus = EnumStatus.Locked;
			else if (isPasswordExpired.Checked == true)
				newStatus = EnumStatus.PasswordExpired;
			else
				newStatus = EnumStatus.None;

			if (newStatus == EnumStatus.None)
			{
				MessageBox.Show("Please select any status, otherwize you can't change user's status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (_user.Status == newStatus)
			{
				MessageBox.Show("This is user's previous status.\nPlease choose another status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			_user.Status = newStatus;
			_user.StatusChangedDate = DateTime.Now;
			_user.ModifiedBy = oCurrentUser.ID;
			_user.ModifiedDate = DateTime.Now;

			try
			{
				string result = userService.UpdateUserStatus(_user.ID, newStatus, oCurrentUser.ID, DateTime.Now, DateTime.Now);

				if (result == "Ok")
				{
					MessageBox.Show($"User status changed successfully.\n{_user.UserName} is now {newStatus.ToString()}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show("Failed.\nPlease try again", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}

				EditingDone?.Invoke(this, EventArgs.Empty);
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region Is Active Change
		private void isActive_CheckedChanged(object sender, EventArgs e)
		{
			if (isActive.Checked == true)
			{
				isActive.Checked = true;
				isInActive.Checked = false;
				isLocked.Checked = false;
				isPasswordExpired.Checked = false;
			}
		}
		#endregion

		#region Is InActive Change
		private void isInActive_CheckedChanged(object sender, EventArgs e)
		{
			if (isInActive.Checked == true)
			{
				isActive.Checked = false;
				isInActive.Checked = true;
				isLocked.Checked = false;
				isPasswordExpired.Checked = false;
			}
		}
		#endregion

		#region Is Locked Change
		private void isLocked_CheckedChanged(object sender, EventArgs e)
		{
			if (isLocked.Checked == true)
			{
				isActive.Checked = false;
				isInActive.Checked = false;
				isLocked.Checked = true;
				isPasswordExpired.Checked = false;
			}
		}
		#endregion

		#region Is Password Expired Change
		private void isPasswordExpired_CheckedChanged(object sender, EventArgs e)
		{
			if (isPasswordExpired.Checked == true)
			{
				isActive.Checked = false;
				isInActive.Checked = false;
				isLocked.Checked = false;
				isPasswordExpired.Checked = true;
			}
		}
		#endregion
	}
}
