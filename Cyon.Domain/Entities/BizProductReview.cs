namespace Cyon.Domain.Entities
{
    public class BizProductReview : BaseEntity
    {
        public string Comment { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public int Rating { get; set; }

        public Guid BizProductId { get; set; }
        public BizProduct BizProduct { get; set; }
    }
}
