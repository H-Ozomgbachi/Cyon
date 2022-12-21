using Cyon.Domain.Common;
using Cyon.Domain.DTOs.Chaplain;
using Cyon.Domain.Models.Chaplain;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Cyon.Api.Controllers.v1
{
    [Route("api/v1/chaplains")]
    [ApiController]
    [Authorize]
    public class ChaplainsController : ControllerBase
    {
        private readonly IChaplainService _chaplainService;

        public ChaplainsController(IChaplainService chaplainService)
        {
            _chaplainService = chaplainService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ChaplainModel>>> GetChaplains()
        {
            return Ok(await _chaplainService.GetAllChaplains());
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<IEnumerable<ChaplainModel>>> GetChaplainsPaged([FromQuery] Pagination pagination)
        {
            return Ok(await _chaplainService.GetChaplains(pagination));
        }

        [HttpGet("{chaplainId}", Name = "GetChaplainById")]
        public async Task<ActionResult<ChaplainModel>> GetChaplainById(Guid chaplainId)
        {
            return Ok(await _chaplainService.GetChaplain(chaplainId));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [Authorize(Roles = "Executive,Super")]
        public async Task<IActionResult> AddChaplain([FromBody] ChaplainCreateDto chaplainDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            var chaplain = await _chaplainService.AddChaplain(chaplainDto, activeUserId);
            return CreatedAtAction(nameof(GetChaplainById), new {chaplainId = chaplain.Id}, chaplain);
        }

        [HttpPut]
        [Authorize(Roles = "Executive,Super")]
        public async Task<IActionResult> UpdateChaplain(ChaplainUpdateDto chaplainUpdateDto)
        {
            Guid activeUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.Name));
            await _chaplainService.UpdateChaplain(chaplainUpdateDto, activeUserId);
            return Ok();
        }

        [HttpDelete("{chaplainId}")]
        [Authorize(Roles = "Executive,Super")]
        public async Task<IActionResult> DeleteChaplain(Guid chaplainId)
        {
            await _chaplainService.DeleteChaplain(chaplainId);
            return NoContent();
        }
    }
}
