using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.BO;
using System.Web.Caching;
using System.Data;

namespace Authentication.BO
{
	#region Employee
	[Serializable]
	public class Role : BasicBaseObject
	{
		#region constructor
		public Role()
		{
			_status = EnumStatus.Active;
			_description = String.Empty;
		}
		#endregion

		#region properties

		#region Name : String 
		public string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}
		#endregion

		#region Code : String 
		public string _code;
		public string Code
		{
			get { return _code; }
			set { _code = value; }
		}
		#endregion

		#region Status : EnumStatus 
		public EnumStatus _status;
		public EnumStatus Status
		{
			get { return _status; }
			set { _status = value; }
		}
		#endregion

		#region Description : String 
		public string _description;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}
		#endregion

		#endregion
	}
	#endregion

	#region IEmployee Service
	public interface IRoleService
	{
		Role GetRoleByID(int ID);
		List<Role> GetAllRole();
		string Save(Role employee);
		void Delete(int ID);
	}
	#endregion
}
