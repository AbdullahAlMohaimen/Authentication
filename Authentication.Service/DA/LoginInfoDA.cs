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
using System.Runtime.InteropServices;

namespace Authentication.Service
{
	public class LoginInfoDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		private LoginInfoDA() { }
		#endregion

		#region Insert
		internal static string Insert(LoginInfo oLoginInfo)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			string status = string.Empty;
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into LoginInfo(LoginID,UserName,Type,PcNumber,LoginTime,LogoutTime,IsLogout)" +
						"values('"+oLoginInfo.LoginID+"','"+oLoginInfo.UserName+"','"+oLoginInfo.Type+"','"+oLoginInfo.PCNumber+"'," +
						"'"+oLoginInfo.LoginTime+"','"+oLoginInfo.LogoutTime+"','"+oLoginInfo.IsLogout+"')",conn,tc);
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

		#region Update
		internal static string Update(LoginInfo loginInfo)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update LoginInfo set LogoutTime = '"+loginInfo.LogoutTime+"' ,IsLogout = '"+loginInfo.IsLogout+"'" +
						"where LoginInfoID = '"+loginInfo.ID+"' and LoginID = '"+loginInfo.LoginID+"'", conn,tc);
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
			finally
			{
				conn.Close();
			}
		}
		#endregion

		#region GetLoginInfoByLoginID
		internal static IDataReader GetLoginInfoByLoginID(string loginID, bool isLogout)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from LoginInfo where LoginID = '"+ loginID + "' and isLogout = '"+isLogout+"'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GET
		internal static IDataReader NoOfLoginInfo(string loginID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from LoginInfo where LoginID = '" + loginID + "'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GetLastLoginInfo
		internal static IDataReader GetLastLoginInfo(string loginID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select top 1 * from LoginInfo where LoginID = '" + loginID + "' and LogoutTime is not null order by LoginTime desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GetCurrentLoginInfo
		internal static IDataReader GetCurrentLoginInfo(string loginID, string type, string pcNo, bool isLogout)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select top 1 * from LoginInfo where LoginID = '" + loginID + "' and Type = '"+type+"' and PCNumber = '"+pcNo+"' and isLogout = '"+isLogout+"' order by LoginTime desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GetLoginInfos (frmDate - toDate)
		internal static IDataReader GetLoginInfos(DateTime fromDate, DateTime toDate)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from LoginInfo where LoginTime between '" + fromDate + "' and '"+ toDate +"' order by LoginTime desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region GetLoginInfos (frmDate - toDate - week)
		internal static IDataReader GetLoginInfos(DateTime fromDate, DateTime toDate, EnumWeek week)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from LoginInfo where LoginTime between '" + fromDate + "' and '" + toDate + "' " +
											"and DATEPART(WEEKDAY, loginTime) = '"+(int)week+"' order by LoginTime desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region Search LoginInfo (frmDate - toDate)
		internal static IDataReader SearchLoginInfos(DateTime fromDate, DateTime toDate, string SearchString)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from LoginInfo where LoginTime between '" + fromDate + "' and '" + toDate + "' " +
					"and (LoginID like '"+SearchString+"%' or UserName like '"+SearchString+"%' or PCNumber like '"+SearchString+"%' or " +
					"PcNumber like '%-"+SearchString+ "%' or CONVERT(NVARCHAR, LoginTime, 120) like '%"+SearchString+ "%' or " +
					"CONVERT(NVARCHAR, LogOutTime, 120) like '%"+SearchString+"%') order by LoginTime desc", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}

		internal static IDataReader SearchLoginInfos(DateTime fromDate, DateTime toDate, string SearchString, EnumWeek week)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from LoginInfo where LoginTime between '" + fromDate + "' and '" + toDate + "' and and DATEPART(WEEKDAY, loginTime) = '"+(int)week+"' " +
					"and (LoginID like '" + SearchString + "%' or UserName like '" + SearchString + "%' or PCNumber like '" + SearchString + "%' or " +
					"PcNumber like '%-" + SearchString + "%' or CONVERT(NVARCHAR, LoginTime, 120) like '%" + SearchString + "%' or " +
					"CONVERT(NVARCHAR, LogOutTime, 120) like '%" + SearchString + "%') order by LoginTime desc", conn);
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
