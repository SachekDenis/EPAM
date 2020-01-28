CREATE TABLE [dbo].[ExamRecord]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [StudentId] INT NOT NULL, 
    [ExamId] INT NOT NULL, 
    [Mark] INT NOT NULL, 
    CONSTRAINT [FK_ExamRecord_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id]), 
    CONSTRAINT [FK_ExamRecord_ToExams] FOREIGN KEY ([ExamId]) REFERENCES [Subjects]([Id])
)
