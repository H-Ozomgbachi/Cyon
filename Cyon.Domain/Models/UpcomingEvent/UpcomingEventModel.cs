namespace Cyon.Domain.Models.UpcomingEvent
{
    public class UpcomingEventModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime ImportantDate { get; set; }
    }
}