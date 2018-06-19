CREATE PROC usp_TransferMoney
(@senderId INT, @receiverId INT, @amount DECIMAL(18,4))
AS
BEGIN
	DECLARE @no_funds_message VARCHAR(50)=CONCAT('Not enough funds in balance 
	with Id: ',@senderId);
	DECLARE @invalid_account VARCHAR (20)='Invalid account';
	DECLARE @current_balance DECIMAL=(SELECT Balance FROM Accounts
									  WHERE Id=@senderId);
	IF(@amount<=0)
	BEGIN
		RAISERROR ('Zero or Negative ammount',16,1);
		ROLLBACK;
		RETURN;
	END
	ELSE IF(@amount>@current_balance)
	BEGIN
		RAISERROR (@no_funds_message,16,1);
		ROLLBACK;
		RETURN;
	END

	BEGIN TRAN
	UPDATE Accounts
	SET Balance -=@amount
	WHERE Id=@senderId

	IF(@@ROWCOUNT<>1)
	BEGIN
		RAISERROR (@invalid_account,16,1);
		ROLLBACK;
		RETURN;
	END
	COMMIT;

	BEGIN TRAN
	UPDATE Accounts
	SET Balance +=@amount
	WHERE Id=@receiverId

	IF(@@ROWCOUNT<>1)
	BEGIN
		RAISERROR (@invalid_account,16,2);
		ROLLBACK;
		RETURN;
	END
	COMMIT;
END

