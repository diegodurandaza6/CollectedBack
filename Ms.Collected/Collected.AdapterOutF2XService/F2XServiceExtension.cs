using Collected.AdapterOutF2XService.Services;
using Microsoft.Extensions.DependencyInjection;
using Collected.Domain.IPortsOut;

namespace Collected.AdapterOutF2XService
{
    public static class F2XServiceExtension
    {
        public static void AddF2XServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IF2XService, F2XService>();
        }
    }
}
