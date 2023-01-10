using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Occupation;
using Cyon.Domain.Models.Authentication;
using Cyon.Domain.Models.Occupation;

namespace Cyon.Domain.Services
{
    public interface IOccupationService
    {
        Task<OccupationModel> AddOccupation(CreateOccupationDto occupationDto, Guid userId);
        Task<IEnumerable<OccupationModel>> GetOccupations(Pagination pagination);
        Task<OccupationModel> GetOccupationByUser(Guid userId);
        Task UpdateOccupation(UpdateOccupationDto occupationDto);
        Task<IEnumerable<AccountModelConcise>> PeopleWithSimilarOccupation(string jobKeyWord, Pagination pagination, Guid currentUser);
    }
}
