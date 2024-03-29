using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Dfc.ProviderPortal.CourseText.Models;
using System.Collections.Generic;
using Dfc.ProviderPortal.CourseText.Interfaces;

namespace Dfc.ProviderPortal.CourseText.Functions
{
    public static class GetCourseTextByLARS
    {
        [FunctionName("GetCourseTextByLARS")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
                                                    ILogger log,
                                                    [Inject] ICourseTextService courseTextService)
        {
            string fromQuery = req.Query["LARS"];
            CourseTextModel persisted = null;

            if (string.IsNullOrWhiteSpace(fromQuery))
                return new BadRequestObjectResult($"Empty or missing LARS Reference.");
            try
            {
                persisted = (CourseTextModel)await courseTextService.GetCourseTextByLARS(fromQuery);
                if (persisted == null)
                    return new NotFoundObjectResult(fromQuery);

                return new OkObjectResult(persisted);

            }
            catch (Exception e)
            {
                return new InternalServerErrorObjectResult(e);
            }
        }
    }
}
