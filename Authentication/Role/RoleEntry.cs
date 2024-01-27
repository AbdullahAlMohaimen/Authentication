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
		UserService _userService = new UserService();
		private UserControl callingForm;
		BO.CurrentUser oCurrentUser = new CurrentUser();
		BO.Role oRole = new BO.Role();
		public string _loginID;
		public string LoginID { get { return _loginID; } set { _loginID = value; } }
		#endregion

		#region Constructor
		public RoleEntry(UserControl caller)
		{
			InitializeComponent();
			callingForm = caller;
		}
		#endregion

		#region SetCurrentUser & Type
		public void SetCurrentUser(BO.CurrentUser oCUser)
		{
			oCurrentUser = oCUser;
		}
		#endregion

		#region SetEditedRole & Type
		public void EditRole(BO.Role editedRole)
		{
			oRole = editedRole;
			BO.Role role = new BO.Role();
			if (oRole != null)
			{
				this.Load();
				txtHeader.Text = "Edit Role";

				txt_RoleName.Text = oRole.Name;
				txt_RoleCode.Text = oRole.Code;
				txt_RoleStatus.SelectedItem = oRole.Status;
				txt_RoleDescription.Text = oRole.Description;
			}
			else
			{
				txtHeader.Text = "New Role Entry";
				oRole = new BO.Role();
				this.Load();
				GenerateCode();
			}
		}
		#endregion

		#region Load Role Data
		public void Load()
		{
			txt_RoleStatus.Items.Add("Select Status");
			foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
			{
				if (status == EnumStatus.Regardless || status == EnumStatus.Active || status == EnumStatus.Inactive)
				{
					txt_RoleStatus.Items.Add(status);
				}
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
			string invalidMessage;
			try
			{
				invalidMessage = this.isValidate();
				if (string.IsNullOrEmpty(invalidMessage))
				{
					oRole.Name = txt_RoleName.Text;
					oRole.Code = _roleService.GetCode();
					oRole.Status = (EnumStatus)txt_RoleStatus.SelectedItem;
					oRole.Description = txt_RoleDescription.Text;

					if(oRole.IsNew == true)
					{
						oRole.CreatedBy = oCurrentUser.ID;
						oRole.CreatedDate = DateTime.Now;
					}
					else
					{
						oRole.ModifiedBy = oCurrentUser.ID;
						oRole.ModifiedDate = DateTime.Now;
					}

					string status = _roleService.Save(oRole);
					if (status == "Ok")
					{
						if (oRole.IsNew == true)
						{
							MessageBox.Show("New roll added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show("Edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
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
