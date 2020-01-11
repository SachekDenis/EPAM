CREATE TABLE [dbo].[ExamRecord]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [StudentId] INT NOT NULL, 
    [ExamId] INT NOT NULL, 
    [Mark] INT NOT NULL, 
    CONSTRAINT [FK_ExamRecord_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([Id]), 
    CONSTRAINT [FK_ExamRecord_ToExams] FOREIGN KEY ([ExamId]) REFERENCES [Subjects]([Id])
)
