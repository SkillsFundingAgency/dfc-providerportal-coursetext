using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Dfc.ProviderPortal.CourseText.Interfaces;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using System.Collections.Generic;

namespace Dfc.ProviderPortal.CourseText.Functions
{
    public static class GetAllCourseText
    {
        [FunctionName("GetAllCourseText")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
                                                    ILogger log,
                                                    [Inject] ICourseTextService courseTextService)
        {
            IEnumerable<ICourseText> results = null;

            try
            {
                results = await courseTextService.GetAllCourseText(log);
                return new OkObjectResult(results);

            }
            catch (Exception e)
            {
                return new InternalServerErrorObjectResult(e);
            }
        }
        }
}
