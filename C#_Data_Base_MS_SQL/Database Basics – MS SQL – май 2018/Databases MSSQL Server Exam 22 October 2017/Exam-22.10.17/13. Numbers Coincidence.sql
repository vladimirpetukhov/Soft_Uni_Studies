

WITH Usernames_CTE([User Usernames]) AS
(
SELECT u.Username
FROM Users AS u
JOIN Reports AS r ON r.UserId=u.Id
WHERE u.Username LIKE '[0-9]%' OR u.Username LIKE '%[0-9]'
)
SELECT Usernames_CTE