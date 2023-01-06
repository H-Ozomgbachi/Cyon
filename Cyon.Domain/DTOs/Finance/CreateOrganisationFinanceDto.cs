namespace Cyon.Domain.DTOs.Finance
{
    public class CreateOrganisationFinanceDto
    {
        public string FinanceType { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
