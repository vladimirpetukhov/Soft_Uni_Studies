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
 