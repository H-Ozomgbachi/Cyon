using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Department;
using Cyon.Domain.Models.Department;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/departments")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<DepartmentModel>>> GetDepartments([FromQuery]Pagination pagination)
        {
            var result = await _departmentService.GetDepartments(pagination);
            return Ok(result);
        }

        [HttpGet("{departmentId}", Name = "GetDepartment")]
        [Authorize]
        public async Task<ActionResult<DepartmentModel>> GetDepartment(Guid departmentId)
        {
            var result = await _departmentService.GetDepartmentByIdAsync(departmentId);
            return Ok(result);
        }

        [HttpPost]
        [Authorize(Roles = $"{Roles.Super}")]
        public async Task<ActionResult<DepartmentModel>> AddDepartment([FromBody] DepartmentCreateDto department)
        {
            var result = await _departmentService.CreateDepartmentAsync(department);

            return CreatedAtAction(nameof(GetDepartment), new { departmentId = result.Id}, result);
        }

        [HttpPut]
        [Authorize(Roles = $"{Roles.Executive},{Roles.Super}")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentUpdateDto department)
        {
            await _departmentService.UpdateDepartmentAsync(department);
            return Ok();
        }

        [HttpDelete("{departmentId}")]
        [Authorize(Roles = $"{Roles.Executive},{Roles.Super}")]
        public async Task<IActionResult> DeleteDepartment(Guid departmentId)
        {
            await _departmentService.DeleteDepartmentAsync(departmentId);
            return NoContent();
        }
    }
}
