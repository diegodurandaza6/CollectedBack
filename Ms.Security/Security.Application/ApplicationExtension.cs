using Microsoft.Extensions.DependencyInjection;
using Security.Domain.IPortsIn;

namespace Security.Application
{
    public static class ApplicationExtension
    {
        public static void AddApplication(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILoginService, LoginService>();
        }
    }
}
