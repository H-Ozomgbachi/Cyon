using Cyon.Domain.Common;
using Cyon.Domain.DTOs.YearProgramme;
using Cyon.Domain.Models.YearProgramme;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cyon.Api.Controllers.v1
{
    public class YearProgrammeController : BaseController
    {
        private readonly IYearProgrammeService _yearProgrammeService;

        public YearProgrammeController(IYearProgrammeService yearProgrammeService)
        {
            _yearProgrammeService = yearProgrammeService;
        }

        [HttpGet("GetYearProgrammeById/{id}")]
        public async Task<IActionResult> GetYearProgrammeById(Guid id)
        {
            var yearProgramme = await _yearProgrammeService.GetYearProgrammeById(id);
            return Ok(yearProgramme);
        }

        [HttpPost("AddYearProgramme")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> AddYearProgramme([FromForm] CreateYearProgrammeDto createYearProgrammeDto)
        {
            var yearPrograme = await _yearProgrammeService.AddYearProgramme(createYearProgrammeDto);
            return CreatedAtAction(nameof(GetYearProgrammeById), new { id = yearPrograme.Id }, yearPrograme);
        }

        [HttpGet("GetYearProgrammes")]
        public async Task<ActionResult<IEnumerable<YearProgrammeModel>>> GetYearProgrammes([FromQuery]Pagination pagination)
        {
            var yearProgrammes = await _yearProgrammeService.GetYearProgrammes(pagination);
            return Ok(yearProgrammes);
        }

        [HttpPut("UpdateYearProgramme")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> UpdateYearProgramme([FromBody] UpdateYearProgrammeDto updateYearProgrammeDto)
        {
            await _yearProgrammeService.UpdateYearProgramme(updateYearProgrammeDto);
            return Ok();
        }

        [HttpDelete("DeleteYearProgramme/{id}")]
        [Authorize(Roles = Roles.Executive)]
        public async Task<IActionResult> DeleteYearProgramme(Guid id)
        {
            await _yearProgrammeService.DeleteYearProgramme(id);
            return NoContent();
        }
    }
}
