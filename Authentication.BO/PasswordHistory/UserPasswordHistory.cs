using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	#region User
	public class UserPasswordHistory : BasicBaseObject
	{
		#region Constructor
		public UserPasswordHistory() {
			EntryDate = DateTime.Now;
		}
		#endregion

		#region Property

		#region UserID INT
		public int _userID;
		public int UserID
		{
			get { return _userID; }
			set { _userID = value; }
		}
		#endregion

		#region UserPassword : String 
		private string _userPassword;
		public string UserPassword
		{
			get { return _userPassword; }
			set { _userPassword = value; }
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

		#region EntryDate : DateTime 
		private DateTime? _entryDate;
		public DateTime? EntryDate
		{
			get { return _entryDate; }
			set { _entryDate = value; }
		}
		#endregion

		#endregion
	}
	#endregion

	#region IUserPasswordHistory
	public interface IUserPasswordHistory
	{
		UserPasswordHistory GetUserPasswordHistory(int ID);
		List<UserPasswordHistory> GetUserPasswordHistories();
		List<UserPasswordHistory> GetUserPasswordHistories(int ID);
		string Save(UserPasswordHistory upH);
		void Delete(int ID);
	}
	#endregion
}
