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
    public class GetAllCourseText
    {
        private readonly ICourseTextService _courseTextService;
        private readonly ILogger _logger;

        public GetAllCourseText(ICourseTextService courseTextService, ILogger logger)
        {
            _courseTextService = courseTextService;
            _logger = logger;
        }

        [FunctionName("GetAllCourseText")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req)
        {
            IEnumerable<ICourseText> results = null;

            try
            {
                results = await _courseTextService.GetAllCourseText(_logger);
                return new OkObjectResult(results);

            }
            catch (Exception e)
            {
                return new InternalServerErrorObjectResult(e);
            }
        }
        }
}
