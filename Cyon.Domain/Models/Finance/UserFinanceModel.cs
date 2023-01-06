namespace Cyon.Domain.Models.Finance
{
    public class UserFinanceModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime DateCollected { get; set; }
        public decimal Amount { get; set; }
    }
}
