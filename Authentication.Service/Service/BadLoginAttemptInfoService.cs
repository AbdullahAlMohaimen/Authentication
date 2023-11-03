using Authentication.BO;
using Authentication.Service.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service
{
	[Serializable]
	public class BadLoginAttemptInfoService : ServiceTemplate , IBadLoginAttemptServie
	{
		#region LoginInfo Data Mapping
		public BadLoginAttemptInfoService() { }

		private void MapObject(BadLoginAttemptInfo oBadLoginAttemptInfo, DataReader oReader)
		{
			base.SetObjectID(oBadLoginAttemptInfo, oReader.GetInt32("AttemptID").Value);
			oBadLoginAttemptInfo.UserID = oReader.GetInt32("UserID").Value;
			oBadLoginAttemptInfo.LoginID = oReader.GetString("LoginID",string.Empty);
			oBadLoginAttemptInfo.Type = oReader.GetString("Type",string.Empty);
			oBadLoginAttemptInfo.AttemptTime = oReader.GetDateTime("AttemptTime", DateTime.MinValue);
			oBadLoginAttemptInfo.PCNumber = oReader.GetString("PcNumber",string.Empty);
			this.SetObjectState(oBadLoginAttemptInfo, BO.ObjectState.Saved);
		}

		protected override T CreateObject<T>(DataReader oReader)
		{
			BadLoginAttemptInfo oBadLoginAttemptInfo = new BadLoginAttemptInfo();
			MapObject(oBadLoginAttemptInfo, oReader);
			return oBadLoginAttemptInfo as T;
		}

		protected BadLoginAttemptInfo CreateObject(DataReader oReader)
		{
			BadLoginAttemptInfo oBadLoginAttemptInfo = new BadLoginAttemptInfo();
			MapObject(oBadLoginAttemptInfo, oReader);
			return oBadLoginAttemptInfo;
		}
		#endregion

		#region Save
		public string Save(BadLoginAttemptInfo oBadLoginAttemptInfo)
		{
			string result;
			try
			{
				result = BadLoginAttemptInfoDA.Insert(oBadLoginAttemptInfo);
			}
			catch (Exception e)
			{
				result = "Failed";
			}
			return null;
		}
		#endregion

		#region GetBadLoginAttempt
		public List<BadLoginAttemptInfo> GetBadLoginAttempt(string loginID, int userID)
		{
			int nCount = 0;
			List<BadLoginAttemptInfo> badLoginAttemptInfos = new List<BadLoginAttemptInfo>();
			badLoginAttemptInfos = null;
			try
			{
				DataReader dr = new DataReader(BadLoginAttemptInfoDA.GetBadLoginAttempt(loginID, userID));
				badLoginAttemptInfos = this.CreateObjects<BadLoginAttemptInfo>(dr);
				dr.Close();

				//DataTable dt = BadLoginAttemptInfoDA.GetBadLoginAttemptCount(tc, userID);
				//int.TryParse(dt.Rows[0][0].ToString(), out totalCount);
			}
			catch (Exception e)
			{
				#region Handle Exception
				#endregion
			}
			return badLoginAttemptInfos;
		}
		#endregion
	}
}
