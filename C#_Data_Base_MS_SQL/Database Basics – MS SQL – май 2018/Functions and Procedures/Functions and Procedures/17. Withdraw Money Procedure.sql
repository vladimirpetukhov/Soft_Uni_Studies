CREATE OR ALTER PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(18,4))
AS
BEGIN
    
	DECLARE @current_balance DECIMAL=(
		SELECT Balance FROM Accounts
		WHERE Id=@accountId)
	IF(@current_balance>=@moneyAmount)
	BEGIN

		BEGIN TRAN
		UPDATE Accounts
		SET Balance -=@moneyAmount
		WHERE Id=@accountId 

		IF(@@ROWCOUNT<>1)
		BEGIN
			ROLLBACK;
			RAISERROR ('Invalid account',16,1);
			RETURN;
		END

		COMMIT;
	END

	ELSE
	BEGIN
		RAISERROR ('The balance ammount is too low!',16,1);
		RETURN;
	END
END

EXEC usp_WithdrawMoney 5,25

