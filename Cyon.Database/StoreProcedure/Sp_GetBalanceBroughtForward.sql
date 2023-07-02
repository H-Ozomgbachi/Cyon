CREATE PROCEDURE [dbo].[Sp_GetBalanceBroughtForward]
	@StartDate datetime2,
	@EndDate datetime2
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	COALESCE((SELECT SUM(Amount) FROM [OrganisationFinances] WHERE [FinanceType] = 'Income' and CAST([Date] AS DATE) < CONVERT(DATE, @StartDate)), 0) -
	COALESCE((SELECT SUM(Amount) FROM [OrganisationFinances] WHERE [FinanceType] = 'Expenditure' and CAST([Date] AS DATE) < CONVERT(DATE, @StartDate)), 0)
	as BalanceBroughtForward
END