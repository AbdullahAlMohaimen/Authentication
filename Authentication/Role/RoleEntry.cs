using Authentication.BO;
using Authentication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Authentication.Role
{
	public partial class RoleEntry : Form
	{
		#region property / Variable
		public event EventHandler EditingDone;
		EmployeeService _employeeService = new EmployeeService();
		RoleService _roleService = new RoleService();
		private UserControl callingForm;
		BO.CurrentUser oCurrentUser = new CurrentUser();
		BO.Role _role = new BO.Role();
		public string _loginID;
		public string LoginID { get { return _loginID; } set { _loginID = value; } }
		#endregion

		#region Constructor
		public RoleEntry(UserControl caller)
		{
			InitializeComponent();
			callingForm = caller;
			GenerateCode();
			this.Load();
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oCUser)
		{
			oCurrentUser = oCUser;
		}
		#endregion

		#region SetEditedUser & Type
		public void EditRole(BO.Role oRole)
		{
			_role = oRole;
			BO.Role role = new BO.Role();
			if (_role != null)
			{
				txtHeader.Text = "Edit User";
				//txt_UserLoginID.Text = _user.LoginID.ToString();
				//txt_UserName.Text = _user.UserName.ToString();
				//txt_UserEmail.Text = _user.Email.ToString();

				//role = this._roles.Find(x => x.ID == _user.RoleID);
				//txt_UserRoleID.SelectedItem = role.Name;

				//BO.Employee _employee = employeeService.GetEmployee(_user.MasterID);
				//txt_UserMaster.Text = "(" + _employee.EmployeeNo + ")" + _employee.Name;
				//if (_user.IsApprover == true)
				//{
				//	txt_IsApprover.Checked = true;
				//}
				//if (_user.IsApprover == false)
				//{
				//	txt_IsApprover.Checked = false;
				//}
				//SearchEmp = _employee;
			}
			else
			{
				txtHeader.Text = "New User Entry";
				_role = new BO.Role();
			}
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
			BO.Role role = new BO.Role();
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

					EditingDone?.Invoke(this, EventArgs.Empty);
					this.Close();
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
