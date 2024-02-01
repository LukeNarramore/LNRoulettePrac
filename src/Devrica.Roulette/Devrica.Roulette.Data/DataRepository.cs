using Dapper;
using Devrica.Roulette.Domain.Models;
using Devrica.Roulette.WebApi.Interface;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Devrica.Roulette.WebApi.Repository
{
    public class DataRepository : IDataRepository
    {
        private readonly IServiceProvider _serviceProvider;

        public DataRepository(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task<StraightBet> SaveBet(StraightBet bet, CancellationToken cancellationToken)
        {
            using var connection = _serviceProvider.GetService<IDbConnection>();
            var parameter = new { spin_number = bet.SpinNumber, bet_amount = bet.Amount, bet_number = bet.Number, color = bet.Color, outcome = bet.Outcome };
            var result = await connection.ExecuteScalarAsync("INSERT INTO straight_bets (spin_number, bet_amount, bet_number, color, outcome) VALUES (@spin_number, @bet_amount, @bet_number, @color, @outcome)", parameter);
            // Save straight_bets
            return bet;
        }

        public async Task<SpinResult> SaveSpinResult(SpinResult spinResult, CancellationToken cancellationToken)
        {
            using var connection = _serviceProvider.GetService<IDbConnection>();
            var result = await connection.ExecuteScalarAsync("INSERT INTO spin_results...");
            // Save spinResult
            return spinResult;
        }

        public async Task<IEnumerable<SpinResult>> GetLastSpinResult(int maxResult, CancellationToken cancellationToken)
        {
            var parameters = new { MaxResult = maxResult };
            using var connection = _serviceProvider.GetService<IDbConnection>();
            var result = await connection.QueryAsync<SpinResult>(
                new CommandDefinition("select top @MaxResult from spin_results order by spin_number desc", parameters, cancellationToken: cancellationToken));
            return result.ToList();
        }
    }
}
