CREATE TABLE Users(
User_Id int IDENTITY NOT NULL,
Email VARCHAR (255) NOT NULL,
Password VARCHAR (255) NOT NULL,
userRole VARCHAR(255) NOT NULL, 
EmployeeId INTEGER NOT NULL REFERENCES Employee(EmployeeId),
DateLastLoggedIn DATETIME,
DateCreated DateTime,
Datelastmodified DateTime,
PRIMARY KEY (User_Id)
);