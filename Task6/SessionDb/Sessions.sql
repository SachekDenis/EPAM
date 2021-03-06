﻿CREATE TABLE [dbo].[Sessions]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [GroupId] INT NOT NULL, 
    [StartDate] DATETIME NOT NULL, 
    [EndDate] DATETIME NOT NULL, 
    CONSTRAINT [FK_Sessions_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id])
)
