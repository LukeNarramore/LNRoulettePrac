using Devrica.Roulette.Domain.Models;
using Devrica.Roulette.WebApi.Interface;

namespace Devrica.Roulette.WebApi.Repository
{
    public class DataRepository : IDataRepository
    {
        public Task<Bet> SaveBet(Bet bet, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<SpinResult> SaveSpinResult(SpinResult bet, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
