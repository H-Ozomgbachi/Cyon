namespace Cyon.Domain.Models.Finance
{
    public class OrganisationAccountStatementModel
    {
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal BalanceBroughtForward { get; set; }

        public IEnumerable<OrganisationFinanceModel> Finances { get; set; }
        public decimal BalanceAtHand { get; set; }
    }
}