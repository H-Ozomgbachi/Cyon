CREATE PROCEDURE [dbo].[Sp_GetUserFinanceSummary]
	@UserId uniqueidentifier
AS
BEGIN
	SET NOCOUNT ON;
	SELECT (SELECT SUM(Amount) FROM [UserFinances] WHERE FinanceType = 'Pay' AND UserId = @UserId) as contribution,
	(SELECT SUM(Amount) FROM [UserFinances] WHERE FinanceType = 'Debt' AND UserId = @userId) as debt
END