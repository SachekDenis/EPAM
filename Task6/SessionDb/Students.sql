CREATE TABLE [dbo].[Students]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FullName] NVARCHAR(MAX) NOT NULL, 
    [Gender] NCHAR(10) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [GroupId] INT NOT NULL, 
    CONSTRAINT [FK_Student_ToGroups] FOREIGN KEY ([GroupId]) REFERENCES [Groups]([Id])
)
