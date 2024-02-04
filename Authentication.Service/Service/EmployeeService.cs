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
using System.Net.Mail;
using System.Data.SqlClient;



namespace Authentication.Service
{
	[Serializable]
	public class EmployeeService : ServiceTemplate, IEmployeeService
	{
		#region Employee Data Mapping
		public EmployeeService() { }

		private void MapObject(Employee oEmployee, DataReader oReader)
		{
			base.SetObjectID(oEmployee, oReader.GetInt32("EmployeeID").Value);
			oEmployee.EmployeeNo = oReader.GetString("EmployeeNo", string.Empty);
			oEmployee.Name = oReader.GetString("Name", string.Empty);
			oEmployee.Gender = oReader.GetString("Gender", string.Empty);
			oEmployee.Religion = oReader.GetString("Religion", string.Empty);
			oEmployee.BirthDate = oReader.GetDateTime("BirthDate", DateTime.MinValue);
			oEmployee.JoiningDate = oReader.GetDateTime("JoiningDate", DateTime.MinValue);
			oEmployee.Email = oReader.GetString("Email", string.Empty);
			oEmployee.MobileNo = oReader.GetString("MobileNo", string.Empty);
			oEmployee.IsConfirmed = oReader.GetBoolean("IsConfirmed", false);
			oEmployee.Status = (EnumStatus)oReader.GetInt32("Status", 1);
			oEmployee.AccountNo = oReader.GetString("AccountNo", string.Empty);
			oEmployee.Department = oReader.GetString("Department", string.Empty);
			oEmployee.MaritalStatus = oReader.GetString("MaritalStatus", string.Empty);
			oEmployee.Designation = oReader.GetString("Designation", string.Empty);
			oEmployee.Address = oReader.GetString("Address", string.Empty);
			oEmployee.BasicSalary = oReader.GetInt32("BasicSalary").Value;
			oEmployee.ChangePasswordAtNextLogon = oReader.GetInt32("ChangePasswordAtNextLogon",1);
			oEmployee.Password = oReader.GetString("Password");
			oEmployee.PasswordHints = oReader.GetString("PasswordHints",string.Empty);
			oEmployee.Salt = oReader.GetString("Salt");
			oEmployee.ForgetPasswordDate = oReader.GetDateTime("ForgetPasswordDate", DateTime.MinValue);
			oEmployee.LastChangedDate = oReader.GetDateTime("LastChangedDate", DateTime.MinValue);
			oEmployee.TempStatus = (EnumStatus)oReader.GetInt32("TempStatus", 1);
			oEmployee.TempStatusTime = oReader.GetDateTime("TempStatusTime", DateTime.MinValue);

			oEmployee.CreatedBy = oReader.GetInt32("CreatedBy", 0);
			oEmployee.CreatedDate = oReader.GetDateTime("CreatedDate", DateTime.MinValue);
			oEmployee.ModifiedBy = oReader.GetInt32("ModifiedBy", 0);
			oEmployee.ModifiedDate = oReader.GetDateTime("ModifiedDate", DateTime.MinValue);
			oEmployee.PasswordResetBy = oReader.GetInt32("PasswordResetBy", 0);
			oEmployee.PasswordResetDate = oReader.GetDateTime("PasswordResetDate", DateTime.MinValue);
			this.SetObjectState(oEmployee, Authentication.BO.ObjectState.Saved);
		}
		protected override T CreateObject<T>(DataReader oReader)
		{
			Employee oEmployee = new Employee();
			MapObject(oEmployee, oReader);
			return oEmployee as T;
		}
		protected Employee CreateObject(DataReader oReader)
		{
			Employee oEmployee = new Employee();
			MapObject(oEmployee, oReader);
			return oEmployee;
		}
		#endregion

		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region Service Implementation

