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

namespace Authentication.SearchEmployee
{
	public partial class SearchEmployee : Form
	{
		BO.Employee.Employee employee = new BO.Employee.Employee();
		EmployeeService employeeService = new EmployeeService();

		public SearchEmployee()
		{
			InitializeComponent();
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void EmpSearch_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txt_ID.Text) && string.IsNullOrEmpty(txt_Name.Text))
			{
				MessageBox.Show("PLease enter employee ID or employee NAME first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!string.IsNullOrEmpty(txt_ID.Text) || !string.IsNullOrEmpty(txt_Name.Text))
			{
				employee = employeeService.SearchEmployee(txt_ID.Text,txt_Name.Text);
				if (employee != null)
				{
					txt_EmpNo.Text = employee.EmployeeNo;
					txt_EmpName.Text = employee.Name;
					txt_EmpJoiningDate.Text = employee.JoiningDate.ToString("dd MMM yyyy");
					txt_EmpDepartment.Text = employee.Department;
					txt_EmpGender.Text = employee.Gender;
				}
				else
				{
					employee = null;
					MessageBox.Show("Employee not found\nPLease try again!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
			}

		}

		private void Select_Click(object sender, EventArgs e)
		{
			Users.UserEntry user = new Users.UserEntry(employee);
			user.Show();
			this.Close();
		}
	}
}
