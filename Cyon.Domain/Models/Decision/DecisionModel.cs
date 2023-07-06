namespace Cyon.Domain.Models.Decision
{
    public class DecisionModel
    {
        public Guid Id { get; set; }
        public string Question { get; set; }
        public string Options { get; set; }
        public string Result { get; set; }
        public bool IsClosed { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
