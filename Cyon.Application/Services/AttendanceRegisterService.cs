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

        public async Task<AttendanceSummaryModel> GetAttendanceSummary(Guid userId)
        {
            var attendanceSummary = await _unitOfWork.AttendanceRegisterRepository.GetAttendanceSummary(userId.ToString());

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

        public async Task<string> MarkAbsent(MarkAbsentDto markAbsentDto)
        {
            bool doesExist = await _unitOfWork.AttendanceRegisterRepository.ExistAsync(x => x.AttendanceTypeId == markAbsentDto.AttendanceTypeId && x.DateAdded.Day == markAbsentDto.DateEventHeld.Day);

            if (doesExist == false)
            {
                throw new BadRequestException("No activity held for the function or date you selected");
            }

            var filter = new List<Expression<Func<AttendanceRegister, bool>>>
            {
                p => p.AttendanceTypeId == markAbsentDto.AttendanceTypeId,
                p => p.DateAdded.Day == markAbsentDto.DateEventHeld.Day
            };

            IEnumerable<AttendanceRegister> attendances = await _unitOfWork.AttendanceRegisterRepository.GetAllAsync(filter);

            List<string> attendeeIds = attendances.Select(m => m.UserId.ToString()).ToList();

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
                        UserId = Guid.Parse(user.Id),
                        UserEmail = user.Email,
                        IsPresent = false,
                        Rating = 0,
                    };
                    attendanceRegisters.Add(attendanceRegister);
                }
                await _unitOfWork.AttendanceRegisterRepository.AddRangeAsync(attendanceRegisters);
                await _unitOfWork.SaveAsync();

                return $"{absentUsers.Count} user(s) marked absent";
            }
            else
            {
                return "Attendance register completely marked for this function";
            }
        }
    }
}
