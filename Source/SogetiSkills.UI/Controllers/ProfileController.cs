﻿using AttributeRouting.Web.Mvc;
using SogetiSkills.Managers;
using SogetiSkills.Models;
using SogetiSkills.UI.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SogetiSkills.UI.Controllers
{
    [Authorize]
    public partial class ProfileController : ControllerBase
    {
        private readonly IUserManager _userManager;
        private readonly IResumeManager _resumeManager;
        private readonly ITagManager _tagManager;

        public ProfileController(
            IUserManager userManager, 
            IResumeManager resumeManager, 
            ITagManager tagManager)
        {
            _userManager = userManager;
            _resumeManager = resumeManager;
            _tagManager = tagManager;
        }

        [GET("Profile/{Id}")]
        public virtual async Task<ActionResult> Details(int id)
        {
            DetailsViewModel model = new DetailsViewModel();

            User user = await _userManager.LoadUserById(id);
            if (user == null)
            {
                return HttpNotFound();
            }

            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.FullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            model.Email = user.EmailAddress;
            model.PhoneNumber = user.PhoneNumber.GetFormattedValue();

            if (user is Consultant)
            {
                Consultant consultant  = (Consultant)user;
                model.UserTypeDescription = "Consultant";
                model.IsConsultant = true;
                model.IsOnBeach = consultant.IsOnBeach ?? false;
                model.ResumeMetadata = await _resumeManager.LoadResumeMetadata(consultant.Id);
                model.Tags = await _tagManager.LoadTagsForConsultant(consultant.Id);
            }
            else if (user is AccountExecutive)
            {
                model.UserTypeDescription = "Account Executive";
            }

            return View(model);
        }
    }
}