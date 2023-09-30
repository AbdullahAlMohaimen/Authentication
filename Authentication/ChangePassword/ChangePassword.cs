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

namespace Authentication.Change_Password
{
	public partial class ChangePassword : Form
	{
		UserService userService = new UserService();
		#region property
		private Form callingForm;
		public string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region Load
		public ChangePassword(Form caller)
		{
			InitializeComponent();
			callingForm = caller;
			txt_LoginID.Text = _loginID;
		}
		#endregion

		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
