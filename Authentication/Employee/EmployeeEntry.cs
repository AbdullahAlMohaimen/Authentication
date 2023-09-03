using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authentication.BO.Global;
using Authentication.BO.Employee;
using Authentication.Service;

namespace Authentication.Employee
{
	public partial class EmployeeEntry : Form
	{
		EmployeeService employeeService = new EmployeeService();
		BO.Employee.Employee employee = new BO.Employee.Employee();

		#region Constructor
		public EmployeeEntry()
		{
			InitializeComponent();
			this.Load();
		}
		#endregion

		#region Employee Data
		public void Load()
		{
			this.txt_EmpGender.SelectedIndex = 0;
			this.txt_EmpReligion.SelectedIndex = 0;
			this.txt_EmpMStatus.SelectedIndex = 0;
			this.txt_EmpDepartment.SelectedIndex = 0;
			this.txt_EmpDesignation.SelectedIndex = 0;
			this.txt_EmpDesignation.AutoCompleteMode = AutoCompleteMode.None;
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
		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Save Employee
		private void SaveEmployee_Click(object sender, EventArgs e)
		{
			string invalidMessage;
			try
			{
				invalidMessage = this.isValidate();
				if (invalidMessage == "")
				{
					employee.Name = txt_EmpName.Text;
					employee.Gender = txt_EmpGender.Text;
					employee.Religion = txt_EmpReligion.Text;
					employee.BirthDate = (DateTime)Convert.ToDateTime(txt_EmpDOB.Text);
					employee.Email = txt_EmpEmail.Text;
					employee.MobileNo = txt_EmpMobileNo.Text;
					employee.AccountNo = string.IsNullOrEmpty(txt_EmpAccountNo.Text) ? null : txt_EmpAccountNo.Text;
					employee.Department = txt_EmpDepartment.Text;
					employee.Designation = txt_EmpDesignation.Text;
					employee.MaritalStatus = string.IsNullOrEmpty(txt_EmpMStatus.Text) ? null : txt_EmpMStatus.Text;
					employee.BasicSalary = (int)Convert.ToInt32(txt_EmpSalary.Text);
					if (txt_EmpIsConfirm.Checked)
					{
						employee.IsConfirmed = txt_EmpIsConfirm.Checked;
					}
					string employeeNo = employeeService.Save(employee);
					if (!string.IsNullOrEmpty(employeeNo))
					{
						this.Clear();
						MessageBox.Show("Employee information save successfully\nA temporary password has been send Employee's email", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Employee information save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				else
				{
					MessageBox.Show(invalidMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				//MessageBox.Show("Employee information save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Clear Method
		public void Clear()
		{
			txt_EmpName.Text = string.Empty;
			txt_EmpGender.SelectedIndex = 0;
			txt_EmpReligion.SelectedIndex = 0;
			txt_EmpDOB.Text = DateTime.Now.ToString();
			txt_EmpMStatus.SelectedIndex = 0;
			txt_EmpMobileNo.Text = string.Empty;
			txt_EmpAccountNo.Text = string.Empty;
			txt_EmpDepartment.SelectedIndex = 0;
			txt_EmpDesignation.SelectedIndex = 0;
			txt_EmpEmail.Text = string.Empty;
			txt_EmpSalary.Text = string.Empty;
			txt_EmpIsConfirm.Checked = false;
		}
		#endregion

		#region Validation
		public string isValidate()
		{
			string invalidMessage = "";
			if (txt_EmpName.Text == "")
			{
				invalidMessage = "Please Enter Employee's Name";
				return invalidMessage;
			}
			if (txt_EmpGender.SelectedIndex == 0)
			{
				invalidMessage = "Please Enter Employee's Gender";
				return invalidMessage;
			}
			if (txt_EmpReligion.SelectedIndex == 0)
			{
				invalidMessage = "Please Enter Employee's Religion";
				return invalidMessage;
			}
			if (Convert.ToDateTime(txt_EmpDOB.Text).Date == DateTime.Now.Date)
			{
				invalidMessage = "Please Enter Employee's Correct Date of Birth";
				return invalidMessage;
			}
			if (txt_EmpMobileNo.Text == "")
			{
				invalidMessage = "Please Enter Employee's Mobile No";
				return invalidMessage;
			}
			if (txt_EmpDepartment.Text == "")
			{
				invalidMessage = "Please Choose Employee's Department";
				return invalidMessage;
			}
			if (txt_EmpDesignation.Text == "")
			{
				invalidMessage = "Please Choose Employee's Designation";
				return invalidMessage;
			}
			if (txt_EmpEmail.Text == "")
			{
				invalidMessage = "Please Choose Employee's Email";
				return invalidMessage;
			}
			if (txt_EmpSalary.Text == "")
			{
				invalidMessage = "Please Choose Employee's Basic Salary";
				return invalidMessage;
			}
			return invalidMessage;
		}
		#endregion
	}
}
