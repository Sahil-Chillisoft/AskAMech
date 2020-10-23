use master 
go 

if not exists (select name from master.dbo.sysdatabases where name = N'AskAMech')
create database AskAMech 
go 

use AskAMech
go 

create table Roles 
(
	Id int not null primary key identity(1,1),
	Description varchar(100) not null
)

create table Employee
(
	Id int not null primary key identity(100000,1),
	FirstName varchar(50) not null,
	LastName varchar(50) not null,
	IdNumber varchar(50) not null unique,
	Email varchar(100) not null unique,
	IsRegisterdUser bit not null default 0,
	CreatedByUserId int not null, 
	DateCreated DateTime not null default getdate(),
	LastModifiedByUserId int not null, 
	DateLastModified DateTime not null, 
	IsActive bit not null default 1 
)

create table Users
(
	Id int not null primary key identity(1000,1),
	Email varchar(100) not null unique,
	Password varchar(100) not null,
	UserRoleId int not null, 
	EmployeeId int null,
	DateLastLoggedIn datetime null,
	DateCreated datetime not null default getdate(),
	DateLastModified datetime not null, 
	DateDeleted datetime null
)

create table UserProfile
(
	Id int not null primary key identity(1,1),
	UserId int not null, 
	Username varchar(50) not null unique,
	About varchar(500) null, 
	DateLastModified datetime not null
)

create table Category 
(
	Id int not null primary key identity(1,1),
	Description varchar(100) not null
)

create table Questions
(
	Id int not null primary key identity(1,1),
	Title varchar(100) not null,
	Description varchar(500) not null,
	CategoryId int not null,
	CreatedByUserId int not null,
	DateCreated DateTime not null default getdate(),
	DateLastModified DateTime not null, 
	DateDeleted datetime null
)

create table Answers
(
	Id int not null primary key identity(1,1),
	QuestionId int not null,
	Description varchar(500) not null,
	AnsweredByUserId int not null,
	IsAcceptedAnswer bit null,
	DateCreated DateTime not null default getdate()
)


--Foreign Key Constraints
alter table Employee 
add constraint FK_User_CreatedByUserId foreign key (CreatedByUserId) references Users(Id)
alter table Employee
add constraint FK_Employee_LastModifiedByUserId foreign key (LastModifiedByUserId) references Users(Id)

alter table Users 
add constraint FK_Users_RoleId foreign key (UserRoleId) references Roles(Id)
alter table Users 
add constraint FK_Users_EmployeeId foreign key (EmployeeId) references Employee(Id)

alter table UserProfile
add constraint FK_UsersProfile_UserId foreign key (UserId) references Users(Id)

alter table Questions
add constraint FK_Questions_CategoryId foreign key (CategoryId) references Category(Id)
alter table Questions
add constraint FK_Questions_CreatedByUserId foreign key (CreatedByUserId) references Users(Id)

alter table Answers
add constraint FK_Answers_QuestionId foreign key (QuestionId) references Questions(Id)
alter table Answers
add constraint FK_Answers_AnsweredByUserId foreign key (AnsweredByUserId) references Users(Id)

