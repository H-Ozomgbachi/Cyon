using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;

namespace Cyon.Domain.Services
{
    public interface IBizCategoryCategoryService
    {
        Task<BizCategoryModel> AddBizCategory(CreateBizCategoryDto bizDto, string modifiedBy);
        Task DeleteBizCategory(Guid bizId);
        Task<BizCategoryModel> GetBizCategory(Guid bizId);
        Task<IEnumerable<BizCategoryModel>> GetBizCategorys(Pagination pagination);
    }
}
