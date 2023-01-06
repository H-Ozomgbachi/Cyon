namespace Cyon.Domain.DTOs.Finance
{
    public class GetAccountStatementDto
    {
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(-30);
    }
}
