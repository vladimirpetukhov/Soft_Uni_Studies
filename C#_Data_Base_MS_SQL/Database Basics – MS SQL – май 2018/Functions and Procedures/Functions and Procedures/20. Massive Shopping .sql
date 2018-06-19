DECLARE @byer_username NVARCHAR(50)='Stamat';
DECLARE @game_name NVARCHAR(50)='Safflower';

DECLARE @byer_cash MONEY=(SELECT u.Username,SUM(ug.Cash) AS TotalCash
						  FROM UsersGames AS ug
						  JOIN Users AS u ON u.Id=ug.UserId
						  WHERE u.Username LIKE @byer_username
						  GROUP BY u.Username )



--SELECT * FROM
--(
--	SELECT  UG.UserId,U.FirstName,UG.GameId,G.Name,UGI.ItemId
--	FROM UsersGames AS UG
--	JOIN Users AS U ON U.Id=UG.UserId
--	JOIN Games AS G ON G.Id=UG.GameId
--	JOIN UserGameItems AS UGI ON UGI.UserGameId=UG.GameId
--) AS INFO

--JOIN Items AS I ON I.Id=INFO.ItemId


