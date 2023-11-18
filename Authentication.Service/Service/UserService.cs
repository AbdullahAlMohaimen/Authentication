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

namespace Authentication.Service
{
	[Serializable]
	public class UserService : ServiceTemplate , IUserService
	{
		#region User Data Mapping
		public UserService() { }

		private void MapObject(Users oUser, DataReader oReader)
		{
			base.SetObjectID(oUser, oReader.GetInt32("UserID").Value);
			oUser.LoginID = oReader.GetString("LoginID", string.Empty);
			oUser.UserName = oReader.GetString("UserName", string.Empty);
			oUser.Status = (EnumStatus)oReader.GetInt32("status", 1);
			oUser.Email = oReader.GetString("Email",string.Empty);
			oUser.RoleID = oReader.GetInt32("RoleID",0);
			oUser.MasterID = oReader.GetInt32("MasterID",0);
			oUser.AuthorizedDate = oReader.GetDateTime("AuthorizedDate",DateTime.MinValue);
			oUser.Password = oReader.GetString("Password", string.Empty);
			oUser.PasswordHints = oReader.GetString("PasswordHints", string.Empty);
			oUser.Salt = oReader.GetString("Salt",string.Empty);
			oUser.ForgetPasswordDate = oReader.GetDateTime("ForgetPasswordDate",DateTime.MinValue);
			oUser.LastChangeDate = oReader.GetDateTime("LastChangedDate", DateTime.MinValue);
			oUser.TempStatus = (EnumStatus)oReader.GetInt32("TempStatus",0);
			oUser.TempStatusTime = oReader.GetDateTime("TempStatusTime",DateTime.MinValue);
			oUser.ChangePasswordNextLogon = oReader.GetInt32("ChangePasswordAtNextLogon",0);
			oUser.PasswordResetByAdmin = oReader.GetBoolean("PasswordResetByAdmin", false);

			oUser.CreatedBy = oReader.GetInt32("CreatedBy", 0);
			oUser.CreatedDate = oReader.GetDateTime("CreatedDate", DateTime.MinValue);
			oUser.ModifiedBy = oReader.GetInt32("ModifiedBy", 0);
			oUser.ModifiedDate = oReader.GetDateTime("ModifiedDate", DateTime.MinValue);
			oUser.PasswordResetBy = oReader.GetInt32("PasswordResetBy", 0);
			oUser.PasswordResetDate = oReader.GetDateTime("PasswordResetDate", DateTime.MinValue);
			oUser.StatusChangedDate = oReader.GetDateTime("StatusChangedDate", DateTime.MinValue);
			this.SetObjectState(oUser, Authentication.BO.ObjectState.Saved);
		}
		protected override T CreateObject<T>(DataReader oReader)
		{
			Users oUser = new Users();
			MapObject(oUser, oReader);
			return oUser as T;
		}
		protected Users CreateObject(DataReader oReader)
		{
			Users oUser = new Users();
			MapObject(oUser, oReader);
			return oUser;
		}
		#endregion

		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Service Implementation

		#region Get User by ID
		public Users GerUser(int userID)
		{
			Users users = new Users();
			try
			{

			}
			catch (Exception ex)
			{

			}
			return users;
		}
		#endregion

		#region Get All Users
		public List<Users> GetUsers()
		{
			List <Users> users = new List<Users>();
			try
			{
				DataReader dr = new DataReader(UsersDA.Get());
				users = this.CreateObjects<Users>(dr);
				dr.Close();
			}
			catch (Exception ex){ 
			
			}
			return users;
		}
		#endregion

