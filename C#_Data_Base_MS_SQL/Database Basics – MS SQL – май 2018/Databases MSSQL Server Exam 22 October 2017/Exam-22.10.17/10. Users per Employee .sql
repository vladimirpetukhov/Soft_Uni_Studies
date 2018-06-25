SELECT DISTINCT CONCAT(e.FirstName,' ',e.LastName) AS [Name],COUNT(r.UserId) 
AS [Users Number]
FROM Employees AS e
LEFT JOIN Reports AS r ON r.EmployeeId=e.Id

GROUP BY CONCAT(e.FirstName,' ',e.LastName)
ORDER BY [Users Number] DESC,[Name] ASC

