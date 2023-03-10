CREATE PROCEDURE [dbo].[Sp_GetFinancesForGivenDateRange]
	@StartDate datetime2,
	@EndDate datetime2
AS
BEGIN
	SET NOCOUNT ON;
	SELECT * FROM [OrganisationFinances]
	WHERE CAST([Date] AS DATE) >= @StartDate and CAST([Date] AS DATE) <= @EndDate
END