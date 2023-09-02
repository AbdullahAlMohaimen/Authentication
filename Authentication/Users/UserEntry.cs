using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Authentication.SearchEmployee;

namespace Authentication.Users
{
	public partial class UserEntry : Form
	{
		#region Load
		public UserEntry()
		{
			InitializeComponent();
		}
		#endregion

		#region LoginId Auto Generate
		private void txt_UserLoginIDAuto_CheckedChanged(object sender, EventArgs e)
		{
			if (txt_UserLoginIDAuto.Checked)
			{
				txt_UserLoginID.Text = "1111";
			}
			else
			{
				txt_UserLoginID.Text = "2222";
			}
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

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Save Button
		private void SaveUser_Click(object sender, EventArgs e)
		{
			
		}
		#endregion

		private void SearchEmployee_Click(object sender, EventArgs e)
		{
			SearchEmployee.SearchEmployee search = new SearchEmployee.SearchEmployee();
			search.Show();
		}
	}
}
