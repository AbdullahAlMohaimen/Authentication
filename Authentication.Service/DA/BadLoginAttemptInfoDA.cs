using Authentication.BO;
using MailKit.Mime;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Messaging;
using Org.BouncyCastle.Ocsp;
using System.Data;
using System.Runtime.InteropServices;

namespace Authentication.Service
{
	public class BadLoginAttemptInfoDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		private BadLoginAttemptInfoDA() { }
		#endregion

		#region Insert
		internal static string Insert(BadLoginAttemptInfo item)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			string status = string.Empty;
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into BadLoginAttemptInfo(LoginID,Type,AttempTime,PcNumber,UserID)" +
						"values('"+ item.LoginID + "','"+ item.Type +"', '"+item.AttemptTime+"', '"+item.PCNumber+"','"+item.UserID+"')", conn, tc);
					insertCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();
					status = "Ok";
				}
			}
			catch (Exception ex)
			{
				status = "Failed";
			}
			finally
			{
				conn.Close();
			}
			return status;
		}
		#endregion

		#region GET
		internal static IDataReader GetBadLoginAttempt(string loginID, int UserID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();

			DateTime toTime = DateTime.Now;
			DateTime fromTime = toTime.Subtract(TimeSpan.FromMinutes(45));

			try
			{
				getCommand = new SqlCommand("Select * from BadLoginAttemptInfo where (UserID = '"+ UserID +"' LoginID = '" + loginID + "') and AttemptTime between '"+ fromTime + "' and '"+ toTime + "'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion
	}
}
