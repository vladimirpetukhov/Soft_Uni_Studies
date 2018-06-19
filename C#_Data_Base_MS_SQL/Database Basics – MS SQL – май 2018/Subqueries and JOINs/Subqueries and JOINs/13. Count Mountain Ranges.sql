SELECT  CountryCode,COUNT(CountryCode) AS MountainRanges
FROM MountainsCountries
GROUP BY CountryCode
HAVING CountryCode IN ('BG','RU','US')