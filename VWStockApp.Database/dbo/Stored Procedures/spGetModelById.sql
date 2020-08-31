CREATE PROCEDURE [dbo].[spGetModelById]
	@ModelID int
AS
BEGIN
	SELECT * 
	FROM CarModels 
	WHERE ID = @ModelID
END