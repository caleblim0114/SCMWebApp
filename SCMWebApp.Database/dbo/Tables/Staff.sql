CREATE TABLE [dbo].[Staff]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Image] NVARCHAR(MAX) NULL, 
    [PhoneNum] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL, 
    [PositionId] INT NULL, 
    [ProgrammeId] INT NULL, 
    CONSTRAINT [FK_Staff_ToPosition] FOREIGN KEY ([PositionId]) REFERENCES [Position]([Id]),
    CONSTRAINT [FK_Staff_ToProgramme] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme]([Id]),
)
