namespace Cyon.Domain.DTOs.Decision
{
    public class CreateDecisionDto
    {
        public string Question { get; set; }
        public List<string> Options { get; set; }
    }
}