using AutoMapper;
using Cyon.Domain.DTOs.Games;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Games;

namespace Cyon.Infrastructure.Mappers
{
    public class GamesMappingProfile : Profile
    {
        public GamesMappingProfile()
        {
            CreateMap<TreasureHuntResult, CreateTreasureHuntResultDto>().ReverseMap();
            CreateMap<TreasureHuntResult, TreasureHuntResultModel>().ReverseMap();
        }
    }
}
