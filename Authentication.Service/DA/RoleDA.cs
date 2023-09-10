﻿using Authentication.BO.Employee;
using MailKit.Mime;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Messaging;
using Org.BouncyCastle.Ocsp;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.IO;
using Authentication.BO.Role;
using MailKit;
using iTextSharp.text.pdf.security;
using System.Data;

namespace Authentication.Service
{
	public class RoleDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		public RoleDA() { }
		#endregion

		#region  GET Code
		public int GetCode()
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			int roleCode = 0;
			try
			{
				conn.Open();
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand getCommand = new SqlCommand("select top 1 RoleID from Role order by RoleID desc", conn, tc);
					SqlDataReader dr = getCommand.ExecuteReader();
					if (dr.Read())
					{
						roleCode = dr.GetInt32(0);
					}
					dr.Close();
					tc.Commit();
					conn.Close();
				}
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			finally
			{
				conn.Close();
			}
			return roleCode;
		}
		#endregion

		#region  Insert
		internal static string Insert(Role role)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			string status = string.Empty;
			try
			{
				using(SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into ROLE (Name,Status,Description) values('"+role.Name+"','"+(int)role.Status+"','"+role.Description+"')",conn,tc);
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

		#region  GET
		internal static IDataReader Get()
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from Role", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex) { 
				conn.Close();
			}
			return dr;
		}
		#endregion
	}
}
