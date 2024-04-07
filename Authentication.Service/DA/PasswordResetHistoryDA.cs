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

namespace Authentication.Service.DA
{
	public class PasswordResetHistoryDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		private PasswordResetHistoryDA() { }
		#endregion

		#region Insert
		internal static string Insert(PasswordResetHistory oPasswordResetHistory)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();

			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into PasswordResetHistory(LoginID,Type,Password,Salt,PasswordResetBy,PasswordResetDate,Reason)" +
						"values('" + oPasswordResetHistory.LoginID + "','" + oPasswordResetHistory.Type + "','" + oPasswordResetHistory.Password + "','" + oPasswordResetHistory.Salt + "', " +
						"'"+ oPasswordResetHistory .PasswordResetBy+ "','"+ oPasswordResetHistory .PasswordResetDate+ "','"+ oPasswordResetHistory .Reason+ "')", conn, tc);
					insertCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();
				}
				return "Ok";
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region Insert
		internal static void Insert(SqlConnection conn, SqlTransaction tc, PasswordResetHistory oPasswordResetHistory)
		{
			try
			{
				SqlCommand insertCommand = new SqlCommand("Insert into PasswordResetHistory(LoginID,Type,Password,Salt,PasswordResetBy,PasswordResetDate,Reason)" +
						"values('" + oPasswordResetHistory.LoginID + "','" + (int)oPasswordResetHistory.Type + "','" + oPasswordResetHistory.Password + "','" + oPasswordResetHistory.Salt + "', " +
						"'" + oPasswordResetHistory.PasswordResetBy + "','" + oPasswordResetHistory.PasswordResetDate + "','" + oPasswordResetHistory.Reason + "')", conn, tc);
				insertCommand.ExecuteNonQuery();
			}
			catch (Exception ex)
			{

			}
		}
		#endregion
		#region GET by LoginID
		internal static IDataReader GetByLoginID(string loginID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from PasswordResetHistory where LoginID = '" + loginID + "' order by PasswordResetDate Desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GET by UserID
		internal static IDataReader GetByUserID(int userID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select p.* from PasswordResetHistory p join Users u on p.LoginID = u.LoginID " +
					"where u.UserID = '"+ userID + "' order by p.PasswordResetDate Desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GET by EmployeeID
		internal static IDataReader GetByEmployeeID(int employeeID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select p.* from PasswordResetHistory p join Employee e on p.LoginID = e.EmployeeNo " +
					"where e.employeeID = '" + employeeID + "' order by p.PasswordResetDate Desc", conn);
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
