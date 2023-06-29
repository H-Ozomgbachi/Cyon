using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Authorize]
    public class AttendanceRegisterController : BaseController
    {
        private readonly IAttendanceRegisterService _attendanceRegisterService;

        public AttendanceRegisterController(IAttendanceRegisterService attendanceRegisterService)
        {
            _attendanceRegisterService = attendanceRegisterService;
        }

        [HttpPost("TakeAttendance")]
        public async Task<IActionResult> CollectAttendance([FromForm]CollectAttendanceDto collectAttendanceDto)
        {
            await _attendanceRegisterService.CollectAttendance(collectAttendanceDto);
            return Ok();
        }

        [HttpGet("GetTodayAttendance")]
        public async Task<ActionResult<IEnumerable<AttendanceRegisterModel>>> GetTodayAttendance([FromQuery]Pagination pagination)
        {
            return Ok(await _attendanceRegisterService.GetCurrentDayAttendance(pagination));
        }
        [HttpGet("GetMyAttendanceRecord")]
        public async Task<ActionResult<IEnumerable<AttendanceRegisterModel>>> GetMyAttendanceRecord([FromQuery] Pagination pagination)
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return Ok(await _attendanceRegisterService.GetMyAttendanceRecord(userId, pagination));
        }

        [HttpPost("MarkAbsentees")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> MarkAbsentees(MarkAbsentDto markAbsentDto)
        {
            string result = await _attendanceRegisterService.MarkAbsent(markAbsentDto);
            return Ok(new {result});
        }

        [HttpGet("GetAttendanceSummary")]
        public async Task<ActionResult<AttendanceSummaryModel>> GetAttendanceSummary()
        {
            Guid userId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            return Ok(await _attendanceRegisterService.GetAttendanceSummary(userId));
        }
    }
}
