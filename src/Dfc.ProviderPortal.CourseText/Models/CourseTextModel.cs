﻿using Dfc.ProviderPortal.CourseText.Interfaces;
using Newtonsoft.Json;
using System;

namespace Dfc.ProviderPortal.CourseText.Models
{
    public class CourseTextModel : ICourseText
    {
        public Guid id { get; set; }
        public string QualificationCourseTitle { get; set; }
        public string LearnAimRef { get; set; }
        public string NotionalNVQLevelv2 { get; set; }
        public string TypeName { get; set; }
        public string AwardOrgCode { get; set; }
        public string CountOfOpportunities { get; set; }
        public string CourseDescription { get; set; }
        public string EntryRequirments { get; set; }
        public string WhatYoullLearn { get; set; }
        public string HowYoullLearn { get; set; }
        public string WhatYoullNeed { get; set; }
        public string HowYoullBeAssessed { get; set; }
        public string WhereNext { get; set; }
    }
}
