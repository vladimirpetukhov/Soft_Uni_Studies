CREATE PROC usp_GetTownsStartingWith (@first_symbol NVARCHAR(3))
AS
	SELECT [Name]
	FROM Towns
	WHERE [Name] LIKE CONCAT(@first_symbol,'%')

