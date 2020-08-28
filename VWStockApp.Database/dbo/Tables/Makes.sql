CREATE TABLE [dbo].[Makes] (
    [MakeID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]   NVARCHAR (50) NULL,
    CONSTRAINT [PK_Makes] PRIMARY KEY CLUSTERED ([MakeID] ASC)
);

