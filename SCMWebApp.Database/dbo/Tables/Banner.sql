CREATE TABLE [dbo].[Banner]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ImagePath] NVARCHAR(MAX) NULL, 
    [Title] NVARCHAR(MAX) NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [BannerTypeId] INT NULL, 
    [ProgrammeId] INT NULL, 
    CONSTRAINT [FK_Banner_ToBannerType] FOREIGN KEY ([BannerTypeId]) REFERENCES [BannerType]([Id]), 
    CONSTRAINT [FK_Banner_Programme] FOREIGN KEY ([ProgrammeId]) REFERENCES [Programme]([Id]), 
)
