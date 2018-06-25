SELECT FirstName,LastName
FROM Clients
WHERE BirthDate BETWEEN '1977-01-01' AND '1994-12-31' 
ORDER BY FirstName,LastName,Id ASC