namespace Cyon.Domain.DTOs.Finance
{
    public class PayDuesByMonthDto
    {
        public Guid UserId { get; set; }
        public string Description { get; set; }
        public int DuesCostMonthly { get; set; }
        public int FromMonth { get; set; }
        public int FromYear { get; set; }
        public int ToMonth { get; set; }
        public int ToYear { get; set; }
    }
}
