using AutoMapper;
using Cyon.Domain.DTOs.YearProgramme;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.YearProgramme;

namespace Cyon.Infrastructure.Mappers
{
    public class YearProgrammeMappingProfile : Profile
    {
        public YearProgrammeMappingProfile()
        {
            CreateMap<CreateYearProgrammeDto, YearProgramme>().ReverseMap();
            CreateMap<YearProgrammeModel, YearProgramme>().ReverseMap();
            CreateMap<UpdateYearProgrammeDto, YearProgramme>().ReverseMap();
        }
    }
}
