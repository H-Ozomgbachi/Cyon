using AutoMapper;
using Cyon.Domain.DTOs.UpcomngEvent;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.UpcomingEvent;

namespace Cyon.Infrastructure.Mappers
{
    public class UpcomingEventMappingProfile : Profile
    {
        public UpcomingEventMappingProfile()
        {
            CreateMap<CreateUpcomingEventDto, UpcomingEvent>().ReverseMap();
            CreateMap<UpdateUpcomingEventDto, UpcomingEvent>().ReverseMap();
            CreateMap<UpcomingEventModel, UpcomingEvent>().ReverseMap();
        }
    }
}
