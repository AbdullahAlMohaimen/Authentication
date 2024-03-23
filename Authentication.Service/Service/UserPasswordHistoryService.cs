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
	public class UserPasswordHistoryService : ServiceTemplate, IUserPasswordHistory
	{
		#region UserPasswordHistory Data Mapping
		public UserPasswordHistoryService() { }

		private void MapObject(UserPasswordHistory oUserPasswordHistory, DataReader oReader)
		{
			base.SetObjectID(oUserPasswordHistory, oReader.GetInt32("UPHID").Value);
			oUserPasswordHistory.UserID = oReader.GetInt32("UserID").Value;
			oUserPasswordHistory.UserPassword = oReader.GetString("UserPassword", string.Empty);
			oUserPasswordHistory.Salt = oReader.GetString("Salt", string.Empty);
			oUserPasswordHistory.EntryDate = oReader.GetDateTime("EntryDate",DateTime.MinValue);
			this.SetObjectState(oUserPasswordHistory, Authentication.BO.ObjectState.Saved);
		}

		protected override T CreateObject<T>(DataReader oReader)
		{
			UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
			MapObject(oUserPasswordHistory, oReader);
			return oUserPasswordHistory as T;
		}
		protected UserPasswordHistory CreateObject(DataReader oReader)
		{
			UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
			MapObject(oUserPasswordHistory, oReader);
			return oUserPasswordHistory;
		}
		#endregion

		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Service Implementation

		#region Get UserPasswordHistory by ID
		public UserPasswordHistory GetUserPasswordHistory(int userID)
		{
			UserPasswordHistory oUserPasswordHistory = new UserPasswordHistory();
			try
			{

			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}
		#endregion

		#region Get All
		public List<UserPasswordHistory> GetUserPasswordHistories()
		{
			List<UserPasswordHistory> oUserPasswordHistory = new List<UserPasswordHistory>();
			try
			{
				//DataReader dr = new DataReader(UsersDA.Get());
				//oUserPasswordHistory = this.CreateObjects<UserPasswordHistory>(dr);
				//dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}

		public List<UserPasswordHistory> GetUserPasswordHistories(int userID)
		{
			List<UserPasswordHistory> oUserPasswordHistory = new List<UserPasswordHistory>();
			try
			{
				DataReader dr = new DataReader(UserPasswordHistoryDA.Get(userID));
				oUserPasswordHistory = this.CreateObjects<UserPasswordHistory>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}

		public List<UserPasswordHistory> GetUserAllPasswordHistories(int userID)
		{
			List<UserPasswordHistory> oUserPasswordHistory = new List<UserPasswordHistory>();
			try
			{
				DataReader dr = new DataReader(UserPasswordHistoryDA.GetAllPasswordHistory(userID));
				oUserPasswordHistory = this.CreateObjects<UserPasswordHistory>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}
		#endregion

		#region Save
		public string Save(UserPasswordHistory oUserPasswordHistory)
		{
			string result = string.Empty;
			try
			{
				result = UserPasswordHistoryDA.Insert(oUserPasswordHistory);
			}
			catch (Exception ex)
			{
				return "Failed";
			}

			return result;
		}
		#endregion

		#region Delete User
		public void Delete(int UserPasswordHistoryID)
		{

		}
		#endregion

		#endregion

	}
}
