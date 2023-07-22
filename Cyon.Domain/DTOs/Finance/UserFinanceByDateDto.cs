namespace Cyon.Domain.DTOs.Finance
{
    public class UserFinanceByDateDto
    {
        public string UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
