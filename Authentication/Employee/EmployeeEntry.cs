﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authentication.BO;
using Authentication.Service;

namespace Authentication.Employee
{
	public partial class EmployeeEntry : Form
	{
		#region Shadow
		[DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
		private static extern IntPtr CreateRoundRectRgn
		(
			int nLeftRect = 0,
			int nTopRect = 0,
			int nRightRect = 0,
			int nBottomRect = 0,
			int nWidthEllipse = 0,
			int nHeightEllipse = 0
		 );
		[DllImport("dwmapi.dll")]
		public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);
		[DllImport("dwmapi.dll")]
		public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
		[DllImport("dwmapi.dll")]
		public static extern int DwmIsCompositionEnabled(ref int pfEnabled);
		private bool m_aeroEnabled;
		private const int CS_DROPSHADOW = 0x00020000;
		private const int WM_NCPAINT = 0x0085;
		private const int WM_ACTIVATEAPP = 0x001C;
		public struct MARGINS
		{
			public int leftWidth;
			public int rightWidth;
			public int topHeight;
			public int bottomHeight;
		}
		private const int WM_NCHITTEST = 0x84;
		private const int HTCLIENT = 0x1;
		private const int HTCAPTION = 0x2;
		protected override CreateParams CreateParams
		{
			get
			{
				m_aeroEnabled = CheckAeroEnabled();

				CreateParams cp = base.CreateParams;
				if (!m_aeroEnabled)
					cp.ClassStyle |= CS_DROPSHADOW;
				return cp;
			}
		}
		private bool CheckAeroEnabled()
		{
			if (Environment.OSVersion.Version.Major >= 6)
			{
				int enabled = 0;
				DwmIsCompositionEnabled(ref enabled);
				return (enabled == 1) ? true : false;
			}
			return false;
		}
		protected override void WndProc(ref Message m)
		{
			switch (m.Msg)
			{
				case WM_NCPAINT:
					if (m_aeroEnabled)
					{
						var v = 2;
						DwmSetWindowAttribute(this.Handle, 2, ref v, 10);
						MARGINS margins = new MARGINS()
						{
							bottomHeight = 0,
							leftWidth = 0,
							rightWidth = 0,
							topHeight = 0
						};
						DwmExtendFrameIntoClientArea(this.Handle, ref margins);
					}
					break;
				default:
					break;
			}
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)
				m.Result = (IntPtr)HTCAPTION;
		}
		#endregion

		#region Property / Variable
		public event EventHandler EditingDone;
		EmployeeService employeeService = new EmployeeService();
		BO.Employee employee = new BO.Employee();
		BO.CurrentUser oCurrentUser = new CurrentUser();
		BO.Users _user = new BO.Users();
		private UserControl callingForm;
		public string _loginID;
		public string LoginID { get { return _loginID; } set { _loginID = value; } }
		#endregion

		#region Constructor (Load)
		public EmployeeEntry(UserControl caller)
		{
			InitializeComponent();
			callingForm = caller;
			this.Load();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oCUser)
		{
			oCurrentUser = oCUser;
		}
		#endregion

		#region SetEditedEmployee & Type
		public void EditEmployee(BO.Employee oEmployee)
		{
			employee = oEmployee;
			if (employee != null)
			{
				txtHeader.Text = "Edit Employee";
				SaveEmployee.Text = "Edit";

				txt_EmpName.Text = employee.Name;
				txt_EmpGender.SelectedItem = employee.Gender;
				txt_EmpReligion.SelectedItem = employee.Religion;
				txt_EmpDOB.Value = employee.BirthDate;
				txt_EmpMStatus.SelectedItem = employee.MaritalStatus;
				txt_EmpMobileNo.Text = employee.MobileNo;
				txt_EmpAccountNo.Text = employee.AccountNo;
				txt_EmpDepartment.SelectedItem = employee.Department;
				txt_EmpDesignation.SelectedItem = employee.Designation;
				txt_EmpEmail.Text = employee.Email;
				txt_EmpSalary.Text = employee.BasicSalary.ToString();
				txt_EmpIsConfirm.Checked = (bool)employee.IsConfirmed;
				txt_EmpAddress.Text = employee.Address;
			}
			else
			{
				txtHeader.Text = "New Employee Entry";
				SaveEmployee.Text = "Edit";
				employee = new BO.Employee();
			}


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
			string employeeNo;
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
					employee.Address = txt_EmpAddress.Text;
					if (txt_EmpIsConfirm.Checked)
						employee.IsConfirmed = txt_EmpIsConfirm.Checked;
					else
						employee.IsConfirmed = false;
				}
				else
				{
					MessageBox.Show(invalidMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}
				if (employee.IsNew == true)
				{
					employee.CreatedBy = oCurrentUser.ID;
					employee.CreatedDate = DateTime.Now;
				}
				else
				{
					employee.ModifiedBy = oCurrentUser.ID;
					employee.ModifiedDate = DateTime.Now;
				}
				employeeNo = employeeService.Save(employee);
				if(employee.IsNew == true)
				{
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
					if (!string.IsNullOrEmpty(employeeNo))
					{
						this.Clear();
						MessageBox.Show("Employee information save successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Employee information save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				//MessageBox.Show("Employee information save failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			this.Clear();

			EditingDone?.Invoke(this, EventArgs.Empty);
			this.Close();
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
			txt_EmpAddress.Text = string.Empty;
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
