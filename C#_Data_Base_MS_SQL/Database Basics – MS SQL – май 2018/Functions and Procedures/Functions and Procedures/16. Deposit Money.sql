CREATE PROC usp_DepositMoney (@accountId int, @moneyAmount DECIMAL(18,4)) 
AS
BEGIN
	BEGIN TRAN 
	UPDATE Accounts
	SET Balance+=@moneyAmount
	WHERE Id=@accountId

	IF(@@ROWCOUNT<>1)
	BEGIN
		ROLLBACK;
		RAISERROR ( 'Invalid Account',16,1);
		RETURN;
	END

	COMMIT;

END
EXEC usp_DepositMoney 1,10
SELECT * FROM Accounts
WHERE Id=1
