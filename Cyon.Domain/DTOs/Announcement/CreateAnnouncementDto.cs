namespace Cyon.Domain.DTOs.Announcement
{
    public class CreateAnnouncementDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime ImportantDate { get; set; }
    }
}
