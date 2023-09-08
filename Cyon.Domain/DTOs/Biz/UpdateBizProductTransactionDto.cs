namespace Cyon.Domain.DTOs.Biz
{
    public class UpdateBizProductTransactionDto
    {
        public Guid Id { get; set; }
        public decimal AmountPaid { get; set; }
        public string ClientEmail { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string PayReceipt { get; set; }
        public bool IsConfirmed { get; set; }

        public Guid BizProductId { get; set; }
    }
}