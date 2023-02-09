using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Minutes;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Minutes;
using Cyon.Domain.Services;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class MinutesService : IMinutesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MinutesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MinutesModel> AddMinute(CreateMinuteDto minuteDto, Guid modifiedBy)
        {
            Minutes minutes = _mapper.Map<Minutes>(minuteDto);
            minutes.ModifiedBy = modifiedBy;

            await _unitOfWork.MinutesRepository.AddAsync(minutes);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<MinutesModel>(minutes);
        }

        public async Task DeleteMinute(Guid minuteId)
        {
            bool exists = await _unitOfWork.MinutesRepository.ExistAsync(x => x.Id == minuteId);

            if (exists == false)
            {
                throw new NotFoundException("Minute does not exist");
            }

            Minutes minutes = await _unitOfWork.MinutesRepository.GetByIdAsync(minuteId);
            await _unitOfWork.MinutesRepository.DeleteAsync(minutes);
            await _unitOfWork.SaveAsync();
        }

        public async Task<MinutesModel> GetMinute(Guid minuteId)
        {
            bool exists = await _unitOfWork.MinutesRepository.ExistAsync(x => x.Id.Equals(minuteId));
            if (exists == false)
            {
                throw new NotFoundException("Minute was not found");
            }

            Minutes minutes = await _unitOfWork.MinutesRepository.GetByIdAsync(minuteId);

            return _mapper.Map<MinutesModel>(minutes);
        }

        public async Task<IEnumerable<MinutesModel>> GetMinuteByMeetingDate(DateTime date)
        {
            var filter = new List<Expression<Func<Minutes, bool>>>
            {
                x => x.DateOfMeeting.Day == date.Day,
            };

            IEnumerable<Minutes> minutes = await _unitOfWork.MinutesRepository.GetAllAsync(0, 1, null, filter);

            return _mapper.Map<IEnumerable<MinutesModel>>(minutes);
        }

        public async Task<IEnumerable<MinutesModel>> GetMinutes(Pagination pagination)
        {
            IEnumerable<Minutes> minutes = await _unitOfWork.MinutesRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<MinutesModel>>(minutes);
        }

        public async Task UpdateMinute(UpdateMinuteDto minuteDto, Guid modifiedBy)
        {
            bool exists = await _unitOfWork.MinutesRepository.ExistAsync(x => x.Id == minuteDto.Id);

            if (!exists)
            {
                throw new NotFoundException("Minute doesn't exist");
            }

            Minutes minutes = _mapper.Map<Minutes>(minuteDto);
            await _unitOfWork.MinutesRepository.UpdateAsync(minutes);
            await _unitOfWork.SaveAsync();
        }
    }
}
