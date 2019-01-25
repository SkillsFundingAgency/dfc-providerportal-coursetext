using Dfc.ProviderPortal.CourseText;
using Dfc.ProviderPortal.CourseText.Helpers;
using Dfc.ProviderPortal.CourseText.Interfaces;
using Dfc.ProviderPortal.CourseText.Services;
using Dfc.ProviderPortal.CourseText.Settings;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;


[assembly: WebJobsStartup(typeof(WebJobsExtensionStartup), "Web Jobs Extension Startup")]
namespace Dfc.ProviderPortal.CourseText
{


    public class WebJobsExtensionStartup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            builder.AddDependencyInjection();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            builder.Services.AddSingleton<IConfiguration>(configuration);
            builder.Services.Configure<CosmosDbSettings>(configuration.GetSection(nameof(CosmosDbSettings)));
            builder.Services.Configure<CosmosDbCollectionSettings>(configuration.GetSection(nameof(CosmosDbCollectionSettings)));
            builder.Services.AddScoped<ICosmosDbHelper, CosmosDbHelper>();
            builder.Services.AddScoped<ICourseTextService, CourseTextService>();
        }
    }
}
