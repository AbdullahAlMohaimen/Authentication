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
	public class UsersDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		private UsersDA() { }
		#endregion

		#region Insert
		internal static string Insert(Users oUser)
		{

			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("INSERT INTO Users(LoginID,UserName,Status,Email,RoleID,MasterID," +
						"AuthorizedDate,Password,PasswordHints,Salt,TempStatus,ChangePasswordAtNextLogon,PasswordResetByAdmin," +
						"CreatedBy,CreatedDate,IsApprover)" +
						"values('"+oUser.LoginID+"','"+oUser.UserName+"','"+(int)oUser.Status+"','"+oUser.Email+"','"+oUser.RoleID+"'," +
						"'"+oUser.MasterID+"','"+oUser.AuthorizedDate+"','"+oUser.Password+"','"+oUser.PasswordHints+"','"+oUser.Salt+"'," +
						"'"+(int)oUser.TempStatus+"','"+oUser.ChangePasswordNextLogon+"','"+oUser.PasswordResetByAdmin+"'," +
						"'"+oUser.CreatedBy+"','"+oUser.CreatedDate+"','"+oUser.IsApprover+"')", conn,tc);
					insertCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();
				}
				conn.Open();
				SqlCommand getCommand = new SqlCommand("Select * from Users where Email='" + oUser.Email + "' and LoginID = '" + oUser.LoginID + "'", conn);
				SqlDataReader dr = getCommand.ExecuteReader();
				if (dr.Read())
				{
					return "Ok";
				}
				else
				{
					return "Failed";
				}
				dr.Close();
				conn.Close();
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region Update
		internal static string Update(Users oUser)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set UserName = '"+oUser.UserName+"',Email = '"+oUser.Email+"'," +
						"RoleID = '"+oUser.RoleID+"', ModifiedBy = '"+oUser.ModifiedBy+"',ModifiedDate = '"+oUser.ModifiedDate+"', IsApprover = '"+oUser.IsApprover+"' where UserID = '" + oUser.ID + "'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
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
					SqlCommand insertCommand = new SqlCommand("Delete from Users where UserID = '" + ID + "'", conn, tc);
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

		#region Update User for Deactivate
		internal static string UpdateUserDeactivate(Users oUser)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set Password = '" + oUser.Password + "'," +
						"Salt = '" + oUser.Salt + "'," +
						"ForgetPasswordDate = '" + oUser.ForgetPasswordDate + "'," +
						"ChangePasswordAtNextLogon = '" + oUser.ChangePasswordNextLogon + "' where UserID = '" + oUser.ID + "'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region Update ForgetPassword
		internal static string UpdateForgetPassword(Users oUser)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set Password = '"+oUser.Password+"'," +
						"Salt = '"+oUser.Salt+"'," +
						"ForgetPasswordDate = '"+oUser.ForgetPasswordDate+"'," +
						"ChangePasswordAtNextLogon = '"+oUser.ChangePasswordNextLogon+"' where UserID = '"+oUser.ID+"'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region Update Password By Admin
		internal static string UpdatePasswordByAdmin(Users oUser)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set Password = '" + oUser.Password + "'," +
						"Salt = '" + oUser.Salt + "', PasswordResetByAdmin = '" + oUser.PasswordResetByAdmin + "'," +
						"PasswordResetBy = '"+oUser.PasswordResetBy+"', PasswordResetDate = '"+oUser.PasswordResetDate+"' where UserID = '" + oUser.ID + "'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region Update UpdateUserPassword
		internal static string UpdateUserPassword(Users oUser)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set Password = '" + oUser.Password + "'," +
						"Salt = '" + oUser.Salt + "'," +
						"LastChangedDate = '" + oUser.LastChangeDate + "'," +
						"ChangePasswordAtNextLogon = '" + oUser.ChangePasswordNextLogon + "',ForgetPasswordDate = null where UserID = '"+oUser.ID +"'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region UpdateUserTempStatus
		internal static string UpdateUserTempStatus(int userID, EnumStatus tempStatus)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set TempStatus = '"+ tempStatus + "' where UserID = '"+ userID + "'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region UpdateUserStatus
		internal static string UpdateUserStatus(int userID, EnumStatus status, int modifiedBy, DateTime modifiedDate, DateTime statusChangeDate)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Users set Status = '" + (int)status + "', ModifiedBy = '"+ (int)modifiedBy +"'," +
								" ModifiedDate = '"+modifiedDate+"', StatusChangedDate = '"+statusChangeDate+"' " +
								"where UserID = '" + userID + "'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();
					return "Ok";
				}
			}
			catch (Exception ex)
			{
				return "Failed";
			}
		}
		#endregion

		#region Search User
		internal static IDataReader SearchUser(string searchText)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select u.* from Users u, Role r where u.RoleID = r.RoleID and " +
					"(u.UserNo like '"+ searchText + "%' or u.UserName like '"+ searchText + "%' or u.Email like '"+ searchText + "%' " +
					"or r.Name like '"+ searchText + "%')", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}

		internal static IDataReader SearchUser(string searchText, EnumStatus status)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select u.* from Users u, Role r where u.RoleID = r.RoleID and " +
					"(u.UserNo like '" + searchText + "%' or u.UserName like '" + searchText + "%' or u.Email like '" + searchText + "%' " +
					"or r.Name like '" + searchText + "%') and u.status = '"+(int)status+"'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GET All
		internal static IDataReader Get()
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from Users", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region Get By ID
		internal static IDataReader Get(int ID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				if (ID != null)
				{
					getCommand = new SqlCommand("Select * from Users where UserID = '" + ID + "'", conn);
					dr = getCommand.ExecuteReader();
				}
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GetUserByLoginID
		internal static IDataReader GetUserByLoginID(string loginID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				if (!string.IsNullOrEmpty(loginID))
				{
					getCommand = new SqlCommand("Select * from Users where LoginID = '" + loginID + "'", conn);
					dr = getCommand.ExecuteReader();
				}
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region  GET By Status
		internal static IDataReader Get(EnumStatus status)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				if (status == EnumStatus.Regardless)
				{
					getCommand = new SqlCommand("Select * from Users Order by UserID", conn);
				}
				else
				{
					getCommand = new SqlCommand("Select * from Users where status = '" + (int)status + "' Order by UserID", conn);
				}
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
