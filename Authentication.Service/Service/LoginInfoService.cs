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
			return null;
		}
		public void Delete(int ID)
		{

		}
		#endregion

		public List<LoginInfo> GetLoginInfoByLoginID(string loginID)
		{
			List<LoginInfo> loginInfos = new List<LoginInfo>();
			loginInfos = null;
			try
			{
				DataReader dr = new DataReader(LoginInfoDA.GetLoginInfoByLoginID(loginID));
				loginInfos = this.CreateObjects<LoginInfo>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return loginInfos;
		}
	}
}
