CREATE TABLE Manufacturers
(
 ManufacturerID INT CONSTRAINT PK_ManufacturerID
 PRIMARY KEY,
 [Name] NVARCHAR(50) NOT NULL,
 EstablishedOn DATE NOT NULL
)

CREATE TABLE Models
(
 ModelID INT CONSTRAINT PK_ModelID
 PRIMARY KEY,
 [Name] NVARCHAR(30) NOT NULL,
 ManufacturerID INT NOT NULL
)


INSERT INTO Models
VALUES 
(101,'X1',1),
(102,'i6',1),
(103,'Model S',2),
(104,'Model X',2),
(105,'Model 3',2),
(106,'Nova',3)

INSERT INTO Manufacturers
VALUES
(1,'BMW','07/03/1916'),
(2,'Tesla','1/01/2003'),
(3,'Lada','01/05/1966')

ALTER TABLE Models
ADD CONSTRAINT FK_Model_ManufacturerID 
FOREIGN KEY (ManufacturerID) 
REFERENCES Manufacturers(ManufacturerID)
