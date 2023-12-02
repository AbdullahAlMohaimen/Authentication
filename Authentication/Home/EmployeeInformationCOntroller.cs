using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Home
{
	public partial class EmployeeInformationCOntroller : UserControl
	{
		#region Property (for Search Employee)
		public BO.Employee _searchEmployee;
		public BO.Employee SearchEmp
		{
			get { return _searchEmployee; }
			set { _searchEmployee = value; }
		}
		#endregion

		public EmployeeInformationCOntroller()
		{
			InitializeComponent();
		}

		#region Set Selected Employee
		public void SetSelectedEmployee(BO.Employee SEemployee)
		{
			if (SEemployee != null)
			{
				txt_UserMaster.Text = "(" + SEemployee.EmployeeNo + ")" + SEemployee.Name;
				SearchEmp = SEemployee;
			}
		}
		#endregion

		#region Active Button Checked
		private void txt_Active_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_Active.Checked == true)
			{
				txt_InActive.Checked = false;
				txt_Locked.Checked = false;
			}

		}
		#endregion

		#region In-Active Button Checked
		private void txt_InActive_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_InActive.Checked == true)
			{
				txt_Active.Checked = false;
				txt_Locked.Checked = false;
			}
		}
		#endregion

		#region Locked Button Checked
		private void txt_Locked_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_Locked.Checked == true)
			{
				txt_Active.Checked = false;
				txt_InActive.Checked = false;
			}
		}
		#endregion

		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchEmployee.SearchEmployee search = new SearchEmployee.SearchEmployee(this);
			search.SearchBy = "User";
			search.Show();
		}
	}
}
