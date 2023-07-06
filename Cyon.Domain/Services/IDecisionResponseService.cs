using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Models.Decision;

namespace Cyon.Domain.Services
{
    public interface IDecisionResponseService
    {
        Task<IEnumerable<DecisionResponseModel>> GetDecisionResponses(Guid decisionId, Pagination pagination);
        Task<DecisionResponseModel> GetMyDecisionResponse(Guid decisionId, string userCode);
        Task<DecisionResponseModel> AddDecisionResponse(CreateDecisionResponseDto decisionResponseDto, string userCode);
    }
}
