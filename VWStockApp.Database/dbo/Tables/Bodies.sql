CREATE TABLE [dbo].[Bodies] (
    [ID]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Bodies] PRIMARY KEY CLUSTERED ([ID] ASC)
);

