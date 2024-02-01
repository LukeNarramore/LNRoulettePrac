using Devrica.Roulette.Domain.Models;
using Devrica.Roulette.Domain.Response;
using MediatR;

namespace Devrica.Roulette.Domain.Request
{
    public class PlaceBetCommand : IRequest<PlaceBetResponse>
    {
        public BetType BetType { get; set; }
        public List<int> Numbers { get; set; }
        public decimal Amount { get; set; }
        public ResultColor Color { get; set; }
    }
}
