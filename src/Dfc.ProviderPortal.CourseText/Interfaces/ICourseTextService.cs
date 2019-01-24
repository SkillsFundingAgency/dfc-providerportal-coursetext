using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dfc.ProviderPortal.CourseText.Interfaces
{
    public interface ICourseTextService
    {
        Task<IEnumerable<IAzureSearchCourseText>> FindCourseTextAzureSearchData(ILogger log);
    }
}
