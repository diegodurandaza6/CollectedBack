﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace Collected.AdapterInHttp.Extensions
{
    public static class HttpExtension
    {
        public static void ConfigureVersioning(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });

            serviceCollection.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            //serviceCollection.AddSingleton<ScheduledTask>();
        }
    }
}