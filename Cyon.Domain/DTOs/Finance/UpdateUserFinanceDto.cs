namespace Cyon.Domain.DTOs.Finance
{
    public class UpdateUserFinanceDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCollected { get; set; }
        public decimal Amount { get; set; }
    }
}
