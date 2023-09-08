using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Models.Biz;

namespace Cyon.Domain.Services
{
    public interface IBizProductService
    {
        Task<BizProductModel> CreateBizProduct(CreateBizProductDto createBizProductDto, string modifiedBy);
        Task UpdateBizProduct(UpdateBizProductDto updateBizProductDto, string modifiedBy);
        Task DeleteBizProduct(Guid bizProductId);
        Task<BizProductModel> GetBizProduct(Guid bizProductId);
        Task<IEnumerable<BizProductModel>> GetBizProducts(Pagination pagination, Guid bizId);
    }
}
