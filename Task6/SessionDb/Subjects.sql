﻿CREATE TABLE [dbo].[Subjects]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [Date] DATETIME NOT NULL, 
    [SessionId] INT NOT NULL, 
    CONSTRAINT [FK_Exams_ToSessions] FOREIGN KEY ([SessionId]) REFERENCES [Sessions]([Id])
)
