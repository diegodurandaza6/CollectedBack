using Microsoft.Extensions.DependencyInjection;
using Collected.AdapterOutRepository.SqlServerDB.Repositories;
using Collected.Domain.IPortsOut;

namespace Collected.AdapterOutRepository
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICollectedRepository, CollectedRepository>();
        }
    }
}
