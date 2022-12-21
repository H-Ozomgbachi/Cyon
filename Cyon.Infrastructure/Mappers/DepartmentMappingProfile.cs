using AutoMapper;
using Cyon.Domain.DTOs.Department;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Department;

namespace Cyon.Infrastructure.Mappers
{
    public class DepartmentMappingProfile : Profile
    {
        public DepartmentMappingProfile()
        {
            CreateMap<Department, DepartmentModel>().ReverseMap();
            CreateMap<Department, DepartmentCreateDto>().ReverseMap();
            CreateMap<Department, DepartmentUpdateDto>().ReverseMap();
        }
    }
}
