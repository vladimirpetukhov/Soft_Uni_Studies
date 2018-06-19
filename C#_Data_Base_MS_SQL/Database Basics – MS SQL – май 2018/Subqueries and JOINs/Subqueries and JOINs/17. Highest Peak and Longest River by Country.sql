SELECT TOP(5) Result.CountryName,Result.HighestPeakElevation,Result.LongestRiverLength
FROM
(
SELECT HPE.CountryName,HPE.HighestPeakElevation,MAX(R.Length) AS LongestRiverLength
FROM
(
SELECT C.CountryCode, CountryName,MAX(P.Elevation) AS HighestPeakElevation
FROM Countries AS C
LEFT JOIN MountainsCountries AS MC ON MC.CountryCode=C.CountryCode
LEFT JOIN Mountains AS M ON M.Id=MC.MountainId
LEFT JOIN Peaks AS P ON P.MountainId=M.Id
GROUP BY CountryName,C.CountryCode
) AS HPE
JOIN CountriesRivers AS CR ON CR.CountryCode=HPE.CountryCode
LEFT JOIN Rivers AS R ON R.Id=CR.RiverId
GROUP BY HPE.CountryName,HPE.HighestPeakElevation
) AS Result
ORDER BY Result.HighestPeakElevation DESC,
		 Result.LongestRiverLength DESC,
		 result.CountryName ASC