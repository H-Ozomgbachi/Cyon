using Cyon.Domain.Common;
using Cyon.Domain.DTOs.YearProgramme;
using Cyon.Domain.Models.YearProgramme;

namespace Cyon.Domain.Services
{
    public interface IYearProgrammeService
    {
        Task<IEnumerable<YearProgrammeModel>> GetYearProgrammes(Pagination pagination);
        Task<YearProgrammeModel> GetYearProgrammeById(Guid id);
        Task<YearProgrammeModel> AddYearProgramme(CreateYearProgrammeDto createYearProgrammeDto);
        Task UpdateYearProgramme(UpdateYearProgrammeDto updateYearProgrammeDto);
        Task DeleteYearProgramme(Guid id);
    }
}
