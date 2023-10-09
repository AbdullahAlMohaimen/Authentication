using Authentication.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	#region User
	[Serializable]
	public class Users : BasicBaseObject
	{
		#region Constructor
		public Users() {
			_status = EnumStatus.Active;
			_authorizedDate = DateTime.Now;
			_passwordHints = string.Empty;
			_forgetPasswordDate = null;
			_tempStatus = EnumStatus.Active;
			_tempStatusTime = null;
			_changePasswordNextLogon = 0;
			_passwordResetByAdmin = false;
		}
		#endregion

		#region Properties

		#region LoginID : String 
		private string _loginID;
		public string LoginID
		{
			get { return _loginID; }
			set { _loginID = value; }
		}
		#endregion

		#region UserName : String 
		private string _userName;
		public string UserName
		{
			get { return _userName; }
			set { _userName = value; }
		}
		#endregion

		#region Status : EnumStatus 
		private EnumStatus _status;
		public EnumStatus Status
		{
			get { return _status; }
			set { _status = value; }
		}
		#endregion

		#region Email : String 
		private string _email;
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		#endregion

		#region RoleID : INT 
		private int _roleID;
		public int RoleID
		{
			get { return _roleID; }
			set { _roleID = value; }
		}
		#endregion

		#region MasterID : INT 
		private int _masterID;
		public int MasterID
		{
			get { return _masterID; }
			set { _masterID = value; }
		}
		#endregion

		#region AuthorizedDate : DateTime 
		private DateTime _authorizedDate;
		public DateTime AuthorizedDate
		{
			get { return _authorizedDate; }
			set { _authorizedDate = value; }
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

		#region PasswordHints : String 
		private string _passwordHints;
		public string PasswordHints
		{
			get { return _passwordHints; }
			set { _passwordHints = value; }
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

		#region ForgetPasswordDate : DateTime 
		private DateTime? _forgetPasswordDate;
		public DateTime? ForgetPasswordDate
		{
			get { return _forgetPasswordDate; }
			set { _forgetPasswordDate = value; }
		}
		#endregion

		#region LastChangeDate : DateTime 
		private DateTime _lastChangeDate;
		public DateTime LastChangeDate
		{
			get { return _lastChangeDate; }
			set { _lastChangeDate = value; }
		}
		#endregion

		#region TempStatus : EnumStatus 
		private EnumStatus _tempStatus;
		public EnumStatus TempStatus
		{
			get { return _tempStatus; }
			set { _tempStatus = value; }
		}
		#endregion

		#region TempStatusTime : DateTime 
		private DateTime? _tempStatusTime;
		public DateTime? TempStatusTime
		{
			get { return _tempStatusTime; }
			set { _tempStatusTime = value; }
		}
		#endregion

		#region ChangePasswordNextLogon : INT 
		private int _changePasswordNextLogon;
		public int ChangePasswordNextLogon
		{
			get { return _changePasswordNextLogon; }
			set { _changePasswordNextLogon = value; }
		}
		#endregion

		#region PasswordResetByAdmin : Bool
		public bool? _passwordResetByAdmin;
		public bool? PasswordResetByAdmin
		{
			get { return _passwordResetByAdmin; }
			set { _passwordResetByAdmin = value; }
		}
		#endregion

		#endregion
	}
	#endregion

	#region IUser Service
	public interface IUserService
	{
		Users GerUser(int ID);
		List<Users> GetUsers();
		string Save(Users user);
		void Delete(int ID);
	}
	#endregion
}
