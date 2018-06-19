SELECT E.EmployeeID,E.FirstName	,E.ManagerID,E2.FirstName
FROM Employees AS E
JOIN Employees AS E2 ON E2.EmployeeID=E.ManagerID
WHERE E.ManagerID IN (3,7)