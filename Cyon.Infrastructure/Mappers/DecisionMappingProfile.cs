using AutoMapper;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Decision;

namespace Cyon.Infrastructure.Mappers
{
    public class DecisionMappingProfile : Profile
    {
        public DecisionMappingProfile()
        {
            CreateMap<CreateDecisionDto, Decision>().ReverseMap();
            CreateMap<UpdateDecisionDto, Decision>().ReverseMap();
            CreateMap<DecisionModel, Decision>().ReverseMap();
        }
    }
}
