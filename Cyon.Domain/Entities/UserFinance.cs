namespace Cyon.Domain.Entities
{
    public class UserFinance : BaseEntity
    {
        public string Description { get; set; }
        public DateTime DateCollected { get; set; }
        public decimal Amount { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime DateModified { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}
