using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Authentication.BO.Global;

namespace Authentication.BO
{

	#region Framwwork: Event delegate
	public delegate void ObjectIDChanged(long newID);
	#endregion

	public abstract class ObjectTemplate
	{
		private int _sortOrder;
		protected ObjectState _objectState;
		protected int _id = int.MinValue;

		public ObjectTemplate()
		{
			_objectState = ObjectState.New;
		}

		public int ID
		{
			get { return _id; } set { _id = value;}
		}

		public bool IsNew
		{
			get { return _objectState == ObjectState.New; }
			set
			{
				if (value == false)
				{
					_objectState = ObjectState.Modified;
				}
				else
				{
					_objectState = ObjectState.New;
				}
			}
		}

		//public bool IsModified
		//{
		//	get { return _objectState == ObjectState.Modified; }
		//}

		public int SortOrder
		{
			get { return _sortOrder; }
			set { _sortOrder = value; }
		}

		protected void SetObjectStateModified()
		{
			//if (_objectState == ObjectState.Saved)
			//    _objectState = ObjectState.Modified;
			_objectState = ObjectState.Modified;
		}

		public void SetID(int id)
		{
			_id = id;

			//if (IDChanged != null)
			//    IDChanged(_id);
		}

		public void SetState(ObjectState state)
		{
			_objectState = state;
		}

		public virtual void SetReadOnlyProperties(params object[] propertyValues)
		{
		}

		public override string ToString()
		{
			return GetType().Name + " (" + _id.ToString() + ")";
		}

		public override bool Equals(object obj)
		{
			if (obj == null || (obj.GetType() != this.GetType()))
				return false;

			return _id.Equals((obj as ObjectTemplate)._id);
		}

		public override int GetHashCode()
		{
			if ((object)_id == null)
				return base.GetHashCode();
			else
				return _id.GetHashCode();
		}

		public static bool operator ==(ObjectTemplate template1, ObjectTemplate template2)
		{
			if ((object)template1 != null)
				return template1.Equals(template2);
			else
				return ((object)template2 == null);
		}

		public static bool operator !=(ObjectTemplate template1, ObjectTemplate template2)
		{
			if ((object)template1 != null)
				return !template1.Equals(template2);
			else
				return !((object)template2 == null);
		}
	}
}
