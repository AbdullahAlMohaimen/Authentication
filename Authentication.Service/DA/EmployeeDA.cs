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
using MailKit.Search;

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
					SqlCommand insertCommand = new SqlCommand("Insert into EMPLOYEE(Name,Gender,Religion,BirthDate," +
								"JoiningDate,Email,MobileNo,IsConfirmed,Status,AccountNo,Department,MaritalStatus,Designation,BasicSalary,AuthorizedDate,ChangePasswordAtNextLogon," +
								"Password,PasswordHints,Salt,TempStatus,PasswordResetByAdmin,Address) values " +
								"('" + e.Name + "','" + e.Gender + "','" + e.Religion + "','" + e.BirthDate + "','" + e.JoiningDate + "','" + e.Email + "','" + e.MobileNo + "'," +
								"'" + e.IsConfirmed + "','" + (int)e.Status + "','" + e.AccountNo + "','" + e.Department + "','" + e.MaritalStatus + "','" + e.Designation + "','" + e.BasicSalary + "','" + e.AuthorizedDate + "'," +
								"'" + e.ChangePasswordAtNextLogon + "','" + e.Password + "','"+e.PasswordHints+"','" + e.Salt + "','" + (int)e.TempStatus + "','" +e.PasswordResetByAdmin+ "','"+e.Address+"')", conn, tc);
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
				dr.Close();
				conn.Close();
			}
			catch(Exception ex) { 
				conn.Close();
			}
			finally
			{
				conn.Close();
			}
			return empID;
		}
		#endregion

		#region Update
		internal static string Update(Employee oEmployee)
		{
			string employeeNo = string.Empty;
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Employee set MaritalStatus = '" + oEmployee.MaritalStatus + "',MobileNo = '" + oEmployee.MobileNo + "'," +
						"AccountNo = '" + oEmployee.AccountNo + "', Department = '" + oEmployee.Department + "',Designation = '" + oEmployee.Designation + "'," +
						"Email = '"+oEmployee.Email + "', Status = '"+(int)oEmployee.Status+"',BasicSalary = '" + oEmployee.BasicSalary+"',IsConfirmed = '"+oEmployee.IsConfirmed+"',Address = '"+oEmployee.Address+"' where EmployeeID = '" + oEmployee.ID + "'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					employeeNo = oEmployee.EmployeeNo;
				}
			}
			catch (Exception ex)
			{
				employeeNo = null;
			}
			return employeeNo;
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
					SqlCommand insertCommand = new SqlCommand("Delete from Employee where EmployeeID = '" + ID + "'", conn, tc);
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

		#region Update Basic Information
		internal static string UpdateEmpBasicInfo(Employee oEmployee)
		{
			string employeeNo = string.Empty;
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Employee Set Name = '"+oEmployee.Name+"',Gender = '"+oEmployee.Gender+"', " +
						"Religion = '"+oEmployee.Religion+"', BirthDate = '"+oEmployee.BirthDate+"', JoiningDate = '"+oEmployee.JoiningDate+"', " +
						"Email = '"+oEmployee.Email+"', MobileNo = '"+oEmployee.MobileNo+"', IsConfirmed = '"+oEmployee.IsConfirmed+"', Status = '"+(int)oEmployee.Status+"', " +
						"AccountNo = '"+oEmployee.AccountNo+"', Department = '"+oEmployee.Department+"', MaritalStatus = '"+oEmployee.MaritalStatus+"', " +
						"Designation = '"+oEmployee.Designation+"', BasicSalary = '"+oEmployee.BasicSalary+"', ModifiedBy = '"+oEmployee.ModifiedBy+"', " +
						"ModifiedDate = '"+oEmployee.ModifiedDate+"', Address = '"+oEmployee.Address+"' where EmployeeID = '"+oEmployee.ID+"'", conn, tc);
					updateCommand.ExecuteNonQuery();
					tc.Commit();
					conn.Close();

					employeeNo = oEmployee.EmployeeNo;
				}
			}
			catch (Exception ex)
			{
				employeeNo = null;
			}
			return employeeNo;
		}
		#endregion

		#region  Search Employee
		internal static IDataReader GetSearchEmpoyee(string empNo, string empName)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				if(!string.IsNullOrEmpty(empNo) && !string.IsNullOrEmpty(empName))
				{
					getCommand = new SqlCommand("Select * from Employee where EmployeeNo = '" + empNo + "' and Name = '"+empName+"'", conn);
				}
				if (!string.IsNullOrEmpty(empNo) && string.IsNullOrEmpty(empName))
				{
					getCommand = new SqlCommand("Select * from Employee where EmployeeNo = '" + empNo + "'", conn);
				}
				if (string.IsNullOrEmpty(empNo) && !string.IsNullOrEmpty(empName))
				{
					getCommand = new SqlCommand("Select * from Employee where Name = '" + empName + "'", conn);
				}
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			dr = getCommand.ExecuteReader();
			return dr;
		}
		#endregion

		#region  GetEmployee BY ID
		internal static IDataReader GetEmployee(int ID)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from Employee where EmployeeID = '" + ID + "'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region  GetEmployee BY INoD
		internal static IDataReader GetEmployee(string empNo)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from Employee where EmployeeNo = '" + empNo + "'", conn);
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
				getCommand = new SqlCommand("Select * from Employee", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}

		internal static IDataReader Get(EnumStatus status)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlCommand getCommand = null;
			SqlDataReader dr = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("Select * from Employee where status = '"+(int)status + "'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region Search Employee In Grid
		internal static IDataReader SearchEmployee(string searchText)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select * from Employee where EmployeeNo like '"+searchText+"%' or " +
					"Name like '"+searchText+"%' or Department like '"+searchText+"%' or Designation like '"+searchText+"%' " +
					"or Gender like '"+searchText+"%' or Religion like '"+searchText+"%'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region Search Employee In TextBox
		internal static IDataReader SearchEmp(string searchText)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				getCommand = new SqlCommand("select * from Employee where EmployeeNo like '" + searchText + "%' or " +
					"Name like '" + searchText + "%'", conn);
				dr = getCommand.ExecuteReader();
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			return dr;
		}
		#endregion

		#region  SearchEmp
		internal static IDataReader SearchEmp(string empNo, string empName, string searchText)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Close();
			SqlDataReader dr = null;
			SqlCommand getCommand = null;
			conn.Open();
			try
			{
				if (!string.IsNullOrEmpty(empNo) && !string.IsNullOrEmpty(empName))
				{
					getCommand = new SqlCommand("Select * from Employee where EmployeeNo = '" + empNo + "' or Name = '" + empName + "' or concat('(',employeeNo,') - ',name) = '"+ searchText + "'", conn);
				}
			}
			catch (Exception ex)
			{
				conn.Close();
			}
			dr = getCommand.ExecuteReader();
			return dr;
		}
		#endregion

		#region Update Password By Admin
		internal static string UpdatePasswordByAdmin(Employee oEmployee)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Employee set Password = '" + oEmployee.Password + "'," +
						"Salt = '" + oEmployee.Salt + "', PasswordResetByAdmin = '" + oEmployee.PasswordResetByAdmin + "'," +
						"PasswordResetBy = '" + oEmployee.PasswordResetBy + "', PasswordResetDate = '" + oEmployee.PasswordResetDate + "' where EmployeeID = '" + oEmployee.ID + "'", conn, tc);
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

		#region UpdateEmployeeStatus
		internal static string UpdateEmployeeStatus(int empID, EnumStatus status, int modifiedBy, DateTime modifiedDate)
		{
			string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
			SqlConnection conn = new SqlConnection(connectionString);
			conn.Open();
			try
			{
				using (SqlTransaction tc = conn.BeginTransaction())
				{
					SqlCommand updateCommand = new SqlCommand("Update Employee set Status = '" + (int)status + "', ModifiedBy = '" + (int)modifiedBy + "'," +
								" ModifiedDate = '" + modifiedDate + "' " +
								"where EmployeeID = '" + empID + "'", conn, tc);
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
	}
}
