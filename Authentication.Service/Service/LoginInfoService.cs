using Authentication.BO;
using Authentication.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service
{
	[Serializable]
	public class LoginInfoService : ServiceTemplate , ILoginInfo
	{
		#region LoginInfo Data Mapping
		public LoginInfoService() { }

		private void MapObject(LoginInfo oLoginInfo, DataReader oReader)
		{
			base.SetObjectID(oLoginInfo, oReader.GetInt32("LoginInfoID").Value);
			oLoginInfo.LoginID = oReader.GetString("LoginID", string.Empty);
			oLoginInfo.UserName = oReader.GetString("UserName", string.Empty);
			oLoginInfo.Type = oReader.GetString("Type", string.Empty);
			oLoginInfo.PCNumber = oReader.GetString("PCNumber", string.Empty);
			oLoginInfo.LoginTime = oReader.GetDateTime("LoginTime", DateTime.MinValue);
			oLoginInfo.LogoutTime = oReader.GetDateTime("LogoutTime", DateTime.MinValue);
			oLoginInfo.IsLogout = oReader.GetBoolean("isLogout",false);
			oLoginInfo.UserID = oReader.GetInt32("UserID") == null ? 0 : oReader.GetInt32("UserID").Value;
			this.SetObjectState(oLoginInfo, BO.ObjectState.Saved);
		}

		protected override T CreateObject<T>(DataReader oReader)
		{
			LoginInfo oLoginInfo = new LoginInfo();
			MapObject(oLoginInfo, oReader);
			return oLoginInfo as T;
		}

		protected LoginInfo CreateObject(DataReader oReader)
		{
			LoginInfo oLoginInfo = new LoginInfo();
			MapObject(oLoginInfo, oReader);
			return oLoginInfo;
		}
		#endregion

		#region Service Implementation

		#region GetLoginInfo By ID
		public LoginInfo GetLoginInfo(int ID)
		{
			return null;
		}
		#endregion

		#region GetLoginInfos
		public List<LoginInfo> GetLoginInfos()
		{
			return null;
		}
		#endregion

		#region Save
		public string Save(LoginInfo loginInfo)
		{
			string result;
			try
			{
				if (loginInfo.IsNew == true)
				{
					result = LoginInfoDA.Insert(loginInfo);
				}
				else
				{
					result = LoginInfoDA.Update(loginInfo);
				}
			}
			catch (Exception e)
			{
				result = "Failed";
			}
			return result;
		}
		#endregion

		#region Delete
		public void Delete(int ID)
		{

		}
		#endregion

		#endregion

		#region GetLoginInfos (fromDate - toDate)
		public List<LoginInfo> GetLoginInfos(DateTime fromDate, DateTime toDate)
		{
			List<LoginInfo> oLoginInfos = new List<LoginInfo>();
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.GetLoginInfos(fromDate, toDate));
				oLoginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oLoginInfos;
		}

		public List<LoginInfo> GetLoginInfosByUserID(int userID, DateTime fromDate, DateTime toDate)
		{
			List<LoginInfo> oLoginInfos = new List<LoginInfo>();
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.GetLoginInfosByUserID(userID, fromDate, toDate));
				oLoginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oLoginInfos;
		}
		#endregion

		#region GetLoginInfos (fromDate - toDate - week)
		public List<LoginInfo> GetLoginInfos(DateTime fromDate, DateTime toDate, EnumWeek week)
		{
			List<LoginInfo> oLoginInfos = new List<LoginInfo>();
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.GetLoginInfos(fromDate, toDate, week));
				oLoginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oLoginInfos;
		}
		#endregion

		#region GetLoginInfos (userID - fromDate - toDate - week)
		public List<LoginInfo> GetLoginInfos(int userID,DateTime fromDate, DateTime toDate, EnumWeek week)
		{
			List<LoginInfo> oLoginInfos = new List<LoginInfo>();
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.GetLoginInfos(userID, fromDate, toDate, week));
				oLoginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oLoginInfos;
		}
		#endregion

		#region GetLoginInfoByLoginID
		public List<LoginInfo> GetLoginInfoByLoginID(string loginID)
		{
			List<LoginInfo> loginInfos = new List<LoginInfo>();
			loginInfos = null;
			bool isLogout;
			try
			{
				isLogout = true;
				DataReader dr = new DataReader(LoginInfoDA.GetLoginInfoByLoginID(loginID , isLogout));
				loginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return loginInfos;
		}
		#endregion

		#region GetNoOFLogin
		public int NoOfLoginInfo(string loginID)
		{
			int nCount = 0;
			List<LoginInfo> loginInfos = new List<LoginInfo>();
			loginInfos = null;
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.NoOfLoginInfo(loginID));
				loginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();

				if (loginInfos != null && loginInfos.Count != 0)
				{
					nCount = loginInfos.Count;
				}
			}
			catch (Exception e)
			{
				#region Handle Exception
				#endregion
			}
			return nCount;
		}
		#endregion

		#region GetLastLoginInfo
		public List<LoginInfo> GetLastLoginInfo(string loginID)
		{
			List<LoginInfo> loginInfos = new List<LoginInfo>();
			loginInfos = null;
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.GetLastLoginInfo(loginID));
				loginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return loginInfos;
		}
		#endregion

		#region GetLastLoginInfo
		public LoginInfo GetCurrentLoginInfo(string loginID,string type,string pcNo, bool isLogout)
		{
			LoginInfo oLoginInfo = new LoginInfo();
			try
			{
				DataReader oreader = new DataReader(LoginInfoDA.GetCurrentLoginInfo(loginID, type, pcNo, isLogout));
				if (oreader.Read())
				{
					oLoginInfo = this.CreateObject<LoginInfo>(oreader);
				}
				else
				{
					oLoginInfo = null;
				}
			}
			catch (Exception ex)
			{
				oLoginInfo = null;
			}
			return oLoginInfo;
		}
		#endregion

		#region SearchLoginInfos (fromDate - toDate)
		public List<LoginInfo> SearchLoginInfos(DateTime fromDate, DateTime toDate, string searchText)
		{
			List<LoginInfo> oLoginInfos = new List<LoginInfo>();
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.SearchLoginInfos(fromDate, toDate, searchText));
				oLoginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oLoginInfos;
		}

		public List<LoginInfo> SearchLoginInfos(DateTime fromDate, DateTime toDate, string searchText,EnumWeek week)
		{
			List<LoginInfo> oLoginInfos = new List<LoginInfo>();
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.SearchLoginInfos(fromDate, toDate, searchText, week));
				oLoginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oLoginInfos;
		}
		#endregion
	}
}
