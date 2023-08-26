using Authentication.BO.Employee;
using MailKit.Mime;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.AspNet.SignalR.Messaging;
using Org.BouncyCastle.Ocsp;

namespace Authentication.Service
{
	public class EmployeeDA
	{
		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Constructor
		private EmployeeDA() { }
		#endregion

		#region  Insert
		internal static string Insert(Employee e)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			string empID = string.Empty;
			conn.Open();
			try 
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand insertCommand = new SqlCommand("Insert into Employee(Name,Gender,Religion,BirthDate," +
								"JoiningDate,Email,MobileNo,IsConfirmed,Status,AccountNo,Department,MaritalStatus,Designation,BasicSalary,ChangePasswordAtNextLogon," +
								"Password,PasswordHints,Salt,TempStatus) values " +
								"('" + e.Name + "','" + e.Gender + "','" + e.Religion + "','" + e.BirthDate + "','" + e.JoiningDate + "','" + e.Email + "','" + e.MobileNo + "'," +
								"'" + e.IsConfirmed + "','" + (int)e.Status + "','" + e.AccountNo + "','" + e.Department + "','" + e.MaritalStatus + "','" + e.Designation + "','" + e.BasicSalary + "'," +
								"'" + e.ChangePasswordNextLogon + "','" + e.Password + "','"+e.PasswordHints+"','" + e.Salt + "','" + (int)e.TempStatus + "')", conn, tc);
					insertCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();
				}

				conn.Open();
				SqlCommand getCommand= new SqlCommand("Select EmployeeNo from Employee where Email='" + e.Email + "' and Password = '"+e.Password+"'", conn);
				SqlDataReader dr = getCommand.ExecuteReader();
				if(dr.Read())
				{
					empID = dr.GetString(0);
				}
				conn.Close();
			}
			catch(Exception ex) { 

			}
			finally
			{
				conn.Close();
			}
			return empID;
		}
		#endregion
	}
}
