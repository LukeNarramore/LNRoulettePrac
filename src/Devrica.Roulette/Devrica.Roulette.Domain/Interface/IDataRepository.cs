using Devrica.Roulette.Domain.Models;

namespace Devrica.Roulette.WebApi.Interface
{
    public interface IDataRepository
    {
        public Task<StraightBet> SaveBet(StraightBet bet, CancellationToken cancellationToken);
        public Task<SpinResult> SaveSpinResult(SpinResult bet, CancellationToken cancellationToken);
    }
}