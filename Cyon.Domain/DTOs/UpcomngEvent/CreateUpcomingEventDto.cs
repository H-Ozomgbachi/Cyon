using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.DTOs.UpcomngEvent
{
    public class CreateUpcomingEventDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}
