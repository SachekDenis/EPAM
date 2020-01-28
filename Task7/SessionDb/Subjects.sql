CREATE TABLE [dbo].[Subjects]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [SessionId] INT NOT NULL, 
    [ExaminerFullName] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Exams_ToSessions] FOREIGN KEY ([SessionId]) REFERENCES [Sessions]([Id])
)
