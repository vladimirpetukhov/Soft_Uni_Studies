SELECT H.Manufacturer,H.AverageConsumption
FROM 
	(SELECT TOP(7) m.Manufacturer,
				  AVG(m.Consumption) AS [AverageConsumption],
				  COUNT(m.Id) AS V
	FROM Vehicles AS v
	JOIN Orders AS o ON o.VehicleId=v.Id
	JOIN Models AS m ON m.Id=v.ModelId
	
	GROUP BY m.Manufacturer,m.Model
	ORDER BY V DESC) AS H
	WHERE AverageConsumption BETWEEN 5 AND 15
ORDER BY H.Manufacturer, H.AverageConsumption 