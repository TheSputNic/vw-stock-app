CREATE TABLE [dbo].[Features] (
    [ID]          INT            IDENTITY (1, 1) NOT NULL,
    [TrimLevelID] INT            NOT NULL,
    [Description] NVARCHAR (100) NULL,
    CONSTRAINT [PK_Features] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Features_TrimLevels_TrimLevelID] FOREIGN KEY ([TrimLevelID]) REFERENCES [dbo].[TrimLevels] ([ID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Features_TrimLevelID]
    ON [dbo].[Features]([TrimLevelID] ASC);

