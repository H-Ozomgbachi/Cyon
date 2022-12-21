using AutoMapper;
using Cyon.Domain.DTOs.Meeting;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Meeting;

namespace Cyon.Infrastructure.Mappers
{
    public class MeetingMappingProfile : Profile
    {
        public MeetingMappingProfile()
        {
            CreateMap<CreateMeetingDto, Meeting>().ReverseMap();
            CreateMap<MeetingModel, Meeting>().ReverseMap();
            CreateMap<UpdateMeetingDto, Meeting>().ReverseMap();
            CreateMap<CreateAgendumDto, Agendum>().ReverseMap();
            CreateMap<AgendumModel, Agendum>().ReverseMap();
            CreateMap<UpdateAgendumDto, Agendum>().ReverseMap();
        }
    }
}
