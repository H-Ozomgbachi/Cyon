namespace Cyon.Domain.DTOs.Finance
{
    public class UpdateOrganisationFinanceDto
    {
        public Guid Id { get; set; }
        public string FinanceType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
