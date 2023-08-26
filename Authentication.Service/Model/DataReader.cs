using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Service.Model
{
	#region DataAccess: Data Handler
	public class DataReader
	{
		private DataTable _table;
		private IDataReader _reader;
		public DataReader(IDataReader reader)
		{
			_reader = reader;
			_table = _reader.GetSchemaTable();
		}

		#region Get Null value
		public static bool? GetNullValue(bool value, bool nullIfValue)
		{
			return (value == nullIfValue) ? null : (bool?)value;
		}
		public static byte? GetNullValue(byte value, byte nullIfValue)
		{
			return (value == nullIfValue) ? null : (byte?)value;
		}
		public static sbyte? GetNullValue(sbyte value, sbyte nullIfValue)
		{
			return (value == nullIfValue) ? null : (sbyte?)value;
		}
		public static short? GetNullValue(short value, short nullIfValue)
		{
			return (value == nullIfValue) ? null : (short?)value;
		}
		public static ushort? GetNullValue(ushort value, ushort nullIfValue)
		{
			return (value == nullIfValue) ? null : (ushort?)value;
		}
		public static int? GetNullValue(int value, int nullIfValue)
		{
			return (value == nullIfValue) ? null : (int?)value;
		}
		public static uint? GetNullValue(uint value, uint nullIfValue)
		{
			return (value == nullIfValue) ? null : (uint?)value;
		}
		public static ulong? GetNullValue(ulong value, ulong nullIfValue)
		{
			return (value == nullIfValue) ? null : (ulong?)value;
		}
		public static long? GetNullValue(long value, long nullIfValue)
		{
			return (value == nullIfValue) ? null : (long?)value;
		}
		public static decimal? GetNullValue(decimal value, decimal nullIfValue)
		{
			return (value == nullIfValue) ? null : (byte?)value;
		}
		public static double? GetNullValue(double value, double nullIfValue)
		{
			return (value == nullIfValue) ? null : (byte?)value;
		}
		public static float? GetNullValue(float value, float nullIfValue)
		{
			return (value == nullIfValue) ? null : (float?)value;
		}
		public static char? GetNullValue(char value, char nullIfValue)
		{
			return (value == nullIfValue) ? null : (char?)value;
		}
		public static object GetNullValue(string value, string nullIfValue)
		{
			return (value == nullIfValue) ? null : value;
		}
		public static DateTime? GetNullValue(DateTime value, DateTime nullIfValue)
		{
			return (value == nullIfValue) ? null : (DateTime?)value;
		}
		public static Guid? GetNullValue(Guid value, Guid nullIfValue)
		{
			return (value == nullIfValue) ? null : (Guid?)value;
		}

		public static bool? GetNullValue(bool? value)
		{
			return (value == null || value == false) ? null : (bool?)value;
		}
		public static byte? GetNullValue(byte? value)
		{
			return (value == null || value == 0) ? null : (byte?)value;
		}
		public static sbyte? GetNullValue(sbyte? value)
		{
			return (value == null || value == 0) ? null : (sbyte?)value;
		}
		public static short? GetNullValue(short? value)
		{
			return (value == null || value == 0) ? null : (short?)value;
		}
		public static ushort? GetNullValue(ushort? value)
		{
			return (value == null || value == 0) ? null : (ushort?)value;
		}
		public static int? GetNullValue(int? value)
		{
			return (value == null || value == 0) ? null : (int?)value;
		}
		public static uint? GetNullValue(uint? value)
		{
			return (value == null || value == 0) ? null : (uint?)value;
		}
		public static ulong? GetNullValue(ulong? value)
		{
			return (value == null || value == 0) ? null : (ulong?)value;
		}
		public static long? GetNullValue(long? value)
		{
			return (value == null || value == 0) ? null : (long?)value;
		}
		public static decimal? GetNullValue(decimal? value)
		{
			return (value == null || value == 0) ? null : (decimal?)value;
		}
		public static double? GetNullValue(double? value)
		{
			return (value == null || value == 0) ? null : (double?)value;
		}
		public static float? GetNullValue(float? value)
		{
			return (value == null || value == 0) ? null : (float?)value;
		}
		public static char? GetNullValue(char? value)
		{
			return (value == null || (byte)value == 0) ? null : (char?)value;
		}
		public static string GetNullValue(string value)
		{
			return (string.IsNullOrEmpty(value)) ? null : value;
		}
		public static DateTime? GetNullValue(DateTime? value)
		{
			return (value == null || value == DateTime.MinValue) ? null : (DateTime?)value;
		}
		public static Guid? GetNullValue(Guid? value)
		{
			return value;
		}
		#endregion

		#region Default Null Values
		public bool? GetBoolean(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (bool?)value.ToBoolean(null);
		}
		public byte? GetByte(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (byte?)value.ToByte(null);
		}
		public sbyte? GetSByte(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (sbyte?)value.ToSByte(null);
		}
		public short? GetInt16(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (short?)value.ToInt16(null);
		}
		public ushort? GetUInt16(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (ushort?)value.ToUInt16(null);
		}
		public int? GetInt32(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (int?)value.ToInt32(null);
		}
		public uint? GetUInt32(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (uint?)value.ToUInt32(null);
		}
		public long? GetInt64(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (long?)value.ToInt64(null);
		}
		public ulong? GetUInt64(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (ulong?)value.ToUInt64(null);
		}
		public decimal? GetDecimal(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (decimal?)value.ToDecimal(null);
		}
		public double? GetDouble(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (double?)value.ToDouble(null);
		}
		public float? GetFloat(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (float?)value.ToSingle(null);
		}
		public char? GetChar(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (char?)value.ToChar(null);
		}
		public string GetString(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : value.ToString(null);
		}
		public DateTime? GetDateTime(int i)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? null : (DateTime?)value.ToDateTime(null);
		}
		public TimeSpan? GetTime(int i)
		{
			object value = _reader.GetValue(i);
			return value == DBNull.Value ? null : (TimeSpan?)((TimeSpan)value);
		}
		public Guid? GetGuid(int i)
		{
			object value = _reader.GetValue(i);
			return value == DBNull.Value ? null : (Guid?)value;
		}
		public byte[] GetLob(int i)
		{
			return (byte[])(_reader.IsDBNull(i) ? (byte[])null : _reader.GetValue(i));
		}

		public bool? GetBoolean(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (bool?)value.ToBoolean(null);
		}
		public byte? GetByte(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (byte?)value.ToByte(null);
		}
		public sbyte? GetSByte(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (sbyte?)value.ToSByte(null);
		}
		public short? GetInt16(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (short?)value.ToInt16(null);
		}
		public ushort? GetUInt16(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (ushort?)value.ToUInt16(null);
		}
		public int? GetInt32(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? (int?)null : (int?)value.ToInt32(null);
		}
		public uint? GetUInt32(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (uint?)value.ToUInt32(null);
		}
		public long? GetInt64(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (long?)value.ToInt64(null);
		}
		public ulong? GetUInt64(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (ulong?)value.ToUInt64(null);
		}
		public decimal? GetDecimal(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (decimal?)value.ToDecimal(null);
		}
		public double? GetDouble(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (double?)value.ToDouble(null);
		}
		public float? GetFloat(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (float?)value.ToSingle(null);
		}
		public char? GetChar(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (char?)value.ToChar(null);
		}
		public string GetString(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : value.ToString(null);
		}
		public DateTime? GetDateTime(string name)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? null : (DateTime?)value.ToDateTime(null);
		}
		public TimeSpan? GetTime(string name)
		{
			object value = _reader[name];
			return value == DBNull.Value ? null : (TimeSpan?)((TimeSpan)value);
		}
		public Guid? GetGuid(string name)
		{
			object value = _reader[name];
			return value == DBNull.Value ? null : (Guid?)value;
		}
		public byte[] GetLob(string name)
		{
			return (byte[])(_reader[name] == DBNull.Value ? (byte[])null : _reader[name]);
		}
		#endregion

		#region Parameterized Null Value
		bool columnExists(string columnName)
		{
			columnName = (from DataRow dr in _table.Rows
						  where Convert.ToString(dr["ColumnName"]).ToLower().Equals(columnName.ToLower())
						  select Convert.ToString(dr["ColumnName"])).FirstOrDefault();

			return !string.IsNullOrEmpty(columnName);
		}

		public bool GetBoolean(int i, bool valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToBoolean(null);
		}
		public byte GetByte(int i, byte valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToByte(null);
		}
		public sbyte GetSByte(int i, sbyte valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToSByte(null);
		}
		public short GetInt16(int i, short valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToInt16(null);
		}
		public ushort GetUInt16(int i, ushort valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToUInt16(null);
		}
		public int GetInt32(int i, int valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToInt32(null);
		}
		public uint GetUInt32(int i, uint valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToUInt32(null);
		}
		public ulong GetUInt64(int i, ulong valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToUInt64(null);
		}
		public long GetInt64(int i, long valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToInt64(null);
		}
		public decimal GetDecimal(int i, decimal valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToDecimal(null);
		}
		public double GetDouble(int i, double valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToDouble(null);
		}
		public float GetFloat(int i, float valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToSingle(null);
		}
		public char GetChar(int i, char valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToChar(null);
		}
		public string GetString(int i, string valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToString(null);
		}
		public DateTime GetDateTime(int i, DateTime valueIfNull)
		{
			IConvertible value = (IConvertible)_reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : value.ToDateTime(null);
		}
		public TimeSpan GetTime(int i, TimeSpan valueIfNull)
		{
			object value = _reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : (TimeSpan)value;
		}
		public Guid GetGuid(int i, Guid valueIfNull)
		{
			object value = _reader.GetValue(i);
			return value == DBNull.Value ? valueIfNull : (Guid)value;
		}

		public bool GetBoolean(string name, bool valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToBoolean(null);
		}
		public byte GetByte(string name, byte valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToByte(null);
		}
		public sbyte GetSByte(string name, sbyte valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToSByte(null);
		}
		public short GetInt16(string name, short valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToInt16(null);
		}
		public ushort GetUInt16(string name, ushort valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToUInt16(null);
		}
		public int GetInt32(string name, int valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToInt32(null);
		}

		public uint GetUInt32(string name, uint valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToUInt32(null);
		}
		public ulong GetUInt64(string name, ulong valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToUInt64(null);
		}
		public long GetInt64(string name, long valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToInt64(null);
		}
		public decimal GetDecimal(string name, decimal valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToDecimal(null);
		}
		public double GetDouble(string name, double valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToDouble(null);
		}
		public float GetFloat(string name, float valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToSingle(null);
		}
		public char GetChar(string name, char valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToChar(null);
		}
		public string GetString(string name, string valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToString(null);
		}
		public DateTime GetDateTime(string name, DateTime valueIfNull)
		{
			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNull : value.ToDateTime(null);
		}
		public TimeSpan GetTime(string name, TimeSpan valueIfNull)
		{
			object value = _reader[name];
			return value == DBNull.Value ? valueIfNull : (TimeSpan)value;
		}
		public Guid GetGuid(string name, Guid valueIfNull)
		{
			object value = _reader[name];
			return value == DBNull.Value ? valueIfNull : (Guid)value;
		}

		public bool GetBoolean(string name, bool fldExists, bool valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			if (value == null || value == DBNull.Value)
				return valueIfNullOrFldNotExists;

			if (value.ToString().Trim().Equals("1") || value.ToString().Trim().Equals("-1") || value.ToString().Trim().ToLower().Equals("true") || value.ToString().Trim().ToLower().Equals("yes"))
				return true;
			else if (value.ToString().Trim().Equals("0") || value.ToString().Trim().ToLower().Equals("false") || value.ToString().Trim().ToLower().Equals("no"))
				return false;
			else
				return value.ToBoolean(null);
		}
		public byte GetByte(string name, bool fldExists, byte valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToByte(null);
		}
		public sbyte GetSByte(string name, bool fldExists, sbyte valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToSByte(null);
		}
		public short GetInt16(string name, bool fldExists, short valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToInt16(null);
		}
		public ushort GetUInt16(string name, bool fldExists, ushort valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToUInt16(null);
		}
		public int GetInt32(string name, bool fldExists, int valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToInt32(null);
		}
		public uint GetUInt32(string name, bool fldExists, uint valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToUInt32(null);
		}
		public ulong GetUInt64(string name, bool fldExists, ulong valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToUInt64(null);
		}
		public long GetInt64(string name, bool fldExists, long valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToInt64(null);
		}
		public decimal GetDecimal(string name, bool fldExists, decimal valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToDecimal(null);
		}
		public double GetDouble(string name, bool fldExists, double valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToDouble(null);
		}
		public float GetFloat(string name, bool fldExists, float valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToSingle(null);
		}
		public char GetChar(string name, bool fldExists, char valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToChar(null);
		}
		public string GetString(string name, bool fldExists, string valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToString(null);
		}
		public DateTime GetDateTime(string name, bool fldExists, DateTime valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			IConvertible value = (IConvertible)_reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : value.ToDateTime(null);
		}

		public TimeSpan GetTime(string name, bool fldExists, TimeSpan valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			object value = _reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : (TimeSpan)value;
		}

		public Guid GetGuid(string name, bool fldExists, Guid valueIfNullOrFldNotExists)
		{
			if (fldExists && _table != null && !this.columnExists(name))
				return valueIfNullOrFldNotExists;

			object value = _reader[name];
			return value == DBNull.Value ? valueIfNullOrFldNotExists : (Guid)value;
		}
		#endregion

		public bool Read()
		{
			return _reader.Read();
		}

		public void Close()
		{
			_reader.Close();
			_reader.Dispose();
			_table.Dispose();

			_table = null;
			_reader = null;
		}
	}
	#endregion
}
