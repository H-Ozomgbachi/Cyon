namespace Cyon.Domain.DTOs.Decision
{
    public class UpdateDecisionDto
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Options { get; set; }
        public bool IsClosed { get; set; }
        public bool IsActive { get; set; }
    }
}
