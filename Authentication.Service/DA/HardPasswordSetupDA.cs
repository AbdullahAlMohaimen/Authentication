
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

namespace Authentication.Service
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

		#region  GET By Status
		internal static IDataReader GetAll()
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from HardPasswordSetup Order by PolicyNo", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
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
						"'"+oHP.SuperUserPassMinLength+"','"+oHP.PasswordMinimumAge+"','"+oHP.IsContainUpperCase+"','"+oHP.IsContainLowerCase+"'," +
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

		#region  Save
		public static string Update(HardPasswordSetup oHP)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			string status = string.Empty;

			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("update HardPasswordSetup set MaxLength = '"+oHP.PassMaxLength+ "', MinLength = '"+oHP.PassMinLength+"', " +
						"SuperUserPassMinLength = '"+oHP.SuperUserPassMinLength+ "', MinPasswordAge = '"+oHP.PasswordMinimumAge+"', " +
						"ContainUppercase = '"+oHP.IsContainUpperCase+"',ContainLowercase = '"+oHP.IsContainLowerCase+"',ContainSpecialCharacter = '"+oHP.IsContainSpecialCharacter+"', " +
						"ContainNumber = '"+oHP.IsContainNumber+"',ContainLetter = '"+oHP.IsContainLatter+"'," +
						"UserPasswordSame = '"+oHP.IsUserPasswordSame+"',PasswordExpireNotificationDays = '"+oHP.PasswordExpNotificationDays+"',PasswordExpireDays = '"+oHP.PasswordExpDays+"' " +
						"where policyID = '"+oHP.ID+"'", conn, tc);
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

		#region  Delete
		internal static string Delete(int ID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			string status = string.Empty;
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand deleteCommand = new SqlCommand("Delete from HardPasswordSetup where PolicyID = '" + ID + "'", conn, tc);
					deleteCommand.ExecuteNonQuery();
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

		#region Search Role
		internal static IDataReader SearchHardPassword(string searchText)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select * from HardPasswordSetup where PolicyNo like '" + searchText + "%' or MaxLength like '"+ searchText + "%' or MinLength like '"+ searchText + "%' " +
					"or MinPasswordAge like '" + searchText + "%' or PasswordExpireDays like '"+ searchText + "%'", conn);
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
