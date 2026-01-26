CREATE TABLE [dbo].[tblRoomStatus] (
    [RoomStatusID]   INT           IDENTITY (1, 1) NOT NULL,
    [RoomStatusName] VARCHAR (90)  NOT NULL,
    [Description]    VARCHAR (MAX) NULL,
    [RoomStatusIcon] VARCHAR (50)  NULL,
    [IsActive]       BIT           CONSTRAINT [DF_tblRoomStatus_IsActive] DEFAULT ((0)) NOT NULL,
    [IsDeleted]      BIT           CONSTRAINT [DF_tblRoomStatus_IsDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedBy]      INT           NULL,
    [CreatedDate]    DATETIME      NULL,
    [UpdatedBy]      INT           NULL,
    [UpdatedDate]    DATETIME      NULL,
    [DeletedBy]      INT           NULL,
    [DeletedDate]    DATETIME      NULL,
    CONSTRAINT [PK_tblRoomStatus] PRIMARY KEY CLUSTERED ([RoomStatusID] ASC)
);

