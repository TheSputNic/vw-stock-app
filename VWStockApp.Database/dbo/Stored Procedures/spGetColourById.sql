CREATE PROCEDURE [dbo].[spGetColourById]
	@ColourID int
AS
BEGIN
	SELECT * 
	FROM Colours 
	WHERE ID = @ColourID
END