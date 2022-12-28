using AutoMapper;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Infrastructure.Mappers
{
    public class ApologyMappingProfile : Profile
    {
        public ApologyMappingProfile()
        {
            CreateMap<Apology, ApologyModel>().ReverseMap();
            CreateMap<ResolveApologyDto, Apology>().ReverseMap();
        }
    }
}
