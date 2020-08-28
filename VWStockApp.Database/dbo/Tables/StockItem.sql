CREATE TABLE [dbo].[StockItem] (
    [ID]            INT   IDENTITY (1, 1) NOT NULL,
    [MakeID]        INT   NULL,
    [CarModelID]    INT   NULL,
    [TrimLevelID]   INT   NULL,
    [ColourID]      INT   NULL,
    [PriceModifier] MONEY NOT NULL,
    CONSTRAINT [PK_StockItem] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_StockItem_CarModels_CarModelID] FOREIGN KEY ([CarModelID]) REFERENCES [dbo].[CarModels] ([ID]),
    CONSTRAINT [FK_StockItem_Colours_ColourID] FOREIGN KEY ([ColourID]) REFERENCES [dbo].[Colours] ([ID]),
    CONSTRAINT [FK_StockItem_Makes_MakeID] FOREIGN KEY ([MakeID]) REFERENCES [dbo].[Makes] ([MakeID]),
    CONSTRAINT [FK_StockItem_TrimLevels_TrimLevelID] FOREIGN KEY ([TrimLevelID]) REFERENCES [dbo].[TrimLevels] ([ID])
);


GO
CREATE NONCLUSTERED INDEX [IX_StockItem_CarModelID]
    ON [dbo].[StockItem]([CarModelID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StockItem_ColourID]
    ON [dbo].[StockItem]([ColourID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StockItem_MakeID]
    ON [dbo].[StockItem]([MakeID] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StockItem_TrimLevelID]
    ON [dbo].[StockItem]([TrimLevelID] ASC);

