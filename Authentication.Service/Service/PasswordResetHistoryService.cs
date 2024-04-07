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
using Authentication.Service.DA;

namespace Authentication
{
	[Serializable]
	public class PasswordResetHistoryService : ServiceTemplate
	{
		#region UserPasswordHistory Data Mapping
		public PasswordResetHistoryService() { }

		private void MapObject(PasswordResetHistory oPasswordResetHistory, DataReader oReader)
		{
			base.SetObjectID(oPasswordResetHistory, oReader.GetInt32("PasswordResetID").Value);
			oPasswordResetHistory.LoginID = oReader.GetString("LoginID");
			oPasswordResetHistory.Type = (EnumUserType)oReader.GetInt32("Type");
			oPasswordResetHistory.Password = oReader.GetString("Password");
			oPasswordResetHistory.Salt = oReader.GetString("Salt");
			oPasswordResetHistory.PasswordResetBy = oReader.GetInt32("PasswordResetBy").Value;
			oPasswordResetHistory.PasswordResetDate = oReader.GetDateTime("PasswordResetDate",DateTime.MinValue);
			oPasswordResetHistory.Reason = oReader.GetString("Reason");
			this.SetObjectState(oPasswordResetHistory, Authentication.BO.ObjectState.Saved);
		}

		protected override T CreateObject<T>(DataReader oReader)
		{
			PasswordResetHistory oPasswordResetHistory = new PasswordResetHistory();
			MapObject(oPasswordResetHistory, oReader);
			return oPasswordResetHistory as T;
		}
		protected PasswordResetHistory CreateObject(DataReader oReader)
		{
			PasswordResetHistory oPasswordResetHistory = new PasswordResetHistory();
			MapObject(oPasswordResetHistory, oReader);
			return oPasswordResetHistory;
		}
		#endregion

		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region Save
		public string Save(PasswordResetHistory oPasswordResetHistory)
		{
			string result = string.Empty;
			try
			{
				result = PasswordResetHistoryDA.Insert(oPasswordResetHistory);
			}
			catch (Exception ex)
			{
				return "Failed";
			}
			return result;
		}
		#endregion

		#region Save
		public void Save(SqlConnection conn, SqlTransaction tc, PasswordResetHistory oPasswordResetHistory)
		{
			string result = string.Empty;
			try
			{
				PasswordResetHistoryDA.Insert(conn, tc, oPasswordResetHistory);
			}
			catch (Exception ex)
			{

			}
		}
		#endregion

		#region GET by LoginID
		public List<PasswordResetHistory> GetByLoginID(string loginID)
		{
			List<PasswordResetHistory> oUserPasswordHistory = new List<PasswordResetHistory>();
			try
			{
				DataReader dr = new DataReader(PasswordResetHistoryDA.GetByLoginID(loginID));
				oUserPasswordHistory = this.CreateObjects<PasswordResetHistory>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}
		#endregion

		#region GET by UserID
		public List<PasswordResetHistory> GetByUserID(int userID)
		{
			List<PasswordResetHistory> oUserPasswordHistory = new List<PasswordResetHistory>();
			try
			{
				DataReader dr = new DataReader(PasswordResetHistoryDA.GetByUserID(userID));
				oUserPasswordHistory = this.CreateObjects<PasswordResetHistory>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}
		#endregion

		#region GET by EmployeeID
		public List<PasswordResetHistory> GetByEmployeeID(int employeeID)
		{
			List<PasswordResetHistory> oUserPasswordHistory = new List<PasswordResetHistory>();
			try
			{
				DataReader dr = new DataReader(PasswordResetHistoryDA.GetByEmployeeID(employeeID));
				oUserPasswordHistory = this.CreateObjects<PasswordResetHistory>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oUserPasswordHistory;
		}
		#endregion
	}
}
