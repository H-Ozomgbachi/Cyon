﻿using Cyon.Domain.Common;
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
        public async Task<IActionResult> CollectAttendance([FromBody]CollectAttendanceDto collectAttendanceDto)
        {
            await _attendanceRegisterService.CollectAttendance(collectAttendanceDto, User.FindFirstValue(ClaimTypes.Actor));
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
            string userCode = User.FindFirstValue(ClaimTypes.Actor);
            return Ok(await _attendanceRegisterService.GetMyAttendanceRecord(userCode, pagination));
        }

        [HttpPost("MarkAbsentees")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<ActionResult<string>> MarkAbsentees([FromBody]MarkAbsentDto markAbsentDto)
        {
            string result = await _attendanceRegisterService.MarkAbsent(markAbsentDto, User.FindFirstValue(ClaimTypes.Actor));
            return Ok(result);
        }

        [HttpGet("GetAttendanceSummary")]
        public async Task<ActionResult<AttendanceSummaryModel>> GetAttendanceSummary()
        {
            string userCode = User.FindFirstValue(ClaimTypes.Actor);
            return Ok(await _attendanceRegisterService.GetAttendanceSummary(userCode));
        }
    }
}
