namespace Cyon.Domain.Models.Biz
{
    public class BizProductReviewModel
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public uint Rating { get; set; }

        public Guid BizProductId { get; set; }
    }
}
