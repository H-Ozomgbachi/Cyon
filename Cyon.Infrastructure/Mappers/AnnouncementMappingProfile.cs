using AutoMapper;
using Cyon.Domain.DTOs.Announcement;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Announcement;

namespace Cyon.Infrastructure.Mappers
{
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<CreateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<UpdateAnnouncementDto, Announcement>().ReverseMap();
            CreateMap<AnnouncementModel, Announcement>().ReverseMap();
        }
    }
}
