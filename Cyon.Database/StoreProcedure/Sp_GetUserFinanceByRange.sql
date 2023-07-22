CREATE PROCEDURE [dbo].[Sp_GetUserFinanceByRange]
	@StartDate datetime2,
	@EndDate datetime2,
	@UserId nvarchar(450)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [UserFinances]
	WHERE [UserId] = @UserId and CAST([DateCollected] AS DATE) >= CONVERT(DATE, @StartDate) and CAST([DateCollected] AS DATE) <= CONVERT(DATE, @EndDate)
END