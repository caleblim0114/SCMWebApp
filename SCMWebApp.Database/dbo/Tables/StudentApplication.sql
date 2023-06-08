CREATE TABLE [dbo].[StudentApplication]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL, 
    [PhoneNumber] NCHAR(10) NULL
)
