using AutoMapper;
using Cyon.Domain;
using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Entities;
using Cyon.Domain.Exceptions;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using Cyon.Infrastructure.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Cyon.Application.Services
{
    public class AttendanceRegisterService : IAttendanceRegisterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttendanceTypeService _attendanceTypeService;
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;

        public AttendanceRegisterService(IUnitOfWork unitOfWork, IAttendanceTypeService attendanceTypeService, IMapper mapper, AppDbContext dbContext)
        {
            _unitOfWork = unitOfWork;
            _attendanceTypeService = attendanceTypeService;
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task CollectAttendance(CollectAttendanceDto collectAttendanceDto, string userCode)
        {
            AttendanceTypeModel attendanceType = await _attendanceTypeService.GetAttendanceType(collectAttendanceDto.AttendanceTypeId);

            HashSet<AttendanceRegister> attendanceRegisters = new();

            foreach (var item in collectAttendanceDto.AttendanceData)
            {
                AttendanceRegister attendanceRegister = new()
                {
                    AttendanceTypeId = attendanceType.Id,
                    AttendanceTypeName = attendanceType.Name,
                    DateAdded = collectAttendanceDto.Date.ToUniversalTime(),
                    UserCode = item.UserCode,
                    Name = item.Name,
                    IsPresent = true,
                    Rating = item.Rating,
                    CreatedBy = userCode,
                };
                if (!(await _unitOfWork.AttendanceRegisterRepository.ExistAsync(x => x.UserCode == attendanceRegister.UserCode && x.AttendanceTypeId == attendanceRegister.AttendanceTypeId && x.DateAdded.Date == attendanceRegister.DateAdded.Date)))
                {
                    attendanceRegisters.Add(attendanceRegister);
                }
            }

            await _unitOfWork.AttendanceRegisterRepository.AddRangeAsync(attendanceRegisters);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AttendanceSummaryModel> GetAttendanceSummary(string userCode)
        {
            var attendanceSummary = await _unitOfWork.AttendanceRegisterRepository.GetAttendanceSummary(userCode);

            int total = attendanceSummary.TotalPresent + attendanceSummary.TotalAbsent;
            if (total == 0)
            {
                return new AttendanceSummaryModel()
                {
                    Presence = "0%",
                    Absence = "0%"
                };
            }

            decimal presence = Math.Round((decimal)attendanceSummary.TotalPresent / total * 100);
            decimal absence = Math.Round((decimal)attendanceSummary.TotalAbsent / total * 100);

            return new AttendanceSummaryModel()
            {
                Presence = $"{presence}%",
                Absence = $"{absence}%"
            };
        }

        public async Task<IEnumerable<AttendanceRegisterModel>> GetCurrentDayAttendance(Pagination pagination)
        {
            var filter = new List<Expression<Func<AttendanceRegister, bool>>>
            {
                p => p.DateAdded.Date == DateTime.UtcNow.Date
            };

            IEnumerable<AttendanceRegister> attendanceRegisters = await _unitOfWork.AttendanceRegisterRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<AttendanceRegisterModel>>(attendanceRegisters);
        }

        public async Task<IEnumerable<AttendanceRegisterModel>> GetMyAttendanceRecord(string userCode, Pagination pagination)
        {
            var filter = new List<Expression<Func<AttendanceRegister, bool>>>
            {
                p => p.UserCode == userCode
            };

            IEnumerable<AttendanceRegister> attendanceRegisters = await _unitOfWork.AttendanceRegisterRepository.GetAllAsync(pagination.Skip, pagination.Limit, null, filter);

            return _mapper.Map<IEnumerable<AttendanceRegisterModel>>(attendanceRegisters.OrderByDescending(x => x.DateAdded));
        }

        public async Task<string> MarkAbsent(MarkAbsentDto markAbsentDto, string userCode)
        {
            bool doesExist = await _unitOfWork.AttendanceRegisterRepository.ExistAsync(x => x.AttendanceTypeId == markAbsentDto.AttendanceTypeId && x.DateAdded.Date == markAbsentDto.DateEventHeld.Date);

            if (doesExist == false)
            {
                throw new BadRequestException("No activity held for the function or date you selected");
            }

            var filter = new List<Expression<Func<AttendanceRegister, bool>>>
            {
                p => p.AttendanceTypeId == markAbsentDto.AttendanceTypeId,
                p => p.DateAdded.Date == markAbsentDto.DateEventHeld.Date
            };

            IEnumerable<AttendanceRegister> attendances = await _unitOfWork.AttendanceRegisterRepository.GetAllAsync(filter);

            List<string> attendeeIds = attendances.Select(m => m.UserCode).ToList();

            var absentUsers = await _dbContext.Users.FromSqlRaw("Sp_GetUsersWhoWereAbsent @PresentUsersIds",
                new SqlParameter("@PresentUsersIds", string.Join(',', attendeeIds))
                ).ToListAsync();

            if (absentUsers.Any())
            {
                /*
                 * The reason for extracting oneAttendee here is merely to capture the attendanceTypeName!
                 * This is because I want to avoid making irrelavant request just to get that.
                 */
                var oneAttendee = attendances.FirstOrDefault();

                HashSet<AttendanceRegister> attendanceRegisters = new();

                foreach (var user in absentUsers)
                {
                    AttendanceRegister attendanceRegister = new()
                    {
                        AttendanceTypeId = markAbsentDto.AttendanceTypeId,
                        AttendanceTypeName = oneAttendee!.AttendanceTypeName,
                        DateAdded = markAbsentDto.DateEventHeld,
                        UserCode = user.UniqueCode,
                        Name = $"{user.FirstName} {user.LastName}",
                        IsPresent = false,
                        Rating = 0,
                        CreatedBy = userCode
                    };
                    if (!(await _unitOfWork.AttendanceRegisterRepository.ExistAsync(x => x.UserCode == attendanceRegister.UserCode && x.AttendanceTypeId == attendanceRegister.AttendanceTypeId && x.DateAdded.Date == attendanceRegister.DateAdded.Date)))
                    {
                        attendanceRegisters.Add(attendanceRegister);
                    }
                }
                await _unitOfWork.AttendanceRegisterRepository.AddRangeAsync(attendanceRegisters);
                await _unitOfWork.SaveAsync();

                string rightWord = absentUsers.Count == 1 ? "member" : "members";

                return $"{absentUsers.Count} {rightWord} marked absent";
            }
            else
            {
                return "Attendance register completely marked for this function";
            }
        }
    }
}
