using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Authentication.SearchEmployee
{
	public partial class SearchEmployeeInformation : Form
	{
		#region Property & Variable
		private UserControl callingController;
		#endregion

		public SearchEmployeeInformation(UserControl userControl)
		{
			InitializeComponent();
			callingController = userControl;
		}
	}
}
