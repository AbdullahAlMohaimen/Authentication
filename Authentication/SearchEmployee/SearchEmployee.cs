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

namespace Authentication.SearchEmployee
{
	public partial class SearchEmployee : Form
	{
		#region Property & Variable
		BO.Employee employee = new BO.Employee();
		EmployeeService employeeService = new EmployeeService();
		List<BO.Employee> employees = new List<BO.Employee>();
		DataTable allEmployeeDataTable = new DataTable();
		private Users.UserEntry originalUserEntryForm;
		private Form callingForm;
		#endregion

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
				total.Text = employees.Count().ToString();
				this.ProcessData();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Process Search Employee
		public void ProcessData()
		{
			DataRow dr = null;
			DataTable employeeList = new DataTable();
			employeeList.TableName = "Employee List";

			employeeList.Columns.Add("ID", typeof(int));
			employeeList.Columns.Add("Employee No", typeof(string));
			employeeList.Columns.Add("Name", typeof(string));
			employeeList.Columns.Add("Department", typeof(string));
			employeeList.Columns.Add("Designation", typeof(string));
			employeeList.Columns.Add("Gender", typeof(string));
			employeeList.Columns.Add("Religion", typeof(string));

			allEmployeeListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allEmployeeListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

			foreach (BO.Employee oEmployee in employees)
			{
				dr = employeeList.NewRow();
				dr["ID"] = oEmployee.ID;
				dr["Employee No"] = oEmployee.EmployeeNo;
				dr["Name"] = oEmployee.Name;
				dr["Department"] = oEmployee.Department;
				dr["Designation"] = oEmployee.Designation;
				dr["Gender"] = oEmployee.Gender;
				dr["Religion"] = oEmployee.Religion;
				employeeList.Rows.Add(dr);
			}
			allEmployeeListTable.DataSource = employeeList;

			foreach (DataGridViewColumn column in allEmployeeListTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allEmployeeListTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allEmployeeListTable.RowHeadersVisible = false;
			allEmployeeListTable.Columns["ID"].Visible = false;
		}
		#endregion

		#region Grid Column CLick
		private void allEmployeeListTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dataGridView = allEmployeeListTable;
			if (dataGridView.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
				int employeeID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());

				employee = employeeService.GetEmployee(employeeID);
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
		#endregion

		private void txt_UserSearch_TextChanged(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(txt_UserSearch.Text))
			{
				string searchText = txt_UserSearch.Text;
				employees = employeeService.SearchEmployee(searchText);
				this.ProcessData();
			}
			else
			{
				this.btn_findAllEmployee_Click(null,null);
			}
		}
	}
}
