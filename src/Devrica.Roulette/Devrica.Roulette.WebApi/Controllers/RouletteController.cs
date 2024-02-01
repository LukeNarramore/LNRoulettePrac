using Devrica.Roulette.Domain.Request;
using Devrica.Roulette.WebApi.Models;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace Devrica.Roulette.WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RouletteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RouletteController(IMediator mediator) 
        {
            _mediator = mediator;
        }

        [HttpPost("Bet")]
        public async Task<IActionResult> PlaceBet(BetDto bet, CancellationToken cancellationToken)
        {
            // these api calls would follow the cqrs pattern: https://learn.microsoft.com/en-us/azure/architecture/patterns/cqrs
            // TODO validators for the requests
            var request = new PlaceBetCommand()
            {
                Numbers = bet.Numbers,
                BetType = bet.BetType,
                Amount = bet.Amount,
                Color = bet.Color,
            };
            await _mediator.Send(request, cancellationToken);
            return Ok();
        }


        [HttpPost("Spin")]
        public async Task<IActionResult> Spin(CancellationToken cancellationToken)
        {
            // SpinCommand
            return Ok();
        }

        [HttpGet("Payout")]
        public async Task<IActionResult> Payout(CancellationToken cancellationToken)
        {
            // PayoutRequest
            return Ok();


        }

        [HttpGet("PreviousSpins")]
        public async Task<IActionResult> ShowPreviousSpins(CancellationToken cancellationToken)
        {
            // ShowPreviousSpinsQuery
            return Ok();
        }
    }
}
