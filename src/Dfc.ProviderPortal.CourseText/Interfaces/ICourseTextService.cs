
using Dfc.ProviderPortal.CourseText.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.CourseText.Interfaces
{
    public interface ICourseTextService
    {
        Task<IEnumerable<CourseTextModel>> GetAllCourseText(ILogger log);
    }
}
