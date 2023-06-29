using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.DTOs.Minutes
{
    public class CreateMinuteDto
    {
        public IFormFile Content { get; set; }
        public DateTime DateOfMeeting { get; set; }
    }
}
