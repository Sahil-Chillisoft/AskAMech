CREATE TABLE Answers(
    AnswerId  int IDENTITY NOT NULL,
 Descriptions VARCHAR (500),
 QuestionId INTEGER NOT NULL REFERENCES Questions(QuestionId),
 AnsweredByUserId INTEGER NOT NULL REFERENCES Users(User_Id),
IsAcceptedAnswer bit,
 DateCreated DateTime,
 PRIMARY KEY (AnswerId)
)