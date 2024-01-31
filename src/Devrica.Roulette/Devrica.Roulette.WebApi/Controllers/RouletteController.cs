using Devrica.Roulette.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Devrica.Roulette.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        public RouletteController() { }

        [HttpPost("Bet")]
        public async Task<IActionResult> PlaceBet(BetDto bet)
        {
            return Ok();
        }


        [HttpPost("Spin")]
        public async Task<IActionResult> Spin()
        {
            return Ok();


        }

        [HttpGet("Payout")]
        public async Task<IActionResult> Payout()
        {
            return Ok();


        }

        [HttpGet("PreviousSpins")]
        public async Task<IActionResult> ShowPreviousSpins()
        {
            return Ok();
        }
    }
}
