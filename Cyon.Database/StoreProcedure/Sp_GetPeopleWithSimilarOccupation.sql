CREATE PROCEDURE [dbo].[Sp_GetPeopleWithSimilarOccupation]
	@UserId uniqueIdentifier,
	@JobKeyWord nvarchar(256),
	@Skip int,
	@Limit int
AS
BEGIN
	SELECT * FROM [Occupations] o
	INNER JOIN [AspNetUsers] u ON o.UserId = u.Id
	WHERE o.UserId != @UserId AND  (o.JobTitle LIKE '%' + @JobKeyWord + '%' OR o.CanDo LIKE '%' + @JobKeyWord + '%')
	ORDER BY o.JobTitle
	OFFSET @Skip ROWS
	FETCH NEXT @Limit ROWS ONLY
END