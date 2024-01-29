using Authentication.BO;
using Authentication.Employee;
using Authentication.Service;
using Authentication.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Authentication.Home
{
	public partial class EmployeeListController : UserControl
	{
		#region property / Variable
		BO.CurrentUser oCurrentUser = new CurrentUser();
		List<BO.Role> roles = new List<BO.Role>();
		List<BO.Employee> employees = new List<BO.Employee>();
		DataTable allEmployeeDataTable = new DataTable();
		RoleService roleService = new RoleService();
		UserService userService = new UserService();
		EmployeeService employeeService = new EmployeeService();
		#endregion

		#region Load
		public EmployeeListController()
		{
			InitializeComponent();
			this.loadGrid();
		}
		#endregion

		#region LoadGrid
		public void loadGrid()
		{
			this.GetAllEmployee();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oUser)
		{
			oCurrentUser = oUser;
		}
		#endregion

		#region Get ALL Employee
		public void GetAllEmployee()
		{
			try
			{
				employees = employeeService.GetEmployees();
				this.ProcessData();
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region ProcessData
		public void ProcessData()
		{
			total.Text = employees.Count().ToString();
			DataRow dr = null;
			DataTable empList = new DataTable();
			empList.TableName = "Employee List";
			empList.Columns.Add("ID", typeof(int));
			empList.Columns.Add("EmployeeNo", typeof(string));
			empList.Columns.Add("Name", typeof(string));
			empList.Columns.Add("Gender", typeof(string));
			empList.Columns.Add("Joining Date", typeof(string));
			empList.Columns.Add("Email", typeof(string));
			empList.Columns.Add("Phone", typeof(string));
			empList.Columns.Add("Status", typeof(string));
			empList.Columns.Add("IsConfirm", typeof(string));

			allEmployeeListTable.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
			allEmployeeListTable.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


			foreach (BO.Employee oEmployee in employees)
			{
				dr = empList.NewRow();
				dr["ID"] = oEmployee.ID;
				dr["Employee No"] = oEmployee.EmployeeNo;
				dr["Name"] = oEmployee.Name;
				dr["Gender"] = oEmployee.Gender;
				dr["Joining Date"] = oEmployee.JoiningDate.ToString("dd MMM yyy");
				dr["Email"] = oEmployee.Email;
				dr["Phone"] = oEmployee.MobileNo;
				dr["Status"] = oEmployee.Status == EnumStatus.Active ? "Active" : "In-Active";
				dr["IsConfirm"] = oEmployee.IsConfirmed == true ? "Yes" : "No";
				empList.Rows.Add(dr);
			}
			allEmployeeListTable.DataSource = empList;
			//allEmployeeListTable.RowHeadersVisible = false;
			//allEmployeeListTable.Columns["ID"].Visible = false;

			foreach (DataGridViewColumn column in allEmployeeListTable.Columns)
			{
				column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
			}
			allEmployeeListTable.Columns["Name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

			allEmployeeListTable.RowHeadersVisible = false;
			allEmployeeListTable.Columns["ID"].Visible = false;
		}
		#endregion

		#region New User Butoon
		private void AddNewUser_Click(object sender, EventArgs e)
		{
			EmployeeEntry employeeEntry = new EmployeeEntry(this);
			employeeEntry.SetCurrentUser(this.oCurrentUser);
			employeeEntry.EditEmployee(null);
			employeeEntry._loginID = oCurrentUser.LoginID;
			employeeEntry.EditingDone += EmployeeEntry_EditingDone;
			employeeEntry.Show();
		}
		#endregion

		private void EmployeeEntry_EditingDone(object sender, EventArgs e)
		{
			this.loadGrid();
		}

		#region Edit Button
		private void editButton_click_Click(object sender, EventArgs e)
		{
			try
			{
				BO.Employee oEmployee = new BO.Employee();
				DataGridView dataGridView = allEmployeeListTable;
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int empID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oEmployee = employeeService.GetEmployee(empID);

					EmployeeEntry employeeEntry = new EmployeeEntry(this);
					employeeEntry.SetCurrentUser(this.oCurrentUser);
					employeeEntry.EditEmployee(oEmployee);
					employeeEntry._loginID = oCurrentUser.LoginID;
					employeeEntry.EditingDone += EmployeeEntry_EditingDone;
					employeeEntry.Show();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Delete Button
		private void deleteButton_Click_Click(object sender, EventArgs e)
		{

		}
		#endregion

		#region Change Status
		private void changeStatus_Click(object sender, EventArgs e)
		{

		}
		#endregion

		#region Employee Search
		private void txt_EmployeeSearch_TextChanged(object sender, EventArgs e)
		{

		}
		#endregion

		#region Password Reset
		private void PasswordReset_Click(object sender, EventArgs e)
		{

		}
		#endregion
	}
}
