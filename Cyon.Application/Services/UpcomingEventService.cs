using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.UpcomngEvent;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.UpcomingEvent;
using Cyon.Domain.Repositories;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class UpcomingEventService : IUpcomingEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IUtilityRepository _utilityRepository;

        public UpcomingEventService(IUnitOfWork unitOfWork, IMapper mapper, IUtilityRepository utilityRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _utilityRepository = utilityRepository;
        }

        public async Task<UpcomingEventModel> AddUpcomingEvent(CreateUpcomingEventDto upcomingEventDto, string modifiedBy)
        {
            UpcomingEvent upcomingEvent = _mapper.Map<UpcomingEvent>(upcomingEventDto);
            upcomingEvent.ImageUrl = await _utilityRepository.UploadFile(upcomingEventDto.Image);
            upcomingEvent.ModifiedBy = modifiedBy;

            await _unitOfWork.UpcomingEventRepository.AddAsync(upcomingEvent);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<UpcomingEventModel>(upcomingEvent);
        }

        public async Task DeleteUpcomingEvent(Guid upcomingEventId)
        {
            UpcomingEvent upcomingEvent = await _unitOfWork.UpcomingEventRepository.GetByIdAsync(upcomingEventId);

            if (upcomingEvent == null)
            {
                throw new NotFoundException("Upcoming event was not found");
            }

            _unitOfWork.UpcomingEventRepository.Delete(upcomingEvent);
            await _unitOfWork.SaveAsync();
        }

        public async Task<UpcomingEventModel> GetUpcomingEvent(Guid upcomingEventId)
        {
            UpcomingEvent upcomingEvent = await _unitOfWork.UpcomingEventRepository.GetByIdAsync(upcomingEventId);

            if (upcomingEvent == null)
            {
                throw new NotFoundException("Upcoming event was not found");
            }

            return _mapper.Map<UpcomingEventModel>(upcomingEvent);
        }

        public async Task<IEnumerable<UpcomingEventModel>> GetUpcomingEvents(Pagination pagination)
        {
            IEnumerable<UpcomingEvent> upcomingEvents = await _unitOfWork.UpcomingEventRepository.GetAllAsync(pagination.Skip, pagination.Limit);

            return _mapper.Map<IEnumerable<UpcomingEventModel>>(upcomingEvents);
        }

        public async Task UpdateUpcomingEvent(UpdateUpcomingEventDto upcomingEventDto, string modifiedBy)
        {
            bool exists = await _unitOfWork.UpcomingEventRepository.ExistAsync(x => x.Id == upcomingEventDto.Id);

            if (!exists)
            {
                throw new NotFoundException("Upcoming event doesn't exist");
            }

            UpcomingEvent upcomingEvent = _mapper.Map<UpcomingEvent>(upcomingEventDto);
            upcomingEvent.ModifiedBy = modifiedBy;
            await _unitOfWork.UpcomingEventRepository.UpdateAsync(upcomingEvent);
            await _unitOfWork.SaveAsync();
        }
    }
}
