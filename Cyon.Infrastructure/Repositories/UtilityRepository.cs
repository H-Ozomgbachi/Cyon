using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Cyon.Infrastructure.Repositories
{
    public class UtilityRepository : IUtilityRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<UtilityRepository> _logger;
        private readonly IOptions<AppSettings> _appSettings;

        public UtilityRepository(IHttpClientFactory httpClientFactory, ILogger<UtilityRepository> logger, IOptions<AppSettings> appSettings)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _appSettings = appSettings;
        }

        public async Task<string> UploadFile(IFormFile formFile)
        {
            string result;
            try
            {
                _logger.LogInformation("Upload of file started");
                var client = _httpClientFactory.CreateClient("FileServer");

                byte[] data;
                using (var br = new BinaryReader(formFile.OpenReadStream()))
                {
                    data = br.ReadBytes((int)formFile.OpenReadStream().Length);
                }
                ByteArrayContent bytes = new(data);
                StringContent projectName = new("cyon");

                MultipartFormDataContent multiContent = new()
                {
                    {bytes, "file", formFile.FileName },
                    {projectName, "projectName" }
                };

                var response = await client.PostAsync(_appSettings.Value.FileServerSingle, multiContent);

                result = await response.Content.ReadAsStringAsync();
                _logger.LogInformation($"Added a new file with url {result}");
            }
            catch (Exception ex)
            {
                _logger.LogError("Error sending file to File Storage Server", ex.Message);
                throw new BadRequestException("A third party service did not respond properly");
            }
            return result;
        }
    }
}
