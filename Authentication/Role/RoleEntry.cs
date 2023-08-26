using Authentication.BO;
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
		public RoleEntry()
		{
			InitializeComponent();

			txt_RoleStatus.Items.Add("Select Status");
			foreach (EnumStatus status in Enum.GetValues(typeof(EnumStatus)))
			{
				txt_RoleStatus.Items.Add(status);
			}
		}

		private void Exit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void Minimize_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void Cancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
