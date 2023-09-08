namespace Cyon.Domain.DTOs.Biz
{
    public class CreateBizProductTransactionDto
    {
        public decimal AmountPaid { get; set; }
        public string ClientEmail { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }

        public Guid BizProductId { get; set; }
    }
}
