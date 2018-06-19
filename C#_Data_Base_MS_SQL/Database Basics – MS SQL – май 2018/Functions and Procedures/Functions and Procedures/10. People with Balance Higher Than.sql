
CREATE PROC usp_GetHoldersWithBalanceHigherThan (@number DECIMAL(15,4))
AS
	SELECT AH.FirstName,AH.LastName
	FROM AccountHolders AS AH
	JOIN Accounts AS A ON A.AccountHolderId=AH.Id
	GROUP BY FirstName,LastName
	HAVING SUM(A.Balance)>@number
	

EXEC usp_GetHoldersWithBalanceHigherThan 50000

SELECT *
FROM AccountHolders