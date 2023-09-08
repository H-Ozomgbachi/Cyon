namespace Cyon.Domain.DTOs.Biz
{
    public class CreateBizProductReviewDto
    {
        public string Comment { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public int Rating { get; set; }

        public Guid BizProductId { get; set; }
    }
}
