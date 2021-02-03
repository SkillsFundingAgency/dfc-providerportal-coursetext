using Dfc.ProviderPortal.CourseText;
using Dfc.ProviderPortal.CourseText.Helpers;
using Dfc.ProviderPortal.CourseText.Interfaces;
using Dfc.ProviderPortal.CourseText.Services;
using Dfc.ProviderPortal.CourseText.Settings;
using DFC.Swagger.Standard;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
[assembly: FunctionsStartup(typeof(Startup))]

namespace Dfc.ProviderPortal.CourseText
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var configuration = builder.GetContext().Configuration;

            builder.Services.Configure<CosmosDbSettings>(configuration.GetSection(nameof(CosmosDbSettings)));
            builder.Services.Configure<CosmosDbCollectionSettings>(configuration.GetSection(nameof(CosmosDbCollectionSettings)));
            builder.Services.AddScoped<ICosmosDbHelper, CosmosDbHelper>();
            builder.Services.AddScoped<ICourseTextService, CourseTextService>();
            builder.Services.AddScoped<ISwaggerDocumentGenerator, SwaggerDocumentGenerator>();
        }
    }
}