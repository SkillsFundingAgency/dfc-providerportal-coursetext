using Dfc.ProviderPortal.CourseText.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dfc.ProviderPortal.CourseText.Controllers
{
    [Produces("application/json")]
    [Route("api")]
    [ApiController]
    public class DocController : ControllerBase
    {
        [Route("GetAllCourseText")]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CourseTextModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetAllCourseText([Required]string code)
        {
            return Ok();
        }

        [Route("GetCourseTextByLARS")]
        [HttpGet]
        [ProducesResponseType(typeof(CourseTextModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCourseTextByLARS(string LARS, [Required]string code)
        {
            return Ok();
        }
    }
}