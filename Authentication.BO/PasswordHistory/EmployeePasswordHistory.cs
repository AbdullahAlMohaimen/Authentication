using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.BO
{
	#region EmployeePassword History
	public class EmployeePasswordHistory
	{
		#region
		public EmployeePasswordHistory() { }
		#endregion

		#region Property

		#region EmployeeID INT
		public int _employeeID;
		public int EmployeeID 
		{
			get { return _employeeID; }
			set { _employeeID = value; }
		}
		#endregion

		#region EmployeePassword : String 
		private string _employeePassword;
		public string EmployeePassword
		{
			get { return _employeePassword; }
			set { _employeePassword = value; }
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

	#region IEmployeePasswordHistory
	public interface IEmployeePasswordHistory
	{
		EmployeePasswordHistory GetEmployeePasswordHistory(int ID);
		List<EmployeePasswordHistory> GetEmployeePasswordHistories();
		string Save(EmployeePasswordHistory empH);
		void Delete(int ID);
	}
	#endregion
}
