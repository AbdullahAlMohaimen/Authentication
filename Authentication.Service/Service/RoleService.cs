using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Data;
using Authentication.BO;
using Authentication.Service.Model;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Authentication.Service
{
	[Serializable]
	public class RoleService : ServiceTemplate, IRoleService
	{
		#region Employee Data Mapping
		public RoleService() { }

		private void MapObject(Role oRole, DataReader oReader)
		{
			base.SetObjectID(oRole, oReader.GetInt32("RoleID").Value);
			oRole.Code = oReader.GetString("Code", string.Empty);
			oRole.Name = oReader.GetString("Name", string.Empty);
			oRole.Status = (EnumStatus)oReader.GetInt32("Status", 1);
			oRole.Description = oReader.GetString("Description", string.Empty);
			this.SetObjectState(oRole, Authentication.BO.ObjectState.Saved);
		}
		protected override T CreateObject<T>(DataReader oReader)
		{
			Role oRole = new Role();
			MapObject(oRole, oReader);
			return oRole as T;
		}

		protected Role CreateObject(DataReader oReader)
		{
			Role oRole = new Role();
			MapObject(oRole, oReader);
			return oRole;
		}
		#endregion

		#region  DB Connection
		string connectionString = "Data Source=DESKTOP-3K3POSS\\SQLEXPRESS;Initial Catalog=AuthenticationDB;Persist Security Info=True;User ID=sa;Password=123456";
		#endregion

		#region  Service Implementation

		#region  Save()
		public string Save(Role role)
		{	
			RoleDA roleDA = new RoleDA();
			string status = string.Empty;
			try
			{
				status = RoleDA.Insert(role);
			}
			catch(Exception ex){
				status = "Failed";
			}
			return status;
		}
		#endregion

		#region  GetRole()
		public List<Role> GetRole()
		{
			List<Role> roles = new List<Role>();
			try
			{
				DataReader dr = new DataReader(RoleDA.Get());
				roles = this.CreateObjects<Role>(dr);
				dr.Close();
			}
			catch(Exception ex)
			{

			}

			return roles;
		}
		#endregion

		#region GetRoleByID()
		public Role GetRoleByID(int ID)
		{
			Role role = new Role();
			return role; ;
		}
		#endregion

		#region Delete
		public void Delete(int RoleID)
		{

		}
		#endregion

		#endregion

		#region  Code AutoGenerate
		public string GetCode()
		{
			RoleDA roleDA = new RoleDA();
			string roleCode;
			int roleID = roleDA.GetCode();
			if (roleID != 0)
				roleCode = "R00" + (roleID+1).ToString();
			else
				roleCode = "R00" + 1;
			return roleCode;
		}
		#endregion
	}
}
