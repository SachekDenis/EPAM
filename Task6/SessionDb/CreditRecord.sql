CREATE TABLE [dbo].[CreditRecord]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StudentId] INT NOT NULL, 
    [CreditId] INT NOT NULL, 
    [Passed] BIT NOT NULL, 
    CONSTRAINT [FK_CreditRecord_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id]), 
    CONSTRAINT [FK_CreditRecord_ToSubjects] FOREIGN KEY ([CreditId]) REFERENCES [Subjects]([Id])
)
