using Authentication.BO;
using Authentication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Home
{
	public partial class EmployeeInformationCOntroller : UserControl
	{
		#region Property (for Search Employee)
		BO.CurrentUser oCurrentUser = new CurrentUser();
		public BO.Employee _selectedEmployee;
		EmployeeService _employeeService = new EmployeeService();
		public BO.Employee SelectedEmployee
		{
			get { return _selectedEmployee; }
			set { _selectedEmployee = value; }
		}
		#endregion

		#region Load
		public EmployeeInformationCOntroller()
		{
			InitializeComponent();
			Clear_Emp_Button.Visible = false;
			SaveEmployee.Enabled = false;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region Active Button Checked
		private void txt_Active_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_Active.Checked == true)
			{
				txt_InActive.Checked = false;
				txt_Locked.Checked = false;
			}

		}
		#endregion

		#region In-Active Button Checked
		private void txt_InActive_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_InActive.Checked == true)
			{
				txt_Active.Checked = false;
				txt_Locked.Checked = false;
			}
		}
		#endregion

		#region Locked Button Checked
		private void txt_Locked_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_Locked.Checked == true)
			{
				txt_Active.Checked = false;
				txt_InActive.Checked = false;
			}
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
				txt_UserMaster.Text = "(" + SEemployee.EmployeeNo + ") - " + SEemployee.Name;
				SelectedEmployee = SEemployee;
			}

			if(SelectedEmployee != null)
			{
				txt_EmpNo.ReadOnly = true;
				SaveEmployee.Enabled = true;
				Clear_Emp_Button.Visible = true;
				this.SetEmployeeProperty();
			}
			else
			{
				Clear_Emp_Button_Click(null,null);
			}
		}
		#endregion

		#region Set Employee Property
		public void SetEmployeeProperty()
		{
			txt_EmpNo.Text = SelectedEmployee.EmployeeNo;
			txt_EmpName.Text = SelectedEmployee.Name;
			txt_EmpEmail.Text = SelectedEmployee.Email;
			txt_EmpMobileNo.Text = SelectedEmployee.MobileNo;
			txt_EmpAccountNo.Text = SelectedEmployee.AccountNo;
			txt_EmpSalary.Text = SelectedEmployee.BasicSalary.ToString();
			txt_EmpAddress.Text = SelectedEmployee.Address;
			txt_EmpDOB.Value = SelectedEmployee.BirthDate;
			txt_EmpJoiningDate.Value = SelectedEmployee.JoiningDate;

			txt_EmpDepartment.SelectedItem = SelectedEmployee.Department;
			txt_EmpDesignation.SelectedItem = SelectedEmployee.Designation;
			txt_EmpGender.SelectedItem = SelectedEmployee.Gender;
			txt_EmpMStatus.SelectedItem = SelectedEmployee.MaritalStatus;
			txt_EmpReligion.SelectedItem = SelectedEmployee.Religion;
			txt_EmpIsConfirm.Checked = (bool)SelectedEmployee.IsConfirmed;
			if (SelectedEmployee.Status == EnumStatus.Active)
				txt_Active.Checked = true;
			if (SelectedEmployee.Status == EnumStatus.Inactive)
				txt_InActive.Checked = true;
			if (SelectedEmployee.Status == EnumStatus.Locked)
				txt_Locked.Checked = true;
		}
		#endregion

		#region Clear Employee Property
		public void ClearEmployeeProperty()
		{
			SelectedEmployee = null;
			txt_EmpNo.Text = string.Empty;
			txt_EmpName.Text = string.Empty;
			txt_EmpEmail.Text = string.Empty;
			txt_EmpMobileNo.Text = string.Empty;
			txt_EmpAccountNo.Text = string.Empty;
			txt_EmpSalary.Text = string.Empty;
			txt_EmpAddress.Text = string.Empty;
			txt_EmpDOB.Value = DateTime.Today;
			txt_EmpJoiningDate.Value = DateTime.Today;
			txt_EmpDepartment.SelectedIndex = 0;
			txt_EmpDesignation.SelectedIndex = 0;
			txt_EmpGender.SelectedIndex = 0;
			txt_EmpMStatus.SelectedIndex = 0;
			txt_EmpReligion.SelectedIndex = 0;
			txt_EmpIsConfirm.Checked = false;
			txt_Active.Checked = false;
			txt_InActive.Checked = false;
			txt_Locked.Checked = false;
		}
		#endregion

		#region Clear Button
		private void Clear_Emp_Button_Click(object sender, EventArgs e)
		{
			txt_UserMaster.Text = string.Empty;
			if (string.IsNullOrEmpty(txt_UserMaster.Text))
			{
				SaveEmployee.Enabled = false;
				Clear_Emp_Button.Visible = false;
				this.ClearEmployeeProperty();
			}
		}
		#endregion

		#region Save Employee Button
		private void SaveEmployee_Click(object sender, EventArgs e)
		{
			if (SelectedEmployee != null)
			{
				SelectedEmployee.EmployeeNo = txt_EmpNo.Text;
				SelectedEmployee.Name = txt_EmpName.Text;
				SelectedEmployee.Email = txt_EmpEmail.Text;
				SelectedEmployee.MobileNo = txt_EmpMobileNo.Text;
				SelectedEmployee.AccountNo = txt_EmpAccountNo.Text;
				SelectedEmployee.BasicSalary = Convert.ToInt32(txt_EmpSalary.Text);
				SelectedEmployee.Address = txt_EmpAddress.Text;
				SelectedEmployee.BirthDate = (DateTime)Convert.ToDateTime(txt_EmpDOB.Text);
				SelectedEmployee.JoiningDate = (DateTime)Convert.ToDateTime(txt_EmpJoiningDate.Text);
				SelectedEmployee.Designation = txt_EmpDesignation.Text;
				SelectedEmployee.Department = txt_EmpDepartment.Text;
				SelectedEmployee.Gender = txt_EmpGender.Text;
				SelectedEmployee.MaritalStatus = txt_EmpMStatus.Text;
				SelectedEmployee.Religion = txt_EmpReligion.Text;
				SelectedEmployee.IsConfirmed = txt_EmpIsConfirm.Checked;

				if (txt_Active.Checked == true)
					SelectedEmployee.Status = EnumStatus.Active;
				if (txt_InActive.Checked == true)
					SelectedEmployee.Status = EnumStatus.Inactive;
				if (txt_Locked.Checked == true)
					SelectedEmployee.Status = EnumStatus.Locked;

				if(SelectedEmployee.IsNew == true)
				{
					SelectedEmployee.CreatedBy = oCurrentUser.ID;
					SelectedEmployee.CreatedDate =DateTime.Now;
				}
				else
				{
					SelectedEmployee.ModifiedBy = oCurrentUser.ID;
					SelectedEmployee.ModifiedDate = DateTime.Now;
				}


				new EmployeeService().SaveEmployeeBasicInfo(SelectedEmployee);
				MessageBox.Show("Employee basic information save successfullly !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("Please select an employee first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		#endregion

		private void txt_UserMaster_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_UserMaster.Text))
			{
				AutoCompleteStringCollection myCollection = new AutoCompleteStringCollection();
				BO.Employee oEmployee = new BO.Employee();
				oEmployee = _employeeService.SearchEmp(txt_UserMaster.Text, txt_UserMaster.Text, txt_UserMaster.Text);
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
	}
}
