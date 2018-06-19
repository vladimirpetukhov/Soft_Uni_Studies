SELECT TOP (50) 
				E.EmployeeID,
				E.FirstName+' '+E.LastName AS EmployeeName,
				E2.FirstName+' '+E2.LastName AS ManagerName,
				D.Name AS DepartmentName
FROM Employees AS E
JOIN Employees AS E2 ON E2.EmployeeID=E.ManagerID
JOIN Departments AS D ON D.DepartmentID=E.DepartmentID
ORDER BY E.EmployeeID