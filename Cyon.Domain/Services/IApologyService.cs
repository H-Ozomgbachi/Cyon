using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Domain.Services
{
    public interface IApologyService
    {
        Task<ApologyModel> AddApology(CreateApologyDto apologyDto, Guid userId, string userCode);
        Task<IEnumerable<ApologyModel>> GetApologies(Pagination pagination, bool isPending);
        Task UpdateApology(Apology apology);
        Task DeleteApology(Guid id);
        Task<IEnumerable<ApologyModel>> GetApologiesByUser(Guid userId, Pagination pagination);
        Task ApproveApology(ResolveApologyDto apology, string doneBy);
        Task DeclineApology(ResolveApologyDto apology);
        Task<ApologySummaryModel> GetApologySummary(Guid userId);
    }
}
