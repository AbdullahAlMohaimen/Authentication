using Authentication.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Model
{
	#region Framework: Service base
	public abstract class ServiceTemplate
	{
		private string _svcName;
		private string _endPoint;
		public ServiceTemplate(string svcName)
		{
			_svcName = svcName;
		}
		public ServiceTemplate()
		{
			_svcName = "";
		}
		public bool IsAlive
		{
			get { return true; }
		}
		public string ServiceName
		{
			get { return _svcName; }
			set { _svcName = value; }
		}
		internal void SetEndPoint(string value)
		{
			_endPoint = value;
		}

		protected string EndPoint
		{
			get { return _endPoint; }
		}

		protected void SetObjectID(ObjectTemplate ot, int id)
		{
			ot.SetID(id);
		}
		protected void SetObjectID(ObjectTemplate ot, long id)
		{
			ot.SetID((int)id);
		}
		protected void SetObjectState(ObjectTemplate ot, ObjectState state)
		{
			ot.SetState(state);
		}
		protected void SetObjectReadOnlyProperties(ObjectTemplate ot, params object[] propertyValues)
		{
			ot.SetReadOnlyProperties(propertyValues);
		}

		protected abstract T CreateObject<T>(DataReader dr)
			where T : ObjectTemplate;

		protected List<T> CreateObjects<T>(DataReader dr)
			where T : ObjectTemplate
		{
			List<T> list = new List<T>();

			while (dr.Read())
			{
				T ot = this.CreateObject<T>(dr);
				ot.SetState(ObjectState.Saved);
				list.Add(ot);
			}
			return list;
		}
	}
	#endregion
}
