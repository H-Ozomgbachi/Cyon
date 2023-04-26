CREATE PROCEDURE [dbo].[Sp_GetApologySummary]
	@UserId nvarchar(450)
AS
BEGIN
	SELECT (SELECT COUNT(*) FROM [Apologies] WHERE UserId = @UserId AND IsResolved = 1 AND IsRejected = 0) AS TotalApproved,
	(SELECT COUNT(*) FROM [Apologies] WHERE UserId = @UserId AND IsResolved = 1 AND IsRejected = 1) AS TotalDeclined
END