using Cyon.Domain.DTOs.Games;
using Cyon.Domain.Models.Games;
using Cyon.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cyon.Api.Controllers.v1
{
    // Everything about this feature was hurriedly done. Please refactor properly
    public class GamesController : BaseController
    {
        private readonly IGamesService _gamesService;

        public GamesController(IGamesService gamesService)
        {
            _gamesService = gamesService;
        }

        [HttpPost("PostTreasureHuntResult/")]
        public async Task<IActionResult> PostTreasureHuntResult([FromBody]CreateTreasureHuntResultDto createTreasureHuntResultDto)
        {
            await _gamesService.PostTreasureHuntResult(createTreasureHuntResultDto);
            return Ok();
        }

        [HttpGet("GetTreasureHuntResults/")]
        public async Task<ActionResult<IEnumerable<TreasureHuntResultModel>>> GetTreasureHuntResults()
        {
            return Ok(await _gamesService.GetTreasureHuntResults());
        }

        [HttpPost("ClearTreasureHuntResults/")]
        public async Task<IActionResult> ClearTreasureHuntResults()
        {
            await _gamesService.ClearTreasureHuntResults();
            return Ok();
        }
    }
}
