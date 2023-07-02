namespace Cyon.Domain.Models.Announcement
{
    public class AnnouncementModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateAdded { get; set; }
        public string ReadBy { get; set; }
    }
}
