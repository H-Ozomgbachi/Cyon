using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Models.Decision;

namespace Cyon.Domain.Services
{
    public interface IDecisionService
    {
        Task<DecisionModel> AddDecision(CreateDecisionDto decisionDto, string modifiedBy);
        Task UpdateDecision(UpdateDecisionDto decisionDto, string modifiedBy);
        Task DeleteDecision(Guid decisionId);
        Task<DecisionModel> GetDecision(Guid decisionId);
        Task<IEnumerable<DecisionModel>> GetDecisions(Pagination pagination);
    }
}
