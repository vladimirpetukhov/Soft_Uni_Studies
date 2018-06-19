ALTER TABLE Logs
ADD CONSTRAINT ID_LogsId iBHWBVRHJ
GO
CREATE TRIGGER tr_Enters ON Accounts FOR UPDATE
AS
	DECLARE @accountId INT=(SELECT Id FROM Accounts);
	DECLARE @old_balance MONEY=(SELECT Balance FROM deleted);
	DECLARE @new_balance MONEY=(SELECT Balance FROM inserted);

	IF(@old_balance<>@new_balance)
	BEGIN
		INSERT INTO Logs 
		VALUES(@accountId,@old_balance,@new_balance);
	END
