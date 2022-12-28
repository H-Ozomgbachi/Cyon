using AutoMapper;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.AccountManagement;

namespace Cyon.Infrastructure.Mappers
{
    public class AccountManagementMappingProfile : Profile
    {
        public AccountManagementMappingProfile()
        {
            CreateMap<AccountDeactivateRequestModel, DeactivateRequest>().ReverseMap();
        }
    }
}
