CREATE TABLE [dbo].[Floors]
(
	[Id] INT NOT NULL, 
    [Name] NVARCHAR(15) NOT NULL, 
    [FloorNumber] INT NOT NULL,
    [HostelId] INT NOT NULL, 

    CONSTRAINT PK_Floors PRIMARY KEY (Id),
    CONSTRAINT FK_Rooms_Hostels FOREIGN KEY (HostelId) REFERENCES Hostels(Id)
)
