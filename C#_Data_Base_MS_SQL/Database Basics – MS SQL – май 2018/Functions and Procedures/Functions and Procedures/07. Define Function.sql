GO
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(max), @word VARCHAR(max))
RETURNS BIT
AS
BEGIN
  DECLARE @isComprised INT ;
  DECLARE @currentIndex INT = 1;
  DECLARE @currentChar CHAR(1);
 
  WHILE(@currentIndex <= LEN(@word))
  BEGIN

    SET @currentChar = SUBSTRING(@word, @currentIndex, 1);
	SET @isComprised=CHARINDEX(@currentChar, @setOfLetters);
    IF( @isComprised= 0)
	BEGIN
      RETURN 0;
	END
    SET @currentIndex+=1;
	
  END

  RETURN 1;
  

END
GO
EXEC dbo.ufn_IsWordComprised 'oistmiahf','Sofia'
DROP FUNCTION dbo.ufn_IsWordComprised 