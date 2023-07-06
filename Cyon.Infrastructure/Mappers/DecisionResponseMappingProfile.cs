using AutoMapper;
using Cyon.Domain.DTOs.Decision;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Decision;

namespace Cyon.Infrastructure.Mappers
{
    public class DecisionResponseMappingProfile : Profile
    {
        public DecisionResponseMappingProfile()
        {
            CreateMap<CreateDecisionResponseDto, DecisionResponse>().ReverseMap();
            CreateMap<DecisionResponseModel, DecisionResponse>().ReverseMap();
        }
    }
}
