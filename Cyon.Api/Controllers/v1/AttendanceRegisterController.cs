using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> CollectAttendance([FromBody]CollectAttendanceDto collectAttendanceDto)
        {
            await _attendanceRegisterService.CollectAttendance(collectAttendanceDto);
            return Ok();
        }

        [HttpGet("GetTodayAttendance")]
        public async Task<ActionResult<AttendanceRegisterModel>> GetTodayAttendance([FromQuery]Pagination pagination)
        {
            return Ok(await _attendanceRegisterService.GetCurrentDayAttendance(pagination));
        }
    }
}
