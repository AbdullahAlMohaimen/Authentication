using Authentication.BO;
using Authentication.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Authentication.HardPasswordSetup
{
	public partial class HardPasswordSetup : Form
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

		#region property / Variable
		public event EventHandler EditingDone;
		HardPasswordSetupService service = new HardPasswordSetupService();
		private UserControl callingForm;
		BO.HardPasswordSetup hardPasswordSetup = new BO.HardPasswordSetup();
		BO.CurrentUser oCurrentUser = new CurrentUser();
		public string _loginID;
		public string LoginID { get { return _loginID; } set { _loginID = value; } }
		#endregion

		#region Constructor
		public HardPasswordSetup(UserControl caller)
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
		public void EditHardPassword(BO.HardPasswordSetup oHardPassword)
		{
			hardPasswordSetup = oHardPassword;
			if (hardPasswordSetup != null)
			{
				txt_Header.Text = "Edit Hard Password Setup";
				SaveHardPasswordPolicy.Text = "Edit";

				txt_PasswordPolicyNo.Text = hardPasswordSetup.PolicyNo;
				txt_PasswordMaxLength.Text = Convert.ToString(hardPasswordSetup.PassMaxLength);
				txt_PasswordMinLength.Text = Convert.ToString(hardPasswordSetup.PassMinLength);
				txt_SuperUserPassMinLength.Text = Convert.ToString(hardPasswordSetup.SuperUserPassMinLength);
				txt_PasswordMinAge.Text = Convert.ToString(hardPasswordSetup.PasswordMinimumAge);
				txt_PassExpNotificationDays.Text = Convert.ToString(hardPasswordSetup.PasswordExpNotificationDays);
				txt_PasswordExpDays.Text = Convert.ToString(hardPasswordSetup.PasswordExpDays);

				IsContainSpecialCharacter.Checked = (bool)hardPasswordSetup.IsContainSpecialCharacter;
				IsConatinUpperCase.Checked = (bool)hardPasswordSetup.IsContainUpperCase;
				IsContainLowerCase.Checked = (bool)hardPasswordSetup.IsContainLowerCase;
				IsContainLatter.Checked = (bool)hardPasswordSetup.IsContainLatter;
				IsContainNumber.Checked = (bool)hardPasswordSetup.IsContainNumber;
				IsSamePassword.Checked = (bool)hardPasswordSetup.IsUserPasswordSame;
			}
			else
			{
				hardPasswordSetup = new BO.HardPasswordSetup();
				SaveHardPasswordPolicy.Text = "Save";
				GeneratePolicyNo();
			}
		}
		#endregion

		#region HardPassword Code Generate
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
			
			string invalidMessage;
			try
			{
				invalidMessage = this.isValidate();
				if (string.IsNullOrEmpty(invalidMessage))
				{
					hardPasswordSetup.PassMaxLength = (int)Convert.ToInt32(txt_PasswordMaxLength.Text);
					hardPasswordSetup.PassMinLength = (int)Convert.ToInt32(txt_PasswordMinLength.Text);
					hardPasswordSetup.SuperUserPassMinLength = (int)Convert.ToInt32(txt_SuperUserPassMinLength.Text);
					hardPasswordSetup.PasswordMinimumAge = (int)Convert.ToInt32(txt_PasswordMinAge.Text);
					hardPasswordSetup.PasswordExpNotificationDays = (int)Convert.ToInt32(txt_PassExpNotificationDays.Text);
					hardPasswordSetup.PasswordExpDays = (int)Convert.ToInt32(txt_PasswordExpDays.Text);
					if (IsContainSpecialCharacter.Checked)
					{
						hardPasswordSetup.IsContainSpecialCharacter = true;
					}
					else
					{
						hardPasswordSetup.IsContainSpecialCharacter = false;
					}
					if (IsConatinUpperCase.Checked)
					{
						hardPasswordSetup.IsContainUpperCase = true;
					}
					else
					{
						hardPasswordSetup.IsContainUpperCase = false;
					}
					if (IsContainLowerCase.Checked)
					{
						hardPasswordSetup.IsContainLowerCase = true;
					}
					else
					{
						hardPasswordSetup.IsContainLowerCase = false;
					}
					if (IsContainLatter.Checked)
					{
						hardPasswordSetup.IsContainLatter = true;
					}
					else
					{
						hardPasswordSetup.IsContainLatter = false;
					}
					if (IsContainNumber.Checked)
					{
						hardPasswordSetup.IsContainNumber = true;
					}
                    else
                    {
						hardPasswordSetup.IsContainNumber = false;
					}
                    if (IsSamePassword.Checked)
					{
						hardPasswordSetup.IsUserPasswordSame = true;
					}
					else
					{
						hardPasswordSetup.IsUserPasswordSame = false;
					}

					string status = service.Save(hardPasswordSetup);
					if (status == "Ok")
					{
						if (hardPasswordSetup.IsNew == true)
						{
							MessageBox.Show("New password policy added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show("Password policy edited successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					else
					{
						MessageBox.Show("New roll added failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
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
