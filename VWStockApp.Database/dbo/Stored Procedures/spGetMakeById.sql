CREATE PROCEDURE [dbo].[spGetMakeById]
	@MakeID int
AS
BEGIN
	SELECT * 
	FROM Makes 
	WHERE MakeID = @MakeID
END
