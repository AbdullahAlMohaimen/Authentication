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
		List<BO.Employee> employees = new List<BO.Employee>();
		DataTable allEmployeeDataTable = new DataTable();
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

		#region Find All Employee Batton
		private void btn_findAllEmployee_Click(object sender, EventArgs e)
		{
			try
			{
				employees = employeeService.GetEmployees();
				allEmployeeGrid.Columns.Clear();
				allEmployeeGrid.DataSource = null;
				allEmployeeDataTable.Rows.Clear();
				this.GetGridColumn();

				allEmployeeGrid.AllowUserToAddRows = false;
				foreach (BO.Employee oEmployee in employees)
				{
					DataRow row = allEmployeeDataTable.NewRow();
					row["Employee No"] = oEmployee.EmployeeNo;
					row["Name"] = oEmployee.Name;
					row["Department"] = oEmployee.Department;
					row["Designation"] = oEmployee.Designation;
					row["Gender"] = oEmployee.Gender;
					row["Religion"] = oEmployee.Religion;
					allEmployeeDataTable.Rows.Add(row);
				}
				allEmployeeGrid.DataSource = allEmployeeDataTable;
				this.SetGridColumn();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Get Grid Column
		public void GetGridColumn()
		{
			allEmployeeDataTable.Columns.Clear();
			allEmployeeDataTable.Columns.Add("Employee No");
			allEmployeeDataTable.Columns.Add("Name");
			allEmployeeDataTable.Columns.Add("Department");
			allEmployeeDataTable.Columns.Add("Designation");
			allEmployeeDataTable.Columns.Add("Gender");
			allEmployeeDataTable.Columns.Add("Religion");
		}
		#endregion

		#region Set Grid Column
		public void SetGridColumn()
		{
			allEmployeeGrid.Columns["Employee No"].Width = 90;
			allEmployeeGrid.Columns["Name"].Width = 220;
			allEmployeeGrid.Columns["Department"].Width = 250;
			allEmployeeGrid.Columns["Designation"].Width = 180;
			allEmployeeGrid.Columns["Gender"].Width = 75;
			allEmployeeGrid.Columns["Religion"].Width = 75;
		}
		#endregion

		private void allEmployeeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

			//var x = allEmployeeGrid.CurrentRow.Cells;
			//DataGridViewRow selectedRow = allEmployeeGrid.Rows[e.RowIndex];

			//string column1Value = selectedRow.Cells["Name"].Value.ToString();
			//string column2Value = selectedRow.Cells["Employee No"].Value.ToString();

			//foreach (DataGridViewCell cell in selectedRow.Cells)
			//{
			//	string cellValue = cell.Value.ToString();
			//}

			employee = employeeService.GetEmployee(allEmployeeGrid.CurrentRow.Cells["Employee No"].Value.ToString());
			if (employee != null)
			{
				txt_EmpNo.Text = employee.EmployeeNo;
				txt_EmpName.Text = employee.Name;
				txt_EmpJoiningDate.Text = employee.JoiningDate.ToString("dd MMM yyyy");
				txt_EmpDepartment.Text = employee.Department;
				txt_EmpGender.Text = employee.Gender;
			}
		}
	}
}
