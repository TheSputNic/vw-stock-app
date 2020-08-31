CREATE PROCEDURE spReseedTable
@TableName varchar(50)
AS
BEGIN
	DBCC CHECKIDENT (@TableName, RESEED, 0);
END