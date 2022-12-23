using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class AttendanceRegisterService : IAttendanceRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttendanceTypeService _attendanceTypeService;
        private readonly IMapper _mapper;

        public AttendanceRegisterService(IUnitOfWork unitOfWork, IAttendanceTypeService attendanceTypeService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _attendanceTypeService = attendanceTypeService;
            _mapper = mapper;
        }

        public async Task CollectAttendance(CollectAttendanceDto collectAttendanceDto)
        {
            AttendanceTypeModel attendanceType = await _attendanceTypeService.GetAttendanceType(collectAttendanceDto.AttendanceTypeId);

            HashSet<AttendanceRegister> attendanceRegisters = new();

            foreach (var item in collectAttendanceDto.AttendanceData)
            {
                AttendanceRegister attendanceRegister = new()
                {
                    AttendanceTypeId = attendanceType.Id,
                    AttendanceTypeName = attendanceType.Name,
                    DateAdded = collectAttendanceDto.Date,
                    UserId = item.UserId,
                    UserEmail = item.UserEmail,
                    IsPresent = true,
                    Rating = item.Rating,
                };
                attendanceRegisters.Add(attendanceRegister);
            }
            await _unitOfWork.AttendanceRegisterRepository.AddRangeAsync(attendanceRegisters);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<AttendanceRegisterModel>> GetCurrentDayAttendance(Pagination pagination)
        {
            var filter = new List<Expression<Func<AttendanceRegister, bool>>>
            {
                p => p.DateAdded.Day == DateTime.Now.Day
            };

            IEnumerable<AttendanceRegister> attendanceRegisters = await _unitOfWork.AttendanceRegisterRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<AttendanceRegisterModel>>(attendanceRegisters);
        }

        public async Task<IEnumerable<AttendanceRegisterModel>> GetMyAttendanceRecord(Guid userId, Pagination pagination)
        {
            var filter = new List<Expression<Func<AttendanceRegister, bool>>>
            {
                p => p.UserId == userId
            };

            IEnumerable<AttendanceRegister> attendanceRegisters = await _unitOfWork.AttendanceRegisterRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<AttendanceRegisterModel>>(attendanceRegisters.OrderByDescending(x => x.DateAdded));
        }
    }
}
