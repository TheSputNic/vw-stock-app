CREATE PROCEDURE [dbo].[spGetTrimById]
	@TrimID int
AS
BEGIN
	SELECT * 
	FROM TrimLevels 
	WHERE ID = @TrimID
END
