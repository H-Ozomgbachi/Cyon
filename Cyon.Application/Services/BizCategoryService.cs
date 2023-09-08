using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Biz;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Biz;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class BizCategoryService : IBizCategoryCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BizCategoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BizCategoryModel> AddBizCategory(CreateBizCategoryDto bizDto, string modifiedBy)
        {
            BizCategory bizCategory = _mapper.Map<BizCategory>(bizDto);
            bizCategory.CreatedBy = modifiedBy;

            await _unitOfWork.BizCategoryRepository.AddAsync(bizCategory);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BizCategoryModel>(bizCategory);
        }

        public async Task DeleteBizCategory(Guid bizId)
        {
            BizCategory bizCategory = await _unitOfWork.BizCategoryRepository.GetByIdAsync(bizId);

            if (bizCategory == null)
            {
                throw new NotFoundException("Biz category was not found");
            }

            _unitOfWork.BizCategoryRepository.Delete(bizCategory);
            await _unitOfWork.SaveAsync();
        }

        public async Task<BizCategoryModel> GetBizCategory(Guid bizId)
        {
            BizCategory bizCategory = await _unitOfWork.BizCategoryRepository.GetByIdAsync(bizId);

            if (bizCategory == null)
            {
                throw new NotFoundException("Biz category was not found");
            }

            return _mapper.Map<BizCategoryModel>(bizCategory);
        }

        public async Task<IEnumerable<BizCategoryModel>> GetBizCategorys(Pagination pagination)
        {
            IEnumerable<BizCategory> bizCategories = await _unitOfWork.BizCategoryRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<BizCategoryModel>>(bizCategories);
        }
    }
}