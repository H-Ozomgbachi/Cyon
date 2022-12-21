using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Chaplain;
using Cyon.Domain.Models.Chaplain;

namespace Cyon.Domain.Services
{
    public interface IChaplainService
    {
        Task<ChaplainModel> AddChaplain(ChaplainCreateDto chaplainDto, Guid modifiedBy);
        Task UpdateChaplain(ChaplainUpdateDto chaplainDto, Guid modifiedBy);
        Task DeleteChaplain(Guid chaplainId);
        Task<ChaplainModel> GetChaplain(Guid chaplainId);
        Task<IEnumerable<ChaplainModel>> GetAllChaplains();
        Task<IEnumerable<ChaplainModel>> GetChaplains(Pagination pagination);
    }
}
