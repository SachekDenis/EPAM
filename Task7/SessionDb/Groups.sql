CREATE TABLE [dbo].[Groups]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(MAX) NOT NULL, 
    [SpecialtyId] INT NOT NULL, 
    CONSTRAINT [FK_Groups_ToSpecialties] FOREIGN KEY ([SpecialtyId]) REFERENCES [Specialties]([Id]) 
)
