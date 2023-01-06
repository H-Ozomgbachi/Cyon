CREATE PROCEDURE [dbo].[Sp_GetOrganisationFinanceBalance]

AS
BEGIN
	SET NOCOUNT ON;
	SELECT (SELECT SUM(Amount) FROM [OrganisationFinances] WHERE FinanceType = 'Income') as totalIncome,
	(SELECT SUM(Amount) FROM [OrganisationFinances] WHERE FinanceType = 'Expenditure') as totalExpenditure
END
