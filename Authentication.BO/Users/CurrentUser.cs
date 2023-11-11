using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	#region User
	[Serializable]
	public class CurrentUser : BasicBaseObject
	{
		#region Constructor
		public CurrentUser() { }
		#endregion

		#region Property
		public string LoginID { get; set; }
		public string UserName { get; set; }
		public EnumStatus Status { get; set; }
		public string Email { get; set; }
		public int RoleID { get; set; }
		public int MasterID { get; set; }
		#endregion
	}
	#endregion
}
