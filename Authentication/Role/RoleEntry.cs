using Authentication.BO;
using Authentication.BO.Role;
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


namespace Authentication.Role
{
	public partial class RoleEntry : Form
	{
		EmployeeService _employeeService = new EmployeeService();
		RoleService _roleService = new RoleService();

		#region Constructor
		public RoleEntry()
		{
			InitializeComponent();
			GenerateCode();
			this.Load();
		}
		#endregion

		#region Load Role Data
		public void Load()
		{
			txt_RoleStatus.Items.Add("Select Status");
			foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
			{
				txt_RoleStatus.Items.Add(status);
			}
			this.txt_RoleStatus.SelectedIndex = 0;
			this.txt_RoleStatus.AutoCompleteMode = AutoCompleteMode.None;
			txt_RoleCode.ReadOnly = true;
		}
		#endregion

		#region Role Code Generate
		public void GenerateCode()
		{
			string code = _roleService.GetCode();
			if (code != null || !string.IsNullOrEmpty(code))
				txt_RoleCode.Text = code;
			else
				txt_RoleCode.Text = string.Empty;
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
		private void SaveRole_Click(object sender, EventArgs e)
		{
			BO.Role.Role role = new BO.Role.Role();
			string invalidMessage;
			try
			{
				invalidMessage = this.isValidate();
				if (string.IsNullOrEmpty(invalidMessage))
				{
					role.Name = txt_RoleName.Text;
					role.Code = _roleService.GetCode();
					role.Status = (EnumStatus)txt_RoleStatus.SelectedItem;
					role.Description = txt_RoleDescription.Text;
					string status = _roleService.Save(role);
					if (status == "Ok")
					{
						MessageBox.Show("New roll added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("New roll added failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					this.GenerateCode();
					this.Clear();
				}
				else
				{
					MessageBox.Show(invalidMessage, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
		#endregion

		#region Clear Method
		public void Clear()
		{
			txt_RoleName.Text = string.Empty;
			txt_RoleStatus.SelectedIndex = 0;
			txt_RoleDescription.Text = string.Empty;
		}
		#endregion

		#region Validation
		public string isValidate()
		{
			string invalidMessage = "";
			if (txt_RoleName.Text == "")
			{
				invalidMessage = "Please Enter Role Name";
				return invalidMessage;
			}
			if (txt_RoleStatus.SelectedIndex == 0)
			{
				invalidMessage = "Please Select Status";
				return invalidMessage;
			}
			if (txt_RoleDescription.Text == "")
			{
				invalidMessage = "Please Enter Role Description";
				return invalidMessage;
			}
			return invalidMessage;
		}
		#endregion
	}
}
