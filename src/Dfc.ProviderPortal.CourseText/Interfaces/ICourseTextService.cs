
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
        Task<IEnumerable<ICourseText>> GetAllCourseText(ILogger log);
        Task<IEnumerable<ICourseText>> GetCourseTextByLARS(string LARSRef);
    }
}
