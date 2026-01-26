CREATE TABLE [dbo].[tblState] (
    [StateID]        INT          IDENTITY (1, 1) NOT NULL,
    [CountryID]      INT          NOT NULL,
    [StateName]      VARCHAR (50) NOT NULL,
    [IsStateActive]  BIT          CONSTRAINT [DF_tblState_IsStateActive] DEFAULT ((0)) NOT NULL,
    [IsStateDeleted] BIT          CONSTRAINT [DF_tblState_IsStateDeleted] DEFAULT ((0)) NOT NULL,
    [CreatedBy]      INT          NULL,
    [CreatedDate]    DATETIME     NULL,
    [UpdatedBy]      INT          NULL,
    [UpdatedDate]    DATETIME     NULL,
    [DeletedBy]      INT          NULL,
    [DeletedDate]    DATETIME     NULL,
    CONSTRAINT [PK_tblState] PRIMARY KEY CLUSTERED ([StateID] ASC),
    CONSTRAINT [FK_tblState_tblCountry] FOREIGN KEY ([CountryID]) REFERENCES [dbo].[tblCountry] ([CountryID])
);

