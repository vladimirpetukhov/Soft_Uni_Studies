SELECT MC.CountryCode,M.MountainRange,P.PeakName,P.Elevation
FROM Mountains AS M
JOIN MountainsCountries AS MC ON MC.MountainId=M.Id
JOIN Peaks AS P ON P.MountainId=M.Id
WHERE MC.CountryCode='BG'AND P.Elevation>2835
ORDER BY P.Elevation DESC
