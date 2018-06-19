CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4)) 
RETURNS VARCHAR(10)
AS
BEGIN
	DECLARE @level_type VARCHAR(7);
	

	IF(@salary<30000)
	BEGIN
		SET @level_type='Low'; 
	END
	IF(@salary>50000)
	BEGIN
		SET @level_type='High'; 
	END
	IF(@salary>=30000 AND @salary<=50000)
	BEGIN
		SET @level_type='Average'; 
	END

	RETURN @level_type

	END;

SELECT  Salary,dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees