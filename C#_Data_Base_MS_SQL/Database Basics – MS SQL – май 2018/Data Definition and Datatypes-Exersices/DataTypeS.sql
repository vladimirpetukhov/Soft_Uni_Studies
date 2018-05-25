use DataTypes

CREATE TABLE People(
Id BIGINT PRIMARY KEY IDENTITY,
[Name] NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture)<900*1024),
Height DECIMAL(10,2),
[Weight] DECIMAL(10,2),
Gender NVARCHAR(1) CHECK (Gender='f' OR Gender='m') NOT NULL,
Birthdate DATETIME NOT NULL,
Biography NVARCHAR(MAX)

)
INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Pesho', null, null, null, 'm', 22, null),
('Angel', null, null, null, 'm', 26, null),
('Dani', null, null, null, 'm', 27, null),
('Vladimir', null, null, null, 'm', 34, null),
('Stamat', null, null, null, 'm', 29, null)

CREATE TABLE Users(
Id BIGINT PRIMARY KEY IDENTITY,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME,
IsDeleted BIT,


)


INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('peshkata', 'peshopesho', NULL, NULL, 'true'),
('angel', '123456', NULL, NULL, 'true'),
('dani', '67890', NULL, NULL, 'false'),
('vladoweb', '1230000', NULL, NULL, 'true'),
('stamat40', '67890', NULL, NULL, 'false')

ALTER TABLE Users
ADD CONSTRAINT CHK_ProfilePicture 
CHECK (DATALENGTH(ProfilePicture)<=900*1024)
--add min size for picture

ALTER TABLE USERS
DROP CONSTRAINT [PK__Users__3214EC07EC7FC43A]
--drop constraint from column

ALTER TABLE Users
ADD CONSTRAINT PK_Username PRIMARY KEY (Id,Username)
--combinate two columns to one primary key

ALTER TABLE Users
ADD DEFAULT GETDATE() FOR LastLoginTime
--make the default value of LastLoginTime field to be the current time

ALTER TABLE Users
ADD CONSTRAINT CHK_Password CHECK (DATALENGTH([Password])>=5)
--add check constraint to ensure that the values in the Password field are at least 5 symbols long

ALTER TABLE Users
DROP CONSTRAINT [UQ__Users__536C85E4C472C343]
--remove combine primary key

ALTER TABLE Users
ADD CONSTRAINT  CHK_UserNameLength CHECK (DATALENGTH(Username)>=3)
--check Username

CREATE DATABASE Movies --ThisLineNotSubmitInJudge

CREATE TABLE Directors(
Id INT PRIMARY KEY IDENTITY(1, 1),
DirectorName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Genres(
Id INT PRIMARY KEY IDENTITY(1, 1),
GenreName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1, 1),
CategoryName NVARCHAR(50) NOT NULL,
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Movies(
Id INT PRIMARY KEY IDENTITY(1, 1),
Title NVARCHAR(50) UNIQUE NOT NULL,
DirectorId INT NOT NULL,
CopyrightYear INT NULL,
[Length] TIME NOT NULL,
GenreId INT NOT NULL,
CategoryId INT NOT NULL,
Rating INT NULL, 
Notes NVARCHAR(MAX) NULL
)

INSERT INTO Directors(DirectorName, Notes) VALUES
('Pesho', null),
('Gosho', null),
('Ivan', null),
('Stanislav', null),
('Todor', null)

INSERT INTO Genres (GenreName, Notes) VALUES
('Drama', null),
('Comedy', null),
('Action', null),
('Crime', null),
('Fantasy', null)

INSERT INTO Categories(CategoryName, Notes) VALUES
('Aimed at young audience', null),
('No age restrictions', null),
('Not recommended for children under 12', null),
('Prohibited for persons under 16', null),
('Restricted to adults only', null)

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('A Star Wars Story', 1, null, '01:05:00', 2, 3, 5, null),
('Deadpool', 3, null, '01:08:00', 4, 1, 2, null),
('Super Troopers', 4, null, '01:00:00', 3, 3, 3, null),
('Overboard', 5, null, '01:15:00', 2, 5, 4, null),
('Radiogram', 2, null, '01:25:00', 1, 3, 5, null)

CREATE DATABASE CarRental --ThisLineNotSubmitInJudge

USE CarRental

CREATE TABLE Categories(
Id INT PRIMARY KEY IDENTITY(1, 1), 
CategoryName NVARCHAR(50) UNIQUE NOT NULL, 
DailyRate INT NULL,
WeeklyRate INT NULL, 
MonthlyRate INT NULL, 
WeekendRate INT NULL
)

CREATE TABLE Cars(
Id INT PRIMARY KEY IDENTITY(1, 1), 
PlateNumber NVARCHAR(50) UNIQUE NULL, 
Manufacturer NVARCHAR(190) NULL, 
Model NVARCHAR(50) NOT NULL, 
CarYear INT NOT NULL, 
CategoryId INT NOT NULL,
Doors INT NOT NULL, 
Picture BINARY NULL, 
Condition NVARCHAR(50) NULL, 
Available INT NULL
)

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1, 1),
FirstName NVARCHAR(50) NOT NULL, 
LastName NVARCHAR(50) NOT NULL, 
Title NVARCHAR(100) NOT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Customers(
Id INT PRIMARY KEY IDENTITY(1, 1), 
DriverLicenceNumber BIGINT UNIQUE NOT NULL, 
FullName NVARCHAR(100) NOT NULL,
[Address] NVARCHAR(100) NULL,
City NVARCHAR(50) NULL,
ZIPCode NVARCHAR(50) NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE RentalOrders(
Id INT PRIMARY KEY IDENTITY(1, 1), 
EmployeeId INT NOT NULL, 
CustomerId INT NOT NULL, 
CarId INT UNIQUE NOT NULL, 
TankLevel INT NOT NULL, 
KilometrageStart INT NOT NULL, 
KilometrageEnd INT NOT NULL, 
TotalKilometrage INT NOT NULL, 
StartDate DATE NOT NULL, 
EndDate DATE NOT NULL, 
TotalDays INT NOT NULL, 
RateApplied NVARCHAR(50) NULL, 
TaxRate NVARCHAR(50) NULL, 
OrderStatus NVARCHAR(50) NULL, 
Notes NVARCHAR(MAX) NULL
)

INSERT INTO Categories(CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('FirstCategory', 3, 4, 5, 1),
('SecondCategory', 3, 2, 1, 1),
('ThirdCategory', 2, 3, 5, 1)


INSERT INTO Cars(PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('AB0507BE', 'AUDI', 'A8', 1997, 2, 2, NULL, NULL, NULL),
('AC0437BE', 'MERCEDES', 'C2', 2005, 3, 4, NULL, NULL, NULL),
('BA0407EB', 'BMW', 'A4', 2007, 1, 2, NULL, NULL, NULL)

INSERT INTO	Employees(FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Ivanov', 'Employee', null),
('Pesho', 'Ivanov', 'Director', null),
('Ivan', 'Dimitrov', 'Employee', null)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
(3456678819, 'Ivan Ivanov', null, 'Stara Zagora', null, null),
(3456678579, 'Georgi Ivanov', null, 'Sofia', null, null),
(3456578869, 'Stanislava Petrova', null, 'Stara Zagora', null, null)

INSERT INTO RentalOrders(EmployeeId, CustomerId, CarId, TankLevel, 
KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, 
RateApplied, TaxRate, OrderStatus, Notes) VALUES
(2, 1, 3, 1, 120000, 130000, 10000, '2018-01-01', '2018-01-11', 10, null, null, null, null),
(2, 1, 2, 2, 120000, 130000, 10000, '2018-03-01', '2018-03-11', 10, null, null, null, null),
(2, 1, 1, 3, 120000, 130000, 10000, '2018-04-01', '2018-04-11', 10, null, null, null, null)

CREATE DATABASE Hotel 

USE Hotel

CREATE TABLE Employees(
Id INT PRIMARY KEY IDENTITY(1, 1), 
FirstName NVARCHAR(50) NOT NULL,
LastName NVARCHAR(50) NOT NULL,
Title NVARCHAR(50) NOT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Customers(
AccountNumber INT UNIQUE NOT NULL, 
FirstName NVARCHAR(50) NOT NULL, 
LastName NVARCHAR(50) NOT NULL, 
PhoneNumber BIGINT NOT NULL, 
EmergencyName NVARCHAR(50) NULL, 
EmergencyNumber INT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE RoomStatus(
RoomStatus NVARCHAR(10), 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE RoomTypes(
RoomType NVARCHAR(50) NOT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE BedTypes(
BedType NVARCHAR(50) NOT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Rooms(
RoomNumber INT UNIQUE NOT NULL, 
RoomType NVARCHAR(50) NOT NULL, 
BedType NVARCHAR(50) NOT NULL, 
Rate INT NOT NULL, 
RoomStatus NVARCHAR(10) NOT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Payments(
Id INT PRIMARY KEY IDENTITY(1, 1), 
EmployeeId INT NOT NULL, 
PaymentDate DATE NOT NULL, 
AccountNumber BIGINT UNIQUE NOT NULL, 
FirstDateOccupied DATE NOT NULL, 
LastDateOccupied DATE NOT NULL, 
TotalDays INT NOT NULL, 
AmountCharged INT NOT NULL, 
TaxRate INT NULL, 
TaxAmount INT NULL, 
PaymentTotal INT NOT NULL, 
Notes NVARCHAR(MAX) NULL
)

CREATE TABLE Occupancies(
Id INT PRIMARY KEY IDENTITY(1, 1), 
EmployeeId INT NOT NULL, 
DateOccupied DATE NOT NULL, 
AccountNumber BIGINT UNIQUE NOT NULL, 
RoomNumber INT NOT NULL, 
RateApplied INT NULL, 
PhoneCharge INT NULL, 
Notes NVARCHAR(MAX) NULL
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Petia', 'Ivanova', 'Manager', null),
('Ivan', 'Ivanova', 'Director', null),
('Gosho', 'Goshev', 'Employee', null)

INSERT INTO Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(232343435, 'Daniel', 'Petrov', 08989333333, null, null, null),
(232543435, 'Daniela', 'Petrova', 0898955555, null, null, null),
(232323435, 'Preslav', 'Petrov', 0898944444, null, null, null)

INSERT INTO RoomStatus(RoomStatus, Notes) VALUES
('free', null),
('busy', null),
('wait', null)

INSERT INTO RoomTypes (RoomType, Notes) VALUES
('small', null),
('big', null),
('middle', null)

INSERT INTO BedTypes(BedType, Notes) VALUES
('small', null),
('big', null),
('middle', null)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(12, 'small', 'small', 12, 'free', null),
(13, 'big', 'big', 12, 'busy', null),
(14, 'middle', 'small', 12, 'free', null)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, 
FirstDateOccupied, LastDateOccupied, TotalDays, 
AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(3, '2007-03-12', 33443545445, '2007-04-10', '2007-04-14', 4, 25, null, null, 25, null),
(2, '2017-03-12', 33443545345, '2017-03-10', '2017-03-14', 4, 45, null, null, 45, null),
(1, '2017-03-12', 33443545425, '2017-03-10', '2017-03-14', 4, 55, null, null, 55, null)

INSERT INTO Occupancies(EmployeeId, DateOccupied, AccountNumber, RoomNumber, 
RateApplied, PhoneCharge, Notes) VALUES
(2, '2007-04-05', 3454534564, 12, null, null, null),
(1, '2007-03-05', 345453445464, 11, null, null, null),
(3, '2007-02-05', 34545335464, 10, null, null, null)

CREATE DATABASE SoftUni

USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Adresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText NVARCHAR(MAX) NOT NULL,
	TownId INT CONSTRAINT FK_Adresses_Town FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL,
	MiddleName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL,
	JobTitle NVARCHAR(30) NOT NULL,
	DepartmentId INT CONSTRAINT FK_Departments FOREIGN KEY REFERENCES Departments(Id),
	HireDate DATE NOT NULL, 
	Salary DECIMAL(10,2) NOT NULL,
	AddressId INT CONSTRAINT FK_Address_Id FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

INSERT INTO Towns([Name])
VALUES
	('Sofia'),
	( 'Plovdiv'),
	( 'Varna'),
	( 'Burgas')

INSERT INTO Departments
VALUES
	('Engineering'),
	( 'Sales'),
	('Marketing'),
	( 'Software Development'),
	( 'Quality Assurance')

ALTER TABLE Employees
ALTER COLUMN AddressId INT

INSERT INTO Employees (FirstName,MiddleName,LastName,JobTitle,
DepartmentId,HireDate,Salary)
VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 4, '2013/02/01', 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, '2004/03/02', 4000.00),
('Maria', 'Petrova', 'Ivanova', 'Intern', 5, '2016/08/28', 525.25),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 2, '2007/12/09', 3000.00),
('Peter', 'Pan', 'Pan', 'Intern', 3, '2016/08/28', 599.88)

SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC 

----------------------
SELECT Name FROM Towns 
ORDER BY [Name]

SELECT Name FROM Departments
ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC 


UPDATE  Employees
SET Salary*=1.10;
--increase salaryes with 10%

SELECT Salary FROM Employees
-------------------------

USE Hotel

UPDATE Payments
SET TaxRate-=TaxRate*0.03;

SELECT TaxRate FROM Payments

SELECT * FROM Occupancies

TRUNCATE TABLE Occupancies