CREATE TABLE [dbo].[tblRole] (
    [RoleID]       INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]     VARCHAR (15)  NOT NULL,
    [Description]  VARCHAR (MAX) NULL,
    [IsRoleActive] BIT           CONSTRAINT [DF_tblRole_IsRoleActive] DEFAULT ((0)) NOT NULL,
    [CreatedBy]    INT           NULL,
    [CreatedDate]  DATETIME      NULL,
    [UpdatedBy]    INT           NULL,
    [UpdatedDate]  DATETIME      NULL,
    [DeletedBy]    INT           NULL,
    [DeletedDate]  DATETIME      NULL,
    CONSTRAINT [PK_tblRole] PRIMARY KEY CLUSTERED ([RoleID] ASC)
);

