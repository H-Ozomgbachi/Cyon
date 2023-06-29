namespace Cyon.Domain.DTOs.Finance
{
    public class CreateUserFinanceDto
    {
        public string Description { get; set; }
        public DateTime DateCollected { get; set; }
        public decimal Amount { get; set; }
        public Guid UserId { get; set; }
        public string FinanceType { get; set; }
    }
}
