using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	#region BadLoginInfo
	[Serializable]
	public class BadLoginAttemptInfo : BasicBaseObject
	{
		#region Constructor
		public BadLoginAttemptInfo() 
		{ 
		
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

		#region Type : String 
		private string _type;
		public string Type
		{
			get { return _type; }
			set { _type = value; }
		}
		#endregion

		#region AttemptTime : String 
		private DateTime _attemptTime;
		public DateTime AttemptTime
		{
			get { return _attemptTime; }
			set { _attemptTime = value; }
		}
		#endregion

		#region PCNumber : String 
		private string _pcNumber;
		public string PCNumber
		{
			get { return _pcNumber; }
			set { _pcNumber = value; }
		}
		#endregion

		#endregion
	}
	#endregion

	#region IBadLoginAttemptServie
	public interface IBadLoginAttemptServie
	{
		BadLoginAttemptInfo GetBadLoginAttemptInfo(int ID);
		List<BadLoginAttemptInfo> GetBadLoginAttemptInfos();
		string Save(BadLoginAttemptInfo badLogin);
		void Delete(int ID);
	}
	#endregion
}
