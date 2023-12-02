using Authentication.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Web.Caching;

namespace Authentication.BO
{
	#region Employee
	[Serializable]
	public class Employee : BasicBaseObject
	{
		#region constructor
		public Employee() { 
			_joiningDate = DateTime.Now;
			_isConfirmed = false;
			_status = EnumStatus.Active;
			_maritalStatus = string.Empty;
			_changePasswordAtNextLogon = 0;
			_passwordHints = string.Empty;
			_tempStatus = EnumStatus.Active;
			_authorizedDate = DateTime.Now;
			_passwordResetByAdmin = false;
			_createdDate = null;
			_modifiedBy = 0;
			_modifiedDate = null;
			_passwordResetBy = 0;
			_passwordResetDate = null;
			_address = string.Empty;
		}
		#endregion

		#region properties

		#region EmployeeNo : String 
		private string _employeeNo;
		public string EmployeeNo
		{
			get { return _employeeNo; }
			set { _employeeNo = value; }
		}
		#endregion

		#region Name : String 
		public string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region Gender : String
		public string _gender;
		public string Gender
		{
			get { return _gender; }
			set { _gender = value; }
		}
		#endregion

		#region Religion : String
		public string _religion;
		public string Religion
		{
			get { return _religion; }
			set { _religion = value; }
		}
		#endregion

		#region BirthDate : DateTime
		public DateTime _birthDate;
		public DateTime BirthDate
		{
			get { return _birthDate; }
			set { _birthDate = value; }
		}
		#endregion

		#region JoiningDate : DateTime
		public DateTime _joiningDate;
		public DateTime JoiningDate
		{
			get { return _joiningDate; }
			set { _joiningDate = value; }
		}

		#endregion

		#region Email : String
		public string _email;
		public string Email
		{
			get { return _email; }
			set { _email = value; }
		}
		#endregion

		#region MobileNo : String
		public string _mobileNo;
		public string MobileNo
		{
			get { return _mobileNo; }
			set { _mobileNo = value; }
		}

		#endregion

		#region IsConfirmed : Bool
		public bool? _isConfirmed;
		public bool? IsConfirmed
		{
			get { return _isConfirmed; }
			set { _isConfirmed = value; }
		}
		#endregion

		#region Status : EnumStatus
		public EnumStatus _status;
		public EnumStatus Status
		{
			get { return _status; }
			set { _status = value; }
		}
		#endregion

		#region AccountNo : String
		public string _accountNo;
		public string AccountNo
		{
			get { return _accountNo; }
			set { _accountNo = value; }
		}
		#endregion

		#region Department : String
		public string _department;
		public string Department
		{
			get { return _department; }
			set { _department = value; }
		}

		#endregion

		#region MaritalStatus : String
		public string _maritalStatus;
		public string MaritalStatus
		{
			get { return _maritalStatus; }
			set { _maritalStatus = value; }
		}

		#endregion

		#region Designation : String
		public string _designation;
		public string Designation
		{
			get { return _designation; }
			set { _designation = value; }
		}
		#endregion

		#region Address : String
		public string _address;
		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}
		#endregion

		#region BasicSalary : INT
		public int _basicSalary;
		public int BasicSalary
		{ get { return _basicSalary; }
			set { _basicSalary = value; }
		}
		#endregion

		#region AuthorizedDate : DateTime
		public DateTime? _authorizedDate;
		public DateTime? AuthorizedDate
		{
			get { return _authorizedDate; }
			set { _authorizedDate = value; }
		}
		#endregion

		#region ChangePasswordAtNextLogon : INT
		public int _changePasswordAtNextLogon;
		public int ChangePasswordAtNextLogon
		{
			get { return _changePasswordAtNextLogon; }
			set { _changePasswordAtNextLogon = value; }
		}

		#endregion

		#region Password : String
		public string _password;
		public string Password
		{
			get { return _password; }
			set { _password = value; }
		}
		#endregion

		#region PasswordHints : String
		public string _passwordHints;
		public string PasswordHints
		{
			get { return _passwordHints; }
			set { _passwordHints = value; }
		}

		#endregion

		#region Salt : String 
		public string _salt;
		public string Salt
		{
			get { return _salt; }
			set { _salt = value; }
		}
		#endregion

		#region ForgetPasswordDate : DateTime
		public DateTime? _forgetPasswordDate;
		public DateTime? ForgetPasswordDate
		{
			get { return _forgetPasswordDate; }
			set { _forgetPasswordDate = value; }
		}
		#endregion

		#region LastChangedDate : DateTime
		public DateTime? _lastChangedDate;
		public DateTime? LastChangedDate
		{
			get { return _lastChangedDate; }
			set
			{
				_lastChangedDate = value;
			}
		}
		#endregion

		#region TempStatus : EnumStatus
		public EnumStatus _tempStatus;
		public EnumStatus TempStatus 
		{ 
			get { return _tempStatus; } 
			set { _tempStatus = value; }
		}

		#endregion

		#region TempStatusTime : DateTime
		public DateTime? _tempStatusTime;
		public DateTime? TempStatusTime
		{
			get { return _tempStatusTime; }
			set { _tempStatusTime = value; }
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

		#region CreatedBy : INT 
		private int _createdBy;
		public int CreatedBy
		{
			get { return _createdBy; }
			set { _createdBy = value; }
		}
		#endregion

		#region CreatedDate : DateTime 
		private DateTime? _createdDate;
		public DateTime? CreatedDate
		{
			get { return _createdDate; }
			set { _createdDate = value; }
		}
		#endregion

		#region ModifiedBy : INT 
		private int _modifiedBy;
		public int ModifiedBy
		{
			get { return _modifiedBy; }
			set { _modifiedBy = value; }
		}
		#endregion

		#region ModifiedDate : DateTime 
		private DateTime? _modifiedDate;
		public DateTime? ModifiedDate
		{
			get { return _modifiedDate; }
			set { _modifiedDate = value; }
		}
		#endregion

		#region PasswordResetBy : INT 
		private int _passwordResetBy;
		public int PasswordResetBy
		{
			get { return _passwordResetBy; }
			set { _passwordResetBy = value; }
		}
		#endregion

		#region PasswordResetDate : DateTime 
		private DateTime? _passwordResetDate;
		public DateTime? PasswordResetDate
		{
			get { return _passwordResetDate; }
			set { _passwordResetDate = value; }
		}
		#endregion

		#endregion
	}
	#endregion

	#region IEmployee Service
	public interface IEmployeeService
	{
		Employee GetEmployee(int ID);
		List<Employee> GetEmployees();
		string Save(Employee employee);
		void Delete(int ID);
	}
	#endregion
}
