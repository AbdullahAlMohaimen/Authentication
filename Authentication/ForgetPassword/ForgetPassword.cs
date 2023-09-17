using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.Forget_Password
{
	public partial class ForgetPassword : Form
	{
		private Form callingForm;
		public ForgetPassword(Form caller)
		{
			InitializeComponent();
			callingForm = caller;
			txt_LoginID.Text = _loginID;
		}

		#region property
		public string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region SetLoginID
		public void SetLoginID(string loginID)
		{
			txt_LoginID.Text = loginID;
		}
		#endregion

		private void Submit_Click(object sender, EventArgs e)
		{

		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

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
