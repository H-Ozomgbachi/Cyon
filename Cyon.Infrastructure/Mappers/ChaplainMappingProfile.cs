using AutoMapper;
using Cyon.Domain.DTOs.Chaplain;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Chaplain;

namespace Cyon.Infrastructure.Mappers
{
    public class ChaplainMappingProfile : Profile
    {
        public ChaplainMappingProfile()
        {
            CreateMap<Chaplain, ChaplainCreateDto>().ReverseMap();
            CreateMap<Chaplain, ChaplainUpdateDto>().ReverseMap();
            CreateMap<Chaplain, ChaplainModel>().ReverseMap();
        }
    }
}
