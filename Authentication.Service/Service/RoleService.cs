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
		#region Role Data Mapping
		public RoleService() { }

		private void MapObject(Role oRole, DataReader oReader)
		{
			base.SetObjectID(oRole, oReader.GetInt32("RoleID").Value);
			oRole.Code = oReader.GetString("Code", string.Empty);
			oRole.Name = oReader.GetString("Name", string.Empty);
			oRole.Status = (EnumStatus)oReader.GetInt32("Status", 1);
			oRole.Description = oReader.GetString("Description", string.Empty);

			oRole.CreatedBy = oReader.GetInt32("CreatedBy", 0);
			oRole.CreatedDate = oReader.GetDateTime("CreatedDate");
			oRole.ModifiedBy = oReader.GetInt32("ModifiedBy", 0);
			oRole.ModifiedDate = oReader.GetDateTime("ModifiedDate");
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
				if(role.IsNew == true)
				{
					status = RoleDA.Insert(role);
				}
				else
				{
					status = RoleDA.Update(role);
				}
			}
			catch(Exception ex){
				status = "Failed";
			}
			return status;
		}
		#endregion

		#region  GetAllRole()
		public List<Role> GetAllRole()
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

		#region  GetRole()
		public List<Role> GetAllRole(EnumStatus status)
		{
			List<Role> roles = new List<Role>();
			try
			{
				DataReader dr = new DataReader(RoleDA.Get(status));
				roles = this.CreateObjects<Role>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{

			}

			return roles;
		}
		#endregion

		#region GetRoleByID()
		public Role GetRoleByID(int ID)
		{
			Role role = new Role();
			try
			{
				DataReader oreader = new DataReader(RoleDA.Get(ID));
				if (oreader.Read())
				{
					role = this.CreateObject<Role>(oreader);
				}
				else
				{
					role = null;
				}
			}
			catch (Exception ex)
			{
				role = null;
			}
			return role;
		}
		#endregion

		#region Delete
		public string Delete(int RoleID)
		{
			string status = string.Empty;
			try
			{
				status = RoleDA.Delete(RoleID);
			}
			catch (Exception ex)
			{
				status = "Failed";
			}
			return status;
		}
		#endregion

		#endregion

		#region SearchRole
		public List<Role> SearchRole(string searchText)
		{
			List<Role> roles = new List<Role>();
			try
			{
				DataReader dr = new DataReader(RoleDA.SearchRole(searchText));
				roles = this.CreateObjects<Role>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{
				roles = null;
			}
			return roles;
		}

		public List<Role> SearchRole(string searchText, EnumStatus status)
		{
			List<Role> roles = new List<Role>();
			try
			{
				DataReader dr = new DataReader(RoleDA.SearchRole(searchText, status));
				roles = this.CreateObjects<Role>(dr);
				dr.Close();
			}
			catch (Exception ex)
			{
				roles = null;
			}
			return roles;
		}
		#endregion

		#region GetRoleByCode()
		public Role GetRoleByCode(string code)
		{
			Role role = new Role();
			try
			{
				DataReader oreader = new DataReader(RoleDA.GetByCode(code));
				if (oreader.Read())
				{
					role = this.CreateObject<Role>(oreader);
				}
				else
				{
					role = null;
				}
			}
			catch (Exception ex)
			{
				role = null;
			}
			return role;
		}
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
