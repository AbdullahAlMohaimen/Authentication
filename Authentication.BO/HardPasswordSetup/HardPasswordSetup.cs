using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.BO.Global;
using System.Web.Caching;
using System.Data;

namespace Authentication.BO.HardPasswordSetup
{
	#region HardPasswordSetup
	[Serializable]
	public class HardPasswordSetup : BasicBaseObject
	{
		#region constructor
		public HardPasswordSetup()
		{

		}
		#endregion

		#region properties

		#region Policy No : String 
		public string _policyNo;
		public string PolicyNo
		{
			get { return _policyNo; }
			set { _policyNo = value; }
		}
		#endregion

		#region Password Maximum Length : INT 
		public int _passMaxLength;
		public int PassMaxLength
		{
			get { return _passMaxLength; }
			set { _passMaxLength = value; }
		}
		#endregion

		#region Password Minimum Length : INT 
		public int _passMinLength;
		public int PassMinLength
		{
			get { return _passMinLength; }
			set { _passMinLength = value; }
		}
		#endregion

		#region SuperUser Password Minimum Length : INT 
		public int _superUserassMinLength;
		public int SuperUserassMinLength
		{
			get { return _superUserassMinLength; }
			set { _superUserassMinLength = value; }
		}
		#endregion

		#region Password Minimum Age : INT 
		public int _passwordMinimumAge;
		public int PasswordMinimumAge
		{
			get { return _passwordMinimumAge; }
			set { _passwordMinimumAge = value; }
		}
		#endregion

		#region Password Expire Notification Days : INT 
		public int _passwordExpNotificationDays;
		public int PasswordExpNotificationDays
		{
			get { return _passwordExpNotificationDays; }
			set { _passwordExpNotificationDays = value; }
		}
		#endregion

		#region Password Expire Days : INT 
		public int _passwordExpDays;
		public int PasswordExpDays
		{
			get { return _passwordExpDays; }
			set { _passwordExpDays = value; }
		}
		#endregion

		#region Contain UpperCase : Bool
		public bool? _isContainUpperCase;
		public bool? IsContainUpperCase
		{
			get { return _isContainUpperCase; }
			set { _isContainUpperCase = value; }
		}
		#endregion

		#region Contain LowerCase : Bool
		public bool? _isContainLowerCase;
		public bool? IsContainLowerCase
		{
			get { return _isContainLowerCase; }
			set { _isContainLowerCase = value; }
		}
		#endregion

		#region Contain SpecialCharacter : Bool
		public bool? _isContainSpecialCharacter;
		public bool? IsContainSpecialCharacter
		{
			get { return _isContainSpecialCharacter; }
			set { _isContainSpecialCharacter = value; }
		}
		#endregion

		#region Contain Number : Bool
		public bool? _isContainNumber;
		public bool? IsContainNumber
		{
			get { return _isContainNumber; }
			set { _isContainNumber = value; }
		}
		#endregion

		#region Contain Latter : Bool
		public bool? _isContainLatter;
		public bool? IsContainLatter
		{
			get { return _isContainLatter; }
			set { _isContainLatter = value; }
		}
		#endregion

		#region User Password Same : Bool
		public bool? _isUserPasswordSame;
		public bool? IsUserPasswordSame
		{
			get { return _isUserPasswordSame; }
			set { _isUserPasswordSame = value; }
		}
		#endregion

		#endregion
	}
	#endregion

	#region IEmployee Service
	public interface iHardPasswordSetupService
	{
		HardPasswordSetup GetHardPasswordSetup(int ID);
		List<HardPasswordSetup> GetHardPasswordSetups();
		void Save(HardPasswordSetup oHP);
		void Delete(int ID);
	}
	#endregion
}
