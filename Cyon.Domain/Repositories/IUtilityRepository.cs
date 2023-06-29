using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.Repositories
{
    public interface IUtilityRepository
    {
        Task<string> UploadFile(IFormFile formFile);
    }
}