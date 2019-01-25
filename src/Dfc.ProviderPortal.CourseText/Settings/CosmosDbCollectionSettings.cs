using Dfc.ProviderPortal.CourseText.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dfc.ProviderPortal.CourseText.Settings
{
    public class CosmosDbCollectionSettings : ICosmosDbCollectionSettings
    {
        public string CourseTextCollectionId { get; set; }
    }
}