		#region Save User
		public string Save(Users user)
		{
			Password password = new Password();
			string randomPassword;
			string result = null;
			try
			{
				if(user.IsNew == true)
				{
					if (user.RoleID == 1 || user.RoleID == 5 || user.RoleID == 20)
						randomPassword = password.GenerateRandomPassword(14, 16);
					else
						randomPassword = password.GenerateRandomPassword(10);

					user.Salt = password.CreateSalt(128);
					user.Password = password.GenerateHash(randomPassword, user.Salt);
					result = UsersDA.Insert(user);

					if (result == "Ok")
					{
						SendEmail sendEmail = new SendEmail();
						sendEmail.To = user.Email;
						sendEmail.Subject = "User Login Password (Do not replay this mail)";
						sendEmail.Body = $@"<html><body><p><b>Dear</b> {user.UserName},</p>
								 <p><b>Your Login ID : </b>{user.LoginID}</p>
			                     <p><b>This is system generated password : </b>{randomPassword}</p>
			                     <p>Regards,</p>
			                     <p>Authentication Team</p></body></html>";
						sendEmail.SendigEmail(sendEmail);
					}
				}
				else
				{
					result = UsersDA.Update(user);
				}
			}
			catch(Exception ex)
			{
				return "Failed";
			}

			return result;
		}
		#endregion

		#region Delete User
		public void Delete(int userID)
		{

		}
		#endregion

		#endregion

		#region GetUserByLoginID
		public Users GetUserByLoginID(string loginID)
		{
			Users oUser = new Users();
			try
			{
				DataReader oreader = new DataReader(UsersDA.GetUserByLoginID(loginID));
				if (oreader.Read())
				{
					oUser = this.CreateObject<Users>(oreader);
				}
				else
				{
					oUser = null;
				}
			}
			catch(Exception ex)
			{
				oUser = null;
			}
			return oUser;
		}
		#endregion

		#region ForgetPassword
		public string ForgetPassword(Users user, string randomPassword)
		{
			Password password = new Password();
			string result = null;
			if (user != null)
			{
				user.Salt = password.CreateSalt(128);
				user.Password = password.GenerateHash(randomPassword, user.Salt);
				user.ForgetPasswordDate = DateTime.Now;
				user.ChangePasswordNextLogon = 1;

				result = UsersDA.UpdateForgetPassword(user);
				if (result == "Ok")
				{
					SendEmail sendEmail = new SendEmail();
					sendEmail.To = user.Email;
					sendEmail.Subject = "User Forget Password (Do not replay this mail)";
					sendEmail.Body = $@"<html><body><p><b>Dear</b> {user.UserName},</p>
			                     <p><b>This is system generated password : </b>{randomPassword}</p>
								 <p><b>This password is valid within 24 hours</p>
			                     <p>Regards,</p>
			                     <p>Authentication Team</p></body></html>";
					sendEmail.SendigEmail(sendEmail);
				}
				else
				{
					result = "failed";
				}
			}
			return result;
		}
		#endregion

		#region UpdatePassword
		public string UpdatePassword(Users user)
		{
			Password password = new Password();
			string result = null;
			if (user != null)
			{
				result = UsersDA.UpdateUserPassword(user);
			}
			return result;
		}
		#endregion

		#region Update
		public string Update(Users user)
		{
			string result = null;
			try
			{
				if (user != null)
				{
					result = UsersDA.Update(user);
				}
			}
			catch (Exception ex)
			{
				result = "Failed";
			}
			return result;
		}
		#endregion

		#region Update User for Deactivated
		public string UpdateUserDeactivate(Users user)
		{
			string result = null;
			try
			{
				if (user != null)
				{
					result = UsersDA.UpdateUserDeactivate(user);
				}
			}
			catch (Exception ex)
			{
				result = "Failed";
			}
			return result;
		}
		#endregion

		#region UpdateUserTempStatus
		public string UpdateUserTempStatus(int userID)
		{
			string result = null;
			try
			{
				if (userID != null)
				{
					EnumStatus tempStatus = EnumStatus.Inactive;
					result = UsersDA.UpdateUserTempStatus(userID , tempStatus);
				}
			}
			catch (Exception ex)
			{
				result = "Failed";
			}
			return result;
		}
		#endregion

		#region UpdateUserStatus
		public string UpdateUserStatus(int userID, EnumStatus status, int modifiedBy, DateTime modifiedDate, DateTime statusChangeDate)
		{
			string result = null;
			try
			{
				if (userID != null)
				{
					result = UsersDA.UpdateUserStatus(userID, status, modifiedBy, modifiedDate, statusChangeDate);
				}
			}
			catch (Exception ex)
			{
				result = "Failed";
			}
			return result;
		}
		#endregion
	}
}
