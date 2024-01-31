using Devrica.Roulette.Domain.Models;

namespace Devrica.Roulette.WebApi.Models
{
    public class BetDto
    {
        public BetType BetType { get; set; }
        public List<int> Numbers { get; set; } = new List<int>();
    }
}
