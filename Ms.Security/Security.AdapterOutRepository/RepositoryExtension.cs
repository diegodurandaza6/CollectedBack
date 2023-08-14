using Microsoft.Extensions.DependencyInjection;
using Security.Domain.IPortsOut;

namespace Security.AdapterOutRepository
{
    public static class RepositoryExtension
    {
        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IUsersDbMock, UsersDbMock>();
        }
    }
}
