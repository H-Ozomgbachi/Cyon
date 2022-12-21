using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Chaplain;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Chaplain;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class ChaplainService : IChaplainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChaplainService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ChaplainModel> AddChaplain(ChaplainCreateDto chaplainDto, Guid modifiedBy)
        {
            Chaplain chaplain = _mapper.Map<Chaplain>(chaplainDto);
            chaplain.ModifiedBy = modifiedBy;

            await _unitOfWork.ChaplainRepository.AddAsync(chaplain);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<ChaplainModel>(chaplain);
        }

        public async Task DeleteChaplain(Guid chaplainId)
        {
            bool exists = await _unitOfWork.ChaplainRepository.ExistAsync(x => x.Id == chaplainId);

            if (exists == false)
            {
                throw new NotFoundException("Chaplain does not exist");
            }

            Chaplain chaplain = await _unitOfWork.ChaplainRepository.GetByIdAsync(chaplainId);
            await _unitOfWork.ChaplainRepository.DeleteAsync(chaplain);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<ChaplainModel>> GetAllChaplains()
        {
            IEnumerable<Chaplain> chaplains = await _unitOfWork.ChaplainRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<ChaplainModel>>(chaplains);
        }

        public async Task<ChaplainModel> GetChaplain(Guid chaplainId)
        {
            bool exists = await _unitOfWork.ChaplainRepository.ExistAsync(x => x.Id.Equals(chaplainId));
            if (exists == false)
            {
                throw new NotFoundException("Chaplain was not found");
            }

            Chaplain chaplain = await _unitOfWork.ChaplainRepository.GetByIdAsync(chaplainId);

            return _mapper.Map<ChaplainModel>(chaplain);
        }

        public async Task<IEnumerable<ChaplainModel>> GetChaplains(Pagination pagination)
        {
            IEnumerable<Chaplain> chaplains = await _unitOfWork.ChaplainRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<ChaplainModel>>(chaplains);
        }

        public async Task UpdateChaplain(ChaplainUpdateDto chaplainDto, Guid modifiedBy)
        {
            bool exists = await _unitOfWork.ChaplainRepository.ExistAsync(x => x.Id == chaplainDto.Id);

            if (!exists)
            {
                throw new NotFoundException("Chaplain doesn't exist");
            }

            Chaplain chaplain = _mapper.Map<Chaplain>(chaplainDto);
            await _unitOfWork.ChaplainRepository.UpdateAsync(chaplain);
            await _unitOfWork.SaveAsync();
        }
    }
}
