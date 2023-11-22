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

		#region Get Employee By ID
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
		#endregion

		#region Save Employee
		public string Save(Employee employee)
		{
			string employeeNo = string.Empty;
			Password password = new Password();
			string randomPassword = password.GenerateRandomPassword();
			employee.Salt = password.CreateSalt(128);
			employee.Password = password.GenerateHash(randomPassword,employee.Salt);
			try
			{
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
			catch(Exception e)
			{

			}
			return employeeNo;
		}
		#endregion

		#region Delete Employee
		public void Delete(int ID)
		{

		}
		#endregion

		#region SearchEmployee Employee
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

		#endregion
	}
}
