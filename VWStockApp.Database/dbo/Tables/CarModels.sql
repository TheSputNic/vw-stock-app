CREATE TABLE [dbo].[CarModels] (
    [ID]        INT           IDENTITY (1, 1) NOT NULL,
    [MakeID]    INT           NOT NULL,
    [Name]      NVARCHAR (50) NULL,
    [YearModel] DATETIME2 (7) NOT NULL,
    CONSTRAINT [PK_CarModels] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_CarModels_Makes_MakeID] FOREIGN KEY ([MakeID]) REFERENCES [dbo].[Makes] ([MakeID]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_CarModels_MakeID]
    ON [dbo].[CarModels]([MakeID] ASC);

