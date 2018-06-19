SELECT COUNT(MCI.CountryCode) AS CountryCode
FROM
(
SELECT  C.CountryCode,MC.MountainId
FROM Countries AS C
FULL JOIN MountainsCountries AS MC ON MC.CountryCode=C.CountryCode

) AS MCI
WHERE MCI.MountainId IS NULL
