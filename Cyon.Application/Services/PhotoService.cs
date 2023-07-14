using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Cyon.Domain.DTOs.Photos;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Cyon.Application.Services
{
    public class PhotoService : IPhotoService
    {
        private readonly IConfiguration _config;
        private readonly CloudinarySettings _cloudinarySettings;
        private readonly Cloudinary _cloudinary;

        public PhotoService(IConfiguration config)
        {
            _config = config;
            _cloudinarySettings = _config.GetSection("CloudinarySettings").Get<CloudinarySettings>();

            Account account = new(_cloudinarySettings.CloudName, _cloudinarySettings.ApiKey, _cloudinarySettings.ApiSecret);

            _cloudinary = new(account);
        }

        public async Task<string> UploadOneImage(IFormFile file)
        {
            if (file.Length > 0)
            {
                if (file.Length > (3 * 1000 * 1024))
                {
                    throw new BadRequestException("File size too large, maximum is 3MB");
                }
                ImageUploadResult uploadResult = new();

                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.Url.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public async Task<string> UploadProfilePicture(PictureDto pictureDto)
        {
            var file = pictureDto.File;

            if (file.Length > 0)
            {
                ImageUploadResult uploadResult = new();

                using var stream = file.OpenReadStream();
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(file.Name, stream),
                    Transformation = new Transformation().Width(150).Height(150).Gravity("face").Crop("thumb")
                };

                uploadResult = await _cloudinary.UploadAsync(uploadParams);

                return uploadResult.Url.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
