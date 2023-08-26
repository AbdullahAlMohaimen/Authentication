Create DataBase AuthenticationDB;
USE AuthenticationDB;


--HardPasswordSetup TABLE
Create Table HardPasswordSetup(
	PolicyID INT IDENTITY(1,1) not null PRIMARY KEY,
	PolicyNO AS ('P' + right('000' + cast(PolicyID AS VARCHAR(8)),8)) PERSISTED,
	MaxLength INT not null,
	MinLength INT not null,
	SuperuserPassMinLength INT not null,
	MinPasswordAge INT not null,
	ContainUppercase BIT, --1 active or TRUE, 0 inactive or FALSE
	ContainLowercase BIT,
	ContainSpecialCharacter BIT,
	ContainNumber BIT,
	ContainLetter BIT,
	UserPasswordSame BIT,
	PasswordExpireNotificationDays INT,
	PasswordExpireDays INT,
);


--ROLE Table
Create Table Role(
	RoleID INT	IDENTITY(1,1) not null PRIMARY KEY,
	Name VARCHAR(200),
	Code AS ('R' + right('000' + cast(RoleID AS VARCHAR(15)),15)) PERSISTED,
	PermissionCode VARCHAR(20),
	Status INT,
	RoleType INT,
	Description VARCHAR(255) null,
);

--Employee TABLE
Create Table Employee(
	EmployeeID INT IDENTITY(1,1) not null PRIMARY KEY,
	EmployeeNO AS ('E' + right('000' + cast(EmployeeID AS VARCHAR(15)),15)) PERSISTED,
	Name VARCHAR(256),
	Gender VARCHAR(15),
	Religion VARCHAR(20),
	BirthDate DATETIME,
	JoiningDate DATETIME,
	Email VARCHAR(100),
	MobileNO VARCHAR(20),
	IsConfirmed BIT null,
	Status INT,
	AccountNo VARCHAR(2500) null,
	Department VARCHAR(100),
	MaritalStatus VARCHAR(20) null,
	Designation VARCHAR(256),
	BasicSalary INT,
	ChangePasswordAtNextLogon INT null,
	Password VARCHAR(100),
	PasswordHints VARCHAR(100) null,
	Salt varchar(256),
	ForgetPasswordDate  DATETIME null,
	LastChangedDate DATETIME null,
	TempStatus int null,
	TempStatusTime DATETIME NULL
);


--User TABLE
Create Table Users(
	UserID INT IDENTITY(1,1) not null PRIMARY KEY,
	LoginID VARCHAR(15) unique,
	UserName VARCHAR(100),
	UserType VARCHAR(100),
	Status INT,
	Email VARCHAR(100),
	OwnerID INT,
	RoleID INT NOT NULL FOREIGN KEY REFERENCES Role(RoleID),
	MasterID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID),
	AuthorizedDate DATETIME null,
	ChangePasswordAtNextLogon INT null,
	Password VARCHAR(100),
	PasswordHints VARCHAR(100) null,
	Salt varchar(255),
	ForgetPasswordDate  DATETIME null,
	LastChangedDate DATETIME null,
	TempStatus int null,
	TempStatusTime DATETIME NULL
);


--Employee PasswordHistory TABLE
Create Table EmployeePasswordHistory(
	EPHID INT IDENTITY(1,1) not null PRIMARY KEY,
	EmployeeID INT not null FOREIGN KEY REFERENCES Employee(EmployeeID),
	UserPassword VARCHAR(100),
	Salt VARCHAR(255),
	EntryDate DATETIME,
);


-- USER PasswordHistory TABLE
Create Table UserPasswordHistory(
	UPHID INT IDENTITY(1,1) not null PRIMARY KEY,
	UserID INT not null FOREIGN KEY REFERENCES Users(UserID),
	UserPassword VARCHAR(100),
	Salt VARCHAR(255),
	EntryDate DATETIME,
);


--LoginInfo TABLE
Create Table LoginInfo(
	LoginInfoID INT IDENTITY(1,1) not null PRIMARY KEY,
	UserID INT not null FOREIGN KEY REFERENCES Users(UserID),
	PCNumber VARCHAR(256),
	LoginTime DATETIME,
	LogoutTime DATETIME,
);


--BadLoginAttemptInfo TABLE
Create Table BadLoginAttemptInfo(
	AttemptID INT IDENTITY(1,1) not null PRIMARY KEY,
	UserID INT not null FOREIGN KEY REFERENCES Users(UserID),
	AttemptTime DATETIME,
	PCNumber VARCHAR(256)
);

select * from HardPasswordSetup;
select * from Employee;
select * from Users;
select * from EmployeePasswordHistory;
select * from UserPasswordHistory;
select * from LoginInfo;
select * from Role;
select * from BadLoginAttemptInfo;


