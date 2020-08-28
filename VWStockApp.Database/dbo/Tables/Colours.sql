CREATE TABLE [dbo].[Colours] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [CarModelID] INT           NULL,
    CONSTRAINT [PK_Colours] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Colours_CarModels_CarModelID] FOREIGN KEY ([CarModelID]) REFERENCES [dbo].[CarModels] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_Colours_CarModelID]
    ON [dbo].[Colours]([CarModelID] ASC);

