using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using Authentication.BO;
using Authentication.Service.Model;
using Authentication.Service;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Authentication
{
	[Serializable]
	public class PasswordResetHistoryService : ServiceTemplate
	{
		#region UserPasswordHistory Data Mapping
		public PasswordResetHistoryService() { }

		
		#endregion
	}
}
