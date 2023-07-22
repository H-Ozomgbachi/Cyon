using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Meeting;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Meeting;
using Cyon.Domain.Services;

namespace Cyon.Application.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MeetingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<MeetingModel> AddMeeting(CreateMeetingDto meetingDto, Guid modifiedBy)
        {
            Meeting meeting = _mapper.Map<Meeting>(meetingDto);
            meeting.ModifiedBy = modifiedBy;

            await _unitOfWork.MeetingRepository.AddAsync(meeting);
            await _unitOfWork.SaveAsync();

            return _mapper.Map<MeetingModel>(meeting);
        }

        public async Task DeleteMeeting(Guid meetingId)
        {
            bool exists = await _unitOfWork.MeetingRepository.ExistAsync(x => x.Id == meetingId);

            if (exists == false)
            {
                throw new NotFoundException("Meeting does not exist");
            }

            Meeting meeting = await _unitOfWork.MeetingRepository.GetByIdAsync(meetingId);
            await _unitOfWork.MeetingRepository.DeleteAsync(meeting);
            await _unitOfWork.SaveAsync();
        }

        public async Task<MeetingModel> GetMeeting(Guid meetingId)
        {
            bool exists = await _unitOfWork.MeetingRepository.ExistAsync(x => x.Id.Equals(meetingId));
            if (exists == false)
            {
                throw new NotFoundException("Meeting was not found");
            }

            Meeting meeting = await _unitOfWork.MeetingRepository.GetByIdAsync(meetingId, new List<string> { "Agenda" });

            return _mapper.Map<MeetingModel>(meeting);
        }

        public async Task<IEnumerable<MeetingModel>> GetMeetings(Pagination pagination)
        {
            IEnumerable<Meeting> meetings = await _unitOfWork.MeetingRepository.GetAllAsync(pagination.Skip, pagination.Limit, new List<string> { "Agenda"});

            return _mapper.Map<IEnumerable<MeetingModel>>(meetings.OrderByDescending(x => x.Date));
        }

        public async Task UpdateMeeting(UpdateMeetingDto meetingDto, Guid modifiedBy)
        {
            Meeting existingMeeting = await _unitOfWork.MeetingRepository.GetByIdAsync(meetingDto.Id, new string[] {"Agenda"});
            existingMeeting.ModifiedBy = modifiedBy;

            if (existingMeeting == null)
            {
                throw new NotFoundException("Meeting doesn't exist");
            }
            var meetingToUpdate = _mapper.Map<Meeting>(meetingDto);
            
            await _unitOfWork.MeetingRepository.UpdateAsync(meetingToUpdate);
            await _unitOfWork.SaveAsync();
        }
    }
}
