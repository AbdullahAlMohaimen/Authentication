namespace Authentication.BO
{
	#region ObjectState
	public enum ObjectState
	{
		New, 
		Modified, 
		Saved
	}
	#endregion

	#region EnuSQL Syntax Enum
	public enum SQLSyntax
	{
		Access = 1,
		SQL,
		Oracle,
		Informix
	}
	#endregion

	#region Provider
	public enum Provider
	{
		Sql = 1, 
		OracleNative, 
		Oracle, 
		OleDb,
		Odbc
	}
	#endregion

	#region Action enumeration
	public enum ActionEnum : short
	{
		Insert = 1,
		Update = 2,
		Delete = 3
	}
	#endregion

	#region Date format Enum
	public enum FormatOptions : byte
	{
		ddMMyyyy = 1,
		MMddyyyy = 2,
		ddMMMyyyy = 3
	}
	#endregion


	public enum ColumnDataTypeEnum : byte
	{
		Fixed = 0,
		Boolean = 1,
		String = 2,
		Numeric = 3,
		DateTime = 4
	}
	public enum EnumStatus : short
	{
		Regardless = 0,
		Active = 1,
		Inactive = 2,
		Locked = 3
	}
	public enum EnumSystemType
	{
		Desktop = 1,
		Web = 2
	}
	public enum EnumMenuPermissionStatus
	{
		Approved = 1,
		Added = 2,
		Removed = 3
	}
	public enum EnumUserLogInMode
	{
		SuperUser = 1,
		Normal = 2,
		PowerUser = 3
	}
	public enum EnumGender
	{
		Male = 1,
		Female = 2,
		Other = 3
	}
}
