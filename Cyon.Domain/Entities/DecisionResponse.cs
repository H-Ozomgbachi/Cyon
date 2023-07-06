namespace Cyon.Domain.Entities
{
    public class DecisionResponse : BaseEntity
    {
        public string Response { get; set; }

        public Guid DecisionId { get; set; }
        public Decision Decision { get; set; }
    }
}
