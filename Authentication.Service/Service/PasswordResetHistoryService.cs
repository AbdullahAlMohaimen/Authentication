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
	}
}
