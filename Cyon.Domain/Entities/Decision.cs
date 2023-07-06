namespace Cyon.Domain.Entities
{
    public class Decision : BaseEntity
    {
        public string Question { get; set; }
        public string Options { get; set; }
        public string Result { get; set; } = string.Empty;
        public bool IsClosed { get; set; } = false;
        public bool IsActive { get; set; } = true;

        public ICollection<DecisionResponse> DecisionResponses { get; set; }
    }
}
