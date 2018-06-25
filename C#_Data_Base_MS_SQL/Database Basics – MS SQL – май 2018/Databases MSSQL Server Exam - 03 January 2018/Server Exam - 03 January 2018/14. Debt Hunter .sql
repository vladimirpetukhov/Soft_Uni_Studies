SELECT *
FROM
	(SELECT 
		   CONCAT(c.FirstName,' ',c.LastName) AS [Category Name],
		   c.Email,
		   t.Name ,
		   SUM(o.Bill) AS Bills  
	FROM Orders AS o
	JOIN Clients AS c ON c.Id=o.ClientId
	JOIN Towns AS t ON t.Id=o.TownId
	WHERE c.CardValidity<o.CollectionDate
	GROUP BY CONCAT(c.FirstName,' ',c.LastName),
			 c.Email,
			 t.Name
			  ) AS H