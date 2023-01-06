namespace Cyon.Domain.Entities
{
    public class OrganisationFinance : BaseEntity
    {
        public string FinanceType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }
    }
}
