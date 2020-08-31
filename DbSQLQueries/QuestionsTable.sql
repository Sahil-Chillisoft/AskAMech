CREATE TABLE Questions(
    QuestionId int IDENTITY NOT NULL,
 Descriptions VARCHAR (255),
 Catergoryid INTEGER NOT NULL REFERENCES Catergory(Catergoryid),
 CreatedByUserId INTEGER NOT NULL REFERENCES Users(User_Id),
 DateCreated DateTime,
 DateLastModified DateTime,
 PRIMARY KEY (QuestionId)
)