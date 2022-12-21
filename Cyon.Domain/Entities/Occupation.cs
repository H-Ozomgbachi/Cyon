namespace Cyon.Domain.Entities
{
    public class Occupation : BaseEntity
    {
        public string JobTitle { get; set; }
        public string Company { get; set; }
        public bool IsStudent { get; set; }
        public bool IsUnemployed { get; set; }
        public string CanDo { get; set; }
        public Guid UserId { get; set; }
    }
}