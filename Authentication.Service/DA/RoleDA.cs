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
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;
using System.IO;
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
					SqlCommand insertCommand = new SqlCommand("Insert into ROLE (Name,Status,Description,CreatedBy,CreatedDate) values('"+role.Name+"','"+(int)role.Status+"','"+role.Description+"','"+role.CreatedBy+"','"+role.CreatedDate+"')",conn,tc);
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

		#region Update
		internal static string Update(Role oRole)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Role set Name = '"+oRole.Name+"', Status = '"+(int)oRole.Status+"',Description = '"+oRole.Description+"'," +
						"ModifiedBy = '"+oRole.ModifiedBy+"',ModifiedDate = '"+oRole.ModifiedDate+"' where RoleID = '"+oRole.ID+"'", conn, tc);
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

		#region  Insert
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
					SqlCommand insertCommand = new SqlCommand("Delete from Role where RoleID = '"+ID+"'", conn, tc);
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
				getCommand = new SqlCommand("Select * from Role Order by RoleID", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex) { 
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
				if(status == EnumStatus.Regardless)
				{
					getCommand = new SqlCommand("Select * from Role Order by RoleID", conn);
				}
				else
				{
					getCommand = new SqlCommand("Select * from Role where status = '" + (int)status + "' Order by RoleID", conn);
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
					getCommand = new SqlCommand("Select * from Role where RoleID = '" + ID + "'", conn);
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

		#region Get By ID
		internal static IDataReader GetByCode(string code)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				if (code != null)
				{
					getCommand = new SqlCommand("Select * from Role where code = '" + code + "'", conn);
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

		#region Search Role
		internal static IDataReader SearchRole(string searchText)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select r.* from Role r, Users u where r.CreatedBy = u.UserID and " +
					"(r.name like '"+ searchText + "%' or r.code like '"+ searchText + "%' or u.UserName like '"+ searchText +"%')", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}

		internal static IDataReader SearchRole(string searchText, EnumStatus status)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select r.* from Role r, Users u where R.status = '"+(int)status+"' and r.CreatedBy = u.UserID and " +
					"(r.name like '" + searchText + "%' or r.code like '" + searchText + "%' or u.UserName like '" + searchText + "%')", conn);
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
