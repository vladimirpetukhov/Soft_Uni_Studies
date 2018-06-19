CREATE PROC usp_GetHoldersFullName 
AS
SELECT  AC.FirstName+' '+AC.LastName AS  [Full Name]
FROM AccountHolders AS AC
JOIN Accounts AS A ON A.Id=AC.Id 
