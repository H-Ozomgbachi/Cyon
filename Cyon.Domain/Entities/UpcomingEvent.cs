namespace Cyon.Domain.Entities
{
    public class UpcomingEvent : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string ModifiedBy { get; set; }
    }
}