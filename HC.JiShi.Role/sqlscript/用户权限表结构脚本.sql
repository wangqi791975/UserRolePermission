CREATE TABLE [User] (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	UserName NVARCHAR(20) NOT NULL,
	[Password] VARCHAR(32) NOT NULL,
	IsAdmin BIT NOT NULL DEFAULT(0),
	IsValid BIT NOT NULL DEFAULT(1),
	CreateDate DATETIME DEFAULT(GETDATE())	
) 

CREATE TABLE [Role] (
	Id INT IDENTITY(1,1) PRIMARY KEY,
	RoleName NVARCHAR(20) NOT NULL,
	IsAdmin BIT NOT NULL DEFAULT(0),
	IsValid BIT NOT NULL DEFAULT(1),
	CreateDate DATETIME DEFAULT(GETDATE())
)

CREATE TABLE UserRole(
	Id INT IDENTITY(1,1) PRIMARY KEY ,
	RoleId INT NOT NULL,
	UserId INT NOT NULL
)

CREATE TABLE Page(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	PageName NVARCHAR(50) NOT NULL,
	Url VARCHAR(512) NOT NULL,
	Domain VARCHAR(50) NULL	
)

CREATE TABLE PageAction(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	PageId INT NOT NULL,
	ActionName NVARCHAR(50) NOT NULL,
	ActionUrl VARCHAR(512) NOT NULL
)

CREATE TABLE PermissionPage(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	[Type] INT NOT NULL,					--权限类型 1：表示UserRoleId是RoleId  2：表示UserRoleId是UserId
	UserRoleId INT NOT NULL,
	PageId INT NOT NULL
)

CREATE Table PermissionPageAction(
	Id INT IDENTITY(1,1) PRIMARY KEY ,
	[Type] INT NOT NULL,					--权限类型 1：表示UserRoleId是RoleId  2：表示UserRoleId是UserId
	UserRoleId INT NOT NULL,
	PageActionId INT NOT NULL
)

SELECT u.Id UserId,p.Id PageId,PageName,Url,Domain 
FROM [User] u 
INNER JOIN PermissionPage pp ON u.Id = pp.UserRoleId AND Type = 2 
INNER JOIN Page p ON pp.PageId = p.Id

SELECT u.Id UserId, pa.Id PageActionId,pa.PageId ,pa.ActionName ,pa.ActionUrl 
FROM [User] u
INNER JOIN PermissionPageAction ppa ON u.Id = ppa.UserRoleId AND Type = 2
INNER JOIN PageAction pa ON ppa.PageActionId = pa.Id

SELECT r.Id RoleId,p.Id PageId,PageName,Url,Domain 
FROM [Role] r
INNER JOIN PermissionPage pp ON r.Id = pp.UserRoleId AND Type = 1
INNER JOIN Page p ON pp.PageId = p.Id

SELECT r.Id RoleId, pa.Id PageActionId,pa.PageId ,pa.ActionName ,pa.ActionUrl 
FROM [Role] r
INNER JOIN PermissionPageAction ppa ON r.Id = ppa.UserRoleId AND Type = 1
INNER JOIN PageAction pa ON ppa.PageActionId = pa.Id

