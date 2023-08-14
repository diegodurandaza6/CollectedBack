using Microsoft.Extensions.DependencyInjection;
using Collected.Domain.IPortsOut;
using Collected.AdapterOutReport.Report;

namespace Collected.AdapterOutReport
{
    public static class ReportExtension
    {
        public static void AddReport(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICollectedReport, CollectedReport>();
        }
    }
}
