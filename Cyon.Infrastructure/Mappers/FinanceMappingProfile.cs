using AutoMapper;
using Cyon.Domain.DTOs.Finance;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Finance;

namespace Cyon.Infrastructure.Mappers
{
    public class FinanceMappingProfile : Profile
    {
        public FinanceMappingProfile()
        {
            CreateMap<CreateUserFinanceDto, UserFinance>().ReverseMap();
            CreateMap<UpdateUserFinanceDto, UserFinance>().ReverseMap();
            CreateMap<UserFinanceModel, UserFinance>().ReverseMap();
            CreateMap<OrganisationFinanceModel, OrganisationFinance>().ReverseMap();
            CreateMap<CreateOrganisationFinanceDto, OrganisationFinance>().ReverseMap();
            CreateMap<UpdateOrganisationFinanceDto, OrganisationFinance>().ReverseMap();
        }
    }
}
