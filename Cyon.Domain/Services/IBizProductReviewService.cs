using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;

namespace Cyon.Domain.Services
{
    public interface IBizProductReviewService
    {
        Task<BizProductReviewModel> CreateAsync(CreateBizProductReviewDto createBizProductReview, string modifiedBy);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<BizProductReviewModel>> GetAllAsync(Pagination pagination, Guid productId);
    }
}
