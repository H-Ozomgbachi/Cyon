namespace Cyon.Domain.Entities
{
    public class DeactivateRequest : BaseEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string ReasonToDeactivate { get; set; }
        public string Phone { get; set; }
    }
}
