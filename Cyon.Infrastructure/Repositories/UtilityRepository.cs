using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Repositories;
using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UtilityRepository(IHttpClientFactory httpClientFactory, ILogger<UtilityRepository> logger, IOptions<AppSettings> appSettings, IWebHostEnvironment webHostEnvironment)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
            _appSettings = appSettings;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<string> UploadFile(IFormFile formFile)
        {
            if (formFile.Length > (3 * 1000 * 1024))
            {
                throw new BadRequestException("File size too large, maximum is 3MB");
            }
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

        public string LoadEmailTemplate(string templateFileName)
        {
            string templatePath = Path.Combine(_webHostEnvironment.WebRootPath, "EmailTemplates", templateFileName);
            string templateContent = File.ReadAllText(templatePath);
            return templateContent;
        }
    }
}
