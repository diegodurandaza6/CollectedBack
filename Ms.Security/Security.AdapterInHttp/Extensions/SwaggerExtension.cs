using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Security.AdapterInHttp.Extensions
{
    public static class SwaggerExtension
    {
        public static void AllowSwaggerToListApiVersions(this WebApplication app, string appName)
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", $"{description.ApiVersion} ({appName})");
                }
                options.DocExpansion(DocExpansion.List);
            });
        }
    }
}
