using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Authentication.BO
{
	public abstract class BasicBaseObject : ObjectTemplate
	{
		protected int _sequence;
		protected EnumStatus _status;
		protected int _returnStatus;

		protected long _createdBy = 0;
		protected long? _modifiedBy = null;
		protected DateTime _createdDate;
		protected DateTime? _modifiedDate;
		protected BasicBaseObject() { }

		public long CreatedBy
		{
			get { return this._createdBy; }
			set
			{
				if (this._createdBy != value)
				{
					this._createdBy = value;
				}
			}
		}
		public DateTime CreatedDate
		{
			get { return this._createdDate; }
			set
			{
				if ((this._createdDate != value))
					this._createdDate = value;
			}
		}
		public long? ModifiedBy
		{
			get { return this._modifiedBy; }
			set
			{
				if (this._modifiedBy != value)
					this._modifiedBy = value;
			}
		}
		public DateTime? ModifiedDate
		{
			get { return this._modifiedDate; }
			set
			{
				if (this._modifiedDate != value)
					this._modifiedDate = value;
			}
		}
		public EnumStatus Status
		{
			get { return this._status; }
			set
			{
				if ((this._status != value))
					this._status = value;
			}
		}
	}
}
