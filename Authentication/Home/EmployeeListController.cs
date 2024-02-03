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

			txt_EmployeeStatus.Items.Add("Select Status...............");
			txt_EmployeeStatus.Items.Add("All");
			foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
			{
				if (status != EnumStatus.None)
				{
					txt_EmployeeStatus.Items.Add(status);
				}
			}
			txt_EmployeeStatus.SelectedItem = "Select Status...............";
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
				employees = employeeService.GetEmployees(EnumStatus.Active);
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
			empList.Columns.Add("Employee No", typeof(string));
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
				dr["Status"] = oEmployee.Status.ToString();
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
			try
			{
				DataGridView dataGridView = allEmployeeListTable;
				BO.Employee oEmployee = new BO.Employee();

				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int empID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oEmployee = employeeService.GetEmployee(empID);

					if (oEmployee != null)
					{
						DialogResult result = MessageBox.Show($"Are you sure to delete {oEmployee.Name} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							string status = employeeService.Delete(oEmployee.ID);
							if (status != null && status == "Ok")
							{
								MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
						return;
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Change Status
		private void changeStatus_Click(object sender, EventArgs e)
		{
			DataGridView dataGridView = allEmployeeListTable;
			BO.Employee oEmployee = new BO.Employee();
			try
			{
				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int empID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oEmployee = employeeService.GetEmployee(empID);

					if (oEmployee != null)
					{
						ChangeEmployeeStatus changeStatus = new ChangeEmployeeStatus(this);
						changeStatus.SetCurrentUser(this.oCurrentUser);
						changeStatus.EditEmployee(oEmployee);
						changeStatus._loginID = oCurrentUser.LoginID;
						changeStatus.EditingDone += EmployeeEntry_EditingDone;
						changeStatus.Show();
					}
				}
				else
				{
					MessageBox.Show("Please select a row for reset password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Employee Search
		private void txt_EmployeeSearch_TextChanged(object sender, EventArgs e)
		{
			try
			{
				DataGridView dataGridView = allEmployeeListTable;
				BO.Employee oEmployee = new BO.Employee();

				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int empID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oEmployee = employeeService.GetEmployee(empID);

					if (oEmployee != null)
					{
						DialogResult result = MessageBox.Show($"Are you sure to delete {oEmployee.Name} ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							string status = employeeService.Delete(oEmployee.ID);
							if (status != null && status == "Ok")
							{
								MessageBox.Show("Deleted Successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Password Reset
		private void PasswordReset_Click(object sender, EventArgs e)
		{
			try
			{
				DataGridView dataGridView = allEmployeeListTable;
				BO.Employee oEmployee = new BO.Employee();

				if (dataGridView.SelectedRows.Count > 0)
				{
					DataGridViewRow selectedRow = dataGridView.SelectedRows[0];
					int empID = Convert.ToInt32(selectedRow.Cells["ID"].Value.ToString());
					oEmployee = employeeService.GetEmployee(empID);

					if (oEmployee != null)
					{
						DialogResult result = MessageBox.Show($"Are you sure to reset the password to this Employee?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (result == DialogResult.Yes)
						{
							oEmployee.PasswordResetByAdmin = true;
							oEmployee.PasswordResetBy = oCurrentUser.ID;
							oEmployee.PasswordResetDate = DateTime.Now;

							string passwordResetStatus = employeeService.PasswordResetByAdmin(oEmployee);

							if (passwordResetStatus == "Ok")
							{
								MessageBox.Show("You have successfully reset a new password to this employee email", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
						}
						return;
					}
				}
				else
				{
					MessageBox.Show("Please select a row for reset password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion
	}
}
