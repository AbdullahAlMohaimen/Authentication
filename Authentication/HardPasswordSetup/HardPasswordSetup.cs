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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Authentication.HardPasswordSetup
{
	public partial class HardPasswordSetup : Form
	{
		HardPasswordSetupService service = new HardPasswordSetupService();

		#region Constructor
		public HardPasswordSetup()
		{
			InitializeComponent();
			GeneratePolicyNo();
		}
		#endregion

		#region Role Code Generate
		public void GeneratePolicyNo()
		{
			string policyNo = service.GetPolicyNo();
			if (policyNo != null || !string.IsNullOrEmpty(policyNo))
				txt_PasswordPolicyNo.Text = policyNo;
			else
				txt_PasswordPolicyNo.Text = string.Empty;
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

		#region Save Hard Password Policy
		private void SaveHardPasswordPolicy_Click(object sender, EventArgs e)
		{
			BO.HardPasswordSetup.HardPasswordSetup hardPasswordSetup = new BO.HardPasswordSetup.HardPasswordSetup();
			string invalidMessage;
			try
			{
				invalidMessage = this.isValidate();
				if (string.IsNullOrEmpty(invalidMessage))
				{
					hardPasswordSetup.PassMaxLength = (int)Convert.ToInt32(txt_PasswordMaxLength.Text);
					hardPasswordSetup.PassMinLength = (int)Convert.ToInt32(txt_PasswordMinLength.Text);
					hardPasswordSetup.SuperUserassMinLength = (int)Convert.ToInt32(txt_SuperUserPassMinLength.Text);
					hardPasswordSetup.PasswordMinimumAge = (int)Convert.ToInt32(txt_PasswordMinAge.Text);
					hardPasswordSetup.PasswordExpNotificationDays = (int)Convert.ToInt32(txt_PassExpNotificationDays.Text);
					hardPasswordSetup.PasswordExpDays = (int)Convert.ToInt32(txt_PasswordExpDays.Text);
					if (IsContainSpecialCharacter.Checked)
						hardPasswordSetup.IsContainSpecialCharacter = true;
					if (IsConatinUpperCase.Checked)
						hardPasswordSetup.IsContainUpperCase = true;
					if (IsContainLowerCase.Checked)
						hardPasswordSetup._isContainLowerCase = true;
					if (IsContainNumber.Checked)
						hardPasswordSetup.IsContainLatter = true;
					if (IsContainNumber.Checked)
						hardPasswordSetup.IsContainNumber = true;
					if (IsSamePassword.Checked)
						hardPasswordSetup.IsUserPasswordSame = true;

					string status = service.Save(hardPasswordSetup);
					if (status == "Ok")
					{
						MessageBox.Show("New password policy added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("New roll added failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					this.GeneratePolicyNo();
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

		#region Cancel Button
		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		#endregion

		#region Validation
		public string isValidate()
		{
			string invalidMessage = "";

			if (txt_PasswordPolicyNo.Text == "" || string.IsNullOrEmpty(txt_PasswordPolicyNo.Text))
			{
				invalidMessage = "Password Policy can't be empty";
				return invalidMessage;
			}
			if (txt_PasswordMaxLength.Text == "" || string.IsNullOrEmpty(txt_PasswordMaxLength.Text) ||
				txt_PasswordMinLength.Text == "" || string.IsNullOrEmpty(txt_PasswordMinLength.Text) ||
				txt_SuperUserPassMinLength.Text == "" || string.IsNullOrEmpty(txt_SuperUserPassMinLength.Text) ||
				txt_PasswordMinAge.Text == "" || string.IsNullOrEmpty(txt_PasswordMinAge.Text) ||
				txt_PassExpNotificationDays.Text == "" || string.IsNullOrEmpty(txt_PassExpNotificationDays.Text) ||
				txt_PasswordExpDays.Text == "" || string.IsNullOrEmpty(txt_PasswordExpDays.Text))
			{
				invalidMessage = "Please enter all the field!!";
				return invalidMessage;
			}
			return invalidMessage;

		}
		#endregion

		#region Clear
		public void Clear()
		{
			GeneratePolicyNo();
			txt_PasswordMaxLength.Text = string.Empty;
			txt_PasswordMinLength.Text = string.Empty;
			txt_SuperUserPassMinLength.Text = string.Empty;
			txt_PasswordMinAge.Text = string.Empty;
			txt_PassExpNotificationDays.Text = string.Empty;
			txt_PasswordExpDays.Text = string.Empty;
			IsContainSpecialCharacter.Checked = false;
			IsConatinUpperCase.Checked = false;
			IsContainLowerCase.Checked = false;
			IsContainLatter.Checked = false;
			IsContainNumber.Checked = false;
			IsSamePassword.Checked = false;
		}
		#endregion
	}
}
