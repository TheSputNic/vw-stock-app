CREATE PROCEDURE [dbo].[insCarModel]
	@MakeID int,
	@Name nvarchar(50),
	@YearModel DateTime2(7)
AS
	INSERT INTO CarModels(MakeID, Name, YearModel)
	VALUES (@MakeID, @Name, @YearModel)
GO;
