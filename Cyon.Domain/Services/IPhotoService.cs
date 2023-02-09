using Cyon.Domain.DTOs.Photos;
using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.Services
{
    public interface IPhotoService
    {
        Task<string> UploadProfilePicture(PictureDto pictureDto);
        Task<string> UploadOneImage(IFormFile file);
    }
}
