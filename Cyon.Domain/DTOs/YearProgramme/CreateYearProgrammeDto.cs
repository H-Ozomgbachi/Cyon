using Microsoft.AspNetCore.Http;

namespace Cyon.Domain.DTOs.YearProgramme
{
    public class CreateYearProgrammeDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IFormFile Image { get; set; }
        public string Scope { get; set; }
        public string Year { get; set; }
    }
}
