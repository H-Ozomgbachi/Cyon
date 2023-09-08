using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Biz;
using Cyon.Domain.Services;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class BizProductReviewService : IBizProductReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BizProductReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BizProductReviewModel> CreateAsync(CreateBizProductReviewDto createBizProductReview, string modifiedBy)
        {
            BizProductReview bizProductReview = _mapper.Map<BizProductReview>(createBizProductReview);
            bizProductReview.CreatedBy = modifiedBy;

            BizProduct product = await _unitOfWork.BizProductRepository.GetByIdAsync(createBizProductReview.BizProductId);
            product.RatingValue += createBizProductReview.Rating;
            product.TotalRating += 1;
            product.AvgRating = product.RatingValue / product.TotalRating;

            await _unitOfWork.BizProductRepository.UpdateAsync(product);

            await _unitOfWork.BizProductReviewRepository.AddAsync(bizProductReview);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BizProductReviewModel>(bizProductReview);
        }

        public async Task DeleteAsync(Guid id)
        {
            BizProductReview bizProductReview = await _unitOfWork.BizProductReviewRepository.GetByIdAsync(id);

            if (bizProductReview is null)
            {
                throw new NotFoundException("Review not found");
            }
            BizProduct product = await _unitOfWork.BizProductRepository.GetByIdAsync(bizProductReview.BizProductId);
            product.RatingValue -= bizProductReview.Rating;
            product.TotalRating -= 1;
            product.AvgRating = product.RatingValue / product.TotalRating;

            await _unitOfWork.BizProductRepository.UpdateAsync(product);

            _unitOfWork.BizProductReviewRepository.Delete(bizProductReview);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BizProductReviewModel>> GetAllAsync(Pagination pagination, Guid productId)
        {
            var filter = new List<Expression<Func<BizProductReview, bool>>>
            {
                x => x.BizProductId == productId
            };
            var result = await _unitOfWork.BizProductReviewRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);
            return _mapper.Map<IEnumerable<BizProductReviewModel>>(result);
        }
    }
}
