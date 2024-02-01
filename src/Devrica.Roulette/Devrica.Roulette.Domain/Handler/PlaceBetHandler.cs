using Devrica.Roulette.Domain.Models;
using Devrica.Roulette.Domain.Request;
using Devrica.Roulette.Domain.Response;
using Devrica.Roulette.WebApi.Interface;
using MediatR;

namespace Devrica.Roulette.Domain.Handler
{
    // Part of the mediator pattern c# via MediaoR
    public class PlaceBetHandler : IRequestHandler<PlaceBetCommand, PlaceBetResponse>
    {
        private readonly IDataRepository _dataRepository;

        public PlaceBetHandler(IDataRepository dataRepository) 
        {
            _dataRepository = dataRepository;
        }

        public async Task<PlaceBetResponse> Handle(PlaceBetCommand request, CancellationToken cancellationToken)
        {
            var bet = new StraightBet()
            {
                Amount = request.Amount,
                Color = request.Color,
                Number = request.Numbers.First()
            };
            var savedBet = await _dataRepository.SaveBet(bet, cancellationToken);
            return new PlaceBetResponse()
            {
                BetId = savedBet.Id,
            };
        }
    }
}
