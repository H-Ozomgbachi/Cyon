using AutoMapper;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Infrastructure.Mappers
{
    public class AttendanceRegisterMappingProfile : Profile
    {
        public AttendanceRegisterMappingProfile()
        {
            CreateMap<AttendanceRegister, AttendanceRegisterModel>().ReverseMap();
        }
    }
}
