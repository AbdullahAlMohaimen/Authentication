drop database AuthenticationDB;
Create DataBase AuthenticationDB;
USE AuthenticationDB;


--HardPasswordSetup TABLE
Create Table HardPasswordSetup(
	PolicyID INT IDENTITY(1,1) not null PRIMARY KEY,
	PolicyNO AS ('P' + right('00' + cast(PolicyID AS VARCHAR(8)),8)) PERSISTED,
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
	Code AS ('R' + right('00' + cast(RoleID AS VARCHAR(15)),15)) PERSISTED,
	Name VARCHAR(200),
	Status INT,
	Description VARCHAR(255) null,
);

--Employee TABLE
Create Table Employee(
	EmployeeID INT IDENTITY(1,1) not null PRIMARY KEY,
	EmployeeNO AS ('E' + right('00' + cast(EmployeeID AS VARCHAR(15)),15)) PERSISTED,
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
	AuthorizedDate DATETIME null,
	Password VARCHAR(100),
	PasswordHints VARCHAR(100) null,
	Salt varchar(256),
	ForgetPasswordDate  DATETIME null,
	LastChangedDate DATETIME null,
	TempStatus int null,
	TempStatusTime DATETIME NULL,
	ChangePasswordAtNextLogon INT null,
	PasswordResetByAdmin BIT null,
);


--User TABLE
Create Table Users(
	UserID INT IDENTITY(1,1) not null PRIMARY KEY,
	LoginID VARCHAR(15) unique,
	UserName VARCHAR(100),
	Status INT,
	Email VARCHAR(100),
	RoleID INT NOT NULL FOREIGN KEY REFERENCES Role(RoleID),
	MasterID INT NOT NULL FOREIGN KEY REFERENCES Employee(EmployeeID),
	AuthorizedDate DATETIME null,
	Password VARCHAR(100),
	PasswordHints VARCHAR(100) null,
	Salt varchar(255),
	ForgetPasswordDate  DATETIME null,
	LastChangedDate DATETIME null,
	TempStatus int null,
	TempStatusTime DATETIME NULL,
	ChangePasswordAtNextLogon INT null,
	PasswordResetByAdmin BIT null,
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
	LoginID VARCHAR(100),
	UserName VARCHAR(200),
	Type VARCHAR(100),
	PCNumber VARCHAR(256),
	LoginTime DATETIME,
	LogoutTime DATETIME,
);


--BadLoginAttemptInfo TABLE
Create Table BadLoginAttemptInfo(
	AttemptID INT IDENTITY(1,1) not null PRIMARY KEY,
	LoginID VARCHAR(100),
	Type VARCHAR(100),
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



ALTER TABLE Users
ADD CreatedBy INT null;
ALTER TABLE Users
ADD CreatedDate DateTime null;
ALTER TABLE Users
ADD ModifiedBy INT null;
ALTER TABLE Users
ADD ModifiedDate DateTime null;
ALTER TABLE Users
ADD PasswordResetBy INT NULL;
ALTER TABLE Users
ADD PasswordResetDate DateTime NULL;


ALTER TABLE Employee
ADD CreatedBy INT null;
ALTER TABLE Employee
ADD CreatedDate DateTime null;
ALTER TABLE Employee
ADD ModifiedBy INT null;
ALTER TABLE Employee
ADD ModifiedDate DateTime null;
ALTER TABLE Employee
ADD PasswordResetBy INT NULL;
ALTER TABLE Employee
ADD PasswordResetDate DateTime NULL;

Alter table LoginInfo
add isLogout bit null; 

ALter table Users
add StatusChangedDate DateTime null;
Alter Table BadLoginAttemptInfo
Add UserID int not null;

Alter Table Employee
Add Address varchar(1000) null;

Alter Table Users
Add IsApprover Bit null;

ALTER TABLE Role
ADD CreatedBy INT null;
ALTER TABLE Role
ADD CreatedDate DateTime null;
ALTER TABLE Role
ADD ModifiedBy INT null;
ALTER TABLE Role
ADD ModifiedDate DateTime null;

ALter table Users
add UserNO varchar(25) null;

Alter table LoginInfo 
add UserID int null;

Alter Table Role
Add PasswordPolicyID int null;

Alter Table Role
Add PasswordPolicyNo int null;

-- USER PasswordHistory TABLE
Create Table PasswordResetHistory(
	PasswordResetID INT IDENTITY(1,1) not null PRIMARY KEY,
	LoginID varchar(15) not null,
	Type int not null,
	Password VARCHAR(100) not null,
	Salt VARCHAR(255) not null,
	PasswordResetBy varchar(255) not null,
	PasswordResetDate DATETIME not null,
	Reason varchar(1000) null
);