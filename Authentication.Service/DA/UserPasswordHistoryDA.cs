﻿using Authentication.BO;
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
	public class UserPasswordHistoryDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		private UserPasswordHistoryDA() { }
		#endregion

		#region Insert
		internal static string Insert(UserPasswordHistory oUserPasswordHistory)
		{

			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into UserPasswordHistory(UserID,UserPassword,Salt,EntryDate)" +
						"values('"+oUserPasswordHistory.UserID+ "','"+oUserPasswordHistory.UserPassword+"','"+oUserPasswordHistory.Salt+"','"+oUserPasswordHistory.EntryDate+ "')", conn, tc);
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
	}
}
