using System;
using System.Collections.Generic;
using System.Text;
using BAL.Services;

namespace BAL.Factory
{
    public interface IAppServices
    {
        CandidateServices Candidate { get; }

        SkillServices Skill { get; }

        PersonalDetailServices PersonalDetail { get; }

        JobExperienceServices JobExperience { get; }

        CanActivityServices CanActivity { get; }
    }
}
