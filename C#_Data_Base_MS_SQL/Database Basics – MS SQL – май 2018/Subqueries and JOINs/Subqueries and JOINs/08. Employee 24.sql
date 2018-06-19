DECLARE @star_date DATETIME='2005-01-01'
SELECT TOP 5 E.EmployeeID,E.FirstName,IIF(P.StartDate>@star_date,NULL,P.Name) AS ProjectName
FROM Employees AS E
JOIN EmployeesProjects AS EP ON EP.EmployeeID=E.EmployeeID
JOIN Projects AS P ON P.ProjectID=EP.ProjectID
WHERE E.EmployeeID=24