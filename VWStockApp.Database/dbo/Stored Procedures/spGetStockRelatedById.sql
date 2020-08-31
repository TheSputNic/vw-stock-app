CREATE PROCEDURE spGetStockRelatedById
                                @StockID int 
                                AS
                                BEGIN
                                    SELECT StockItem.ID, Makes.MakeID, StockItem.CarModelID, StockItem.TrimLevelID, StockItem.ColourID, StockItem.PriceModifier, Makes.Name AS "Make.Name", CarModels.Name AS "CarModels.Name", CarModels.YearModel, TrimLevels.Name AS "TrimLevels.Name", TrimLevels.Price, Colours.Name AS "Colours.Name"
									FROM StockItem 
									LEFT JOIN Makes ON Makes.MakeID = StockItem.MakeID
									LEFT JOIN CarModels ON CarModels.ID = StockItem.CarModelID
									LEFT JOIN TrimLevels ON TrimLevels.ID = StockItem.TrimLevelID
									LEFT JOIN Colours ON Colours.ID = StockItem.ID
									WHERE StockItem.ID = @StockID
                                END