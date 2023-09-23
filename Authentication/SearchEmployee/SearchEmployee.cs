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
		BO.Employee employee = new BO.Employee();
		EmployeeService employeeService = new EmployeeService();
		private Users.UserEntry originalUserEntryForm;
		private Form callingForm;

		#region Load
		public SearchEmployee(Form caller)
		{
			InitializeComponent();
			callingForm = caller;
		}
		#endregion

		#region property
		public string SearchType;
		public string SearchBy
		{
			get { return SearchType; }
			set { SearchType = value; }
		}
		#endregion

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Exit Button
		private void Exit_Click(object sender, EventArgs e)
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

		#region Employee Search Button
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
		#endregion

		#region Select Button
		private void Select_Click(object sender, EventArgs e)
		{
			if(employee != null)
			{
				if (callingForm is Users.UserEntry userEntryForm)
				{
					userEntryForm.SetSelectedEmployee(employee);
					userEntryForm.Show();
				}
				this.Hide();
			}
			else
			{
				MessageBox.Show("Please find an employee first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}
		#endregion
	}
}
