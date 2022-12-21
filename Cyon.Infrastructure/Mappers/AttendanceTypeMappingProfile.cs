using AutoMapper;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;

namespace Cyon.Infrastructure.Mappers
{
    public class AttendanceTypeMappingProfile : Profile
    {
        public AttendanceTypeMappingProfile()
        {
            CreateMap<CreateAttendanceTypeDto, AttendanceType>().ReverseMap();
            CreateMap<UpdateAttendanceTypeDto, AttendanceType>().ReverseMap();
            CreateMap<AttendanceTypeModel, AttendanceType>().ReverseMap();
        }
    }
}
