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
					row["Religion"] = oEmployee.Religion;
					row["DOB"] = oEmployee.BirthDate.ToString("dd MMM yyy");
					row["Email"] = oEmployee.Email;
					row["Phone"] = oEmployee.MobileNo;
					row["Status"] = oEmployee.Status == EnumStatus.Active ? "Active" : "In-Active";
					allEmployeeDataTable.Rows.Add(row);
				}
				allEmployeeGrid.DataSource = allEmployeeDataTable;
				this.SetGridColumn();

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
			allEmployeeDataTable.Columns.Add("Religion");
			allEmployeeDataTable.Columns.Add("DOB");
			allEmployeeDataTable.Columns.Add("Email");
			allEmployeeDataTable.Columns.Add("Phone");
			allEmployeeDataTable.Columns.Add("Status");
		}
		#endregion

		#region Set Grid Column
		public void SetGridColumn()
		{
			allEmployeeGrid.Columns["Emp No"].Width = 55;
			allEmployeeGrid.Columns["Name"].Width = 165;
			allEmployeeGrid.Columns["Gender"].Width =55;
			allEmployeeGrid.Columns["Religion"].Width = 60;
			allEmployeeGrid.Columns["DOB"].Width = 75;
			allEmployeeGrid.Columns["Email"].Width = 160;
			allEmployeeGrid.Columns["Phone"].Width = 80;
			allEmployeeGrid.Columns["Status"].Width =80;
		}

		#endregion

		private void AddNewUser_Click(object sender, EventArgs e)
		{
			EmployeeEntry userEntry = new EmployeeEntry(this);
			userEntry.SetCurrentUser(this.oCurrentUser);
			userEntry.EditUser(null);
			userEntry._loginID = oCurrentUser.LoginID;
			userEntry.Show();
		}
	}
}
