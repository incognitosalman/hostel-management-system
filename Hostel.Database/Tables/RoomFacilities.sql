CREATE TABLE [dbo].[RoomFacilities]
(
	[RoomId] INT NOT NULL, 
    [FacilityId] INT NOT NULL,

	CONSTRAINT PK_RoomFacilities PRIMARY KEY(RoomId, FacilityId),
	CONSTRAINT FK_RoomFacilities_Rooms FOREIGN KEY (RoomId) REFERENCES Rooms(Id),
	CONSTRAINT FK_RoomFacilities_Facilities FOREIGN KEY (FacilityId) REFERENCES Facilities(Id)
)
