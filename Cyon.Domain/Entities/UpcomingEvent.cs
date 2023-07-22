namespace Cyon.Domain.Entities
{
    public class UpcomingEvent : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ImportantDate { get; set; } = DateTime.MinValue;
    }
}