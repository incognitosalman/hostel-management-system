CREATE TABLE [dbo].[Rooms]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [RoomNumber] NVARCHAR(15) NOT NULL, 
    [FloorId] INT NOT NULL,
    
    CONSTRAINT PK_Rooms PRIMARY KEY (Id), 
    CONSTRAINT FK_Rooms_Floors FOREIGN KEY (FloorId) REFERENCES Floors(Id)
)
