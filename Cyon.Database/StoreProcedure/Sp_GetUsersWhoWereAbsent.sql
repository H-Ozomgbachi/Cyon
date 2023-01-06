CREATE PROCEDURE [dbo].[Sp_GetUsersWhoWereAbsent]
	@PresentUsersIds nvarchar(max)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [AspNetUsers]
	WHERE IsActive = 1 AND Id NOT IN (SELECT value FROM STRING_SPLIT(@PresentUsersIds, ','))
END