using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Attendance;
using Cyon.Domain.Models.Attendance;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/attendanceTypes")]
    [ApiController]
    [Authorize]
    public class AttendanceTypesController : ControllerBase
    {
        private readonly IAttendanceTypeService _attendanceTypeService;

        public AttendanceTypesController(IAttendanceTypeService attendanceTypeService)
        {
            _attendanceTypeService = attendanceTypeService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AttendanceTypeModel>>> GetAllAttendanceTypes([FromQuery]Pagination pagination)
        {
            return Ok(await _attendanceTypeService.GetAttendanceTypes(pagination));
        }

        [HttpGet("{attendanceTypeId}", Name = "GetAttendanceTypeById")]
        public async Task<ActionResult<AttendanceTypeModel>> GetAttendanceTypeById(Guid attendanceTypeId)
        {
            return Ok(await _attendanceTypeService.GetAttendanceType(attendanceTypeId));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<AttendanceTypeModel>> AddAttendanceType([FromForm] CreateAttendanceTypeDto attendanceTypeDto)
        {
            var result = await _attendanceTypeService.AddAttendanceType(attendanceTypeDto);

            return CreatedAtAction(nameof(GetAttendanceTypeById), new { attendanceTypeId = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAttendanceType([FromForm] UpdateAttendanceTypeDto attendanceTypeDto)
        {
            await _attendanceTypeService.UpdateAttendanceType(attendanceTypeDto);
            return Ok();
        }

        [HttpDelete("{attendanceTypeId}")]
        public async Task<IActionResult> DeleteAttendanceType(Guid attendanceTypeId)
        {
            await _attendanceTypeService.DeleteAttendanceType(attendanceTypeId);
            return NoContent();
        }
    }
}
