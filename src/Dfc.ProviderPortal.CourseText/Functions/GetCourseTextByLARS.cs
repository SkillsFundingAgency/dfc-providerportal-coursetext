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
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
                                                    ILogger log,
                                                    [Inject] ICourseTextService courseTextService)
        {
            string fromQuery = req.Query["LARS"];
            List<CourseTextModel> persisted = null;

            if (string.IsNullOrWhiteSpace(fromQuery))
                return new BadRequestObjectResult($"Empty or missing LARS Reference.");

            if (!int.TryParse(fromQuery, out int LARSRef))
                return new BadRequestObjectResult($"Invalid UKPRN value, expected a valid integer");
            try
            {
                persisted = (List<CourseTextModel>)await courseTextService.GetCourseTextByLARS(LARSRef);
                if (persisted == null)
                    return new NotFoundObjectResult(LARSRef);

                return new OkObjectResult(persisted);

            }
            catch (Exception e)
            {
                return new InternalServerErrorObjectResult(e);
            }
        }
    }
}
