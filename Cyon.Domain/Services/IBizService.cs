using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;

namespace Cyon.Domain.Services
{
    public interface IBizService
    {
        Task<BizModel> AddBiz(CreateBizDto bizDto, string modifiedBy);
        Task UpdateBiz(UpdateBizDto bizDto, string modifiedBy);
        Task DeleteBiz(Guid bizId);
        Task<BizModel> GetBiz(Guid bizId);
        Task<IEnumerable<BizModel>> GetBizs(Pagination pagination);
    }
}
