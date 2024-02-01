using Devrica.Roulette.Domain.Models;

namespace Devrica.Roulette.WebApi.Models
{
    public class BetDto
    {
        public BetType BetType { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();
        public decimal Amount { get; internal set; }
        public ResultColor Color { get; internal set; }
    }
}
