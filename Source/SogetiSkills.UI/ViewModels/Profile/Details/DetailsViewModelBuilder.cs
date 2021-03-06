﻿using SogetiSkills.Core.Managers;
using SogetiSkills.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SogetiSkills.UI.ViewModels.Profile.Details
{
    public class DetailsViewModelBuilder : IDetailsViewModelBuilder
    {
        private readonly IUserManager _userManager;
        private readonly IResumeManager _resumeManager;
        private readonly ISkillManager _skillManager;

        public DetailsViewModelBuilder(
            IUserManager userManager, 
            IResumeManager resumeManager, 
            ISkillManager skillManager)
        {
            _userManager = userManager;
            _resumeManager = resumeManager;
            _skillManager = skillManager;
        }

        public async Task<DetailsViewModel> BuildAsync(int profileUserId, int loggedInUserId)
        {
            DetailsViewModel model = new DetailsViewModel();

            User user = await _userManager.LoadUserByIdAsync(profileUserId);
            if (user == null)
            {
                return null;
            }

            model.UserId = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.FullName = string.Format("{0} {1}", user.FirstName, user.LastName);
            model.Email = user.EmailAddress;
            model.PhoneNumber = user.PhoneNumber.GetFormattedValue();

            if (user is Consultant)
            {
                Consultant consultant = (Consultant)user;
                model.UserTypeDescription = "Consultant";
                model.IsConsultant = true;
                model.IsOnBeach = consultant.IsOnBeach;
                
                model.ResumeMetadata = await _resumeManager.LoadResumeMetadataByUserIdAsync(consultant.Id);
                model.ConsultantSkills = (await _skillManager.LoadSkillsForConsultantAsync(consultant.Id)).OrderBy(x => x.SkillName);
            }
            else if (user is AccountExecutive)
            {
                model.UserTypeDescription = "Account Executive";
            }

            model.ProfileBelongsToCurrentUser = profileUserId == loggedInUserId;

            return model;
        }
    }
}