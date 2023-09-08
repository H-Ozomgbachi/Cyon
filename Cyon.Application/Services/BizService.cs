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
    public class BizService : IBizService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BizService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BizModel> AddBiz(CreateBizDto bizDto, string modifiedBy)
        {
            Biz biz = _mapper.Map<Biz>(bizDto);
            biz.CreatedBy = modifiedBy;

            await _unitOfWork.BizRepository.AddAsync(biz);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<BizModel>(biz);
        }

        public async Task DeleteBiz(Guid bizId)
        {
            Biz biz = await _unitOfWork.BizRepository.GetByIdAsync(bizId);

            if (biz == null)
            {
                throw new NotFoundException("Biz was not found");
            }

            _unitOfWork.BizRepository.Delete(biz);
            await _unitOfWork.SaveAsync();
        }

        public async Task<BizModel> GetBiz(Guid bizId)
        {
            Biz biz = await _unitOfWork.BizRepository.GetByIdAsync(bizId);

            if (biz == null)
            {
                throw new NotFoundException("Biz was not found");
            }

            return _mapper.Map<BizModel>(biz);
        }

        public async Task<IEnumerable<BizModel>> GetBizs(Pagination pagination)
        {
            var filter = new List<Expression<Func<Biz, bool>>>
            {
                f => f.IsActive == true
            };
            IEnumerable<Biz> bizs = await _unitOfWork.BizRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<BizModel>>(bizs);
        }

        public async Task UpdateBiz(UpdateBizDto bizDto, string modifiedBy)
        {
            Biz biz = await _unitOfWork.BizRepository.GetByIdAsync(bizDto.Id);

            if (biz == null)
            {
                throw new NotFoundException("Biz not found");
            }

            _mapper.Map(bizDto, biz);
            await _unitOfWork.BizRepository.UpdateAsync(biz);
            await _unitOfWork.SaveAsync();
        }
    }
}
