SELECT TOP 1 AVG(E.Salary) AS MinAverageSalary
FROM Employees AS E
--JOIN Departments AS D ON D.DepartmentID=E.DepartmentID
GROUP BY E.DepartmentID
ORDER BY MinAverageSalary