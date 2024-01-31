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
		None = -1,
		Regardless = 0,
		Active = 1,
		Inactive = 2,
		Locked = 3,
		PasswordExpired = 4,
	}

	public enum EnumLogoutType : short
	{
		NotInitiate = 0,
		Administrator = 1,
		Manager_Or_Supervisor = 2,
		Employee = 3,
		Guest = 4,
		SuperUser = 5,
		Moderator = 6,
		Content_Creator = 7,
		Salesperson = 8,
		Finance_Accounting = 9,
		Human_Resources = 10,
		Marketing = 11,
		Developer_Or_Programmer = 12,
		QA_Analyst = 13,
		Security_Officer = 14,
		Compliance_Officer = 15,
		Auditor = 16,
		Vendor_Supplier = 17,
		Supervisor = 18,
		Password_Manager = 19,
	}


	public enum EnumAdministrator
	{
		User = 1,
		Employee = 2,
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
