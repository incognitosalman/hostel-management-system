CREATE TABLE [dbo].[Hostels]
(
	[Id] INT NOT NULL IDENTITY(1, 1), 
    [Name] NVARCHAR(150) NOT NULL, 
    [Address] NVARCHAR(250) NULL, 
    [PhoneNumber] NVARCHAR(15) NULL, 
    [Email] NVARCHAR(350) NULL,

    [NumberOfFloors] INT NOT NULL, 
    CONSTRAINT PK_Hostels PRIMARY KEY (Id)
)
