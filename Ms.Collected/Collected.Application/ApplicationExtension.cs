using Microsoft.Extensions.DependencyInjection;
using Collected.Domain.IPortsIn;

namespace Collected.Application
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICollectedService, CollectedService>();
        }
    }
}
