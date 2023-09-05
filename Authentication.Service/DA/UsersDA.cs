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
using Authentication.BO.Users;


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
						"AuthorizedDate,Password,PasswordHints,Salt,TempStatus,ChangePasswordAtNextLogon,PasswordResetByAdmin)" +
						"values('"+oUser.LoginID+"','"+oUser.UserName+"','"+(int)oUser.Status+"','"+oUser.Email+"','"+oUser.RoleID+"'," +
						"'"+oUser.MasterID+"','"+oUser.AuthorizedDate+"','"+oUser.Password+"','"+oUser.PasswordHints+"','"+oUser.Salt+"'," +
						"'"+(int)oUser.TempStatus+"','"+oUser.ChangePasswordNextLogon+"','"+oUser.PasswordResetByAdmin+"')", conn,tc);
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
	}
}
