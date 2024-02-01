using Devrica.Roulette.WebApi.Interface;
using Devrica.Roulette.WebApi.Repository;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;

namespace Devrica.Roulette.Data
{
    public static class BuilderExtensions
    {
        /// <summary>
        /// Add the Services 
        /// </summary>
        /// <param name="configurationBuilder"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
        {
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped(CreateDataConnection);

            return services;
        }

        private static IDbConnection CreateDataConnection(IServiceProvider serviceProvider)
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string? connectionString = config.GetConnectionString("SQLITE_DB");
            if (connectionString == null)
            {
                throw new ConfigurationErrorsException("Misisng 'SQLITE_DB' setting.", "appsettings.json", 0);
            }
            return new SqliteConnection(connectionString!);
        }

    }
}