		#region Get Employee By ID
		public Employee GetEmployee(int ID)
		{
			Employee oEmployee = new Employee();
			try
			{
				DataReader oreader = new DataReader(EmployeeDA.GetEmployee((int)ID));
				if (oreader.Read())
				{
					oEmployee = this.CreateObject<Employee>(oreader);
				}

			}
			catch (Exception e)
			{

			}
			return oEmployee;
		}
		#endregion

		#region Get Employee By EmpNo
		public Employee GetEmployee(string empNo)
		{
			Employee oEmployee = new Employee();
			try
			{
				DataReader oreader = new DataReader(EmployeeDA.GetEmployee(empNo));
				if (oreader.Read())
				{
					oEmployee = this.CreateObject<Employee>(oreader);
				}

			}
			catch (Exception e)
			{

			}
			return oEmployee;
		}
		#endregion

		#region Get All Employee
		public List<Employee> GetEmployees()
		{
			List<Employee> oEmployees = new List<Employee>();
			try
			{
				DataReader dr = new DataReader(EmployeeDA.Get());
				oEmployees = this.CreateObjects<Employee>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oEmployees;
		}

		public List<Employee> GetEmployees(EnumStatus status)
		{
			List<Employee> oEmployees = new List<Employee>();
			try
			{
				DataReader dr = new DataReader(EmployeeDA.Get(status));
				oEmployees = this.CreateObjects<Employee>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}
			return oEmployees;
		}
		#endregion

		#region Save Employee
		public string Save(Employee employee)
		{
			string employeeNo = string.Empty;
			Password password = new Password();
			try
			{
				if (employee.IsNew == true)
				{
					string randomPassword = password.GenerateRandomPassword();
					employee.Salt = password.CreateSalt(128);
					employee.Password = password.GenerateHash(randomPassword, employee.Salt);
					employeeNo = EmployeeDA.Insert(employee);
					if (!string.IsNullOrEmpty(employeeNo))
					{
						SendEmail sendEmail = new SendEmail();
						sendEmail.To = employee.Email;
						sendEmail.Subject = "Employee Login Password (Do not replay this mail)";
						sendEmail.Body = $@"<html><body><p><b>Dear</b> {employee.Name},</p>
								 <p><b>Your Employee ID : </b>{employeeNo}</p>
			                     <p><b>This is system generated password : </b>{randomPassword}</p>
			                     <p>Regards,</p>
			                     <p>Authentication Team</p></body></html>";
						sendEmail.SendigEmail(sendEmail);
					}
				}
				else
				{
					employeeNo = EmployeeDA.Update(employee);
				}
			}
			catch(Exception e)
			{

			}
			return employeeNo;
		}
		#endregion

		#region Save Employee
		public string SaveEmployeeBasicInfo(Employee employee)
		{
			string employeeNo = string.Empty;
			Password password = new Password();
			try
			{
				employeeNo = EmployeeDA.UpdateEmpBasicInfo(employee);
			}
			catch (Exception e)
			{

			}
			return employeeNo;
		}
		#endregion

		#region Delete Employee
		public string Delete(int ID)
		{
			string status = string.Empty;
			try
			{
				status = EmployeeDA.Delete(ID);
			}
			catch (Exception ex)
			{
				status = "Failed";
			}
			return status;
		}
		#endregion

		#region SearchEmployee
		public Employee SearchEmployee(string empNo, string empName)
		{
			Employee oEmployee = null;
			try
			{
				DataReader oreader = new DataReader(EmployeeDA.GetSearchEmpoyee(empNo,empName));
				if (oreader.Read())
				{
					oEmployee = this.CreateObject<Employee>(oreader);
				}
				
			}
			catch(Exception e)
			{

			}
			return oEmployee;
		}
		#endregion

		#region SearchRole In Grid
		public List<Employee> SearchEmployee(string searchText)
		{
			List<Employee> employees = new List<Employee>();
			try
			{
				DataReader dr = new DataReader(EmployeeDA.SearchEmployee(searchText));
				employees = this.CreateObjects<Employee>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{
				employees = null;
			}
			return employees;
		}

		public List<Employee> SearchEmployee(string searchText, EnumStatus status)
		{
			List<Employee> employees = new List<Employee>();
			try
			{
				DataReader dr = new DataReader(EmployeeDA.SearchEmployee(searchText, status));
				employees = this.CreateObjects<Employee>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{
				employees = null;
			}
			return employees;
		}
		#endregion

		#region SearchEmp 
		public Employee SearchEmp(string empNo, string empName, string searchText)
		{
			Employee oEmployee = null;
			try
			{
				DataReader oreader = new DataReader(EmployeeDA.SearchEmp(empNo, empName, searchText));
				if (oreader.Read())
				{
					oEmployee = this.CreateObject<Employee>(oreader);
				}

			}
			catch (Exception e)
			{

			}
			return oEmployee;
		}
		#endregion

		#region SearchRole In Grid
		public List<Employee> SearchEmp(string searchText)
		{
			List<Employee> employees = new List<Employee>();
			try
			{
				DataReader dr = new DataReader(EmployeeDA.SearchEmp(searchText));
				employees = this.CreateObjects<Employee>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{
				employees = null;
			}
			return employees;
		}
		#endregion

		#endregion

		#region Password Reset By Administrator
		public string PasswordResetByAdmin(Employee oEmployee)
		{
			Password password = new Password();
			string result = null;
			string randomPassword = null;
			if (oEmployee != null)
			{
				randomPassword = password.GenerateRandomPassword();
				oEmployee.Salt = password.CreateSalt(128);
				oEmployee.Password = password.GenerateHash(randomPassword, oEmployee.Salt);

				result = EmployeeDA.UpdatePasswordByAdmin(oEmployee);
				if (result == "Ok")
				{
					SendEmail sendEmail = new SendEmail();
					sendEmail.To = oEmployee.Email;
					sendEmail.Subject = "Admin Reset Password (Do not replay this mail)";
					sendEmail.Body = $@"<html><body><p><b>Dear</b> {oEmployee.Name},</p>
								 <p><b>An admin can reset your password.</p>
			                     <p><b>This is system generated password : </b>{randomPassword}</p>
								 <p><b>This password is valid within 24 hours. Please change your password now.</p>
			                     <p>Regards,</p>
			                     <p>Authentication Team</p></body></html>";
					sendEmail.SendigEmail(sendEmail);
				}
				else
				{
					result = "failed";
				}
			}
			return result;
		}
		#endregion

		#region UpdateEmployeeStatus
		public string UpdateUserStatus(int empID, EnumStatus status, int modifiedBy, DateTime modifiedDate)
		{
			string result = null;
			BO.Employee oEmployee = new BO.Employee();
			string statusString = "";
			try
			{
				if (status == EnumStatus.Active)
					statusString = "ACTIVE";
				if (status == EnumStatus.Inactive)
					statusString = "INACTIVE";
				if (status == EnumStatus.Locked)
					statusString = "LOCKED";
				if (status == EnumStatus.PasswordExpired)
					statusString = "Password Expired";

				if (empID != null)
				{
					result = EmployeeDA.UpdateEmployeeStatus(empID, status, modifiedBy, modifiedDate);

					oEmployee = this.GetEmployee(empID);
					if (result == "Ok")
					{
						SendEmail sendEmail = new SendEmail();
						sendEmail.To = oEmployee.Email;
						sendEmail.Subject = "User Profile Activation (Do not replay this mail)";
						sendEmail.Body = $@"<html><body><p><b>Dear</b> {oEmployee.Name},</p>
								 <p><b>An admin can {statusString} your profile</p>
			                     <p>Regards,</p>
			                     <p>Authentication Team</p></body></html>";
						sendEmail.SendigEmail(sendEmail);
					}
					else
					{
						result = "failed";
					}
				}
			}
			catch (Exception ex)
			{
				result = "Failed";
			}
			return result;
		}
		#endregion
	}
}
