using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.DTOs.Photos
{
    public class PictureDto
    {
        public IFormFile File { get; set; }
    }
}
