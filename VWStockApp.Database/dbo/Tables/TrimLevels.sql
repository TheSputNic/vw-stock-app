CREATE TABLE [dbo].[TrimLevels] (
    [ID]         INT           IDENTITY (1, 1) NOT NULL,
    [CarModelID] INT           NOT NULL,
    [Name]       NVARCHAR (50) NULL,
    [Price]      MONEY         NOT NULL,
    CONSTRAINT [PK_TrimLevels] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_TrimLevels_CarModels_CarModelID] FOREIGN KEY ([CarModelID]) REFERENCES [dbo].[CarModels] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TrimLevels_CarModelID]
    ON [dbo].[TrimLevels]([CarModelID] ASC);

