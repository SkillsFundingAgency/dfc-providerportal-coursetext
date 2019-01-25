using Dfc.ProviderPortal.CourseText.Interfaces;
using Dfc.ProviderPortal.CourseText.Models;
using Dfc.ProviderPortal.Packages.AzureFunctions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.CourseText.Functions
{
    public static class GetAllCourseText
    {
        [FunctionName("GetAllCourseText")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
                                                    ILogger log,
                                                    [Inject] ICourseTextService courseTextService
            )
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
