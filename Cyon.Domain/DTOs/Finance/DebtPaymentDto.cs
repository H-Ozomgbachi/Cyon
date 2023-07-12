namespace Cyon.Domain.DTOs.Finance
{
    public class DebtPaymentDto
    {
        public Guid DebtId { get; set; }
        public decimal AmountToClear { get; set; }
    }
}
