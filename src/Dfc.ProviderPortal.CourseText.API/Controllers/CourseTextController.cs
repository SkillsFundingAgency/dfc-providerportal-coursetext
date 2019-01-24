﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dfc.ProviderPortal.CourseText.Functions;
using Dfc.ProviderPortal.CourseText.Interfaces;
using Dfc.ProviderPortal.Packages;

namespace Dfc.ProviderPortal.CourseText.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseTextController : ControllerBase
    {
        private ILogger _log = null;
        public ICourseTextService _service = null;
        public CourseTextController(ILogger<CourseTextController> logger, ICourseTextService service)
        {
            Throw.IfNull<ILogger<CourseTextController>>(logger, nameof(logger));
            Throw.IfNull<ICourseTextService>(service, nameof(service));

            _log = logger;
            _service = service;
        }

        [HttpGet("PopulateSearch", Name = "PopulateSearch")]
        public ActionResult<IEnumerable<IAzureSearchCourseText>> PopulateSearch()
        {
            try
            {
                Task<IEnumerable<IAzureSearchCourseText>> task = _service.FindCourseTextAzureSearchData(_log);
                task.Wait();
                return new ActionResult<IEnumerable<IAzureSearchCourseText>>(task.Result);
            }
            catch(Exception ex)
            {
                return new InternalServerErrorObjectResult(ex);
            }
        }
    }
}