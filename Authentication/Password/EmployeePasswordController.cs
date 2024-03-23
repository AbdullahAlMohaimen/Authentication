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
	public partial class EmployeePasswordController : UserControl
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
		EmployeeService _employeeService = new EmployeeService();
		BO.Employee SelectedEmployee = new BO.Employee();
		#endregion

		#region Load
		public EmployeePasswordController()
		{
			InitializeComponent();
			Clear_Emp_Button.Visible = false;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region Search Button Click
		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchEmployee.SearchEmployeeInformation searchEmployeeInformation = new SearchEmployee.SearchEmployeeInformation(this);
			searchEmployeeInformation.Show();
		}
		#endregion

		#region Set Selected Employee
		public void SetSelectedEmployee(BO.Employee SEemployee)
		{
			SelectedEmployee = null;
			if (SEemployee != null)
			{
				txt_UserSearchText.Text = "(" + SEemployee.EmployeeNo + ") - " + SEemployee.Name;
				SelectedEmployee = SEemployee;
			}

			if (SelectedEmployee != null)
			{
				Clear_Emp_Button.Visible = true;
				this.SetEmployeeProperty();
			}
			else
			{
				Clear_Emp_Button.Visible = false;
				this.ClearEmployeeProperty();
			}
		}
		#endregion

		#region Clear Employee Property
		private void Clear_Emp_Button_Click(object sender, EventArgs e)
		{
			txt_UserSearchText.Text = string.Empty;
			if (string.IsNullOrEmpty(txt_UserSearchText.Text))
			{
				Clear_Emp_Button.Visible = false;
				this.ClearEmployeeProperty();
			}
		}
		#endregion

		#region Set Employee Property
		public void SetEmployeeProperty()
		{
			if (SelectedEmployee != null)
			{
				txt_EmployeeNo.Text = SelectedEmployee.EmployeeNo;
				txt_EmployeeName.Text = SelectedEmployee.Name;
				txt_EmployeeGender.Text = SelectedEmployee.Gender;
				txt_EmployeeReligion.Text = SelectedEmployee.Religion;
				txt_EmployeeDepartment.Text = SelectedEmployee.Department;
				txt_EmployeeDesignation.Text = SelectedEmployee.Designation;
				txt_EmployeeMaritalStatus.Text = SelectedEmployee.MaritalStatus;
				txt_EmployeeStatus.Text = SelectedEmployee.Status.ToString();
				txt_EmployeeConfirmation.Text = SelectedEmployee.IsConfirmed == true ? "Yes" : "No";
				txt_EmployeeEmail.Text = SelectedEmployee.Email;
				txt_EmployeePhoneNo.Text = SelectedEmployee.MobileNo;
				txt_LastPasswordChangeDate.Text = SelectedEmployee.LastChangedDate == DateTime.MinValue ? "" : SelectedEmployee.LastChangedDate.Value.ToString("dd MMM yyyy | hh:mm tt");
			}
		}
		#endregion

		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_UserSearchText.Text))
			{
				AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
				BO.Employee oEmployee = new BO.Employee();
				oEmployee = _employeeService.SearchEmp(txt_UserSearchText.Text, txt_UserSearchText.Text, txt_UserSearchText.Text);
				if (oEmployee != null)
				{
					SetSelectedEmployee(oEmployee);
				}
				else
				{
					this.ClearEmployeeProperty();
				}
			}
			else
			{
				SetSelectedEmployee(null);
			}
		}

		#region Clear Employee Property
		public void ClearEmployeeProperty()
		{
			txt_EmployeeNo.Text = "";
			txt_EmployeeName.Text = "";
			txt_EmployeeGender.Text = "";
			txt_EmployeeReligion.Text = "";
			txt_EmployeeDepartment.Text = "";
			txt_EmployeeDesignation.Text = "";
			txt_EmployeeMaritalStatus.Text = "";
			txt_EmployeeStatus.Text = "";
			txt_EmployeeConfirmation.Text = "";
			txt_EmployeeEmail.Text = "";
			txt_EmployeePhoneNo.Text = "";
			txt_LastPasswordChangeDate.Text = "";
		}
		#endregion

		private void PasswordReset_Click(object sender, EventArgs e)
		{
			if (SelectedEmployee != null)
			{
				if (SelectedEmployee.IsConfirmed == false)
				{
					MessageBox.Show("This employee isn't confirmed yet.\nYou can't reset a new password to this employee email. !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}

				DialogResult result = MessageBox.Show($"Are you sure to reset the password to this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (result == DialogResult.Yes)
				{
					SelectedEmployee.PasswordResetByAdmin = true;
					SelectedEmployee.PasswordResetBy = oCurrentUser.ID;
					SelectedEmployee.PasswordResetDate = DateTime.Now;

					string passwordResetStatus = _employeeService.PasswordResetByAdmin(SelectedEmployee);

					if (passwordResetStatus == "Ok")
					{
						MessageBox.Show("You have successfully reset a new password to this employee email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
			else
			{
				MessageBox.Show("Please find an Employee First !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				return;
			}
		}
	}
}
