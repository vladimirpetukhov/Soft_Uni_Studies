SELECT Ranking.ContinentCode,Ranking.CurrencyCode,Ranking.CurrencyUssage
FROM

(
SELECT 
	Info.ContinentCode,
	Info.CurrencyCode,
	Info.CurrencyUssage,
	DENSE_RANK() OVER(PARTITION BY(Info.ContinentCode)
	ORDER BY Info.CurrencyUssage DESC) AS [Rank]
FROM
		(
		SELECT ContinentCode, CurrencyCode,COUNT(CurrencyCode) AS CurrencyUssage
		FROM Countries
		GROUP BY CurrencyCode,ContinentCode
		)AS Info
) AS Ranking
WHERE Ranking.[Rank]= 1 AND CurrencyUssage>1


