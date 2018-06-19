SELECT TOP(5)
	 CountryName AS Country,
	 ISNULL(P.PeakName,'(no highest peak)') AS [Highest Peak Name],
	 ISNULL(MAX(P.Elevation),0) AS HighestPeakElevation,
	 ISNULL(M.MountainRange ,'(no mountain)') AS Mountain
FROM Countries AS C
LEFT JOIN MountainsCountries AS MC ON MC.CountryCode=C.CountryCode
LEFT JOIN Mountains AS M ON M.Id=MC.MountainId
LEFT JOIN Peaks AS P ON P.MountainId=M.Id
GROUP BY CountryName,MountainRange,P.PeakName
ORDER BY Country,[Highest Peak Name]