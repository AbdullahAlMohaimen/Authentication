﻿using Authentication.BO;
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
				allEmployeeGrid.Columns.Clear();
				allEmployeeGrid.DataSource = null;
				allEmployeeDataTable.Rows.Clear();
				this.GetGridColumn();
				allEmployeeGrid.AllowUserToAddRows = false;

				foreach (BO.Employee oEmployee in employees)
				{
					DataRow row = allEmployeeDataTable.NewRow();
					row["Emp No"] = oEmployee.EmployeeNo;
					row["Name"] = oEmployee.Name;
					row["Gender"] = oEmployee.Gender;
					row["DOJ"] = oEmployee.JoiningDate.ToString("dd MMM yyy");
					row["Email"] = oEmployee.Email;
					row["Phone"] = oEmployee.MobileNo;
					row["Status"] = oEmployee.Status == EnumStatus.Active ? "Active" : "In-Active";
					row["IsConfirm"] = oEmployee.IsConfirmed == true ? "Yes" : "No";
					allEmployeeDataTable.Rows.Add(row);
				}
				allEmployeeGrid.DataSource = allEmployeeDataTable;
				this.SetGridColumn();

				DataGridViewButtonColumn statusChangedButton = new DataGridViewButtonColumn();
				statusChangedButton.HeaderText = "Change Status";
				statusChangedButton.Text = "Change Status";
				statusChangedButton.UseColumnTextForButtonValue = true;
				statusChangedButton.DefaultCellStyle.BackColor = SystemColors.Control;
				statusChangedButton.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
				statusChangedButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				statusChangedButton.CellTemplate.Style.ForeColor = Color.Maroon;
				statusChangedButton.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				allEmployeeGrid.Columns.Add(statusChangedButton);

				DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
				editButton.HeaderText = "Edit";
				editButton.Text = "Edit";
				editButton.UseColumnTextForButtonValue = true;
				editButton.DefaultCellStyle.BackColor = SystemColors.Control;
				editButton.DefaultCellStyle.Font = new Font("Arial", 9, FontStyle.Bold);
				editButton.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
				editButton.CellTemplate.Style.ForeColor = Color.Maroon;
				editButton.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
				allEmployeeGrid.Columns.Add(editButton);
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		#region Get Grid Column
		public void GetGridColumn()
		{
			allEmployeeDataTable.Columns.Clear();
			allEmployeeDataTable.Columns.Add("Emp No");
			allEmployeeDataTable.Columns.Add("Name");
			allEmployeeDataTable.Columns.Add("Gender");
			allEmployeeDataTable.Columns.Add("DOJ");
			allEmployeeDataTable.Columns.Add("Email");
			allEmployeeDataTable.Columns.Add("Phone");
			allEmployeeDataTable.Columns.Add("Status");
			allEmployeeDataTable.Columns.Add("IsConfirm");
		}
		#endregion

		#region Set Grid Column
		public void SetGridColumn()
		{
			allEmployeeGrid.Columns["Emp No"].Width = 50;
			allEmployeeGrid.Columns["Name"].Width = 150;
			allEmployeeGrid.Columns["Gender"].Width =45;
			allEmployeeGrid.Columns["DOJ"].Width = 70;
			allEmployeeGrid.Columns["Email"].Width = 140;
			allEmployeeGrid.Columns["Phone"].Width = 75;
			allEmployeeGrid.Columns["Status"].Width = 45;
			allEmployeeGrid.Columns["IsConfirm"].Width = 90;
		}

		#endregion

		#region New User Butoon
		private void AddNewUser_Click(object sender, EventArgs e)
		{
			EmployeeEntry userEntry = new EmployeeEntry(this);
			userEntry.SetCurrentUser(this.oCurrentUser);
			userEntry.EditEmployee(null);
			userEntry._loginID = oCurrentUser.LoginID;
			userEntry.Show();
		}
		#endregion

		#region Grid Button Click
		private void allEmployeeGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				BO.Employee oEmployee = new BO.Employee();
				DataGridViewRow selectedRow = allEmployeeGrid.Rows[e.RowIndex];
				string employeeNo = selectedRow.Cells["Emp No"].Value.ToString();
				oEmployee = employeeService.GetEmployee(employeeNo);

				if (allEmployeeGrid.Columns[e.ColumnIndex].HeaderText == "Edit")
				{
					#region Edit User
					EmployeeEntry employeeEntry = new EmployeeEntry(this);
					employeeEntry.SetCurrentUser(this.oCurrentUser);
					employeeEntry.EditEmployee(oEmployee);
					employeeEntry._loginID = oCurrentUser.LoginID;
					employeeEntry.EditingDone += EmployeeEntry_EditingDone;
					employeeEntry.Show();
					#endregion
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		#endregion

		private void EmployeeEntry_EditingDone(object sender, EventArgs e)
		{
			this.loadGrid();
		}
	}
}
