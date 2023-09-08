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
    public class BizProductService : IBizProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IPhotoService _photoService;

        public BizProductService(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _photoService = photoService;
        }

        public async Task<BizProductModel> CreateBizProduct(CreateBizProductDto createBizProductDto, string modifiedBy)
        {
            BizProduct bizProduct = _mapper.Map<BizProduct>(createBizProductDto);
            bizProduct.CreatedBy = modifiedBy;
            bizProduct.ImgUrl = await _photoService.UploadOneImage(createBizProductDto.Img);

            await _unitOfWork.BizProductRepository.AddAsync(bizProduct);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BizProductModel>(bizProduct);
        }

        public async Task DeleteBizProduct(Guid bizProductId)
        {
            var bizProduct = await _unitOfWork.BizProductRepository.GetByIdAsync(bizProductId);

            if (bizProduct is null)
            {
                throw new NotFoundException("Biz product does not exist");
            }
            _unitOfWork.BizProductRepository.Delete(bizProduct);
            await _unitOfWork.SaveAsync();
        }

        public async Task<BizProductModel> GetBizProduct(Guid bizProductId)
        {
            var bizProduct = await _unitOfWork.BizProductRepository.GetByIdAsync(bizProductId);

            if (bizProduct is null)
            {
                throw new NotFoundException("Biz product does not exist");
            }
            return _mapper.Map<BizProductModel>(bizProduct);
        }

        public async Task<IEnumerable<BizProductModel>> GetBizProducts(Pagination pagination, Guid bizId)
        {
            var filter = new List<Expression<Func<BizProduct, bool>>>
            {
                x => x.BizId == bizId
            };
            var result = await _unitOfWork.BizProductRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<BizProductModel>>(result);
        }

        public async Task UpdateBizProduct(UpdateBizProductDto updateBizProductDto, string modifiedBy)
        {
            var bizProduct = await _unitOfWork.BizProductRepository.GetByIdAsync(updateBizProductDto.Id);

            if (bizProduct is null)
            {
                throw new NotFoundException("Biz product not found");
            }
            _mapper.Map(updateBizProductDto, bizProduct);
            await _unitOfWork.BizProductRepository.UpdateAsync(bizProduct);
            await _unitOfWork.SaveAsync();
        }
    }
}
