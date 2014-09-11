﻿using SogetiSkills.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SogetiSkills.UI.ViewModels.Profile
{
    public class DetailsViewModel
    {
        public string UserTypeDescription { get; set; }
        public bool IsConsultant { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsOnBeach { get; set; }
        public bool ProfileBelongsToCurrentUser { get; set; }

        public ResumeMetadata ResumeMetadata { get; set; }
        public IEnumerable<Tag> Tags { get; set; }
    }
}