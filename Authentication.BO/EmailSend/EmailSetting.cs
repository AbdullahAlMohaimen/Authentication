using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	public class EmailSetting
	{
		public string WebAddress { get; set; }
		public string SendMethod { get; set; }
		public string EmailServer { get; set; }
		public string FromAddress { get; set; }
		public string UserID { get; set; }
		public string Password { get; set; }
		public string PortNumber { get; set; }
		public string EnableSSL { get; set; }
		public string SingleSignOn { get; set; }
		public string LDAP { get; set; }
	}
}
