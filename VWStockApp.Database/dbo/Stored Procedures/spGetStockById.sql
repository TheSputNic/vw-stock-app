Create procedure spGetStockById
                                @Id int
                                as
                                Begin
                                    Select * from StockItem
                                    where ID = @Id
                                End
