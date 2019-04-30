using System;

namespace Dfc.ProviderPortal.CourseText.Interfaces
{
    public interface ICourseText
    {
        Guid id { get; }
        string QualificationCourseTitle { get; }
        object LearnAimRef { get; }
        string NotionalNVQLevelv2 { get; }
        string TypeName { get; }
        string AwardOrgCode { get; }
        string CountOfOpportunities { get; }
        string CourseDescription { get; }
        string EntryRequirements { get; }
        string WhatYoullLearn { get; }
        string HowYoullLearn { get; }
        string WhatYoullNeed { get; }
        string HowYoullBeAssessed { get; }
        string WhereNext { get; }
    }
}
