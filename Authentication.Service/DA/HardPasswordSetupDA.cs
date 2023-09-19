using Authentication.BO.HardPasswordSetup;
using Authentication.BO.Employee;
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

namespace Authentication.Service.DA
{
	public  class HardPasswordSetupDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		public HardPasswordSetupDA() { }
		#endregion

		#region Get(ID)
		internal static IDataReader Get(int id)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from HardPasswordSetup where PolicyID = '" + id + "'", conn);
				dr = getCommand.ExecuteReader();
			}catch (Exception ex)
			{

			}
			return dr;
		}
		#endregion

		#region  GET PolicyNo
		public int GetPolicyID()
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			int policyID = 0;
			try
			{
				conn.Open();
				using ( SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand getCommand = new SqlCommand("select top 1 PolicyID from HardPasswordSetup order by PolicyID desc", conn, tc);
					SqlDataReader dr = getCommand.ExecuteReader();
					if (dr.Read())
					{
						policyID = dr.GetInt32(0);
					}
					dr.Close();
					tc.Commit();
					conn.Close();
				}
			}
			catch (Exception ex)
			{

			}
			finally
			{ 
				conn.Close(); 
			}

			return policyID;
		}
		#endregion

		#region  Save
		public static string Insert(HardPasswordSetup oHP)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			string status = string.Empty;

			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into HardPasswordSetup (MaxLength,MinLength,SuperUserPassMinLength," +
						"MinPasswordAge,ContainUppercase,ContainLowercase,ContainSpecialCharacter,ContainNumber,ContainLetter," +
						"UserPasswordSame,PasswordExpireNotificationDays,PasswordExpireDays) values('"+oHP.PassMaxLength+"','"+oHP.PassMinLength+"'," +
						"'"+oHP.SuperUserassMinLength+"','"+oHP.PasswordMinimumAge+"','"+oHP.IsContainUpperCase+"','"+oHP.IsContainLowerCase+"'," +
						"'"+oHP.IsContainSpecialCharacter+"','"+oHP.IsContainNumber+"','"+oHP.IsContainLatter+"','"+oHP.IsUserPasswordSame+"'," +
						"'"+oHP.PasswordExpNotificationDays+"','"+oHP.PasswordExpDays+"')", conn,tc);
					insertCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();
					status = "Ok";
				}
			}
			catch (Exception ex)
			{
				conn.Close();
				status = "Failed";
				#region Handle Exception

				#endregion
			}
			finally
			{
				conn.Close();
			}
			return status;
		}
		#endregion

	}
}
