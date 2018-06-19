CREATE PROC usp_DeleteEmployeesFromDepartment(@departmentID INT)
AS
ALTER TABLE Departments
ALTER COLUMN ManagerID INT NULL

DELETE FROM EmployeesProjects
WHERE EmployeeID IN	
	(
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID=@departmentID
	)

UPDATE  Employees
SET ManagerID=NULL
WHERE ManagerID IN
	(
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID=@departmentID
	)

UPDATE Departments
SET ManagerID=NULL
WHERE ManagerID IN
	(
		SELECT EmployeeID
		FROM Employees
		WHERE DepartmentID=@departmentID
	)

DELETE FROM Employees
WHERE EmployeeID IN 
	(
		SELECT EmployeeID FROM Employees
		WHERE DepartmentID = @departmentId
	)

DELETE FROM Departments
WHERE DepartmentID = @departmentId
SELECT COUNT(*) AS [Employees Count] FROM Employees AS e
JOIN Departments AS d
ON d.DepartmentID = e.DepartmentID
WHERE e.DepartmentID = @departmentId

EXEC usp_DeleteEmployeesFromDepartment 