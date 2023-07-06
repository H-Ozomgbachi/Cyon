namespace Cyon.Domain.Models.Decision
{
    public class DecisionResponseModel
    {
        public Guid Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string CreatedBy { get; set; }
        public string Response { get; set; }
        public Guid DecisionId { get; set; }
    }
}