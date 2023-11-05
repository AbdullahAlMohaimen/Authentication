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
		public LoginInfo GetLoginInfo(int ID)
		{
			return null;
		}
		public List<LoginInfo> GetLoginInfos()
		{
			return null;
		}
		public string Save(LoginInfo loginInfo)
		{
			string result;
			try
			{
				result = LoginInfoDA.Insert(loginInfo);
			}
			catch (Exception e)
			{
				result = "Failed";
			}
			return null;
		}
		public void Delete(int ID)
		{

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
				isLogout = false;
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
	}
}
