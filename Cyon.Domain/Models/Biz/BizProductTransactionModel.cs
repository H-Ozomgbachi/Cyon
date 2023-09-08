namespace Cyon.Domain.Models.Biz
{
    public class BizProductTransactionModel
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
