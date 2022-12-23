using AutoMapper;
using Cyon.Domain.DTOs.Occupation;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Occupation;

namespace Cyon.Infrastructure.Mappers
{
    public class OccupationMappingProfile : Profile
    {
        public OccupationMappingProfile()
        {
            CreateMap<CreateOccupationDto, Occupation>().ReverseMap();
            CreateMap<UpdateOccupationDto, Occupation>().ReverseMap();
            CreateMap<Occupation, OccupationModel>().ReverseMap();
        }
    }
}
