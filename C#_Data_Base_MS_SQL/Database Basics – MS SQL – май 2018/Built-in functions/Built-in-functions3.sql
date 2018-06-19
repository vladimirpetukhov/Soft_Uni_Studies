USE SoftUni

--01. Find Names of All Employees by First Name
SELECT FirstName,LastName FROM Employees
 WHERE FirstName LIKE 'SA%'

 --02. Find Names of All Employees by Last Name
SELECT FirstName,LastName  FROM Employees
 WHERE LastName LIKE '%ei%'

 --03. Find First Names of All Employess
 SELECT FirstName FROM Employees
  WHERE DepartmentID IN(3,10)

  --Problem 4.Find All Employees Except Engineers
 SELECT FirstName,LastName FROM Employees
  WHERE JobTitle NOT LIKE '%engineer%'

   --Problem 5.Find Towns with Name Length
 SELECT [Name] FROM Towns
 WHERE LEN([Name])=5 OR LEN([Name])=6
 ORDER BY [Name]

 --Problem 6.Find Towns Starting With
 SELECT TownId,[Name] FROM Towns
 WHERE [Name] LIKE '[MKBE]%'
 ORDER BY [Name]

 --Problem 7.Find Towns Not Starting With
 SELECT TownId,[Name] FROM Towns
 WHERE [Name] LIKE '[^RBD]%'
 ORDER BY [Name]

 --08.Create View Employees Hired After
 GO
 CREATE VIEW V_EmployeesHiredAfter2000
     AS
 SELECT FirstName,LastName FROM Employees
  WHERE HireDate>'2001'

 --09.Length of Last Name
 SELECT FirstName,LastName FROM Employees
  WHERE LEN(LastName)=5

 --Problem 10.Countries Holding ‘A’ 3 or More Times
 USE Geography

 SELECT CountryName,IsoCode FROM Countries
  WHERE CountryName LIKE '%A%A%A%'
  ORDER BY IsoCode
 
 --Problem 11.Mix of Peak and River Names
 SELECT PeakName,RiverName,
 LOWER(CONCAT (LEFT(PeakName, LEN(PeakName)-1),RiverName)) AS Mix
   FROM Peaks,Rivers
  WHERE RIGHT(PeakName,1) = LEFT(RiverName,1)
  ORDER BY Mix

  --Problem 12.Games from 2011 and 2012 year
  USE Diablo
 SELECT TOP (50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
   FROM Games
  WHERE DATEPART(YEAR, [Start]) = '2011' OR DATEPART(YEAR, [Start]) = '2012'
ORDER BY [Start], [Name]
  
  --Problem 13.User Email Providers
  SELECT Username, SUBSTRING(Email,CHARINDEX('@',Email)+1, LEN(Email))
	  AS [Email Provider]
   FROM Users
  ORDER BY [Email Provider],Username

  --Problem 14.Get Users with IPAdress Like Pattern
  SELECT  Username,IpAddress
	FROM Users
   WHERE IpAddress LIKE '___.1%.%.___'
  ORDER BY Username
  
  --Problem 15.Show All Games with Duration and Part of the Day
  SELECT [Name] AS Game,
	CASE
		WHEN DATEPART(HOUR,[Start])>= 0 AND DATEPART(HOUR,[Start])<12 THEN 'Morning'
		WHEN DATEPART(HOUR,[Start])>=12 AND DATEPART(HOUR,[Start])<18 THEN 'Afternoon'
		WHEN DATEPART(HOUR,[Start])>=18 AND DATEPART(HOUR,[Start])<24 THEN 'Evening'
	END
	AS [Part of the day],

	CASE
		WHEN Duration<=3 THEN 'Extra Short '
		WHEN Duration >=4 AND Duration<=6 THEN 'Short'
		WHEN Duration >6 THEN 'Long'
		WHEN Duration IS NULL THEN 'Extra Long'
	END
	AS Duration

  FROM Games
  ORDER BY Game,Duration, [Part of the day]

  --Problem 16.Orders Table
  USE Orders
  SELECT ProductName,OrderDate,
  DATEADD(DAY,3,OrderDate) AS [Pay Due],
  DATEADD(MONTH,1,OrderDate) AS [Deliver Due]
  FROM Orders

  --Problem 17.People Table
  CREATE TABLE Peopl(
Id INT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(50) NOT NULL,
Birthdate DATETIME NOT NULL
)

INSERT INTO People([Name], Birthdate) VALUES
('Victor', '2000-12-07'),
('Steven', '1992-09-10'),
('Stephen', '1910-09-19'),
('John', '1984-02-05')

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	   DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	   DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	   DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People