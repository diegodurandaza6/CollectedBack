using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Collected.AdapterOutRepository.SqlServerDB
{
    public static class SqlServerDBExtension
    {

        public static void AddPersistence(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("SqlServerDb");
            serviceCollection.AddDbContext<DiegoDBContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
