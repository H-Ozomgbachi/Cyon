using AutoMapper;
using Cyon.Domain.DTOs.Minutes;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Minutes;

namespace Cyon.Infrastructure.Mappers
{
    public class MinutesMappingProfile : Profile
    {
        public MinutesMappingProfile()
        {
            CreateMap<CreateMinuteDto, Minutes>().ReverseMap();
            CreateMap<UpdateMinuteDto, Minutes>().ReverseMap();
            CreateMap<MinutesModel, Minutes>().ReverseMap();
        }
    }
}
