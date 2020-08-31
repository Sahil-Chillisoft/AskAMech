CREATE TABLE Employee(
    EmployeeId int IDENTITY not NULL,
firstName VARCHAR (255),
 LastName VARCHAR (255),
 idNumber VARCHAR (13),
Email VARCHAR (255),
 IsRegisterdUser bit,
 DateCreated DateTime,
DateLastModified DateTime,
PRIMARY KEY (EmployeeId)
)