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

namespace Authentication.HardPasswordSetup
{
	public partial class HardPasswordSetup : Form
	{
		HardPasswordSetupService service = new HardPasswordSetupService();
		public HardPasswordSetup()
		{
			InitializeComponent();
		}

		#region Role Code Generate
		public void GenerateCode()
		{
			string policyNo = service.GetPolicyNo();
			if (policyNo != null || !string.IsNullOrEmpty(policyNo))
				txt_PasswordPolicyNo.Text = policyNo;
			else
				txt_PasswordPolicyNo.Text = string.Empty;
		}
		#endregion



		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
	}
}
