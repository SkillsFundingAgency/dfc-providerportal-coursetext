using Dfc.ProviderPortal.CourseText.Interfaces;
using System;

namespace Dfc.ProviderPortal.CourseText.Models
{
    public class CourseTextModel : ICourseText
    {
        public Guid id { get; }
        public string QualificationCourseTitle { get; }
        public string LearnAimRef { get; }
        public string NotionalNVQLevelv2 { get; }
        public string TypeName { get; }
        public string AwardOrgCode { get; }
        public string CountOfOpportunities { get; }
        public string CourseDescription { get; }
        public string EntryRequirments { get; }
        public string WhatYoullLearn { get; }
        public string HowYoullLearn { get; }
        public string WhatYoullNeed { get; }
        public string HowYoullBeAssessed { get; }
        public string WhereNext { get; }
    }
}
