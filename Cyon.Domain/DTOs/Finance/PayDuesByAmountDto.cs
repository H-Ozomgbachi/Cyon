using System.Text.Json.Serialization;

namespace Cyon.Domain.DTOs.Finance
{
    public class PayDuesByAmountDto
    {
        public Guid UserId { get; set; }
        public int AmountPaid { get; set; }
        public int DuesCostMonthly { get; set; }
        [JsonIgnore]
        public string Description { get; set; } = "Monthly Dues";
    }
}