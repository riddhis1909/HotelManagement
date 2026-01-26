CREATE TABLE [dbo].[tblCountry] (
    [CountryID]        INT          IDENTITY (1, 1) NOT NULL,
    [CountryName]      VARCHAR (50) NOT NULL,
    [ISO2]             VARCHAR (10) NULL,
    [ISO3]             VARCHAR (10) NULL,
    [PhoneCode]        VARCHAR (50) NULL,
    [Capital]          VARCHAR (50) NULL,
    [Currency]         VARCHAR (50) NULL,
    [IsCountryActive]  BIT          CONSTRAINT [DF_tblCountry_IsCountryActive] DEFAULT ((0)) NOT NULL,
    [IsCountryDeleted] BIT          NOT NULL,
    [CreatedBy]        INT          NULL,
    [CreatedDate]      DATETIME     NULL,
    [UpdatedBy]        INT          NULL,
    [UpdatedDate]      DATETIME     NULL,
    [DeletedBy]        INT          NULL,
    [DeletedDate]      DATETIME     NULL,
    CONSTRAINT [PK_tblCountry] PRIMARY KEY CLUSTERED ([CountryID] ASC)
);

