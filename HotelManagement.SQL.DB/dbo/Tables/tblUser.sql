CREATE TABLE [dbo].[tblUser] (
    [UserID]          INT           IDENTITY (1, 1) NOT NULL,
    [RoleID]          INT           NOT NULL,
    [FirstName]       VARCHAR (20)  NOT NULL,
    [LastName]        VARCHAR (20)  NOT NULL,
    [EmailID]         VARCHAR (50)  NOT NULL,
    [MobileNumber]    VARCHAR (20)  NOT NULL,
    [Address]         VARCHAR (MAX) NULL,
    [City]            VARCHAR (20)  NULL,
    [ZipCode]         VARCHAR (15)  NULL,
    [StateID]         INT           NULL,
    [Password]        VARCHAR (MAX) NULL,
    [IsProfileActive] BIT           CONSTRAINT [DF_tblUser_IsProfileActive] DEFAULT ((0)) NOT NULL,
    [CreatedBy]       INT           NULL,
    [CreatedDate]     DATETIME      NULL,
    [UpdatedBy]       INT           NULL,
    [UpdatedDate]     DATETIME      NULL,
    [DeletedBy]       INT           NULL,
    [DeletedDate]     DATETIME      NULL,
    [LastLoginDate]   DATETIME      NULL,
    CONSTRAINT [PK_tblUser] PRIMARY KEY CLUSTERED ([UserID] ASC),
    CONSTRAINT [FK_tblUser_tblRole] FOREIGN KEY ([RoleID]) REFERENCES [dbo].[tblRole] ([RoleID])
);

