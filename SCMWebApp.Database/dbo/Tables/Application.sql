CREATE TABLE [dbo].[Application]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(MAX) NULL, 
    [Email] NVARCHAR(MAX) NULL, 
    [PhoneNum] NVARCHAR(MAX) NULL, 
    [IsReply] INT NULL
)
