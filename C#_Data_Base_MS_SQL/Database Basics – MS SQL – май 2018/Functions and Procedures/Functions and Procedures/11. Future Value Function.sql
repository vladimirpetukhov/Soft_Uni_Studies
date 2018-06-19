CREATE OR ALTER FUNCTION ufn_CalculateFutureValue(@initialSum DECIMAL(18,4),
										 @yearlyinterestrate FLOAT,
										 @numberOfYears INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	
	DECLARE @futureValue DECIMAL(18,4);

	SET @futureValue=@initialSum*(POWER(1+@yearlyinterestrate,@numberOfYears));

	RETURN @futureValue;
END
GO
SELECT dbo.ufn_CalculateFutureValue (1000,0.1,5)
