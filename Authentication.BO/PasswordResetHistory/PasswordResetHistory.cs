using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	#region PasswordResetHistory
	public class PasswordResetHistory : BasicBaseObject
	{
		#region Constructor
		public PasswordResetHistory() { }
		#endregion

		#region Property

		#region LoginID string
		public string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region Type EnumUserType
		public EnumUserType _type;
		public EnumUserType Type
		{
			get { return _type; }
			set { _type = value; }
		}
		#endregion

		#region Password : String 
		private string _password;
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}
		#endregion

		#region Salt : String 
		private string _salt;
		public string Salt
		{
			get { return _salt; }
			set { _salt = value; }
		}
		#endregion

		#region PasswordResetBy : INT
		public int _passwordResetBy;
		public int PasswordResetBy
		{
			get { return _passwordResetBy; }
			set { _passwordResetBy = value; }
		}
		#endregion

		#region PasswordResetDate : DateTime
		public DateTime _passwordResetDate;
		public DateTime PasswordResetDate
		{
			get { return _passwordResetDate; }
			set { _passwordResetDate = value; }
		}
		#endregion

		#region Reason : string
		public string _reason;
		public string Reason
		{
			get { return _reason; }
			set { _reason = value; }
		}
		#endregion

		#endregion
	}
	#endregion
}
