using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.DTOs.Announcement
{
    public class CreateAnnouncementDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IFormFile Photo { get; set; }
    }
}
