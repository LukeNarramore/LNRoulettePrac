using Devrica.Roulette.Domain.Models;

namespace Devrica.Roulette.WebApi.Interface
{
    public interface IDataRepository
    {
        public Task<Bet> SaveBet(Bet bet, CancellationToken cancellationToken);
        public Task<SpinResult> SaveSpinResult(SpinResult bet, CancellationToken cancellationToken);
    }
}