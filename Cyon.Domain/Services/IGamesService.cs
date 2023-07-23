using Cyon.Domain.DTOs.Games;
using Cyon.Domain.Models.Games;

namespace Cyon.Domain.Services
{
    public interface IGamesService
    {
        Task PostTreasureHuntResult(CreateTreasureHuntResultDto createTreasureHuntResult);
        Task<IEnumerable<TreasureHuntResultModel>> GetTreasureHuntResults();
        Task ClearTreasureHuntResults();
    }
}
