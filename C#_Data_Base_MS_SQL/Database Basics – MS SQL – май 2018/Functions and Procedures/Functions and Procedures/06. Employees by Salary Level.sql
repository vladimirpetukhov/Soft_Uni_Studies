CREATE PROC usp_EmployeesBySalaryLevel (@level VARCHAR(7))
AS
SELECT  FirstName,LastName
FROM Employees
WHERE dbo.ufn_GetSalaryLevel(Salary)=@level

