namespace Cyon.Domain.Entities
{
    public class BizProductTransaction : BaseEntity
    {
        public decimal AmountPaid { get; set; }
        public string ClientEmail { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string PayReceipt { get; set; }
        public bool IsConfirmed { get; set; } = false;

        public Guid BizProductId { get; set; }
        public BizProduct BizProduct { get; set; }
    }
}