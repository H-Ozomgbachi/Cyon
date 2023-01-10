using AutoMapper;
using Cyon.Domain.DTOs.Authentication;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Authentication;

namespace Cyon.Infrastructure.Mappers
{
    public class AuthenticationMappingProfile : Profile
    {
        public AuthenticationMappingProfile()
        {
            CreateMap<UserForRegistrationDto, User>().ReverseMap();
            CreateMap<AccountModel, User>().ReverseMap();
            CreateMap<AccountModelConcise, User>().ReverseMap();
        }
    }
}
