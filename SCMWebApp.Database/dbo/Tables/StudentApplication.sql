CREATE TABLE [dbo].[StudentApplication]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL, 
    [PhoneNumber] NVARCHAR(MAX) NULL, 
    [ProgrammeId] INT NULL, 
    CONSTRAINT [FK_StudentApplication_ToProgramme] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme]([Id]),
)
