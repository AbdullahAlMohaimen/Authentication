using Authentication.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data.SqlClient;
using Authentication.BO.Role;
using Authentication.BO.Users;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using Authentication.BO;
using Authentication.BO.Employee;
using Authentication.BO.Password;
using Authentication.BO.SendEmail;
using Authentication.BO.HardPasswordSetup;
using Authentication.Service.DA;

namespace Authentication.Service
{
	[Serializable]
	public class HardPasswordSetupService : ServiceTemplate , iHardPasswordSetupService
	{
		#region HardPasswordSetup Data Mapping
		public HardPasswordSetupService() { }

		private void MapObject(HardPasswordSetup oHardPasswordSetup, DataReader oReader)
		{
			base.SetObjectID(oHardPasswordSetup, oReader.GetInt32("PolicyID").Value);
			oHardPasswordSetup.PolicyNo = oReader.GetString("PolicyNo", string.Empty);
			oHardPasswordSetup.PassMaxLength = oReader.GetInt32("MaxLength").Value;
			oHardPasswordSetup.PassMinLength = oReader.GetInt32("MinLength").Value;
			oHardPasswordSetup.SuperUserPassMinLength = oReader.GetInt32("SuperuserPassMinLength").Value;
			oHardPasswordSetup.PasswordMinimumAge = oReader.GetInt32("MinPasswordAge").Value;
			oHardPasswordSetup.PasswordExpNotificationDays = oReader.GetInt32("PasswordExpireNotificationDays").Value;
			oHardPasswordSetup.PasswordExpDays = oReader.GetInt32("PasswordExpireDays").Value;
			oHardPasswordSetup.IsContainUpperCase = oReader.GetBoolean("ContainUppercase", false);
			oHardPasswordSetup.IsContainLowerCase = oReader.GetBoolean("ContainLowercase", false);
			oHardPasswordSetup.IsContainSpecialCharacter = oReader.GetBoolean("ContainSpecialCharacter", false);
			oHardPasswordSetup.IsContainNumber = oReader.GetBoolean("ContainNumber", false);
			oHardPasswordSetup.IsContainLatter = oReader.GetBoolean("ContainLetter", false);
			oHardPasswordSetup.IsUserPasswordSame = oReader.GetBoolean("UserPasswordSame", false);
			this.SetObjectState(oHardPasswordSetup, Authentication.BO.ObjectState.Saved);
		}

		protected override T CreateObject<T>(DataReader oReader)
		{
			HardPasswordSetup oHardPasswordSetup = new HardPasswordSetup();
			MapObject(oHardPasswordSetup, oReader);
			return oHardPasswordSetup as T;
		}
		protected HardPasswordSetup CreateObject(DataReader oReader)
		{
			HardPasswordSetup oHardPasswordSetup = new HardPasswordSetup();
			MapObject(oHardPasswordSetup, oReader);
			return oHardPasswordSetup;
		}
		#endregion

		#region Service Implementation
		public HardPasswordSetup GetHardPasswordSetup(int ID)
		{
			HardPasswordSetup oHardPasswordSetup = new HardPasswordSetup();
			try
			{
				DataReader oreader = new DataReader(HardPasswordSetupDA.Get(ID));
				if (oreader.Read())
				{
					oHardPasswordSetup = this.CreateObject<HardPasswordSetup>(oreader);
				}
				else
				{
					oHardPasswordSetup = null;
				}
			}
			catch(Exception ex)
			{

			}
			return oHardPasswordSetup;
		}

		public List<HardPasswordSetup> GetHardPasswordSetups()
		{
			List<HardPasswordSetup> hardPasswordSetups = new List<HardPasswordSetup>();

			return hardPasswordSetups;
		}

		public string Save(HardPasswordSetup oHP)
		{
			HardPasswordSetupDA hardPasswordSetupDA = new HardPasswordSetupDA();
			string status = string.Empty;
			try
			{
				status = HardPasswordSetupDA.Insert(oHP);
			}
			catch (Exception ex)
			{
				status = "Failed";
			}
			return status;
		}

		public void Delete(int ID)
		{

		}
		#endregion

		#region  PolicyNo Generate
		public string GetPolicyNo()
		{
			HardPasswordSetupDA hpDA = new HardPasswordSetupDA();
			string policyNo = null;
			int policyID = hpDA.GetPolicyID();
			if (policyID != 0)
				policyNo = "P00" + (policyID + 1).ToString();
			else
				policyNo = "P00" + 1;
			return policyNo;
		}
		#endregion

		#region IsHardPasswordSetup
		public bool IsHardPasswordSetup(string password, string userName, int roleID)
		{
			HardPasswordSetup hardPasswordSetup = new HardPasswordSetup();
			hardPasswordSetup = GetHardPasswordSetup(1);
			bool isHardPassword = true;

			if (hardPasswordSetup != null)
			{
				if (hardPasswordSetup.IsContainNumber)
				{
					if (!password.ToCharArray().Any(char.IsDigit))
						isHardPassword = false;
				}
				if (hardPasswordSetup.IsContainLatter)
				{
					if (!password.ToCharArray().Any(char.IsLetter))
						isHardPassword = false;
				}
				if (hardPasswordSetup.IsContainLowerCase)
				{
					if (!password.ToCharArray().Any(char.IsLower))
						isHardPassword = false;
				}
				if (hardPasswordSetup.IsContainUpperCase)
				{
					if (!password.ToCharArray().Any(char.IsUpper))
						isHardPassword = false;
				}
				if (hardPasswordSetup.IsContainSpecialCharacter)
				{
					Regex specialCharacterRegex = new Regex("[!@#$%^&*()_+{}[\\]:;<>,.?~\\\\/\\-=|]");
					if (!specialCharacterRegex.IsMatch(password))
						isHardPassword = false;
				}
				if (hardPasswordSetup.IsUserPasswordSame)
				{
					if (userName.ToLower().Trim() == password.ToLower().Trim())
						isHardPassword = false;
				}
				if (hardPasswordSetup.PassMaxLength>0)
				{
					if (password.Length > hardPasswordSetup.PassMaxLength)
						isHardPassword = false;
				}
				if (hardPasswordSetup.PassMinLength > 0)
				{
					if (password.Length < hardPasswordSetup.PassMinLength)
						isHardPassword = false;
				}
				if (hardPasswordSetup.SuperUserPassMinLength > 0 && (userName.ToLower() == "SuperUser" || userName.ToLower() == "MasterUser"))
				{
					if (password.Length < hardPasswordSetup.SuperUserPassMinLength)
						isHardPassword = false;
				}
				if(roleID == 1 || roleID == 5 || roleID == 20)
				{
					if (password.Length < hardPasswordSetup.SuperUserPassMinLength)
						isHardPassword = false;
				}
				return isHardPassword;
			}
			else
			{
				return isHardPassword;
			}
		}
		#endregion
	}
}
